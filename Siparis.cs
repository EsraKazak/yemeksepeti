using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yemeksepeti
{
	
		public class Siparis
		{
			public int OrderID { get; set; }
			public int CustemerID { get; set; }  
			public DateTime OrderDate { get; set; }
			public double PrioritizationScore { get; set; }
		public string CustomerType { get; set; }
	}
	
}
