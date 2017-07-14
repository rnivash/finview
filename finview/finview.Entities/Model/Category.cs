using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finview.Entities.Model
{
    public class Category
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
