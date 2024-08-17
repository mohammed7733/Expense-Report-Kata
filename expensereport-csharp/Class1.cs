using System;
using System.Collections.Generic;
using System.Linq;

namespace expensereport_csharp
{
    public enum ExpenseType
    {
        DINNER, BREAKFAST, CAR_RENTAL
    }

    public class Expense
    {
        public ExpenseType type;
        public int amount;

        public string ExpenseName() =>
            type switch
            {
                ExpenseType.DINNER => "Dinner",
                ExpenseType.BREAKFAST => "Breakfast",
                ExpenseType.CAR_RENTAL => "Car Rental",
                _ => ""
            };

        private bool IsBreakfast() => type == ExpenseType.BREAKFAST;

        private bool IsDinner() => type == ExpenseType.DINNER;

        public bool IsMealOverExpense()
        {
            return IsDinner() && amount > 5000 ||
                   IsBreakfast() && amount > 1000;
        }

        public bool IsMeal()
        {
            return type == ExpenseType.DINNER || type == ExpenseType.BREAKFAST;
        }
    }

    public class Expenses
    {
        public readonly List<Expense> ExpensesList;

        public Expenses(List<Expense> expensesList)
        {
            this.ExpensesList = expensesList;
        }
    }

    public class ExpenseReport
    {
        public void PrintReport(Expenses expenses)
        {
            Console.WriteLine("Expenses " + DateTime.Now);

            var mealExpenses = expenses.ExpensesList.Where(expense => expense.IsMeal()).Sum(expense => expense.amount);

            foreach (Expense expense in expenses.ExpensesList)
            {
                Console.WriteLine(expense.ExpenseName() + "\t" + expense.amount + "\t" + MealOverExpensesMarker(expense));
            }

            var total = expenses.ExpensesList.Sum(expense => expense.amount);

            Console.WriteLine("Meal expenses: " + mealExpenses);
            Console.WriteLine("Total expenses: " + total);
        }

        private static string MealOverExpensesMarker(Expense expense)
        {
            
            var mealOverExpensesMarker =
                expense.IsMealOverExpense()
                    ? "X"
                    : " ";
            return mealOverExpensesMarker;
        }
    }
}