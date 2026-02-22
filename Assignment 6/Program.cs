using System.Globalization;

namespace Assignment_6
{
    public class StopWatch
    {
        private DateTime _startTime;
        private TimeSpan _duration;
        private bool _started = false;
        public void StartTheStopWatch()
        {
            if (_started)
            {
                throw new InvalidOperationException("Stopwatch is already running.");
            }
            _startTime = DateTime.Now;
            _started = true;
        }
        public void StopTheStopWatch()
        {
            if (!_started)
            {
                throw new InvalidOperationException("Stopwatch is not running.");
            }
            _duration = DateTime.Now - _startTime;
            _started = false;
        }
        public TimeSpan Duration
        {
            get
            {
                if (_started)
                    return DateTime.Now - _startTime;
                return _duration;
            }
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
                if (x == 0)
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
                    Console.WriteLine($"Elapsed time: {watch.Duration}");
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
