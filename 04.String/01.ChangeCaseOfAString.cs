using System;

public class ChangeCaseOfAString {
    public static void ChangeCase() {
        char[] str = "ABDULHATHI".ToCharArray();
        for(int i = 0; i < str.Length; i++)
            str[i] = (char)(str[i] ^ ' ');
        Console.WriteLine(str);
    }
}