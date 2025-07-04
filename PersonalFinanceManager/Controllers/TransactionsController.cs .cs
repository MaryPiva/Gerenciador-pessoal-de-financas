using Microsoft.AspNetCore.Mvc;
using PersonalFinanceManager.Data;
using PersonalFinanceManager.Models;
using System.Linq;

namespace PersonalFinanceManager.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var transactions = _context.Transactions.ToList();
            return View(transactions);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Transactions.Add(transaction);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(transaction);
        }

        public IActionResult Delete(int id)
        {
            var transaction = _context.Transactions.FirstOrDefault(t => t.Id == id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var transaction = _context.Transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       public IActionResult Edit(int id, Transaction transaction)
{
    if (id != transaction.Id)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        _context.Update(transaction);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    return View(transaction);
}
    }
}
