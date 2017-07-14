using finview.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using finview.Entities.Model;
using finview.DataAccess.Data;

namespace finview.DataAccess
{
    public class CategoryRepository : ICategoryRepository
    {
        public void SaveCategory(Category cat)
        {
            using (FinViewModel fvm = new FinViewModel())
            {
                fvm.Categorys.Add(cat);
                fvm.SaveChanges();
            }
        }
    }
}
