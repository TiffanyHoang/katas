using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class Game 
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly List<Player> _players;
        private readonly IBoard _board;
        private readonly ICoordinateParser _coordinateParser;
        public bool Running { get; private set; } = true;

        public Game(IInput input, IOutput output, List<Player> players, IBoard board, ICoordinateParser coordinateParser)
        {
            _input = input;
            _output = output;
            _players = players;
            _board = board;
            _coordinateParser = coordinateParser;
        }
        
        public void Run()
        {
            var turns = 0;
            _output.OutputText(Resources.WelcomeMessage);
            _output.OutputText(Resources.BoardIntro);
            _board.PrintBoard();
            do
            {
                var player = _players[turns % _players.Count];
                
                if (player.Name == "Human")
                {
                    _output.OutputText(string.Format(Resources.TakeTurn, player.Name));
                }
                else
                {
                    _output.OutputText(string.Format(Resources.ComputerTakeTurn, player.Name));
                }
                RunPlay(player);
                turns++;
                CheckGameRules(player);
            } while (Running);
        }

        private void RunComputerPlay(Player player) //todo implement logic
        {
            _output.OutputText(string.Format(Resources.ComputerTakeTurn, player.Name));
        }

        private void RunPlay(Player player)
        {
            _output.OutputText(string.Format(Resources.TakeTurn, player.Name));
            do
            {
                var playerMove = _input.InputText();
                
                if (playerMove == "q")
                {
                    ExitApp();
                    break;
                }

                Coordinate coordinate;
                if (_coordinateParser.IsValidFormat(playerMove))
                {
                    coordinate = SetCoordinate(playerMove);
                }
                else
                {
                    _output.OutputText(Resources.IncorrectFormat);
                    _output.OutputText(string.Format(Resources.TakeTurn, player.Name));
                    continue;
                }
                
                if (_coordinateParser.IsValidCoordinate(coordinate, _board))
                {
                    if (_board.CellIsAvailable(coordinate))
                    {
                        PlayMove(player, coordinate);
                        break;
                    }
                    _output.OutputText(string.Format(Resources.CellUnavailable)); 
                }
                else
                {
                    _output.OutputText(string.Format(Resources.OutsideOfBounds));
                }
                _output.OutputText(string.Format(Resources.TakeTurn,player.Name));
            } while (true);
        }

        private Coordinate SetCoordinate(string playerMove)
        {
            return _coordinateParser.GetCoordinates(playerMove);
        }
        
        private void CheckGameRules(Player player)
        {
            if (GameRuleChecker.HasDraw(_board))
            {
                RunDraw();
            }
            else
            {
                if (!GameRuleChecker.HasWin(player, _board)) return;
                RunWin(player);
            }
        }

        private void RunWin(Player player)
        {
            _output.OutputText(string.Format(Resources.YouHaveWon, player.Name));
            ExitApp();
        }

        private void RunDraw()
        {
            _output.OutputText(Resources.Draw);
            ExitApp();
        }
        
        private void PlayMove(Player player, Coordinate coordinate)
        {
            _board.AssignTokenToCell(player, coordinate);
            _output.ClearConsole();
            _output.OutputText(Resources.MoveAccepted);
            _board.PrintBoard();
        }
        
        private void ExitApp()
        {
            Running = false;
        }
    }
}