using System;

namespace Classes_M2;

public class BankAccount
{
    private static int s_nextAccountNumber;
    public int AccountNumber { get; }
    public static double InterestRate;
    public string CustomerId { get; }

    public double Balance { get; private set; } = 0;    
    public string AccountType { get; set; } = "Checking";
    
    static BankAccount()
    {
        Random random = new Random();
        s_nextAccountNumber = random.Next(10000000, 20000000);
        InterestRate = 0;
    }

    public BankAccount(string customerIdNumber)
    {
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = customerIdNumber;
    }

    public BankAccount(string customerIdNumber, double balance, string accountType)
    {
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = customerIdNumber;
        this.Balance = balance;
        this.AccountType = accountType;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
        else
        {
            throw new ArgumentException("Deposit amount must be positive.");
        }
    }

    public bool Withdraw(double amount)
    {
        if (amount > 0)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            throw new ArgumentException("Withdrawal amount must be positive.");
        }
    }

    public bool Transfer(BankAccount targetAccount, double amount)
    {
        if (amount > 0)
        {
            if (Withdraw(amount))
            {
                targetAccount.Deposit(amount);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            throw new ArgumentException("Transfer amount must be positive.");
        }
    }

    public void ApplyInterest()
    {
        Balance += Balance * InterestRate;
    }

    public string DisplayAccountInfo()
    {
        return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance}, Interest Rate: {InterestRate}, Customer ID: {CustomerId}";
    }
}
