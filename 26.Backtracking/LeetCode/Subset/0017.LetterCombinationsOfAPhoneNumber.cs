using System;
using System.Collections.Generic;

public class LetterCombinationsOfAPhoneNumber {
    public LetterCombinationsOfAPhoneNumber() {
        var combination = LetterCombinations("23");
        Console.WriteLine(string.Join(",", combination));
    }
    public IList<string> LetterCombinations(string digits) {
        var combinations = new List<string>();
        var newComb = new List<string>();
        
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
       
        foreach(var chr in keyMap[digits[0]])
            combinations.Add(chr.ToString());
        
        for(int i = 1; i < digits.Length; i++) {
            newComb = new List<string>();
            NewCombination(keyMap[digits[i]], 0);
            combinations = newComb;
        }
        return combinations;
        
        void NewCombination(char[] chars, int pos) {
            if(pos < combinations.Count) {
                foreach(var chr in chars) 
                    newComb.Add(combinations[pos] + chr.ToString());
                NewCombination(chars, pos+1);
            }
        }
    }
}