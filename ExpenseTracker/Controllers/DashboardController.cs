using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
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
        public async IActionResult Index()
        {
            //last 7 days transactions
            DateTime StartDate = DateTime.Today.AddDays(-6);
            DateTime EndDate = DateTime.Today;

            List<Transaction> SelectedTransactions = await _context.Transactions

            return View();
        }
    }
}
