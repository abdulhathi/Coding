public class SymmetricMatrix {
    int[] symmMatrix = null;
    public SymmetricMatrix() {
        symmMatrix = new int[5];
        Add(0,0,2);
        PrintMatrix();
    }
    public void Add(int row, int col, int val) {
        if(row > col)
            symmMatrix[col] = val;
        else
            symmMatrix[row] = val;
    }
    public int Find(int row, int col) {
        return row > col ? symmMatrix[col] : symmMatrix[row]; 
    }
    public void PrintMatrix() {
        for(int r = 0; r < symmMatrix.Length; r++) {
            for(int c = 0; c < symmMatrix.Length; c++)
                Console.Write(Find(r,c)+" ");
            Console.WriteLine();
        }
    }
}