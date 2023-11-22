using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public enum PieceType
    {
        pawn,
        bishop,
        knight,
        rook,
        queen,
        king
    }

    public enum PieceColor
    {
        white,
        black,
    }


    abstract class Piece
    {
        public int X;
        public int Y;
        
        public abstract List<int[]> FindPossibleMoves();
        public string[] Img;
        public static int SquareSize;
        public static List<Square> Squares;
        public PieceColor Color;
        public PieceType Type;

        public virtual bool Move(int x, int y)
        {
            int[] pos = { x, y };
            if (FindPossibleMoves().Contains(pos))
            {
                GetSquare(x, y);
                this.X = x;
                this.Y = y;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Square GetSquare(int x, int y) //get the square object from coordinates
        {
            foreach (Square square in Squares)
            {
                if (square.X == x && square.Y == y)
                {
                    return square;
                }
            }
            return null;

        }
    }






    class Pawn : Piece
    {

        public Pawn(int x, int y, PieceColor color)
        {
            this.Type = PieceType.pawn;
            this.Color = color;
            this.Img = new string[] { "##", "####", "####", "##", "##", "####", "######", "######" };
            //  ##
            // ####
            // ####
            //  ##
            //  ##
            // ####
            //######
            //######
            GetSquare(y, x).CurPiece = this;
            this.X = x;
            this.Y = y;
            
        }

        public override List<int[]> FindPossibleMoves()
        {
            List<int[]> possibleMoves = new List<int[]>();

            if(this.Color == PieceColor.white)
            {

                Square forwardsquare = GetSquare(this.X, this.Y + 1);
                Square forward2square = GetSquare(X, Y + 2);
                if (forwardsquare.CurPiece == null) //if the square forward is empty
                {
                    possibleMoves.Add(new int[] {forwardsquare.X, forwardsquare.Y});

                    if (forward2square.CurPiece == null && Y == 2) //if the square 2 squares forward is empty and y = 2
                    {
                        possibleMoves.Add(new int[] { forward2square.X, forward2square.Y });
                    }

                }

                Square topleftsquare = GetSquare(X -1, Y+1);
                Square toprightsquare = GetSquare(X + 1, Y + 1);
                if (topleftsquare.CurPiece != null)
                {
                    possibleMoves.Add(new int[] { topleftsquare.X, topleftsquare.Y });
                }
                if (toprightsquare.CurPiece != null)
                {   
                    possibleMoves.Add(new int[] { toprightsquare.X, toprightsquare.Y} );
                }



            }



            return possibleMoves;
        }
    }
}
