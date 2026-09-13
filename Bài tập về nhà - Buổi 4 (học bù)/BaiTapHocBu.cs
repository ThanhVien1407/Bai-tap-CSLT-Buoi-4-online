using System.Text;

internal class BaiTapHocBu
{
    static void diceGame()
    {
        long tien = 1000000; 

        int soLanChoi = 0; 

        int soLanThua = 0; 

        int soLanDacBiet = 0; 

        bool continuePlaying = true; 

        do
        {
            soLanChoi++;

            Console.Write($"Bạn có {tien} đồng. \nBạn đặt bao nhiêu?: ");

            long tienDatCuoc = 0;

            do
            {
                bool ok = long.TryParse(Console.ReadLine()!, out long result);

                if (ok && result <= tien && result > 1000)
                {
                    tienDatCuoc = result;
                    break;
                }
                else
                {
                    Console.WriteLine($"Vui lòng nhập một số hợp lệ hoặc số tiền đặt cược không được vượt quá số tiền hiện có {tien}. Hoặc trên 1000 đồng");
                    Console.Write("Bạn đặt bao nhiêu?: ");
                }
            } while (true);

            Random rand = new Random();

            int dice1 = rand.Next(1, 7); 
            int dice2 = rand.Next(1, 7);

            int sum = dice1 + dice2;

            string guess;
            do
            {
                Console.Write("Bạn đoán tài (T), xỉu (X) hay lục (L)? ");

                guess = Console.ReadLine()!.ToLower();

                if (guess != "t" && guess != "x" && guess != "l")
                {
                    Console.WriteLine("Vui lòng nhập T, X hoặc L.");
                }
                else
                {
                    break;
                }
            } while (true);

            bool isWin = false; 

            bool isSpecial = false; 

            if (guess == "t" && sum > 6)
            {
                isWin = true;
            }
            else if (guess == "x" && sum < 6)
            {
                isWin = true;
            }
            else if (guess == "l" && sum == 6)
            {
                isWin = true;

                isSpecial = true;
            }
            Console.WriteLine($"Kết quả gieo súc sắc: {dice1} + {dice2} = {sum}");

            if (isWin)
            {
                if (isSpecial)
                {
                    soLanDacBiet++;
                    tien += tienDatCuoc * 3;
                    Console.WriteLine($"Bạn thắng đặc biệt! Tổng số tiền hiện tại: {tien} đồng.");
                }
                else
                {
                    tien += tienDatCuoc;
                    Console.WriteLine($"Bạn thắng! Tổng số tiền hiện tại: {tien} đồng.");
                }
            }
            else
            {
                tien -= tienDatCuoc;
                soLanThua++;
                Console.WriteLine($"Bạn thua! Tổng số tiền hiện tại: {tien} đồng.");
            }
            string input;

            do
            {
                Console.WriteLine("Bạn có muốn chơi tiếp không? (C/K): ");

                input = Console.ReadLine()!.ToUpper();

                if (input != "C" && input != "K")
                {
                    Console.WriteLine("Vui long nhap C hoac K: ");
                }
                else
                {
                    break;
                }

            } while (true);

            if (input == "K")
            {
                continuePlaying = false;
            }

        } while (continuePlaying);
      
        Console.WriteLine($"Trò chơi kết thúc!");

        Console.WriteLine($"Tổng số lần chơi: {soLanChoi}");

        Console.WriteLine($"Tổng số lần thắng: {soLanChoi - soLanThua - soLanDacBiet}");

        Console.WriteLine($"Tổng số lần thua: {soLanThua}");

        Console.WriteLine($"Tổng số lần thắng đặc biệt: {soLanDacBiet}");
    }

