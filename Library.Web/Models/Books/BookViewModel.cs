using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Models.Books
{
    public class BookViewModel
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        
        [EmailAddress]
        [Remote(action: "VerifyEmail", controller: "Books")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string AuthorEmail { get; set; }
        
        [StringLength(100)]
        public string Description { get; set; }
    }
}