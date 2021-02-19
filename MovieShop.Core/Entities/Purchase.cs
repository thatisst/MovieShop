using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieShop.Core.Entities
{
    [Table("Purchase")]
    public class Purchase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Guid PurchaseNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDateTime { get; set; }
        public int MovieId { get; set; }
        //1 : 1
        public User User { get; set; }
        public Movie Movies { get; set; } // 1:N
    }
}
