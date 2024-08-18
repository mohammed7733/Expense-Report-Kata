namespace expensereport_csharp;

public abstract class Expense
{
    public int Amount;
    public abstract string Name();
    public abstract bool IsMeal();
    public abstract bool IsOverExpense();
}