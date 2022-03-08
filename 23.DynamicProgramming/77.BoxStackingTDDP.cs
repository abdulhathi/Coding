using System;

public class BoxStackingTDDP {
    public BoxStackingTDDP() {
        int[][] boxes = {   new int[] {2,1,2}, new int[] {3,2,3}, 
                            new int[] {2,2,8}, new int[] {2,3,4}, 
                            new int[] {2,2,1}, new int[] {4,4,5} };
        Console.WriteLine(TopDown_BoxStackingMaxHeight(boxes));
    }
    public int TopDown_BoxStackingMaxHeight(int[][] boxes) {
        int[] memory = new int[boxes.Length];
        // Sort the input boxes by height
        boxes = boxes.OrderBy(b => b[2]).ToArray();
        memory[0] = boxes[0][2];

        int max = int.MinValue;
        for(int i = boxes.Length - 1; i >= 1; i--)
            max = Math.Max(TopDown(i), max);
        return max;

        int TopDown(int boxB) {
            if(memory[boxB] != 0)
                return memory[boxB];
           
            for(int boxT = boxB-1; boxT >= 0; boxT--) {
                 if(boxes[boxT][0] < boxes[boxB][0] && boxes[boxT][1] < boxes[boxB][1]) {
                     memory[boxB] = Math.Max(TopDown(boxT), memory[boxB]);
                 }
            }
            memory[boxB] += boxes[boxB][2];
            return memory[boxB];
        }
    }
}