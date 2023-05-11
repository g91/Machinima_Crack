using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public static class bcp
    {
        public static string o()
        {
            return Environment.UserName;
        }

        public static string n()
        {
            return Environment.MachineName;
        }

        private static string g(string A_0)
        {
            MD5 md = MD5.Create();
            byte[] value = md.ComputeHash(Encoding.UTF8.GetBytes(A_0));
            string text = BitConverter.ToString(value);
            return text.Replace("-", string.Empty);
        }

        public static string g()
        {
            string a_ = bcp.o() + bcp.n();
            string text = bcp.g(a_);
            return string.Format("{0}{1}{2}{3}-{4}{5}{6}-{7}{8}{9}{10}", new object[]
            {
                text[4],
                text[6],
                text[8],
                text[3],
                text[1],
                text[2],
                text[0],
                text[7],
                text[5],
                text[9],
                text[0]
            });
        }


        public static string f()
        {
            string text = bcp.g(bcp.g());
            text = text.ToLower();
            text = text.Substring(0, 15);
            text = bcp.g(text);
            text = text.ToLower();
            return text.Substring(0, 15);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(bcp.f());
            Console.ReadLine();
        }
    }
}
