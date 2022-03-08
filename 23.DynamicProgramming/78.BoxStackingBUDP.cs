using System;

public class BoxStackingBUDP {
    public BoxStackingBUDP() {
        int[][] boxes = {   new int[] {2,1,2}, new int[] {3,2,3}, 
                            new int[] {2,2,8}, new int[] {2,3,4}, 
                            new int[] {2,2,1}, new int[] {4,4,5} };
        Console.WriteLine(BottomUp_BoxStackingMaxHeight(boxes));
    }
    public int BottomUp_BoxStackingMaxHeight(int[][] boxes) {
        // Sort the boxes by box height
        boxes = boxes.OrderBy(b => b[2]).ToArray();

        int[] tabulation = boxes.Select(x => x[2]).ToArray();
        
        int max = int.MinValue;
        for(int boxB = 1; boxB < boxes.Length; boxB++) {
            for(int boxT = boxB - 1; boxT >= 0; boxT--) {
                // Checking the width and Depth should max in boxB compare with boxT
                if(boxes[boxB][0] > boxes[boxT][0] && boxes[boxB][1] > boxes[boxT][1]) {
                    tabulation[boxB] = Math.Max(tabulation[boxT] + boxes[boxB][2], tabulation[boxB]);
                }
            }
            max = Math.Max(tabulation[boxB], max);
        }
        return max;
    }
}