using System;

public class HeightVsNodeInNAryStrictBinaryTree {
    /*
            3 Ary Tree
            ----------
            height = 2

            Min Nodes (7)       Max Nodes(13)
              ()                      ()
            / |  \                 /  |   \ 
          ()  ()  ()             ()   ()    ()    
        / | \                   /|\   /|\   /|\
       () () ()                ()()()()()()()()() 
       node = (h*m)+1             node = (m^(h+1)-1)/(m-1)
    */
    public HeightVsNodeInNAryStrictBinaryTree() {
        Console.WriteLine($"Min node : {FindMinNode(2, 3)}");
        Console.WriteLine($"Max node : {FindMaxNode(2, 3)}");
        Console.WriteLine($"Min height : {FindMinHeight(13, 3)}");
        Console.WriteLine($"Min height : {FindMaxHeight(13, 3)}");
    }
    public int FindMinNode(int height, int noOfAry) {
        // Formula N = (h * noOfAry) + 1
        return (noOfAry*height)+1;
    }
    public int FindMaxNode(int height, int noOfAry) {
        // Formula N = (noOfAry^(h+1) - 1) / (noOfAry-1)
        int x = Convert.ToInt32(Math.Pow(noOfAry, height+1)) - 1;
        int y = noOfAry - 1;
        return x/y;
    }
    public int FindMinHeight(int node, int noOfAry) {
        // Forumla h = log base noOfAry[(n*(noOfAry-1)) + 1] - 1
        int x = (node * (noOfAry - 1)) + 1;
        x = Convert.ToInt32(Math.Log(x,noOfAry)) - 1;
        return x;
    }
    public int FindMaxHeight(int node, int noOfAry) {
        // Forumla h = (n-1)/noOfAry
        return (node-1)/noOfAry;
    }
}