using System;
using System.Collections.Generic;
using SenKan;

namespace SenKanConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Very Abstract version of SenKan (or Battleship...)");
            Console.WriteLine("Disclaimer: There is no input check, this is purely for testing if the mechanics work.");
            Console.WriteLine("YES, THAT INCLUDES MAKING BOARDS SMALLER THAN SHIPS AND SUCH.");
            var engine = GetDummyMatch();
            while (engine.Match.IsGoing)
            {
                do
                {
                    try
                    {
                        Console.Clear();
                        var currentTurnIndex = engine.Match.CurrentTurnIndex;
                        var currentPlayer = engine.Match.Players[currentTurnIndex];
                        Console.WriteLine("Legend: O = Ship, X = Hit, M = Miss");
                        Console.WriteLine($"Player: {currentPlayer.Name}");
                        DrawEnemyBoard(engine, currentPlayer);
                        Console.WriteLine("------------------------------");
                        DrawPlayerBoard(engine, currentPlayer);
                        Console.WriteLine("Attack coordinates Captain?");
                        Console.Write("X > ");
                        var x = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Y > ");
                        var y = Convert.ToInt32(Console.ReadLine());
                        engine.PlayerAttack(x, y, currentPlayer);
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                    }
                } while (true);
            }
            Console.WriteLine($"Winner is {engine.Match.Winner}");
        }

        private static void DrawPlayerBoard(GameEngine engine, Player player)
        {
            for (var y = 1; y < engine.Match.Ruleset.Board.Width+1; y++)
            {
                for (var x = 1; x < engine.Match.Ruleset.Board.Height+1; x++)
                {
                    var tile = GetPlayerBoardTile(x, y, player);
                    Console.Write(tile);
                }
                Console.Write("\n");
            }
        }

        private static void DrawEnemyBoard(GameEngine engine, Player player)
        {
            Player enemy;
            // This will only work with 2 players... imagine battleship with 2+ players...
            enemy = player.GameId == 1 ? engine.Match.Players[1] : engine.Match.Players[0];
            for (var y = 1; y < engine.Match.Ruleset.Board.Width+1; y++)
            {
                for (var x = 1; x < engine.Match.Ruleset.Board.Height+1; x++)
                {
                    var tile = GetEnemyBoardTile(x, y, player, enemy, engine.Match.TurnHistory);
                    Console.Write(tile);
                }
                Console.Write("\n");
            }
        }

        private static string GetPlayerBoardTile(int x, int y, Player player)
        {
            foreach (var ship in player.Ships)
            {
                foreach (var coordinate in ship.Coordinates)
                {
                    if (coordinate.X == x && coordinate.Y == y)
                    {
                        if (coordinate.IsHit)
                        {
                            return "[X]";
                        }

                        return $"[O]";
                    }
                }
            }

            return "[ ]";
        }

        private static string GetEnemyBoardTile(int x, int y, Player player, Player enemy, List<Turn> turnHistory)
        {
            var playerTurns = GetPlayerTurnHistory(player, turnHistory);
            foreach (var ship in enemy.Ships)
            {
                foreach (var coordinate in ship.Coordinates)
                {
                    if (coordinate.X == x && coordinate.Y == y)
                    {
                        if (coordinate.IsHit)
                        {
                            return "[X]";
                        }
                    }
                }
            }

            foreach (var turn in playerTurns)
            {
                if (turn.X == x && turn.Y == y)
                {
                    return "[M]";
                }
            }

            return "[ ]";
        }

        private static List<Turn> GetPlayerTurnHistory(Player player, List<Turn> turnHistory)
        {
            var playerTurns = new List<Turn>();
            foreach (var turn in turnHistory)
            {
                if (turn.PlayerId == player.GameId)
                {
                    playerTurns.Add(turn);
                }
            }

            return playerTurns;
        }

        private static GameEngine GetDummyMatch()
        {
            // Setup Premade Rules
            // Because fuck it we're on a rush

            var engine = new GameEngine();
            
            const int boardWidth = 10;
            const int boardHeight = 10;
            
            var board = new Board(boardWidth, boardHeight);
            var shipRulesets = new List<ShipRuleset>();
            shipRulesets.Add(new ShipRuleset( 2, 2));
            shipRulesets.Add((new ShipRuleset( 3, 2)));
            var ruleset = new Ruleset(board, shipRulesets);
            
            var p1Ships = new List<Ship>();
            var p2Ships = new List<Ship>();
            p1Ships.Add(new Ship(1, 3, 1, 1));
            p1Ships.Add(new Ship( 3, 4, 5, 4));
            p1Ships.Add(new Ship( 6, 8, 6, 7));
            p1Ships.Add(new Ship( 8, 5, 8, 6));
            
            p2Ships.Add(new Ship( 2, 7, 2, 6));
            p2Ships.Add(new Ship( 5, 5, 5, 7));
            p2Ships.Add(new Ship( 6, 3, 5, 3));
            p2Ships.Add(new Ship( 7, 5, 7, 7));
            
            var players = new List<Player>();
            players.Add(new Player(1, p1Ships, "Manuel"));
            players.Add(new Player(2, p2Ships, "The Other Manuel"));

            engine.CreateNewMatch(players, ruleset);
            return engine;
        }
    }
}