using System;
using System.Text;
using System.Collections.Generic;

public class LetterCombinationsOfAPhoneNumber {
    public LetterCombinationsOfAPhoneNumber() {
        var combination = LetterCombinations("23");
        Console.WriteLine(string.Join(",", combination));
    }
    
    public IList<string> LetterCombinations(string digits) {
        var combinations = new List<string>();
        StringBuilder oneComb = new StringBuilder();
        if(string.IsNullOrEmpty(digits))
            return combinations;
        var keyMap = new Dictionary<char, char[]> {
            { '2', "abc".ToCharArray() },
            { '3', "def".ToCharArray() },
            { '4', "ghi".ToCharArray() },
            { '5', "jkl".ToCharArray() },
            { '6', "mno".ToCharArray() },
            { '7', "pqrs".ToCharArray() },
            { '8', "tuv".ToCharArray() },
            { '9', "wxyz".ToCharArray() }
        };

        BackTracking(0);
        return combinations;

        void BackTracking(int pos) {
            if(pos == digits.Length)
                combinations.Add(oneComb.ToString());
            else {
                foreach(var chr in keyMap[digits[pos]]) {
                    oneComb.Append(chr);
                    BackTracking(pos+1);
                    oneComb.Remove(oneComb.Length-1,1);
                }
            }
        }
    }
}