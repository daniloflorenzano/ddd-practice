namespace DDDPractice.Logic;

public sealed class SnackMachine
{
    public Money MoneyInside { get; private set; }
    public Money MoneyInTransaction { get; private set; }

    private void InsertMoney(Money money)
    {
        MoneyInTransaction += money;
    }

    public void ReturnMoney()
    {
        //MoneyInTransaction = 0;
    }

    public void BuySnack()
    {
        MoneyInside += MoneyInTransaction;
        //MoneyInTransaction = 0;
    }
}