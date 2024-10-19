public class CurrentAccount
{
    public string Number { get; set; }
    public double Balance { get; private set; }
    public double CreditLine { get; set; }
    public Person Owner { get; set; }

    public CurrentAccount(string number, double initialBalance, double creditLine, Person owner)
    {
        Number = number;
        Balance = initialBalance;
        CreditLine = creditLine;
        Owner = owner;
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }

        if (Balance - amount < -CreditLine)
        {
            throw new InvalidOperationException("Insufficient funds.");
        }

        Balance -= amount;
    }

    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }

        Balance += amount;
    }

    public double GetBalance()
    {
        return Balance;
    }
}

class Program
{
    static void Main()
    {
        Person person1 = new Person("Julie", "Martin", new DateTime(1990, 5, 10));
        Person person2 = new Person("Alex", "Dupont", new DateTime(1985, 8, 20));

        CurrentAccount account1 = new CurrentAccount("123456", 1000.0, 500.0, person1);
        CurrentAccount account2 = new CurrentAccount("789012", 2000.0, 1000.0, person1);
        CurrentAccount account3 = new CurrentAccount("345678", 1500.0, 300.0, person2);

        Bank bank = new Bank("BNP");

        bank.AddAccount(account1);
        bank.AddAccount(account2);
        bank.AddAccount(account3);

        Console.WriteLine($"Solde du compte 123456 : {bank.GetAccountBalance("123456")}");

        account1.Deposit(500.0);
        Console.WriteLine($"Solde après dépôt de 500 : {bank.GetAccountBalance("123456")}");
        
        account1.Withdraw(300.0);
        Console.WriteLine($"Solde après retrait de 300 : {bank.GetAccountBalance("123456")}");

        Console.WriteLine($"Somme des comptes pour Julie Martin : {bank.GetTotalBalanceForPerson(person1)}");

        bank.DeleteAccount("789012");

        try
        {
            Console.WriteLine(bank.GetAccountBalance("789012"));
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Erreur : {e.Message}");
        }
    }
}
