using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Board
    {
        public int Size { get; set; }
        public Cell[,] theGrid { get; set; }

        public Board (int Size)
        {
            this.Size = Size;
            theGrid = new Cell[Size,Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public void MarkNextLegalMoves(Cell currentCell, string chesssPiece)
        {
            //step 1 - clear all previous legal moves
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j].LegalNextMove = false;
                    theGrid[i, j].CurrentlyOccupied = false;
                }

            }

            //step 2 - find all legal moves and mark the cell as "legal"
            switch (chesssPiece)
            {
                case "Knight":
                    if(inRange(currentCell.RowNumber + 2, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true;

                    if (inRange(currentCell.RowNumber + 2, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNextMove = true;

                    if (inRange(currentCell.RowNumber - 2, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNextMove = true;

                    if (inRange(currentCell.RowNumber - 2, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNextMove = true;

                    if (inRange(currentCell.RowNumber + 1, currentCell.ColumnNumber + 2))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNextMove = true;

                    if (inRange(currentCell.RowNumber + 1, currentCell.ColumnNumber -2))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNextMove = true;

                    if (inRange(currentCell.RowNumber - 1, currentCell.ColumnNumber + 2))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNextMove = true;

                    if (inRange(currentCell.RowNumber - 1, currentCell.ColumnNumber - 2))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNextMove = true;

                    break;


                case "King":
                    if (inRange(currentCell.RowNumber + 1, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1 ].LegalNextMove = true;

                    if (inRange(currentCell.RowNumber + 1, currentCell.ColumnNumber))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].LegalNextMove = true;

                    if (inRange(currentCell.RowNumber + 1, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNextMove = true;

                    if (inRange(currentCell.RowNumber, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1].LegalNextMove = true;

                    if (inRange(currentCell.RowNumber, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].LegalNextMove = true;

                    if (inRange(currentCell.RowNumber -1, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNextMove = true;

                    if (inRange(currentCell.RowNumber - 1, currentCell.ColumnNumber ))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber ].LegalNextMove = true;

                    if (inRange(currentCell.RowNumber - 1, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNextMove = true;

                    break;


                case "Rook":
                    //Console.WriteLine("Rook");
                    CheckLegalRecurse(currentCell, 1, 0);
                    CheckLegalRecurse(currentCell, -1, 0);
                    CheckLegalRecurse(currentCell, 0, 1);
                    CheckLegalRecurse(currentCell, 0, -1);
                    break;


                case "Bishop":
                    CheckLegalRecurse(currentCell,-1,-1);
                    CheckLegalRecurse(currentCell,-1,1);
                    CheckLegalRecurse(currentCell,1,1);
                    CheckLegalRecurse(currentCell,1,-1);
                    break;


                case "Queen":
                    CheckLegalRecurse(currentCell, 1, 0);
                    CheckLegalRecurse(currentCell, -1, 0);
                    CheckLegalRecurse(currentCell, 0, 1);
                    CheckLegalRecurse(currentCell, 0, -1);
                    CheckLegalRecurse(currentCell, -1, -1);
                    CheckLegalRecurse(currentCell, -1, 1);
                    CheckLegalRecurse(currentCell, 1, 1);
                    CheckLegalRecurse(currentCell, 1, -1);
                    break;
                default: break;
            }
            theGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;
        }

        private void CheckLegalRecurse(Cell checkingCell,int deltaRow, int deltaColumn)
        {
            if (inRange(checkingCell.RowNumber + deltaRow, checkingCell.ColumnNumber + deltaColumn)){
                theGrid[checkingCell.RowNumber + deltaRow,checkingCell.ColumnNumber + deltaColumn].LegalNextMove = true;
                CheckLegalRecurse(theGrid[checkingCell.RowNumber + deltaRow, checkingCell.ColumnNumber + deltaColumn], deltaRow, deltaColumn);
            }
        }

        private bool inRange(int row, int column)
        {
            if ( row <0 ||  column < 0 ) return false;
            else if (row > Size-1 ||  column > Size-1) return false;
            else return true;
        }
    }
}
