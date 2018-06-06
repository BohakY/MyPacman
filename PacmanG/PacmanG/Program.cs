using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPacman
{
    public enum Directions { Left = 0, Right = 1, Top, Down };

    public static class Coord
    {
        public const int MIN_X = 0, MIN_Y = 0, MAX_X = 10, MAX_Y = 10;

        public static Point CalculateCoordinates___(Point coordinates, Directions direction, int distance)
        {
            switch (direction)
            {
                case Directions.Left:
                    coordinates.X -= distance;
                    break;
                case Directions.Right:
                    coordinates.X += distance;
                    break;
                case Directions.Top:
                    coordinates.Y += distance;
                    break;
                case Directions.Down:
                    coordinates.Y -= distance;
                    break;
            }
            return coordinates;
        }


        //доробити обробку
        public static bool IsCorrect(Point coordinates)
        {

            if ((MIN_X < coordinates.X) && (coordinates.X < MAX_X) && (MIN_Y < coordinates.Y) && (coordinates.Y < MAX_Y))
            {
                return true;
            }

            return false;
        }
    }

    public struct Point
    {
        public int X;
        public int Y;
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }


    public class Player
    {
        private static Directions DEFAULT_DIRECTION = Directions.Right;
        private static Point DEFAULT_COORDINATES = new Point(0, 0);

        public static int ObjectCount = 0;
       // public static int Coef = 100;

        public int Speed;
        public string Name;
        public Directions direction;
        public Point Coordinates;

        public Player()
        {
            Name = "Pacman";
            direction = DEFAULT_DIRECTION;
           Coordinates = DEFAULT_COORDINATES;
            IncreaseObjectCount();
        }

        public Player(int Speed, Directions direction, Point Coordinates, string Name = "NEW Player")
        {
            this.Speed = Speed;
            this.Name = Name;
            this.direction = direction;
            this.Coordinates = Coordinates;
            IncreaseObjectCount();
        }

        //public void ChangeSpeed()
        //{
        //    this.Speed *= Coef;
        //}

       
            // змінити на +- в залежності від direction
        public void Move(int deltaX, int deltaY)
        {
            Coordinates.X += deltaX;
            Coordinates.Y += deltaY;
        }

        public void Move(Point delta)
        {
            Coordinates.X += delta.X;
            Coordinates.Y += delta.Y;
        }

        public void Move(int distance)
        {
            this.Coordinates = Coord.CalculateCoordinates___(this.Coordinates, this.direction, distance);
        }

        public static void IncreaseObjectCount()
        {
            ObjectCount++;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Players: " + Player.ObjectCount);

            Player John = new Player(1, Directions.Down, new Point(2, 2), Name: "Gri");
            Console.WriteLine("Players: " + Player.ObjectCount);

            Player player2 = new Player(2, Directions.Down, new Point(2, 2), Name: "P2");
            Console.WriteLine("Players: " + Player.ObjectCount);


            Player player1 = new Player(1, Directions.Top, new Point(5, 2), Name: "Gri");
            Console.WriteLine("Player1 Name: " + player1.Name);
            Console.WriteLine("Player1 direction: " + player1.direction);
            Console.WriteLine("Player Speed: " + player1.Speed);

            Console.WriteLine("Player1 Coordinates: ({0}, {1})", player1.Coordinates.X, player1.Coordinates.Y);
            player1.Move(5,2);


            //Player player2 = new Player(2, Directions.Down, new Point(2, 2), Name: "P2");

            //Console.WriteLine("Player1 Speed: " + player1.Speed);
            //Console.WriteLine("Player2 Speed: " + player2.Speed);
            //player1.ChangeSpeed();
            //player2.ChangeSpeed();
            //Console.WriteLine("Player1 Speed: " + player1.Speed);
            //Console.WriteLine("Player2 Speed: " + player2.Speed);

            //Player.Coef = 2;
            //Console.WriteLine("Player1 Coef: " + Player.Coef);
            //Console.WriteLine("Player1 Speed: " + player1.Speed);
            //Console.WriteLine("Player2 Speed: " + player2.Speed);

            //player1.ChangeSpeed();
            //player2.ChangeSpeed();
            //Console.WriteLine("Player1 Speed: " + player1.Speed);
            //Console.WriteLine("Player2 Speed: " + player2.Speed);


            Console.ReadKey();
        }
    }

}
