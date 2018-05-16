using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Models
{
    public enum ItemType
    {
        Book,
        Magazine,
        Article
    }
    
    public class LibraryItem : BaseItem
    {
        [Required]
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public int PageCount { get; set; }
        
        public DateTime ProducedDate { get; set; }
    }
}