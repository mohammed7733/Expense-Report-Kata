using System;
using System.Collections.Generic;
using System.Linq;

namespace expensereport_csharp
{
    public enum ExpenseType
    {
        DINNER, BREAKFAST, CAR_RENTAL
    }

    public abstract class Expense
    {
        public int Amount;
        public abstract string Name();
        public abstract bool IsMeal();
        public abstract bool IsOverExpense();
    }

    public class Breakfast : Expense
    {
        public Breakfast(int amount)
        {
            Amount = amount;
        }

        public override string Name() => "Breakfast";

        public override bool IsMeal() => true;

        public override bool IsOverExpense() => Amount > 1000;
    }

    public class Dinner : Expense
    {
        public Dinner(int amount)
        {
            Amount = amount;
        }

        public override string Name() => "Dinner";

        public override bool IsMeal() => true;

        public override bool IsOverExpense() => Amount > 5000;
    }

    public class CarRental : Expense
    {
        public CarRental(int amount)
        {
            Amount = amount;
        }

        public override string Name() => "Car Rental";

        public override bool IsMeal() => false;

        public override bool IsOverExpense() => false;
    }

    public class Expenses
    {
        public readonly List<Expense> ExpensesList;

        public Expenses(List<Expense> expensesList)
        {
            this.ExpensesList = expensesList;
        }

        public int TotalExpenses() => ExpensesList.Sum(expense => expense.Amount);
        public int MealExpenses() => ExpensesList.Where(expense => expense.IsMeal()).Sum(expense => expense.Amount);
    }

    public class ExpenseReport
    {
        public void PrintReport(Expenses expenses)
        {
            Console.WriteLine("Expenses " + DateTime.Now);
            PrintExpenses(expenses);
            Console.WriteLine("Meal expenses: " + expenses.MealExpenses());
            Console.WriteLine("Total expenses: " + expenses.TotalExpenses());
        }

        private static void PrintExpenses(Expenses expenses)
        {
            foreach (var expense in expenses.ExpensesList)
            {
                Console.WriteLine(expense.Name() + "\t" + expense.Amount + "\t" + MealOverExpensesMarker(expense));
            }
        }

        private static string MealOverExpensesMarker(Expense expense) =>
            expense.IsOverExpense()
                ? "X"
                : " ";
    }
}