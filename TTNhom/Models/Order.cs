namespace TTNhom.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int OrderID { get; set; }

        public int? Paid { get; set; }

        public int? TransferStatus { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TransferDate { get; set; }

        public int? CustomerID { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
