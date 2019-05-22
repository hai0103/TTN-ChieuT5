using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTNhom.Models
{
    public class ShoppingCart
    {
        PetLandModel db = new PetLandModel();
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string Image { get; set; }

        public double Price { get; set; }

        public int Total { get; set; }

        public double TotalPrice { get { return Total * Price; } }

        public ShoppingCart(int ProductID)
        {
            this.ProductID = ProductID;
            Product pr = db.Products.SingleOrDefault(n => n.ProductID == ProductID);
            ProductName = pr.ProductName;
            Image = pr.Image;
            Price = (double)pr.Price;
            Total = 1;
        }
    }
}