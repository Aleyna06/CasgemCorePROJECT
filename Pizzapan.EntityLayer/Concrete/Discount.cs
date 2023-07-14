using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzapan.EntityLayer.Concrete
{
   public class Discount
    {
        [Key]
        public int DiscountID { get; set; }
        public string DiscountCupon { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndlingDate { get; set; }
        public int Discountcount { get; set; }
    }
}
