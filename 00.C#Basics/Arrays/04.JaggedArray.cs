using System;

public class JaggedArray {
    public JaggedArray() {
        int[][] jArray = new int[4][];

        for(int i = 0; i < 4; i++) {
            jArray[i] = new int[4];
            for(int j = 0; j < 4; j++) {
                jArray[i][j] = new Random().Next(0,4);
            }
        }
        Console.WriteLine(jArray.Length);
        Console.WriteLine(jArray[0].Length);
        foreach(var row in jArray)
            Console.WriteLine(string.Join(",", row));
    }
}