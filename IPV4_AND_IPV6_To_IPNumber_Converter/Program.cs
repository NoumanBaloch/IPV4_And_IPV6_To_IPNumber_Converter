using System;
using System.Collections.Generic;

namespace IPV4_AND_IPV6_To_IPNumber_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            string strIP = "ffff:ffff:ffff:ffff:ffff:ffff:ffff:ffff"; // IPV6 Format
            //string strIP = "39.52.19.96"; // IPV4 Format
            System.Net.IPAddress address;
            System.Numerics.BigInteger ipnum;

            if (System.Net.IPAddress.TryParse(strIP, out address))
            {
                byte[] addrBytes = address.GetAddressBytes();

                if (System.BitConverter.IsLittleEndian)
                {
                    List<byte> byteList = new System.Collections.Generic.List<byte>(addrBytes);
                    byteList.Reverse();
                    addrBytes = byteList.ToArray();
                }

                if (addrBytes.Length > 8)
                {
                    //IPv6
                    ipnum = System.BitConverter.ToUInt64(addrBytes, 8);
                    ipnum <<= 64;
                    ipnum += System.BitConverter.ToUInt64(addrBytes, 0);
                    Console.WriteLine("IPV6 to IP Number : {0} ", ipnum);
                }
                else
                {
                    //IPv4
                    ipnum = System.BitConverter.ToUInt32(addrBytes, 0);
                    Console.WriteLine("IPV4 to IP Number: {0}", ipnum);
                }
            }
        }
    }
}
