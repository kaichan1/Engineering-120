namespace BigO
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//int[] arr = { 0, 1, 2, 3 };
			//var result = Contains(arr, 3);
			////O(n)
			//var resultWorst = Contains(arr, 3);
			//var resultBest = Contains(arr, 0);

			Console.WriteLine(SumRecursive(5)); //A
		}

		public static int SumRecursive(int n)
		{
			if (n == 0) return 0;
			int prev = SumRecursive(n - 1); //B
			int sum = n + prev;
			return sum;
		}
		public static int SumLoop(int n)
		{
			int sum = 0;
			for (int i = 0; i <= n; i++)
			{
				sum += i;
			}
			return sum;
		}
		public static bool Contains(int[] arr, int num)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				return arr[i] == num;
			}
			return false;
		}
	}
}

		


