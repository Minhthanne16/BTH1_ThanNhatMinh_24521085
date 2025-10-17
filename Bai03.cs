using System;
using System.Text;
using System.Threading.Tasks;

namespace TinhHopLeApp
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

        static bool TinhHopLe(int day, int month, int year)
        {
            if (year <= 0 || month < 1 || month > 12)
            {
                return false;
            }

            int maxDays = NgayTrongThang(month, year);
            if (day < 1 || day > maxDays)
            {
                return false;
            }

            return true;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("--- CHƯƠNG TRÌNH KIỂM TRA NGÀY THÁNG NĂM HỢP LỆ ---");
            int day = ReadPositiveInt("Nhập ngày: ");
            int month = ReadPositiveInt("Nhập tháng: ");
            int year = ReadPositiveInt("Nhập năm: ");
           
            bool isValid = TinhHopLe(day, month, year);

            Console.WriteLine($"Ngày tháng năm đã nhập: {day}/{month}/{year}");

            if (isValid)
            {
                Console.WriteLine("KẾT QUẢ: Ngày tháng năm HỢP LỆ.");
            }
            else
            {
                Console.WriteLine("KẾT QUẢ: Ngày tháng năm KHÔNG HỢP LỆ.");
            }

            Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}
