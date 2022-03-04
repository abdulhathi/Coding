using System;

public class RemoveVowelsFromAString {
    public RemoveVowelsFromAString() {
        string result = RemoveVowels("leetcodeisacommunityforcoders");
        Console.WriteLine(result);
    }
    
    public string RemoveVowels(string s) {
        string newStr = "";
        foreach(var chr in s) {
            if(chr == 'a' || chr == 'e' || chr == 'i' || chr == 'o' || chr == 'u')
                continue;
            newStr += chr;
        }
        return newStr;
    }
}