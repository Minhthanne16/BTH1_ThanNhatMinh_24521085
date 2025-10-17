using System;
using System.Text;


namespace MatrixMenuApp
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

        static void Nhap(int[,] array, int rows, int cols)
        {
            
            Random r = new Random();
      
          
    
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                   
                    array[i, j] = r.Next(101);
                }
            }
        }

        static void Xuat(int[,] array, int rows, int cols)
        {
            Console.WriteLine("\n--- Ma trận hiện tại ---");
            if (rows == 0 || cols == 0)
            {
                Console.WriteLine("Ma trận rỗng (0x0).");
                return;
            }
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static int TimMax(int[,] array, int rows, int cols)
        {
            int max = int.MinValue;
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    if (array[i, j] > max)
                        max = array[i, j];
                }
            }
            return max;
        }

        static int TimMin(int[,] array, int rows, int cols)
        {
            int min = int.MaxValue;
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    if (array[i, j] < min)
                        min = array[i, j];
                }
            }
            return min;
        }

        static int TimMaxSumRowIndex(int[,] array, int rows, int cols)
        {
            if (rows == 0 || cols == 0) return -1;

            int maxRowIndex = -1;
            long maxRowSum = long.MinValue;

            for (int i = 0; i < rows; ++i)
            {
                long currentSum = 0;
                for (int j = 0; j < cols; ++j)
                {
                    currentSum += array[i, j];
                }
                if (currentSum > maxRowSum)
                {
                    maxRowSum = currentSum;
                    maxRowIndex = i;
                }
            }
            return maxRowIndex;
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

        static int SumPrimes(int[,] array, int rows, int cols)
        {
            int sum = 0;
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    if (!IsPrime(array[i, j]))
                        sum += array[i, j];
                }
            }
            return sum;
        }

        static void XoaHang(int[,] array, ref int rows, int cols, int k)
        {
            if (k < 1 || k > rows)
            {
                Console.WriteLine("Lỗi: Dòng k không hợp lệ.");
                return;
            }

            for (int i = k - 1; i < rows - 1; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    array[i, j] = array[i + 1, j];
                }
            }

            rows--;

            Console.WriteLine($"\nĐã XÓA DÒNG THỨ {k}.");
            Xuat(array, rows, cols);
        }

        static void XoaHangCoMax(int[,] array, int rows, ref int cols)
        {
            if (cols == 0)
            {
                Console.WriteLine("Lỗi: Không có cột nào để xóa.");
                return;
            }

            int max = TimMax(array, rows, cols);
            int maxColIndex = -1;

            for (int j = 0; j < cols; ++j)
            {
                for (int i = 0; i < rows; ++i)
                {
                    if (array[i, j] == max)
                    {
                        maxColIndex = j;
                        goto DeleteStep;
                    }
                }
            }

        DeleteStep:
            if (maxColIndex == -1)
            {
                Console.WriteLine("Lỗi: Không tìm thấy phần tử lớn nhất để xóa cột.");
                return;
            }

            for (int i = 0; i < rows; ++i)
            {
                for (int j = maxColIndex; j < cols - 1; ++j)
                {
                    array[i, j] = array[i, j + 1];
                }
            }

            cols--;

            Console.WriteLine($"\nĐã XÓA CỘT THỨ {maxColIndex + 1} (chứa phần tử lớn nhất {max}).");
            Xuat(array, rows, cols);
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("--- CHƯƠNG TRÌNH XỬ LÝ MA TRẬN (MẢNG 2 CHIỀU) ---");

            int n = ReadPositiveInt("Nhập số hàng n: ");
            int m = ReadPositiveInt("Nhập số cột m: ");

            int[,] array = new int[n, m];
            Nhap(array, n, m);

            int choice;
            do
            {
                Console.WriteLine("\n==================================================");
                Console.WriteLine($"Kích thước Ma trận hiện tại: {n} hàng x {m} cột");
                Console.WriteLine("==================================================");
                Console.WriteLine("1. Hiển thị Ma trận hiện tại");
                Console.WriteLine("2. Tìm giá trị LỚN NHẤT và NHỎ NHẤT");
                Console.WriteLine("3. Tìm dòng có TỔNG lớn nhất");
                Console.WriteLine("4. Tính TỔNG các số KHÔNG LÀ SỐ NGUYÊN TỐ");
                Console.WriteLine("5. Xóa DÒNG thứ K");
                Console.WriteLine("6. Xóa CỘT chứa phần tử Lớn nhất");
                Console.WriteLine("0. Thoát chương trình");
                Console.WriteLine("==================================================");
                Console.Write("Mời bạn chọn chức năng: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("\nLựa chọn không hợp lệ. Vui lòng nhập số từ 0 đến 6.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Xuat(array, n, m);
                        break;

                    case 2:
                        if (n > 0 && m > 0)
                        {
                            Console.WriteLine($"\nKết quả: Giá trị lớn nhất của ma trận là: {TimMax(array, n, m)}");
                            Console.WriteLine($"Kết quả: Giá trị nhỏ nhất của ma trận là: {TimMin(array, n, m)}");
                        }
                        else
                        {
                            Console.WriteLine("\nKhông thể thực hiện. Ma trận hiện tại rỗng.");
                        }
                        break;

                    case 3:
                        int maxRowIndex = TimMaxSumRowIndex(array, n, m);
                        if (maxRowIndex != -1)
                            Console.WriteLine($"\nKết quả: Dòng có tổng lớn nhất là dòng thứ: {maxRowIndex + 1}");
                        else
                            Console.WriteLine("\nKhông thể thực hiện. Ma trận hiện tại rỗng.");
                        break;

                    case 4:
                        if (n > 0 && m > 0)
                        {
                            Console.WriteLine($"\nKết quả: Tổng các số không là số nguyên tố có trong ma trận là: {SumPrimes(array, n, m)}");
                        }
                        else
                        {
                            Console.WriteLine("\nKhông thể thực hiện. Ma trận hiện tại rỗng.");
                        }
                        break;

                    case 5:
                        if (n <= 0)
                        {
                            Console.WriteLine("\nKhông thể xóa. Ma trận hiện tại không có dòng nào hợp lệ.");
                            break;
                        }
                        Console.Write($"\nNhập số dòng muốn xóa (k, từ 1 đến {n}): ");
                        int k;
                        while (!int.TryParse(Console.ReadLine(), out k) || k < 1 || k > n)
                            Console.Write($"Vui lòng nhập lại k (1 đến {n}): ");

                        XoaHang(array, ref n, m, k);
                        break;

                    case 6:
                        if (m <= 0)
                        {
                            Console.WriteLine("\nKhông thể xóa. Ma trận hiện tại không có cột nào hợp lệ.");
                            break;
                        }
                        XoaHangCoMax(array, n, ref m);
                        break;

                    case 0:
                        Console.WriteLine("Kết thúc chương trình.");
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }

                if (choice != 0)
                {
                    Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                    Console.ReadKey();
                }

            } while (choice != 0);
        }
    }
}

