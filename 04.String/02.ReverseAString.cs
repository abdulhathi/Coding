using System;

public class ReverseAString {
    public static void Run() {
        Console.WriteLine("Reverse chars : "); Reverse("ABDULHATHI");
         Console.WriteLine("Reverse without special chars : "); ReverseWithSpecialChars("Ab,c,de!$");
    }
    public static void Reverse(string str) {
        char[] chars = str.ToCharArray();
        for(int i = 0, j = chars.Length-1; i < j; i++, j--) {
            var temp = chars[i];
            chars[i] = chars[j];
            chars[j] = temp;
        }
        Console.WriteLine(chars);
    }
    public static void ReverseWithSpecialChars(string str) {
        char[] chars = str.ToCharArray();
        int i = 0, j = chars.Length-1;
        while(i < j) {
            while(!IsLetter(chars[i]))
                i++;
            while(!IsLetter(chars[j]))
                j--;
            if(i < j) {
                var temp = chars[i];
                chars[i] = chars[j];
                chars[j] = temp;
                i++; j--;
            }
        }
        Console.WriteLine(chars);
    }
    public static bool IsLetter(char c)
    {
        return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
    }
}