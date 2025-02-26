using DDDPractice.Logic;
using FluentAssertions;

using static DDDPractice.Logic.Money;

namespace TestProject1;

public class SnackMachineSpecs
{
    [Fact]
    public void Return_money_empties_money_in_transaction()
    {
        // Arrange
        SnackMachine snackMachine = new SnackMachine();
        snackMachine.InsertMoney(Dollar);
        
        // Act
        snackMachine.ReturnMoney();
         
        // Assert
        snackMachine.MoneyInTransaction.Amount.Should().Be(0);
    }
    
    [Fact]
    public void Inserted_money_goes_to_money_in_transaction()
    {
        SnackMachine snackMachine = new SnackMachine();
        
        snackMachine.InsertMoney(Cent);
        snackMachine.InsertMoney(Dollar);
        
        snackMachine.MoneyInTransaction.Amount.Should().Be(1.01m);
    }

    [Fact]
    public void Cannot_insert_more_than_a_coin_or_note_at_a_time()
    {
        var snackMachine = new SnackMachine();  
        var twoCent = Cent + Cent;
        
        Action action = () => snackMachine.InsertMoney(twoCent);
        
        action.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Money_in_transaction_goes_to_money_inside_after_purchase()
    {
        var snackMachine = new SnackMachine();
        snackMachine.InsertMoney(Dollar);
        snackMachine.InsertMoney(Dollar);
        
        snackMachine.BuySnack();

        snackMachine.MoneyInTransaction.Should().Be(None);
        snackMachine.MoneyInside.Amount.Should().Be(2);
    }
}