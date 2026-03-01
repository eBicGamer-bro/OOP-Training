using System.Runtime.InteropServices;
using System.Text;

namespace Assignment_7
{
    public class Product
    {
        protected string _name;
        protected int _quantity;
        protected double _price;
        public Product(string name, int quantity, double price)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(name))
                throw new InvalidOperationException("Name can't be empty");
            if (price < 0.0)
                throw new InvalidOperationException("Price can't be less than 0");
            if (quantity < 0)
                throw new InvalidOperationException("quantity can't be less than 0");
            _name = name;
            _quantity = quantity;
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
        public int Quantity
        {
            private set
            {
                if (value < 0)
                    throw new InvalidOperationException("quantity can't be less than 0");
                _quantity = value;
            }
            get
            {
                return _quantity;
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
            
            if (quantity < 1 || quantity > Quantity)
                throw new InvalidOperationException("Quantity can't be less than 1 or more than the products quantity");
            Quantity -= quantity;
            return quantity * _price;
        }
        public double CalculatePrice(int quantity, double discount)
        {
            return quantity * _price * (1 - discount / 100);
        }
        public void Restock()//Since the set for quantity is private I added a restock method with a constant amount for each restock
        {
            Quantity += 10;
        }
    }
    public class Course : Product
    {
        public Course(string name, int quantity, double price) : base(name, quantity, price) { }

    }
    public class Gadget : Product
    {
        public Gadget(string name, int quantity, double price) : base(name, quantity, price) { }
    }
    public class Clothing : Product
    {
        public Clothing(string name, int quantity, double price) : base(name, quantity, price) { }
    }

    public class ShoppingCart
    {
        private Dictionary<Product, int> _products;
        private double _totalPrice;
        private StringBuilder transactions;
        public ShoppingCart()
        {
            _products = new Dictionary<Product, int>();
            _totalPrice = 0.0;
            transactions = new StringBuilder();
            transactions.AppendLine("Shopping Cart Details:\n");
        }
        public void PurchaseProduct(Product product, int quantity, double? discount = 0)
        {
            double currentPrice;
            if (!_products.ContainsKey(product))
                _products[product] = quantity;
            else _products[product] = quantity + _products.GetValueOrDefault(product);
            if (discount < 0)
                throw new InvalidOperationException("Discount can't be less than 0");
            else if (discount == 0)
                currentPrice = product.CalculatePrice(quantity);
            else currentPrice = product.CalculatePrice(quantity, (double)discount);
            _totalPrice += currentPrice;
            transactions.AppendLine($"{product.Name} | Price: ${product.Price} | Quantity: {quantity}\nTotal Price: ${currentPrice}\n");
        }
        public void DisplayTransaction()
        {
            Console.WriteLine($"{transactions}\nGrand Total for Cart: ${_totalPrice}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Course("C# Programming", 5, 50.0);
            Product product2 = new Gadget("Headphones", 5, 100.0);
            Product product3 = new Clothing("T-Shirt", 5, 20.0);
            ShoppingCart cart = new ShoppingCart();
            cart.PurchaseProduct(product1, 2, 10);
            cart.PurchaseProduct(product2, 1, 15);
            cart.PurchaseProduct(product3, 5);
            cart.DisplayTransaction();

        }
    }
}