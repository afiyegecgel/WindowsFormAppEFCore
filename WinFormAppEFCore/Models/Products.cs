using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormAppEFCore.Models
{
    class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        
        public int CategoryId { get; set; }

        [NotMapped]
        public string CategoryName { get; set; }
        public Categories Category { get; set; }
        
    }
}
