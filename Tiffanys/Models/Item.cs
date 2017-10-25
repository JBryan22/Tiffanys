using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiffanys.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        public bool Sold { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

		public List<AssociateItem> AssociateItems { get; set; }


		public Item()
        {
            this.Sold = false;
        }
    }
}
