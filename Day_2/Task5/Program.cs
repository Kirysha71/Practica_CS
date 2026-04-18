namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            int[][] arr = new int[][]
            {
                new int[] { 1, 3, 5, 7, 9 },
                new int[] { 2, 4, 6, 8 },
                new int[] { 10, 12, 14, 16, 18 }
            };

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }

            int[] currentArray = arr[1];
            int target = 6;

            int left = 0;
            int right = currentArray.Length - 1;
            int foundIndex = -1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (currentArray[mid] == target)
                {
                    foundIndex = mid;
                    break;
                }
                else if (currentArray[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            if (foundIndex != -1)
            {
                Console.WriteLine($"Число {target} найдено тут - {foundIndex}");
            }
            else
            {
                Console.WriteLine($"Число {target} не найдено");
            }
        }
    }
}
