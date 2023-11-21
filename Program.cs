    
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
        //[StructLayout(LayoutKind.Sequential)]
        struct POINT
        {
            public Int32 X;
            public Int32 Y;
        }
        //[DllImport("user32.dll")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool GetCursorPos(out POINT point);


        static void Main()
        {

            //POINT mousepos = new POINT();
            //GetCursorPos(out mousepos);
            GenerateBoard(ConsoleColor.Green, ConsoleColor.White, 80);


        }
        static void GenerateBoard(ConsoleColor blackColor, ConsoleColor whitecolor, int height)
        {
            if (height * 3 > 300)
            {
                throw new ArgumentException("Height too large");
            }


            List<Square> Squares = new List<Square>();
            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

            foreach (char c in alphabet)
            {
                for (int i = 0; i < 8; i++)
                {
                    Squares.Add(new Square(c, i+1, GetColorOfPos(c, i+1, whitecolor, blackColor)));
                }
            }
            string temp = "";
            for (int i = 0; i < (height/8) * 3; i++)
            {
                temp += "#";
            }
            Square.DrawingString = temp;
            
            Console.WriteLine("Please Zoom out");
            while (Console.BufferWidth < 300)
            {

            }
            Console.Clear();
            Square.SquareSize = height / 8;
            foreach (Square square in Squares)
            {
                square.Render();
            }
            
            Console.ReadKey(true);

        }



        static ConsoleColor GetColorOfPos(char c, int y, ConsoleColor whitecolor, ConsoleColor blackcolor)
        {
            Dictionary<char, int> tempdict = new Dictionary<char, int>()
            {
                {'a', 0}, {'b', 1}, {'c', 2}, {'d', 3}, {'e', 4}, {'f', 5}, {'g',  6}, {'h', 7}
            };


            if (tempdict[c]%2 == 0)
            {
                if (y % 2 == 0)
                {
                    return whitecolor;
                }
                else
                {
                    return blackcolor;
                }


            }
            else
            {
                if (y % 2 == 0)
                {
                    return blackcolor;
                }
                else
                {
                    return whitecolor;
                }
            }
        }
    }
    class Square
    {
        public ConsoleColor Color;

        public char X;

        public int Y;

        
        public static int SquareSize
        {
            get; set;
        } 
        

        public static string DrawingString;

        public Square(char x, int y, ConsoleColor color)
        {
            this.X = x;
            this.Y = y;
            this.Color = color;
            
        }
        public void Render()
        {
            
            Dictionary<char, int> tempdict = new Dictionary<char, int>()
            {
                {'a', 0}, {'b', 1}, {'c', 2}, {'d', 3}, {'e', 4}, {'f', 5}, {'g',  6}, {'h', 7}
            };
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
                Console.SetCursorPosition(tempdict[X] * SquareSize * 3, i + ((Y-1) * SquareSize));
                Console.Write(DrawingString);

            }
            Console.ResetColor();

        }
        
    }
    abstract class Piece
    {
        public char X;
        public int Y;
        static Dictionary<char, int> XConverter = new Dictionary<char, int>() { { 'a', 0 }, { 'b', 1 }, { 'c', 2 }, { 'd', 3 }, { 'e', 4 }, { 'f', 5 }, { 'g', 6 }, { 'h', 7 } };
        void FindPossibleMoves()
        {
            
        }
    }
    class Pawn:Piece
    {

    }
    
}