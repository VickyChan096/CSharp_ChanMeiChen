namespace NumberGuessing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TODO:
            // 1. 產生一個祕密數字
            // 2. 初始化範圍 (0, 99)
            // 3. 提示使用者猜測
            // 4. 驗證輸入：有效整數/範圍內，無效或超出提示重猜
            // 5. 判斷猜測結果：
            //   - 等於秘密數字顯示 bingo
            //   - 小於秘密數字，修改下限為猜測數字 + 1
            //   - 大於秘密數字，修改上限為猜測數字 - 1
            // 6. 顯示更新的有效範圍
            // 7. 遊戲結束：
            //   - 猜對數字，獲勝
            //   - 沒數字可猜，失敗

            // Solution:
            // 1.
            // 建立一個 Random 物件，生成隨機數
            Random random = new Random();
            // 產生一個 0-99 的隨機整數作為秘密數字
            // random.Next(minValue, maxValue) 會生成一個大於等於 minValue 但小於 maxValue 的數字
            // 所以這裡輸入 100 會產生 0 到 99
            int secretNumber = random.Next(0, 100);

            // 2.
            // 初始化範圍
            int lowerBound = 0;
            int upperBound = 99;

            // 3-4.
            while (lowerBound <= upperBound)
            {
                // 3.提示使用者猜測
                Console.WriteLine($"目前猜測範圍是({lowerBound}, {upperBound})");

                // 4.
                // 初始化輸入
                int guess = 0;
                bool isValidInput = false;

                while (!isValidInput)
                {
                    Console.Write("請輸入你的猜測數字");
                    string input = Console.ReadLine();

                    // 驗證輸入是否為有效整數
                    if (!int.TryParse(input, out guess))
                    {
                        Console.WriteLine("輸入無效，請輸入一個整數");
                        continue;
                    }

                    // 驗證輸入是否在範圍內
                    if (guess < lowerBound || guess > upperBound)
                    {
                        Console.WriteLine("錯誤，超出範圍");
                        continue;
                    }

                    isValidInput = true;

                }

                if (guess == secretNumber)
                {
                    Console.WriteLine("bingo! 你猜對了！");
                    break; 
                }
                else if (guess < secretNumber)
                {
                    lowerBound = guess + 1;
                }
                else 
                {
                    upperBound = guess - 1;
                }

                Console.WriteLine("-----------------------------------------");

                if (lowerBound == upperBound)
                {
                    Console.WriteLine($"你輸了，答案是{secretNumber}");
                    break;
                }
            }
        }
    }
}
