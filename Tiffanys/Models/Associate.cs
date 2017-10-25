using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiffanys.Models
{
	[Table("Associates")]
	public class Associate
	{
		public int AssociateId { get; set; }
		public double TotalSales { get; set; }
        public double TotalReturns { get; set; }

        public List<AssociateItem> AssociateItems { get; set; } 

		public virtual ApplicationUser User { get; set; }

	
		public Associate()
		{
            this.TotalSales = 0;
            this.TotalReturns = 0;
		}


	}
}