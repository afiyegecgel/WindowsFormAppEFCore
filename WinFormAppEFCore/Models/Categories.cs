using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormAppEFCore.Models
{
    class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Property -- A category can be include more than one product.
        public IList<Products> Products { get; set; }
    }
}
