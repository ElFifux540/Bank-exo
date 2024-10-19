
public class Bank
{
    public Dictionary<string, CurrentAccount> Accounts { get; private set; } = new Dictionary<string, CurrentAccount>();

    public string Name { get; set; }

    public Bank(string name)
    {
        Name = name;
    }
    public void AddAccount(CurrentAccount account)
    {
        if (Accounts.ContainsKey(account.Number))
        {
            throw new ArgumentException($"Account {account.Number} already exists.");
        }
        Accounts[account.Number] = account;
    }
    public void DeleteAccount(string number)
    {
        if (!Accounts.ContainsKey(number))
        {
            throw new ArgumentException($"Nothing found with number {number}.");
        }
        Accounts.Remove(number);
    }
    public double GetAccountBalance(string accountNumber)
    {
        if (!Accounts.ContainsKey(accountNumber))
        {
            throw new ArgumentException($"Nothing found with number {accountNumber}.");
        }
        return Accounts[accountNumber].GetBalance();
    }
    public double GetTotalBalanceForPerson(Person person)
    {
        double totalBalance = 0;
        foreach (var account in Accounts.Values)
        {
            if (account.Owner == person)
            {
                totalBalance += account.GetBalance();
            }
        }
        return totalBalance;
    }
}
