using System.Text;

namespace Assignment_8
{
    public class Product
    {
        private string _name;
        private double _price;
        public Product(string name, double price)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException("Name can't be empty");
            if(price < 0.0)
                throw new InvalidOperationException("Price can't be negative");

            _name = name;
            _price = price;
        }
        public string Name
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                    throw new InvalidOperationException("Name can't be empty");
                _name = value;
            }
            get
            {
                return _name;
            }
        }
        public double Price
        {
            set
            {
                if (value < 0)
                    throw new InvalidOperationException("price can't be less than 0");
                _price = value;
            }
            get
            {
                return _price;
            }
        }
        public double CalculatePrice(int quantity)
        {
            return quantity * _price;
        }
    }
    public interface IInvoiceGenerator
    {
        string GenerateInvoice(Dictionary<Product,int> products, DateTime created, double totalPrice);
    }
    public class PDF : IInvoiceGenerator
    {
        public string GenerateInvoice(Dictionary<Product, int> products, DateTime created, double totalPrice)
        {
            return "Processing From PDF...";
        }
    }
    public class Excel : IInvoiceGenerator
    {
        public string GenerateInvoice(Dictionary<Product, int> products, DateTime created, double totalPrice)
        {
            return "Processing From Excel...";
        }
    }
    public class JSON : IInvoiceGenerator
    {
        public string GenerateInvoice(Dictionary<Product, int> products, DateTime created, double totalPrice)
        {
            return "Processing From JSON...";
        }
    }
    public class ConsoleInvoice : IInvoiceGenerator
    {
        public string GenerateInvoice(Dictionary<Product, int> products, DateTime created, double totalPrice)
        {
            StringBuilder invoice = new StringBuilder();
            invoice.AppendLine($"{created.DayOfWeek} | {created.TimeOfDay}");
            invoice.AppendLine("Number| Item | Price | Total");
            for (int i = 0; i < products.Count; i++)
            {
                invoice.AppendLine($"{products.ElementAt(i).Value}  |  {products.ElementAt(i).Key.Name}  |  ${products.ElementAt(i).Key.Price}  |  ${products.ElementAt(i).Key.CalculatePrice(products.ElementAt(i).Value)}");
            }
            invoice.AppendLine($"Total = ${totalPrice}");
            return invoice.ToString();
        }
    }
    public class Order
    {
        private Dictionary<Product, int> _products;
        private DateTime _created;
        private double _totalPrice;
        public Order()
        {
            _products = new Dictionary<Product, int>();
            _totalPrice = 0.0;
        }
        public void AddItem(Product product, int quantity)
        {
            if (quantity <= 0)
                throw new InvalidOperationException("Quantity can't be zero or less");
            if (!_products.ContainsKey(product))
                _products[product] = quantity;
            else _products[product] = quantity + _products.GetValueOrDefault(product);
            _totalPrice += product.CalculatePrice(quantity);
        }
        public void CreateOrder(IInvoiceGenerator invoice)
        {
            _created = DateTime.Now;
            Console.WriteLine(invoice.GenerateInvoice(_products, _created, _totalPrice));

        }     
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Product bag = new Product("Gucci", 100);
            Product course = new Product("C# .net", 200);
            Product mobile = new Product("Samsung", 2000);

            Order order = new Order();
            order.AddItem(bag, 4);
            order.AddItem(course, 1);
            order.AddItem(mobile, 2);
            order.AddItem(bag, 2);
            order.CreateOrder(new PDF());
            order.CreateOrder(new Excel());
            order.CreateOrder(new JSON());
            order.CreateOrder(new ConsoleInvoice());


        }
    }
}
