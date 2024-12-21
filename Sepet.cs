using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yemeksepeti
{
	public class Sepet
	{
		public int ProductID { get; set; }       // Ürün ID
		public string ProductName { get; set; }  // Ürün Adı
		public int Quantity { get; set; }        // Adet
		public decimal UnitPrice { get; set; }   // Birim Fiyat
		public decimal TotalPrice => Quantity * UnitPrice;
	}
}
