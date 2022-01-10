using System;

public class UpperToLowerCase {
    public static void ConvertUpperToLower() {
        for(int ch = 'A'; ch <= 'Z'; ch++)
            Console.Write($"{(char)(ch ^ ' ')} ");

        // Console.WriteLine((char)('A' ^ ' ')); 
    }
}