using System.Globalization;

namespace Assignment_6
{
    public class StackOverFlowPost
    {
        private string _title;
        private string _description;
        private int _currentValue;
        public DateTime createdAt { get; private set; }
        public StackOverFlowPost(string title, string description)
        {
            if (string.IsNullOrEmpty(title))
                throw new InvalidOperationException("title cannot me empty");
            if (string.IsNullOrEmpty(description))
                throw new InvalidOperationException("description cannot me empty");
            this._title = title;
            this._description = description;
            createdAt = DateTime.Now;
            _currentValue = 0;
        }
        public void UpVote()
        {
            _currentValue++;
        }
        public void DownVote()
        {
            _currentValue--;
        }
        public int GetCurrentValue()
        {
            return _currentValue;
        }
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                    throw new InvalidOperationException("title cannot me empty");
                _title = value;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                    throw new InvalidOperationException("description cannot me empty");
                _description = value;
            }
        }
      
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            StackOverFlowPost stackOverFlowPost = new StackOverFlowPost("C# Basics", "OOP Encapsulation importance");
            do
            {
                Console.WriteLine(stackOverFlowPost.Title);
                Console.WriteLine(stackOverFlowPost.Description);
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
