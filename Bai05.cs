using System;
using System.Text;

namespace DayOfWeekApp
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

        static string ThuTrongTuan(int day, int month, int year)
        {
            DateTime date = new DateTime(year, month, day);
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday: return "Thứ Hai";
                case DayOfWeek.Tuesday: return "Thứ Ba";
                case DayOfWeek.Wednesday: return "Thứ Tư";
                case DayOfWeek.Thursday: return "Thứ Năm";
                case DayOfWeek.Friday: return "Thứ Sáu";
                case DayOfWeek.Saturday: return "Thứ Bảy";
                case DayOfWeek.Sunday: return "Chủ Nhật";
                default: return "";
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("--- CHƯƠNG TRÌNH XÁC ĐỊNH THỨ TRONG TUẦN ---");

            int day, month, year;
            bool isDateValid = false;

            do
            {
                day = ReadPositiveInt("Nhập ngày: ");  
                month = ReadPositiveInt("Nhập tháng (1-12): ");
                year = ReadPositiveInt("Nhập năm: ");
                int maxDay = NgayTrongThang(month, year);

                if (month < 1 || month > 12)
                {
                    Console.WriteLine("Lỗi: Tháng phải nằm trong khoảng từ 1 đến 12.");
                }
                else if (day < 1 || day > maxDay)
                {
                    Console.WriteLine($"Lỗi: Tháng {month} năm {year} chỉ có {maxDay} ngày. Vui lòng nhập lại.");
                }
                else
                {
                    isDateValid = true;
                }
            } while (!isDateValid);

            string thu = ThuTrongTuan(day, month, year);
            Console.WriteLine($"Ngày {day}/{month}/{year} là {thu}.");


            Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}
