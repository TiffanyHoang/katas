using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class GameRuleCheckerTests
    { 
        [Fact]
      public void HorizontalWinReturnsTrue() 
      {
          var board = new Board(3);
          var input = new ConsoleInput();
          var player = new Player("Player 1", Token.X, input);
          board.AssignTokenToCell(player, new Coordinate(0,0));
          board.AssignTokenToCell(player, new Coordinate(0,1));
          board.AssignTokenToCell(player, new Coordinate(0,2));

          var result = GameRuleChecker.HasWin(player, board);
          
          Assert.True(result);
      } 
      
      [Fact]
      public void VerticalWinReturnsTrue()
      {
          var board = new Board(3);
          var input = new ConsoleInput();
          var player = new Player("Player 1", Token.X, input);
          board.AssignTokenToCell(player, new Coordinate(0,0));
          board.AssignTokenToCell(player, new Coordinate(1,0));
          board.AssignTokenToCell(player, new Coordinate(2,0));
      
          var result = GameRuleChecker.HasWin(player, board);
          
          Assert.True(result);
      }
      
      [Fact]
      public void LtrDiagonalWinReturnsTrue()
      {
          var board = new Board(3);
          var input = new ConsoleInput();
          var player = new Player("Player 1", Token.X, input);
          board.AssignTokenToCell(player, new Coordinate(0,0));
          board.AssignTokenToCell(player, new Coordinate(1,1));
          board.AssignTokenToCell(player, new Coordinate(2,2));
      
          var result = GameRuleChecker.HasWin(player, board);
          
          Assert.True(result);
      }
      
      [Fact]
      public void RtlDiagonalWinReturnsTrue()
      {
          var board = new Board(3);
          var input = new ConsoleInput();
          var player = new Player("Player 1", Token.X, input);
          board.AssignTokenToCell(player, new Coordinate(0,2));
          board.AssignTokenToCell(player, new Coordinate(1,1));
          board.AssignTokenToCell(player, new Coordinate(2,0));
      
          var result = GameRuleChecker.HasWin(player, board);
          
          Assert.True(result);
      }
      
      [Fact]
      public void NoWinReturnsFalse()
      {
          var board = new Board(3);
          var input = new ConsoleInput();
          var player = new Player("Player 1", Token.X, input);
          board.AssignTokenToCell(player, new Coordinate(1,2));
          board.AssignTokenToCell(player, new Coordinate(1,1));
          board.AssignTokenToCell(player, new Coordinate(2,0));
      
          var result = GameRuleChecker.HasWin(player, board);
          
          Assert.False(result);
      }
      
      [Fact]
      public void DrawReturnsTrue()
      {
          var board = new Board(3);
          var input = new ConsoleInput();
          var player = new Player("Player 1", Token.X, input);
          board.AssignTokenToCell(player, new Coordinate(0,0));
          board.AssignTokenToCell(player, new Coordinate(0,1));
          board.AssignTokenToCell(player, new Coordinate(0,2));
          board.AssignTokenToCell(player, new Coordinate(1,0));
          board.AssignTokenToCell(player, new Coordinate(1,1));
          board.AssignTokenToCell(player, new Coordinate(1,2));
          board.AssignTokenToCell(player, new Coordinate(2,0));
          board.AssignTokenToCell(player, new Coordinate(2,1));
          board.AssignTokenToCell(player, new Coordinate(2,2));
          
          var result = GameRuleChecker.HasDraw(board);
          
          Assert.True(result);
      }
      
      [Fact]
      public void NoDrawReturnsFalse()
      {
          var board = new Board(3);
          var input = new ConsoleInput();
          var player = new Player("Player 1", Token.X, input);
          board.AssignTokenToCell(player, new Coordinate(0,0));
          board.AssignTokenToCell(player, new Coordinate(0,1));
          board.AssignTokenToCell(player, new Coordinate(0,2));
          board.AssignTokenToCell(player, new Coordinate(1,0));
          board.AssignTokenToCell(player, new Coordinate(1,1));
          board.AssignTokenToCell(player, new Coordinate(1,2));
          board.AssignTokenToCell(player, new Coordinate(2,0));
          board.AssignTokenToCell(player, new Coordinate(2,1));

          var result = GameRuleChecker.HasDraw(board);
          
          Assert.False(result);
      }
    }
}