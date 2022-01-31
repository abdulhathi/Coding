using System;
using System.Collections.Generic;

public class DictionaryTest {
    public DictionaryTest() {
        var dictionary = new Dictionary<char, (int id, string name)>();

        dictionary.Add('A' , (1,"Abdul"));
        dictionary.Add('B' , (1,"Abdul"));
        dictionary.Add('C' , (1,"Abdul"));
        dictionary.Add('D' , (1,"Abdul"));

        foreach(var kvp in dictionary)
            Console.WriteLine(kvp.Value);

        dictionary['B'] = (2, "Aysha");

        foreach(var kvp in dictionary)
            Console.WriteLine(kvp.Value);
    }
}