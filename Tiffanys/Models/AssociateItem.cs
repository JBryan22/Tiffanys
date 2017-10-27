using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiffanys.Models
{
    [Table("AssociateItems")]
    public class AssociateItem
    {
        public int AssociateId { get; set; }
        public Associate Associate { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }


        public AssociateItem()
        {
            
        }
		public AssociateItem(int associateId, int itemId)
		{
            this.AssociateId = associateId;
            this.ItemId = itemId;
		}
    }
}
