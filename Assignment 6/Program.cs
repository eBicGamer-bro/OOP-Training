using System.Globalization;

namespace Assignment_6
{
    public class StackOverFlowPost
    {
        public string title;
        public string description;
        private int _upVote,_downVote;
        public DateTime createdAt { get; private set; }
        public StackOverFlowPost(string title, string description)
        {
            this.title = title;
            this.description = description;
            createdAt = DateTime.Now;
            _downVote = 0;
            _upVote = 0;
        }
        public void UpVote()
        {
            _upVote++;
        }
        public void DownVote()
        {
            _downVote++;
        }
        public string GetCurrentValue()
        {
            return "Up Votes: " + _upVote + "  Down Votes: " + _downVote;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            StackOverFlowPost stackOverFlowPost = new StackOverFlowPost("C# Basics", "OOP Encapsulation importance");
            do
            {
                Console.WriteLine(stackOverFlowPost.title);
                Console.WriteLine(stackOverFlowPost.description);
                Console.WriteLine(stackOverFlowPost.createdAt);
                Console.WriteLine(stackOverFlowPost.GetCurrentValue());

                Console.WriteLine("Up Vote press 1");
                Console.WriteLine("Down Vote press 2");
                var s = Console.ReadLine();
                int x = Convert.ToInt32(s);

                if (x == 1)
                    stackOverFlowPost.UpVote();
                else if (x == 2)
                    stackOverFlowPost.DownVote();
                else return;
                Console.Clear();

            } while (true);

            
        }
    }
}
