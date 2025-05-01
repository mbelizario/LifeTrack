using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LifeTrack.UI.Web.ViewModels.Transaction
{
    public class TransactionCreateViewModel
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
