using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTNhom.Models
{
    public class CategoryViewModel
    {
        PetLandModel db = new PetLandModel();

        public List<CategoryOfProduct> ListAll()
        {
            return db.CategoryOfProducts.ToList();
        }
    }
}