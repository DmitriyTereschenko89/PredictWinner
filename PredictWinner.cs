namespace PredictWinner
{
	internal class PredictWinner
	{
		private int DFS(int[,] dp, int[] nums, int left, int right)
		{
			if (dp[left, right] != -1)
			{
				return dp[left, right];
			}
			if (left == right)
			{
				return nums[left];
			}
			int scoreLeft = nums[left] - DFS(dp, nums, left + 1, right);
			int scoreRight = nums[right] - DFS(dp, nums, left, right - 1);
			dp[left, right] = Math.Max(scoreLeft, scoreRight);
			return dp[left, right];

		}

		public bool PredictTheWinner(int[] nums)
		{
			int n = nums.Length;
			int[,] dp = new int[n, n];
			for (int i = 0; i < n; ++i)
			{
				for (int j = 0; j < n; ++j)
				{
					dp[i, j] = -1;
				}
			}
			return DFS(dp, nums, 0, n - 1) >= 0;
		}
	}
}
