using System;
using System.Collections.Generic;

namespace Minimum_Cost_Tree_From_Leaf_Values
{
  class Program
  {
    static void Main(string[] args)
    {
      var arr = new int[] { 6, 2, 4 }; // 4, 3, 2, 1, 5
      Solution s = new Solution();
      var answer = s.MctFromLeafValues(arr);
      Console.WriteLine(answer);
    }
  }

  public class Solution
  {
    public int MctFromLeafValues(int[] arr)
    {
      int res = 0;
      Stack<int> stk = new Stack<int>();
      foreach (int i in arr)
      {
        while (stk.Count > 0 && stk.Peek() <= i)
        {
          // found a valley
          int mid = stk.Pop();
          if (stk.Count == 0)
          {
            res += mid * i;
            continue;
          }
          // as we found the valley. so valley of left is stack top node as in previous step we did pop and right of valley is the current node in the loop
          int left = stk.Peek();
          int right = i;
          res += mid * Math.Min(left, right);
        }

        stk.Push(i);
      }

      while(stk.Count > 1)
      {
        // pop first and then peek very much importatnt
        res += stk.Pop() * stk.Peek();
      }

      return res;
    }
  }
}
