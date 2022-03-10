public class ToplitzMatrix {
    int n = 0;
    int[] toplitzMatrix = null;
    public ToplitzMatrix() {
        n = 5;
        toplitzMatrix = new int[(2*n) - 1];
        Add(0,0, 2);
        Add(0,1, 3);
        Add(0,2, 4);
        Add(0,3, 5);
        Add(0,4, 6);
        Add(1,0, 7);
        Add(2,0, 8);
        Add(3,0, 9);
        Add(4,0, 10);
        PrintMatrix();
    }
    public void Add(int row, int col, int val) {
        if(row <= col)
            toplitzMatrix[col - row] = val;
        else
            toplitzMatrix[(n-1)+(row-col)] = val;
    }
    public int Find(int row, int col) {
        return row <= col ? toplitzMatrix[col - row] : toplitzMatrix[(n-1)+(row-col)];
    }
    public void PrintMatrix() {
        for(int r = 0; r < n; r++) {
            for(int c = 0; c < n; c++)
                Console.Write(Find(r,c)+" ");
            Console.WriteLine();
        }
    }
}