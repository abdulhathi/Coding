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