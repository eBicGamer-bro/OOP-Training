namespace Assignment_5
{
    class Grades
    {
        public int[] grades;
        public Grades()
        {
            grades = new int[5];
        }
        public int this[int index]
        {
            get { return grades[index]; }
            set { grades[index] = value; }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Grades grades = new Grades();
            grades[0] = 95;
            grades[1] = 88;
            Console.WriteLine(grades[0]);
            Console.WriteLine(grades[1]);



        }
    }
}