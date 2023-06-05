namespace ConsoleApp
{
    internal class Program
    {
        //創建一個Dictionary，使用store來儲存計算過的結果，避免重複跑已經計算的結果。
        static Dictionary<int, long> store = new Dictionary<int, long>();

        //創建計算費式數列和之靜態方法(回傳long)
        static long Fibonacci(int n)
        {
            if (n <= 0)
                return 0;
            else if (n == 1)
                return 1;
            //從Dictionary中來取已經計算好的值。
            if (store.ContainsKey(n))
                return store[n];

            //利用recursive的算法來計算費式數列。
            long result = Fibonacci(n - 1) + Fibonacci(n - 2);

            //將計算好的值存進Dictionary中。
            store[n] = result;

            //回傳。
            return result;
        }

        static void Main(string[] args)
        {
            bool continueState = true;

            while (continueState)
            {
                Console.Write("請輸入要計算費式數列的第幾項：");

                //使用者輸入
                int n = Convert.ToInt32(Console.ReadLine());

                long result = Fibonacci(n);

                Console.WriteLine($"第 {n} 項費式數列為：{result}");


                //是否要再次執行
                Console.WriteLine("是否要再次執行計算？(Y/N)");

                string continueInput = Console.ReadLine();

                if (continueInput.ToUpper() != "Y")
                    continueState = false;

                Console.WriteLine();
            }
        }
    }
}