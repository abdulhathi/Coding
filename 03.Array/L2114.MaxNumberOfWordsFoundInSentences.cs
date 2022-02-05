/*  https://leetcode.com/problems/maximum-number-of-words-found-in-sentences/
    A sentence is a list of words that are separated by a single space with no leading or trailing spaces.
    You are given an array of strings sentences, where each sentences[i] represents a single sentence.
    Return the maximum number of words that appear in a single sentence.
*/
public class MaximumNumOfWordsInScentences {
    public MaximumNumOfWordsInScentences() {
        string[] sentences = {"alice and bob love leetcode","i think so too","this is great thanks very much"};
        int maxWords = MostWordsFound(sentences);
        Console.WriteLine($"Maximum words count : {maxWords}");
    }
    public int MostWordsFound(string[] sentences) {
        int maxWords = 0; int wordsCount = 1;
        foreach(var sentence in sentences) {
            for(int i = 0; i < sentence.Length; i++) {
                if(sentence[i] == ' ')
                    wordsCount++;
            }
            if(maxWords < wordsCount)
                maxWords = wordsCount;
            wordsCount = 1;
        }
        return maxWords;
    }
}