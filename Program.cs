using System;

namespace LearnCSharp.Day4 {
    public class Program {
        public static void Main() {
            Console.WriteLine(String.Join(',', TwoSum(new int[] { 2, 7, 11, 15 }, 9)));
            Console.WriteLine(String.Join(',', TwoSum(new int[] { 3, 2, 4 }, 6)));
            Console.WriteLine(String.Join(',', TwoSum(new int[] { 3, 3 }, 6)));

            Console.WriteLine(String.Join(',', ThreeSum(new int[] { 1, 1, 1, 1, 1 })));
            Console.WriteLine(String.Join(',', ThreeSum(new int[] { -1, -1, -1, 0, 0, 1, 1, 1 })));
            Console.WriteLine(String.Join(',', ThreeSum(new int[] { 3, 3 })));
        }

        public static IList<IList<int>> ThreeSum(int[] nums) {
            Array.Sort(nums);
            int lo, hi;
            IList<IList<int>> res = new List<IList<int>>();
            for (int i = 0; i < nums.Length; i++) {
                // remove duplicate i
                if (i != 0 && nums[i] == nums[i - 1]) continue;
                lo = i + 1;
                hi = nums.Length - 1;
                while (lo < hi) {
                    if (nums[i] + nums[lo] + nums[hi] == 0) {
                        List<int> curr = new List<int>();
                        curr.Add(nums[i]);
                        curr.Add(nums[lo]);
                        curr.Add(nums[hi]);
                        res.Add(curr);
                        // remove duplicate lo & hi
                        while (lo < hi && nums[lo] == nums[lo + 1]) lo++;
                        while (lo < hi && nums[hi] == nums[hi - 1]) hi--;
                        lo++;
                        hi--;
                    } else if (nums[i] + nums[lo] + nums[hi] < 0) lo++;
                    else hi--;
                }
            }
            return res;
        }

        public static int[] TwoSum(int[] nums, int target) {
            Dictionary<int, int> numIdxes = new Dictionary<int, int>();
            int[] res = new int[2];
            for (int i = 0; i < nums.Length; i++) {
                int comp = target - nums[i];
                if (numIdxes.ContainsKey(comp)) {
                    return new int[] { i, numIdxes[comp] };
                }
                numIdxes[nums[i]] = i;
            }
            return res;
        }

    }
}

