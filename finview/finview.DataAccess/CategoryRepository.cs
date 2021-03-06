﻿using finview.DataAccess.Contracts;
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

        public List<Category> GetCategories()
        {
            List<Category> res;
            using (FinViewModel fvm = new FinViewModel())
            {
                res = fvm.Set<Category>().ToList();
            }
            return res;
        }

        public void RemoveCategory(Category cat)
        {
            using (FinViewModel fvm = new FinViewModel())
            {
                fvm.Categorys.Attach(cat);
                fvm.Categorys.Remove(cat);
                fvm.SaveChanges();
            }
        }
    }
}
