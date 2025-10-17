using System;
using System.Text;

namespace ArrayMenuApp
{
    internal class Program
    {
        static int[] CreateRandomArray(int size)
        {
            int[] array = new int[size];
            Random r = new Random();
            for (int i = 0; i < size; i++)
            {
                // Tạo số random từ 0 đến 100 (r.Next(101) sẽ trả về giá trị max là 100)
                array[i] = r.Next(101);
            }
            return array;
        }

        // Hàm hiển thị các phần tử của mảng
        static void DisplayArray(int[] array)
        {
            Console.WriteLine("Các phần tử của mảng là:");
            foreach(var x in array)
            {
                Console.Write(x + " ");
            }
        }

        // Hàm tính tổng các số lẻ
        static int SumOdd(int[] array)
        {
            var sum = 0;
            foreach (var x in array)
            {
                if (x % 2 != 0)
                {
                    sum += x;
                }
            }
            return sum;
        }

        // Hàm kiểm tra số nguyên tố
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

        // Hàm đếm số lượng số nguyên tố
        static int CountPrimes(int[] array)
        {
            var count = 0;
            foreach (var x in array)
            {
                if (IsPrime(x))
                    count++;
            }
            return count;
        }

        // Hàm kiểm tra số chính phương
        static bool IsPerfectSquare(int number)
        {
            if (number <= 0) return false;
            // Sử dụng Math.Sqrt và ép kiểu để kiểm tra số nguyên
            var root = (int)Math.Sqrt(number);
            return root * root == number;
        }

        // Hàm tìm số chính phương nhỏ nhất
        static int FindMinPerfectSquare(int[] array)
        {
            var count = 0;
            var result = int.MaxValue;

            foreach (var x in array)
            {
                if (IsPerfectSquare(x))
                {
                    count++;
                    if (x < result)
                        result = x;
                }
            }

            // Trả về -1 nếu không có số chính phương nào trong mảng
            if (count == 0)
                return -1;

            return result;
        }

        // Hàm đọc số nguyên dương
        static int ReadPositiveInt(string message)
        {
            int n;
            bool isValid;
            do
            {
                Console.Write(message);
                isValid = int.TryParse(Console.ReadLine(), out n) && n > 0;
                if (!isValid)
                {
                    Console.WriteLine("Nhập không hợp lệ. Vui lòng nhập một số nguyên dương (n > 0).");
                }
            } while (!isValid);
            return n;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.WriteLine("--- CHƯƠNG TRÌNH XỬ LÝ MẢNG 1 CHIỀU ---");
            // Yêu cầu người dùng nhập số lượng phần tử
            int n = ReadPositiveInt("Nhập số lượng phần tử (n > 0): ");
            int[] arr = CreateRandomArray(n);

            DisplayArray(arr);

            int choice;
            do
            {
                Console.WriteLine("\n===== MENU CHỨC NĂNG =====");
                Console.WriteLine("1. In mảng (Làm mới mảng)");
                Console.WriteLine("2. Tính tổng các số lẻ");
                Console.WriteLine("3. Đếm số lượng số nguyên tố");
                Console.WriteLine("4. Tìm số chính phương nhỏ nhất");
                Console.WriteLine("0. Thoát");
                Console.Write("Mời bạn chọn chức năng: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập số từ 0 đến 4.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("--- TẠO MẢNG MỚI ---");
                        // Tùy chọn làm mới mảng
                        n = ReadPositiveInt("Nhập kích thước mảng mới (n > 0): ");
                        arr = CreateRandomArray(n);
                        DisplayArray(arr);
                        break;
                    case 2:
                        int sumOdd = SumOdd(arr);
                        Console.WriteLine($"\nKết quả: Tổng các số lẻ trong mảng là: {sumOdd}");
                        break;
                    case 3:
                        int countPrimes = CountPrimes(arr);
                        Console.WriteLine($"\nKết quả: Số lượng số nguyên tố trong mảng là: {countPrimes}");
                        break;
                    case 4:
                        int minPerfectSquare = FindMinPerfectSquare(arr);
                        if (minPerfectSquare != -1)
                        {
                            Console.WriteLine($"\nKết quả: Số chính phương nhỏ nhất trong mảng là: {minPerfectSquare}");
                        }
                        else
                        {
                            Console.WriteLine("\nKết quả: Không tìm thấy số chính phương trong mảng.");
                        }
                        break;
                    case 0:
                        Console.WriteLine("Đã chọn Thoát. Kết thúc chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }

            } while (choice != 0);
        }
    }
}
