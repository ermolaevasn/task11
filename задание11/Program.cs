using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание11
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine(@"Данная программа шифрует выражения
Введите выражение, состоящее из 0 и 1");
            string s = Console.ReadLine();
            Proverka("выражение",ref s);
            char[] array = s.ToCharArray();
            int[] a = new int[array.Length];
            int[] b = new int[array.Length];
            n = array.Length;

            for (int i = 0; i < array.Length; i++)
            {
                a[i]= Convert.ToInt16(array[i])- 48;
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
            b[0] = a[0];

            for(int i=1;i<n;i++)
            {
                if (a[i - 1] == a[i]) b[i] = 1;
                else b[i] = 0;
            }

            Console.WriteLine("Закодировано:");
            for (int i = 0; i < n; i++) Console.Write(b[i] + " ");
            Console.ReadKey();
        }

        static void Proverka(string s, ref string a)//проверка ввода
        {
            bool ok = false;
            string buf;
            do
            {
                int kol = 0;
                char[] array = a.ToCharArray();
                for (int i = 0; i < a.Length; i++)
                {
                    if ((array[i] == '1') || (array[i] == '0')) kol++;                       
                }
                if (kol == a.Length) ok = true;
                else
                {
                    if (!ok) Console.WriteLine("\aВведите " + s + " заново");
                    Console.Write(s + " = ");
                    a = Console.ReadLine();
                    ok = false;
                }
            } while (!ok);
        }
    }
}
