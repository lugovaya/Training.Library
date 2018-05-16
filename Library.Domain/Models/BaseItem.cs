using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Models
{
    public class BaseItem<T>
    {
        [Key]
        public T Id { get; set; }
    }

    public class BaseItem : BaseItem<int>
    {
        
    }
}