    static void numberGuessingGame()
    {
        long tien = 1000000;

        int soLanChoi = 0;

        int soLanThang = 0;

        int soLanThua = 0;

        bool continuePlaying = true;

        do
        {
            if (tien <= 0)
            {
                Console.WriteLine("Bạn đã hết sạch tiền vốn! Trò chơi bắt buộc kết thúc");
                break;
            }
            Console.WriteLine("""
               ________                              ___________.__              _______               ___.                 
             /  _____/ __ __   ____   ______ ______ \__    ___/|  |__   ____    \      \  __ __  _____\_ |__   ___________ 
            /   \  ___|  |  \_/ __ \ /  ___//  ___/   |    |   |  |  \_/ __ \   /   |   \|  |  \/     \| __ \_/ __ \_  __ \
            \    \_\  \  |  /\  ___/ \___ \ \___ \    |    |   |   Y  \  ___/  /    |    \  |  /  Y Y  \ \_\ \  ___/|  | \/
             \______  /____/  \___  >____  >____  >   |____|   |___|  /\___  > \____|__  /____/|__|_|  /___  /\___  >__|   
                    \/            \/     \/     \/                  \/     \/          \/            \/    \/     \/        
            """);

            soLanChoi++;

            Console.WriteLine($"Bạn đang có {tien:#,##0} VNĐ");

            Console.Write("Bạn đặt cược bao nhiêu: ");

            long tienDatCuoc = 0;

            do
            {
                bool nhapSoTien = long.TryParse(Console.ReadLine()!, out long ketQuaTienCuoc);

                if (nhapSoTien && ketQuaTienCuoc > 0 && ketQuaTienCuoc <= tien)
                {
                    tienDatCuoc = ketQuaTienCuoc;
                    break;
                }
                else
                {
                    Console.WriteLine($"Số tiền đặt cược không hợp lệ. \nSố tiền đặt cược không được vượt quá số tiền hiện có {tien}. Hoặc trên 0 đồng hãy thử lại!");

                    Console.Write("Bạn đặt cược bao nhiêu: ");
                }
            } while (true);

            Console.WriteLine("Chọn chế độ (Dễ - 1 / Trung bình - 2 / Khó - 3): ");

            int soLanDoan;

            do
            {
                bool chonCheDo = int.TryParse(Console.ReadLine()!, out int ketQuaCheDo);

                if (chonCheDo && ketQuaCheDo == 1)
                {
                    soLanDoan = 9;
                    break;

                } else if (chonCheDo && ketQuaCheDo == 2)
                {
                    soLanDoan = 6;
                    break;

                } else if (chonCheDo && ketQuaCheDo == 3)
                {
                    soLanDoan = 4;
                    break;

                } else
                {
                    Console.Write("Bạn nhập sai rồi, hãy nhập lại (Dễ - 1 / Trung bình - 2 / Khó - 3)");
                }


            } while (true);

            Random rand = new Random();

            int ngauNhien = rand.Next(1, 101);

            bool isWin = false;

            Console.WriteLine($"Bạn có {soLanDoan} lần đoán số");

            for (int i = 1; i <= soLanDoan; i ++)
            {
                Console.Write($"Lần đoán {i}/{soLanDoan}. Nhập số bạn đoán: ");

                int guess;

                do
                {
                    bool doan = int.TryParse(Console.ReadLine()!, out int result);

                    if (doan && result >= 1 && result <= 100)
                    {
                        guess = result;
                        break;

                    }
                    else
                    {
                        Console.WriteLine("Vui lòng chọn số chính xác từ 1 đến 100");

                        Console.Write("Hãy nhập lại: ");
                    }
                } while (true);

                if (guess == ngauNhien)
                {
                    isWin = true;
                    break;
                } else if (guess > ngauNhien)
                {
                    Console.WriteLine("Số bạn đoán quá lớn");

                } else
                {
                    Console.WriteLine("Số bạn đoán quá nhỏ");
                }
            }
                
            if (soLanDoan == 9)
            {
                if (isWin)
                {
                    soLanThang++;
                    tien += tienDatCuoc / 2;
                    Console.WriteLine($"Bạn thắng! Tổng số tiền hiện tại: {tien} đồng.");

                }
                else
                {
                    soLanThua++;
                    tien -= tienDatCuoc / 2;
                    Console.WriteLine($"Bạn đã thua! Tổng số tiền hiện tại: {tien} đồng.");
                }
            } else if (soLanDoan == 6)
            {
                if (isWin)
                {
                    soLanThang++;
                    tien += tienDatCuoc;
                    Console.WriteLine($"Bạn thắng! Tổng số tiền hiện tại: {tien} đồng.");

                }
                else
                {
                    soLanThua++;
                    tien -= tienDatCuoc;
                    Console.WriteLine($"Bạn đã thua! Tổng số tiền hiện tại: {tien} đồng.");
                }
            } else
            {
                if (isWin)
                {
                    soLanThang++;
                    tien += tienDatCuoc * 3;
                    Console.WriteLine($"Bạn thắng! Tổng số tiền hiện tại: {tien} đồng.");

                }
                else
                {
                    soLanThua++;
                    tien -= tienDatCuoc * 3;
                    Console.WriteLine($"Bạn đã thua! Tổng số tiền hiện tại: {tien} đồng.");
                }
            }

            string input;

            do
            {
                Console.WriteLine("Bạn có muốn chơi tiếp không? (C/K): ");

                input = Console.ReadLine()!.ToUpper();

                if (input != "C" && input != "K")
                {
                    Console.WriteLine("Vui long nhap C hoac K: ");
                }
                else
                {
                    break;
                }

            } while (true);

            if (input == "K")
            {
                continuePlaying = false;
            }

        } while (continuePlaying);

        Console.WriteLine($"Trò chơi kết thúc!");

        Console.WriteLine($"Tổng số lần chơi: {soLanChoi}");

        Console.WriteLine($"Tổng số lần thắng: {soLanChoi - soLanThua}");

        Console.WriteLine($"Tổng số lần thua: {soLanThua}");
    }
    public static void Baitap02()
    {
        Console.Write("Nhập số tự nhiên n:");

        int n = int.Parse(Console.ReadLine()!);

        if (n <= 0)
        {
            Console.WriteLine($"{n} không phải là perfect number");
            return;
        }

        int tong = 0;

        for (int i = 1; i <= n / 2; i++)
        {
            if (n % i == 0)
            {
                tong += i;
            }
        }

        if (tong == n)
        {
            Console.WriteLine($"{n} là perfect number");

        }
        else
        {
            Console.WriteLine($"{n} không phải là perfect number");
        }
    }

    public static void Baitap03()
    {
        Console.Write("Nhập số tự nhiên n:");

        int n = int.Parse(Console.ReadLine()!);

        bool songuyento = true;

        if (n < 2)
        {
            songuyento = false;
        }

        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                songuyento = false;
                break;
            }
        }
        if (songuyento)
        {
            Console.WriteLine($"{n} là số nguyên tố");

        }
        else
        {
            Console.WriteLine($"{n} không phải là số nguyên tố");
        }

    }

    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        //Baitap01();

        //numberGuessingGame();

        //Baitap02();

        //Baitap03();
    }
}