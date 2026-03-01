using System.Runtime.InteropServices;
using System.Text;

namespace Assignment_7
{
    public class Product
    {
        private string _name;
        private int _quantity;
        private double _price;
        public Product(string name, int quantity, double price)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(name))
                throw new InvalidOperationException("Name can't be empty");
            if(price < 0.0)
                throw new InvalidOperationException("Price can't be less than 0");
            if(quantity < 0)
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
            set
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
            return quantity * _price;
        }
        public double CalculatePrice(int quantity, double discount)
        {
            return quantity * _price *(1-discount/100);
        }
    }
    public class ShoppingCart
    {
        private Dictionary<string,int> _products;
        private double _totalPrice;
        private StringBuilder transactions;
        public ShoppingCart()
        {
            _products = new Dictionary<string, int>();
            _totalPrice = 0.0;
            transactions = new StringBuilder();
            transactions.AppendLine("Shopping Cart Details:\n");
        }
        public void PurchaseProduct(Product product, int quantity, double? discount = 0)
        {
            double currentPrice;
            if (quantity < 1 || quantity > product.Price)
                throw new InvalidOperationException("quantity can't be less than 1 or more than the products quantity");
            if (!_products.ContainsKey(product.Name))
                _products[product.Name] = quantity;
            else _products[product.Name] = quantity + _products.GetValueOrDefault(product.Name);
            product.Quantity -= quantity;
            if (discount.HasValue)
                if (discount < 0)
                    throw new InvalidOperationException("Discount can't be less than 0");
                else
                currentPrice = product.CalculatePrice(quantity, (double)discount);
            else currentPrice = product.CalculatePrice(quantity);
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
            Product product1 = new Product("C# Programming", 5, 50.0);
            Product product2 = new Product("Headphones", 5, 100.0);
            Product product3 = new Product("T-Shirt", 5, 20.0);
            ShoppingCart cart = new ShoppingCart();
            cart.PurchaseProduct(product1, 2, 10);
            cart.PurchaseProduct(product2, 1, 15);
            cart.PurchaseProduct(product3, 5);
            cart.DisplayTransaction();
            //I know that I should have added different types of products and inherit from product but it basically would be the same, the only difference
            //is that I will add different purchase method for each product in ShoppingCart or use the refernce as parent and type of child and use override and virtual

        }
    }
}
