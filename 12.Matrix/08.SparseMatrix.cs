using System.Collections.Generic;

public class SparseMatrix {
    public SparseMatrix() {
        int[][] sparseMat = { new int[] {0,1,5,0,0},
                    new int[] {0,0,0,2,0},
                    new int[] {0,0,0,0,1},
                    new int[] {8,0,0,0,0},
                    new int[] {0,0,7,0,12},
                    new int[] {0,5,0,0,0},

        };
        PrintDictionaryRep(DictionaryRep(sparseMat));
    }
    public Dictionary<int, Dictionary<int, int>> DictionaryRep(int[][] sparseMat) {
        var sparseMap = new Dictionary<int, Dictionary<int, int>>();
        for(int r = 0; r < sparseMat.Length; r++) {
            if(!sparseMap.ContainsKey(r))
                sparseMap.Add(r, new Dictionary<int, int>());
            for(int c = 0; c < sparseMat[r].Length; c++) {
                if(sparseMat[r][c] != 0) {
                    if(!sparseMap[r].ContainsKey(c))
                        sparseMap[r].Add(c, sparseMat[r][c]);
                }
            }
        }
        return sparseMap;
    }
    public void PrintDictionaryRep(Dictionary<int, Dictionary<int, int>> sparseMap) {
        foreach(var key in sparseMap.Keys) {
            foreach(var val in sparseMap[key])
                Console.WriteLine($"{key} - {val.Key} = {val.Value}");
        }
    }
}