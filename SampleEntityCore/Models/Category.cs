using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleEntityCore.Models
{
    public class Category
    {
        [Display(Name ="Category ID")]
        public int CategoryID { get; set; } //master karena ada id, ada desc
        [Display(Name ="Category Name")]
        [Required(ErrorMessage ="Catergory Name harus diisi")]
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; } // bisa dilihat KAtegori 1 itu barang nya apa saja sih
        //ini pasti many nya karena ada collection

    }
}
