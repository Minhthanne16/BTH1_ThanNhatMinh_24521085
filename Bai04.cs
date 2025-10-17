using System;
using System.Text;
using System.Threading.Tasks;

namespace GetDaysInMonthApp
{
    internal class Program
    {
        static int ReadPositiveInt(string prompt)
        {
            int value;
            bool isValid;
            do
            {
                Console.Write(prompt);
                isValid = int.TryParse(Console.ReadLine(), out value) && value > 0;
                if (!isValid)
                {
                    Console.WriteLine("Lỗi: Vui lòng nhập một số nguyên dương (> 0).");
                }
            } while (!isValid);
            return value;
        }

        static bool NamNhuan(int year)
        {
            return (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
        }

        static int NgayTrongThang(int month, int year)
        {
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    return NamNhuan(year) ? 29 : 28;
                default:
                    return 0;
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("--- CHƯƠNG TRÌNH IN SỐ NGÀY CỦA THÁNG ---");

            

            int month;
            bool isMonthValid;
            do
            {
                month = ReadPositiveInt("Nhập tháng (1-12): ");
                isMonthValid = month >= 1 && month <= 12;
                if (!isMonthValid)
                {
                    Console.WriteLine("Lỗi: Tháng phải nằm trong khoảng từ 1 đến 12.");
                }
            } while (!isMonthValid);

            int year = ReadPositiveInt("Nhập năm: ");
            int days = NgayTrongThang(month, year);


            if (days > 0)
            {
                Console.WriteLine($"Tháng {month} năm {year} có {days} ngày.");
            }
            else
            {
                Console.WriteLine("Lỗi không xác định: Tháng không hợp lệ.");
            }


            Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}
