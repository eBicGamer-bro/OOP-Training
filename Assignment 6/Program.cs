using System.Globalization;

namespace Assignment_6
{
    public class StopWatch
    {
        private DateTime startTime;
        public TimeSpan duration {  get; private set; }
        private bool started = false;
        public void StartTheStopWatch()
        {
            if (started)
            {
               throw new InvalidOperationException("Stopwatch is already running.");
            }
            startTime = DateTime.Now;
            started = true;
        }
        public void StopTheStopWatch()
        {
            if (!started)
            {
                throw new InvalidOperationException("Stopwatch is not running.");
            }
            duration = DateTime.Now - startTime;
            started = false;
        }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            StopWatch watch = new StopWatch();
            Console.WriteLine("To Start press 0");
            Console.WriteLine("To End press 1");
            Console.WriteLine("To Show interval press 2");
            Console.WriteLine("To Exit press 3");
            while (true)
            {
                string choose = Console.ReadLine();
                int x = Convert.ToInt32(choose);
                if( x == 0)
                {
                    watch.StartTheStopWatch();
                    Console.WriteLine("Stopwatch started.");
                }
                else if (x == 1)
                {
                    watch.StopTheStopWatch();
                    Console.WriteLine("Stopwatch stopped.");
                }
                else if (x == 2)
                {
                    Console.WriteLine($"Elapsed time: {watch.duration}");
                }
                else if (x == 3)
                {
                    Console.WriteLine("Exiting...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }


            }
        }
    }
}
