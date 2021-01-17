using System;
using System.Collections.Generic;

namespace SenKan
{
    public class GameEngine
    {
        public Match Match { get; set; }
        
        public GameEngine() { }

        public GameEngine(Match match)
        {
            Match = match;
        }

        public Match CreateNewMatch(List<Player> players, Ruleset ruleset)
        {
            Match = new Match(players, ruleset);
            return Match;
        }

        public void PlayerAttack(int x, int y, Player player)
        {
            var error = ValidateAttack(x, y, player);
            if (error != null)
            {
                throw new Exception(error);
            }
            // This will only work with 2 players... imagine battleship with 2+ players...
            var enemy = player.GameId == 1 ? Match.Players[1] : Match.Players[0];
            foreach (var ship in enemy.Ships)
            {
                foreach (var coordinate in ship.Coordinates)
                {
                    if (coordinate.X == x && coordinate.Y == y)
                    {
                        coordinate.IsHit = true;
                        if (IsShipDestroyed(ship))
                        {
                            ship.IsUp = false;
                        }
                    }
                }
            }
            Match.CurrentTurnIndex = Match.CurrentTurnIndex == 0 ? 1 : 0;
            if (IsEnemyDefeated(enemy))
            {
                Match.Winner = player.Name;
                Match.IsGoing = false;
            }
            RecordTurn(player, x, y);
        }

        private string ValidateAttack(int x, int y, Player player)
        {
            if (x > Match.Ruleset.Board.Width || y > Match.Ruleset.Board.Height || x <= 0 || y <= 0)
            {
                return "Coordinates need to be in range.";
            }

            foreach (var turn in Match.TurnHistory)
            {
                if (turn.X == x && turn.Y == y && turn.PlayerId == player.GameId)
                {
                    return "You cannot attack the same coordinates twice.";
                }
            }

            return null;
        }

        private bool IsEnemyDefeated(Player enemy)
        {
            foreach (var ship in enemy.Ships)
            {
                if (ship.IsUp)
                {
                    return false;
                }
            }

            return true;
        }
        private void RecordTurn(Player player, int x, int y)
        {
            var turn = new Turn(player.GameId, x, y);
            Match.TurnHistory.Add(turn);
        }

        private bool IsShipDestroyed(Ship ship)
        {
            foreach (var shipCoordinate in ship.Coordinates)
            {
                if (!shipCoordinate.IsHit)
                {
                    return false;
                }
            }

            return true;
        }
    }
}