using System.Runtime.InteropServices;
using System.Text;

namespace Assignment_7
{
    public abstract class Account
    {
        private static int count = 1000;
        protected string _accountNumber;
        protected string _ownerName;
        protected DateTime _createdDate;
        protected double _balance;
        public Account(string ownerName)
        {
            if (string.IsNullOrEmpty(ownerName) || string.IsNullOrWhiteSpace(ownerName))
                throw new InvalidOperationException("Owner name can't be empty");
            _accountNumber = count++.ToString();
            _ownerName = ownerName;
            _createdDate = DateTime.Now;
            _balance = 0.0;
            Console.WriteLine($"Welcome {ownerName}! Your account number is {_accountNumber}.");
        }
        public string OwnerName
        {
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new InvalidOperationException("Owner name can't be empty");
                _ownerName = value;
            }
            get
            {
                return _ownerName;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return _createdDate;
            }
        }
        public string AccountNumber
        {
            get
            {
                return _accountNumber;
            }
        }
        public abstract void Withdraw(double amount);
        
        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new InvalidOperationException("amount can't be less than zero");
            else
                _balance += amount;
        }
        public abstract void ShowAccountDetails();
        
    }
    public class SavingsAccount : Account
    {
        public SavingsAccount(string ownerName) : base(ownerName){}
        public override void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new InvalidOperationException("amount can't be less than zero");
            else if (amount > _balance)
                Console.WriteLine("Insuffecient funds!");
            else
            {
                _balance -= amount;
            }
        }
        public void MonthlyInterest()
        {
            _balance += _balance * 0.05;
        }

        public override void ShowAccountDetails()
        {

            Console.WriteLine($"Owner name: {OwnerName} | Account Number: {AccountNumber} | Balance: {_balance} | Created Date: {CreatedDate} | Account Type: Savings Account.");
        }
    }
    public class CurrentAccount : Account
    {
        public CurrentAccount(string ownerName) : base(ownerName){}

        public override void ShowAccountDetails()
        {

            Console.WriteLine($"Owner name: {OwnerName} | Account Number: {AccountNumber} | Balance: {_balance} | Created Date: {CreatedDate} | Account Type: Current Account.");
        }

        public override void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new InvalidOperationException("amount can't be less than zero");
            else if (amount+10 > _balance)
                Console.WriteLine("Insuffecient funds!");
            else
            {
                _balance = _balance - (amount+10);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount savingsAccount = new SavingsAccount("Fares");
            CurrentAccount currentAccount = new CurrentAccount("Fares 2");
            savingsAccount.Deposit(100);
            currentAccount.Deposit(100);
            savingsAccount.MonthlyInterest();
            currentAccount.Withdraw(50);
            savingsAccount.Withdraw(50);
            savingsAccount.ShowAccountDetails();
            currentAccount.ShowAccountDetails();

        }
    }
}
