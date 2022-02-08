using System;

public class TrappingRainWater {
    public TrappingRainWater() {
        int trapedWater = Trap(new int[] {0,1,0,2,1,0,1,3,2,1,2,1});
        Console.WriteLine(trapedWater);
    }
     public int Trap(int[] height) {
         int left = 1, right = height.Length - 2;
         int leftMax = height[0], rightMax = height[height.Length - 1];
         int sum = 0;
         while(left <= right) {
             if(leftMax <= rightMax) {
                 leftMax = Math.Max(leftMax, height[left]);
                 sum += leftMax - height[left];
                 left++;
             }
             else {
                 rightMax = Math.Max(rightMax, height[right]);
                 sum += rightMax - height[right];
                 right--;
             }
         }
         return sum;
     }
}