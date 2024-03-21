using System.Diagnostics;

Stopwatch stopwatch = new Stopwatch();

Solution s = new Solution();

int[] nums = {2,7,11,15};
int[] r = {};
int target = 9;

stopwatch.Start();
r = s.TwoSum(nums, target);
Console.WriteLine("Classic Solution");
Console.WriteLine($"[{r[0]},{r[1]}]");
stopwatch.Stop();
Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds} milissegundos");

stopwatch.Reset();
Console.WriteLine();

stopwatch.Start();
Console.WriteLine("Dictionary Solution");
r = s.DictTwoSum(nums, target);
Console.WriteLine($"[{r[0]},{r[1]}]");
stopwatch.Stop();
Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds} milissegundos");



public class Solution {

    /**
    * Classic solution
    **/
    public int[] TwoSum(int[] nums, int target) {
        int[] r = [];
        for(int i = 0; i < nums.Length; i++)
        {
            for(int b = i + 1; b < nums.Length; b++)
            {
                if(nums[i] + nums[b] == target)
                {
                    return [i,b];
                }
            }
        }

        throw new ArgumentException("No solution");
    }

    /**
    * Using Dictionary<>
    */
    public int[] DictTwoSum(int[] nums, int target)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();

        for(int i = 0; i < nums.Length; i++)
        {
            int sub = target - nums[i];

            if (dict.TryGetValue(sub, out var value))
            {
                return [value, i];
            }

            dict.TryAdd(nums[i], i);
        }

        throw new ArgumentException("No solution");
    }
}
