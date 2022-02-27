using System;
using System.Collections.Generic;

public class TravelingSalesMan {
    public TravelingSalesMan() {
        int[][] costAdjMatrix = { 
            new int[] {0,20,45,25},
            new int[] {20,0,30,34},
            new int[] {42,30,0,10},
            new int[] {25,34,10,0},
        };
        int minCost = TSM_Recursion(costAdjMatrix, 0);
        Console.WriteLine(minCost);
    }
    public int TSM_Recursion(int[][] costAdjMatrix, int source) {
        int noOfCity = costAdjMatrix.Length;
        var memoization = new Dictionary<int, Dictionary<int, int>>();   
        for(int i = 0; i < (1<<(noOfCity-1)); i++)
            memoization.Add(i, new Dictionary<int, int>());
        
        return TSM(1, source);

        int TSM(int visitedCities, int city) {
            if(visitedCities == (1 << noOfCity)-1)
                return costAdjMatrix[city][source];
            if(memoization[visitedCities].ContainsKey(city))
                return memoization[visitedCities][city];

            int minCost = int.MaxValue;
            for(int i = 0; i < noOfCity; i++) {
                if((visitedCities & (1 << i)) > 0)
                    continue;
                int cost = costAdjMatrix[city][i] + TSM((visitedCities | (1 << i)), i);
                minCost = Math.Min(cost, minCost);
            }
            if(!memoization[visitedCities].ContainsKey(city))
                memoization[visitedCities].Add(city, 0);
            memoization[visitedCities][city] = minCost;
            return minCost;
        }
    }
    public void TSM_Problem() {

    }
}