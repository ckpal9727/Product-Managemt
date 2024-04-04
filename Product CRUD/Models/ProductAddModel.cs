using System.ComponentModel.DataAnnotations;

namespace Product_CRUD.Models
{
    public class ProductAddModel
    {
        [Required(ErrorMessage = "Please Enter Product name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter cost price")]
        [Display(Name ="Cost Price")]
        public double CostPrice { get; set; }
        public double SalesPrice { get; set; }
        [Required(ErrorMessage = "Please Enter Quantity")]
        [Display(Name = "Quantity")]
        public int Qty { get; set; }
    }
}
