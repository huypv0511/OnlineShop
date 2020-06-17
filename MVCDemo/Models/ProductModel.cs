using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class ProductModel
    {
        [Required(ErrorMessage = "Bạn chưa nhập tên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập giá")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập giá khuyến mại")]
        public decimal? PromotionPice { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập số lượng")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Bạn chưa chọn thể loại")]
        public long? CategoryID { get; set; }
    }
}