namespace Assignment_5
{
    class MyCookieCollection
    {

        Dictionary<string, string> cookies;
        public MyCookieCollection()
        {
            cookies = new Dictionary<string, string>();
        }
        public string this[string key]
        {
            get
            {
                if (cookies.ContainsKey(key))
                {
                    return cookies[key];
                }
                return null;
            }
            set
            {
                cookies[key] = value;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyCookieCollection cookies = new MyCookieCollection();
            cookies["username"] = "John Doe";
            cookies["theme"] = "dark";
            cookies["language"] = "en";
            Console.WriteLine("Username: " + cookies["username"]);
            Console.WriteLine("Theme: " + cookies["theme"]);
            Console.WriteLine("Language: " + cookies["language"]);

        }
    }
}