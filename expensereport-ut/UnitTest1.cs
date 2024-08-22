using System;
using System.Collections.Generic;
using System.IO;
using expensereport_csharp;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void PrintReport_WithEmptyExpenses_WorkAsExpected()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            var expenseReport = new ExpenseReport();
            var dateTime = DateTime.Now;
            expenseReport.PrintReport(new Expenses(new List<Expense>()));
            Assert.Equal($"Expenses {dateTime}\nMeal expenses: 0\nTotal expenses: 0\n", writer.ToString());
        }

        [Theory]
        [InlineData(900, false)]
        [InlineData(1000, false)]
        [InlineData(1100, true)]
        public void NewBreakfast_InitiatedAsExpected(int amount, bool isOverExpense)
        {
            var breakfast = new Breakfast(amount);
            Assert.Equal(amount, breakfast.Amount);
            Assert.Equal("Breakfast", breakfast.Name());
            Assert.True(breakfast.IsMeal());
            Assert.Equal(isOverExpense, breakfast.IsOverExpense());
        }

        [Theory]
        [InlineData(2900, false)]
        [InlineData(3000, false)]
        [InlineData(3100, true)]
        public void NewLunch_InitiatedAsExpected(int amount, bool isOverExpense)
        {
            var lunch = new Lunch(amount);
            Assert.Equal(amount, lunch.Amount);
            Assert.Equal("Lunch", lunch.Name());
            Assert.True(lunch.IsMeal());
            Assert.Equal(isOverExpense, lunch.IsOverExpense());
        }

        [Theory]
        [InlineData(4900, false)]
        [InlineData(5000, false)]
        [InlineData(5100, true)]
        public void NewDinner_InitiatedAsExpected(int amount, bool isOverExpense)
        {
            var dinner = new Dinner(amount);
            Assert.Equal(amount, dinner.Amount);
            Assert.Equal("Dinner", dinner.Name());
            Assert.True(dinner.IsMeal());
            Assert.Equal(isOverExpense, dinner.IsOverExpense());
        }

        [Fact]
        public void NewCarRental_InitiatedAsExpected()
        {
            var carRental = new CarRental(70);
            Assert.Equal(70, carRental.Amount);
            Assert.Equal("Car Rental", carRental.Name());
            Assert.False(carRental.IsMeal());
            Assert.False(carRental.IsOverExpense());
        }

        [Fact]
        public void PrintReport_WithExpenses_WorkAsExpected()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            var expenseReport = new ExpenseReport();
            var expenses = new List<Expense>
            {
                new Breakfast(900),
                new Dinner(5100),
                new CarRental(2000)
            };
            var dateTime = DateTime.Now;
            expenseReport.PrintReport(new Expenses(expenses));
            Assert.Equal($"Expenses {dateTime}\n" +
                         $"Breakfast\t900\t \n" +
                         $"Dinner\t5100\tX\n" +
                         $"Car Rental\t2000\t \n" +
                         $"Meal expenses: 6000\n" +
                         $"Total expenses: 8000\n", writer.ToString());
        }
    }
}