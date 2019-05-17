namespace TTNhom.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Blog")]
    public partial class Blog
    {
        public int BlogID { get; set; }

        public string Title { get; set; }

        public string ContentDM { get; set; }

        public string ContentDetail { get; set; }

        [StringLength(1000)]
        public string Image { get; set; }

        public int? New { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
    }
}
