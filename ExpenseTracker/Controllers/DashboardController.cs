﻿using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace ExpenseTracker.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDBContext _context;

        public DashboardController(ApplicationDBContext context)
        { 
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            //last 7 days transactions
            DateTime StartDate = DateTime.Today.AddDays(-6);
            DateTime EndDate = DateTime.Today;

            List<Transaction> SelectedTransactions = await _context.Transactions
                .Include(x => x.Category)
                .Where(y => y.Date >= StartDate && y.Date <= EndDate)
                .ToListAsync();

            //Total income
            int TotalIncome = SelectedTransactions
                .Where(i => i.Category.Type == "Income")
                .Sum(j +.j.Amount);
            ViewBag.TotalIncome = TotalIncome.ToString("C0");

            //Total expense
            int TotalExpense = SelectedTransactions
                .Where(i => i.Category.Type == "Expense")
                .Sum(j +.j.Amount);
            ViewBag.TotalExpense = TotalExpense.ToString("C0");


            //Balance
            int Balance = TotalIncome - TotalExpense;
            ViewBag.Balance = Balance.ToString("C0");
            return View();
        }
    }
}
