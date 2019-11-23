using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace Debugging.StanovimsiaHackerami.GenerimKey
{
    internal class KeyGenerator
    {
        public string Key()
        {
            var netInterface = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault();

            if (netInterface == null)
                Console.WriteLine("Bedaa, bratan, megom v magaz za network interface'om'");

            var bufNetworkInterface = netInterface.GetPhysicalAddress().GetAddressBytes();
            var bufDate = BitConverter.GetBytes(DateTime.Now.Date.ToBinary());
            var count = Math.Min(bufNetworkInterface.Length, bufDate.Length);

            var list = new List<int>(count);

            for (var i = 0; i < count; i++)
            {
                var partOfKey = (bufDate[i] ^ bufNetworkInterface[i]) * 10;
                list.Add(partOfKey);
            }

            return string.Join("-", list);
        }
    }
}
