using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yemeksepeti
{
	public class SepetManager
	{
		// Kullanıcıların sepetlerini tutan bir sözlük
		private static Dictionary<int, List<Sepet>> sepetler = new Dictionary<int, List<Sepet>>();

		// Sepete ürün ekleme
		public static void SepeteEkle(int userId, Sepet item)
		{
			if (!sepetler.ContainsKey(userId))
			{
				sepetler[userId] = new List<Sepet>();
			}

			sepetler[userId].Add(item);
		}

		// Kullanıcıya özel sepeti alma
		public static List<Sepet> GetSepet(int userId)
		{
			if (sepetler.ContainsKey(userId))
			{
				return sepetler[userId];
			}

			return new List<Sepet>();
		}

		// Kullanıcının sepetini temizleme
		public static void SepetiTemizle(int userId)
		{
			if (sepetler.ContainsKey(userId))
			{
				sepetler[userId].Clear();
			}
		}
	}
}
