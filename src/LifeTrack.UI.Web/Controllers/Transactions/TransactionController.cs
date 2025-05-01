using LifeTrack.Application.Interfaces;
using LifeTrack.UI.Web.ViewModels.Transaction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LifeTrack.UI.Web.Controllers.Transactions
{
    public class TransactionController : Controller
    {
        private readonly ITransactionCategoryService _transactionCategoryService;
        public TransactionController(ITransactionCategoryService transactionCategoryService)
        {
            _transactionCategoryService = transactionCategoryService;
        }
        public async Task<IActionResult> Create()
        {
            var viewModel = new TransactionCreateViewModel()
            {
                Types = new List<SelectListItem> { new SelectListItem() { Text = "Entrada", Value = "1"}, new SelectListItem() { Text = "Saída", Value = "2" } }
            };
            return View(viewModel);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
