using System;
using System.Linq;

namespace KeyGen
{
	class Program
	{
		static void Main(string[] args)
		{
			var nic = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault();
			var addr = nic.GetPhysicalAddress();
			var addrbytes = addr.GetAddressBytes();

			var binarydate = System.DateTime.Now.Date.ToBinary();
			var datebytes = System.BitConverter.GetBytes(binarydate);

			var outarr =new  string[addrbytes.Length];
			for (int i = 0; i < addrbytes.Length; i++) 
			{
				outarr[i] = ((addrbytes[i] ^ datebytes[i]) * 10).ToString();
			}

			Console.WriteLine(string.Join("-", outarr));
			Console.ReadLine();
		}
	}
}
