    
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


namespace Chess
{
    

    class Chess
    {
        [StructLayout(LayoutKind.Sequential)]
        struct POINT
        {
            public Int32 X;
            public Int32 Y;
        }
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out POINT point);
        static List<Square> Squares = new List<Square>();

        static void Main()
        {
            POINT mousepos = new POINT();
            GetCursorPos(out mousepos);
            GenerateBoard(ConsoleColor.Green, ConsoleColor.White, 240);
        }











        static void GenerateBoard(ConsoleColor blackColor, ConsoleColor whitecolor, int height) // generate board an pieces
        {
            if (false)//height * 3 > 300)
            {
                throw new ArgumentException("Height too large");
            }




            #region Rendering Squares
            for (int y = 1; y < 9; y++)
            {
                for (int i = 1; i < 9; i++)
                {
                    Squares.Add(new Square(y+1, i+1, _GetColorOfPos(y, i, whitecolor, blackColor)));
                }
            }
            string temp = "";
            for (int i = 0; i < (height/8) * 3; i++)
            {
                temp += "#";
            }
            Square.DrawingString = temp;
            
            Console.WriteLine("Please Zoom out");
            while (Console.BufferHeight < height )
            {

            }
            Console.Clear();
            Square.SquareSize = height / 8;
            foreach (Square square in Squares)
            {
                square.Render();
            }
            Piece.Squares = Squares;

            #endregion

            Pawn pawn = new Pawn(1, 1, PieceColor.black);

        }



        static ConsoleColor _GetColorOfPos(int x, int y, ConsoleColor whitecolor, ConsoleColor blackcolor) //Used to get the color of a position on a chess board
        {

            if ((x + y) % 2 == 0) return whitecolor; else return blackcolor;

            //if (x % 2 == 0)
            //{
            //    if (y % 2 == 0)
            //    {
            //        return whitecolor;
            //    }
            //    else
            //    {
            //        return blackcolor;
            //    }


            //}
            //else
            //{
            //    if (y % 2 == 0)
            //    {
            //        return blackcolor;
            //    }
            //    else
            //    {
            //        return whitecolor;
            //    }
            //}
        }


        
    }










    class Square // 
    {
        public ConsoleColor Color;

        public int X;

        public int Y;
        public Piece? CurPiece;

        
        public static int SquareSize
        {
            get; set;
        } 
        

        public static string DrawingString;

        public Square(int x, int y, ConsoleColor color, Piece? curPiece = null)
        {
            this.X = x;
            this.Y = y;
            this.Color = color;
            CurPiece = curPiece;
        }
        public void Render()
        {
            
            
            Console.ForegroundColor = this.Color;
            Console.BackgroundColor = this.Color;
            
            float temp = 0;
            if (X == 1)
            {
                temp = 3f;
            }
            

            for (int i = 0; i < SquareSize; i++)
            {
                int hello = Console.BufferWidth;
                Console.SetCursorPosition(X * SquareSize * 3, i + ((Y-1) * SquareSize));
                Console.Write(DrawingString);

            }
            Console.ResetColor();

        }
        
    }
    
    
}