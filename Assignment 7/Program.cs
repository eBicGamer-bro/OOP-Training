namespace Assignment_7
{
    public class Point
    {
        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public static Point operator +(Point A, Point B)
        {
           return new Point(A.x+B.x,A.y+B.y);
        }
        public static bool operator >(Point A, Point B)//I am comparing between A and B's distance from the origin.
        {
            return Math.Sqrt(Math.Pow(A.x, 2) + Math.Pow(A.y, 2)) > Math.Sqrt(Math.Pow(B.x, 2) + Math.Pow(B.y, 2));
        }
        public static bool operator <(Point A, Point B)
        {
            return Math.Sqrt(Math.Pow(A.x, 2) + Math.Pow(A.y, 2)) < Math.Sqrt(Math.Pow(B.x, 2) + Math.Pow(B.y, 2));
        }
        public static bool operator <=(Point A, Point B)
        {
            return Math.Sqrt(Math.Pow(A.x, 2) + Math.Pow(A.y, 2)) <= Math.Sqrt(Math.Pow(B.x, 2) + Math.Pow(B.y, 2));
        }
        public static bool operator >=(Point A, Point B)
        {
            return Math.Sqrt(Math.Pow(A.x, 2) + Math.Pow(A.y, 2)) >= Math.Sqrt(Math.Pow(B.x, 2) + Math.Pow(B.y, 2));
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Point A = new Point(5, 7);
            Point B = new Point(1, 8);
            Point sum = A + B;
            Console.WriteLine($"A + B = ({sum.x},{sum.y})");
            Console.WriteLine($"A bigger than B is {A > B}");
            Console.WriteLine($"A less than or equal to B is {A <= B}");


        }
    }
}
