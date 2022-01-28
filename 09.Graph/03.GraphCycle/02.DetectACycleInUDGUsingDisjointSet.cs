using System;

public class DetectACycleInUDGUsingDisjointSet {
    public DetectACycleInUDGUsingDisjointSet() {
        Dictionary <char, char[]> adjList = new Dictionary <char, char[]>();
        adjList.Add('A', new char[] {'B','F'});
        adjList.Add('B', new char[] {'C','E'});
        adjList.Add('C', new char[] {'D'});
        adjList.Add('D', new char[] {'E'});
        adjList.Add('E', new char[] {'B'});
        //adjList.Add('E', new char[0]);
        DisjointSet<char> disjointSet = new DisjointSet<char>();
        foreach(var key in adjList.Keys)
            disjointSet.MakeSet(key);

        bool cycleExist = false;
        foreach(var key in adjList.Keys)
            cycleExist = DetectCycleUsingDisjointSet(key, adjList, disjointSet);
        Console.WriteLine($"Cycle exist is {cycleExist}");
    }
    public bool DetectCycleUsingDisjointSet(char vertexU, Dictionary <char, char[]> adjList, DisjointSet<char> disjointSet) {
        if(adjList.ContainsKey(vertexU)) {
            foreach(var vertexV in adjList[vertexU]) {
                if(!disjointSet.UnionSet(vertexU, vertexV))
                    return true;
                return DetectCycleUsingDisjointSet(vertexV, adjList, disjointSet);
            }
        }
        return false;
    }
}