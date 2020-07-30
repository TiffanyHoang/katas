using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Board : IBoard
    {
        private Cell[,] _cell;

        public Board(IOutput output, int size)
        {
            _output = output;
            Size = size;
            CreateBoard();
        }

        private readonly IOutput _output;
        public int Size { get; }

        private void CreateBoard()
        {
            _cell = new Cell[Size, Size];
            for (var x = 0; x < Size; x++)
            {
                for (var y = 0; y < Size; y++)
                {
                    _cell[x, y] = new Cell(".");
                }
            }
        }
        
        public IEnumerable<List<string>> GetRowValues()
        {
            var horizontalValueList = new List<List<string>>();
            //crate a new list for each increment of size with unique name??
            var firstRow = new List<string>();
            var secondRow = new List<string>();
            var thirdRow = new List<string>();
            
                for (var col = 0; col < Size; col++)
                {
                    firstRow.Add(_cell[0,col].Value);
                    secondRow.Add(_cell[1,col].Value);
                    thirdRow.Add(_cell[2,col].Value);
                }

                horizontalValueList.Add(firstRow);
                horizontalValueList.Add(secondRow);
                horizontalValueList.Add(thirdRow);
            
            return horizontalValueList;
        }

        public IEnumerable<List<string>> GetColumnValues()
        {
            var verticalValueList = new List<List<string>>();
            var firstColumn = new List<string>();
            var secondColumn = new List<string>();
            var thirdColumn = new List<string>();
            
            for (var row = 0; row < Size; row++)
            {
                firstColumn.Add(_cell[row,0].Value);
                secondColumn.Add(_cell[row,1].Value);
                thirdColumn.Add(_cell[row,2].Value);
            }

            verticalValueList.Add(firstColumn);
            verticalValueList.Add(secondColumn);
            verticalValueList.Add(thirdColumn);
            
            return verticalValueList;
        }
        
        public IEnumerable<List<string>> GetDiagonalValues()
        {
            var diagonalValueList = new List<List<string>>();
            var lTr = new List<string>();
            var rTl = new List<string>();
            var col = Size - 1;
            
            for (var row = 0; row < Size; row++)
            {
                lTr.Add(_cell[row,row].Value);
                rTl.Add(_cell[row,col].Value);
                col--;
            }
            
            diagonalValueList.Add(lTr);
            diagonalValueList.Add(rTl);
            
            return diagonalValueList;
        }

        public void AssignTokenToCell(Player player, Coordinate coordinate)
        {
            GetCellByCoordinates(coordinate).Value = player.Token;
            MarkCellAsUnavailable(coordinate);
        }
        
        private void MarkCellAsUnavailable(Coordinate coordinate)
        {
            GetCellByCoordinates(coordinate).IsAvailable = false;
        }
        
        public bool CellIsAvailable(Coordinate coordinate)
        {
            return GetCellByCoordinates(coordinate).IsAvailable;
        }

        private Cell GetCellByCoordinates(Coordinate coordinate)
        {
            return _cell[coordinate.X, coordinate.Y];
        }

        public void PrintBoard()
        {
            var boardString = "";  
            for (var x = 0; x < Size; x++)
            {
                for (var y = 0; y < Size; y++)
                {
                    boardString +=_cell[x,y].Value + " ";
                }
                if (x < Size - 1)
                {
                    boardString += Environment.NewLine;
                }
            }
            _output.OutputText(boardString);
        }
    }
}
