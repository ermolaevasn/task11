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
            int n,cases;
            bool ok=false;
            Console.WriteLine("Введите выражение, состоящее из 0 и 1");
            string s = Console.ReadLine();//ввод шифруемого выраженiя
            Proverka("выражение",ref s);
            char[] array = s.ToCharArray();//представление выр-ия в виде массива
            int[] a = new int[array.Length];//массив для выражения
            int[] b = new int[array.Length];//массив для зашифрованного выражения
            int[] c = new int[array.Length];//массив для расшифрованного выражения
            n = array.Length;//длина выражения

            for (int i = 0; i < array.Length; i++)//перевод выражения в массив
            {
                a[i]= Convert.ToInt16(array[i])- 48;
            }
            Console.WriteLine();

            b[0] = a[0];

            do
            {
                Console.WriteLine(@"1. Зашифровать выражение
2. Расшифровать выражение");

                Vvod("действие", out cases);
                switch (cases)
                {
                    case 1:
                        for (int i = 1; i < n; i++)//шифрование выражения
                        {
                            if (a[i - 1] == a[i]) b[i] = 1;
                            else b[i] = 0;
                        }
                        Console.WriteLine("Результат зашифровки:");
                        for (int i = 0; i < n; i++) Console.Write(a[i] + " ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("-> ");
                        Console.ResetColor();
                        for (int i = 0; i < n; i++) Console.Write(b[i] + " ");
                        ok = true;
                        break;
                    case 2://расшифрование выражения
                        c[0] = a[0];
                        for (int i = 1; i < n; i++)
                        {
                            if (a[i] == 0)
                            {
                                if (c[i - 1] == 0) c[i] = 1;
                                else c[i] = 0;
                            }
                            else c[i] = a[i - 1];
                        }
                        Console.WriteLine("Результат расшифровки:");
                        for (int i = 0; i < n; i++) Console.Write(a[i] + " ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("-> ");
                        Console.ResetColor();
                        for (int i = 0; i < n; i++) Console.Write(c[i] + " ");
                        ok = true;
                        break;
                    default:
                        Console.WriteLine("Введите один из предложенных вариантов");
                        ok = false;
                        break;
                }
            } while (ok==false);
            Console.ReadKey();
        }

        static void Proverka(string s, ref string a)//проверка ввода выражения
        {
            bool ok = false;
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
        static double Vvod(string s, out int n)//ввод чисел с проверкой
        {
            bool ok;
            string buf;
            do
            {
                Console.Write(s + " = ");
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out n);
                if (!ok) Console.WriteLine("Введите " + s + " заново");
            } while (!ok);
            return n;
        }
    }
}
