using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yemeksepeti
{
	public class Sepet
	{
		public int ProductID { get; set; }       
		public string ProductName { get; set; }  
		public int Quantity { get; set; }        
		public decimal UnitPrice { get; set; }   
		public decimal TotalPrice => Quantity * UnitPrice;
	}
}
