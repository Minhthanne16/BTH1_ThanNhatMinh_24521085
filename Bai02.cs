using System;
using System.Text;
using System.Threading.Tasks;

namespace SumPrimesLessThanNApp
{
    internal class Program
    {
        static int ReadPositiveInt(string a)
        {
            int value;
            bool isValid;
            do
            {
                Console.Write(a);
                isValid = int.TryParse(Console.ReadLine(), out value) && value > 0;
                if (!isValid)
                {
                    Console.WriteLine("Lỗi: Vui lòng nhập một số nguyên dương (> 0).");
                }
            } while (!isValid);
            return value;
        }

        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (int i = 3; i * i <= number; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        static long SNTBeHonN(int n)
        {
            if (n <= 2) return 0;

            long sum = 0;
            for (int i = 2; i < n; i++)
            {
                if (IsPrime(i))
                {
                    sum += i;
                }
            }
            return sum;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; 

            Console.WriteLine("--- CHƯƠNG TRÌNH TÍNH TỔNG CÁC SỐ NGUYÊN TỐ NHỎ HƠN N ---");
            int n = ReadPositiveInt("Nhập số nguyên dương N: ");
            long sumResult = SNTBeHonN(n);
 
            Console.WriteLine($"Số N đã nhập là: {n}");
            Console.WriteLine($"Tổng các số nguyên tố nhỏ hơn {n} là: {sumResult}");
           
            Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}
