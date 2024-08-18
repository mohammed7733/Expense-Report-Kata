﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace expensereport_csharp
{
    public enum ExpenseType
    {
        DINNER, BREAKFAST, CAR_RENTAL
    }

    public class ExpenseToRemove
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
            return type is ExpenseType.DINNER or ExpenseType.BREAKFAST;
        }
    }

    public class Expenses
    {
        public readonly List<ExpenseToRemove> ExpensesList;

        public Expenses(List<ExpenseToRemove> expensesList)
        {
            this.ExpensesList = expensesList;
        }

        public int TotalExpenses() => ExpensesList.Sum(expense => expense.amount);
        public int MealExpenses() => ExpensesList.Where(expense => expense.IsMeal()).Sum(expense => expense.amount);
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
                Console.WriteLine(expense.ExpenseName() + "\t" + expense.amount + "\t" + MealOverExpensesMarker(expense));
            }
        }

        private static string MealOverExpensesMarker(ExpenseToRemove expenseToRemove) =>
            expenseToRemove.IsMealOverExpense()
                ? "X"
                : " ";
    }
}