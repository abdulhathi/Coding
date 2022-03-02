using System;

public class GrayCode {
    public GrayCode() {
        var grayCodeList = GraySimilarCode(4);
        Console.WriteLine(string.Join(",", grayCodeList));
    }
    public List<int> GraySimilarCode(int n) {
        int max = 1;
        List<int> grayCodeList = new List<int>() {0};
        while(max <= ((1 << n) - 1)) {
            for(int i = grayCodeList.Count - 1, j = max; i >= 0; i--) {
                max = Math.Max(max, (grayCodeList[i] | j));
                grayCodeList.Add((grayCodeList[i] | j));
            }
            max = max + 1;
        }
        return grayCodeList;
    }
}