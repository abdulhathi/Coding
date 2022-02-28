using System;

public class MatrixExponentiation {
    public MatrixExponentiation() {
        int[,] mA = { {1, 1}, {1, 0} };
        int[,] result = GetMatrixExponentiation(mA, 13);
        int n = mA.GetLength(0);
        for(int r = 0; r < n; r++) {
            for(int c = 0; c < n; c++) {
                Console.Write(result[r,c]+" ");
            }
            Console.WriteLine();
        }
    }
    public int[,] GetMatrixExponentiation(int[,] mA, int n) {
        int[,] resultM = null;
        while(n > 0) {
            if((n & 1) == 1) {
                resultM = resultM == null ? mA : MultiplyMatrices(resultM, mA);
            }
            mA = MultiplyMatrices(mA, mA);
            n = n >> 1;
        }

        return resultM;

        int[,] MultiplyMatrices(int[,] mA, int[,] mB) {
            int n = mB.GetLength(0);
            int[,] m = new int[n,n];
            for(int r = 0; r < n; r++) {
                for(int c = 0; c < n; c++) {
                    for(int k = 0; k < n; k++) {
                        m[r,c] += mA[r,k] * mB[k,c];
                    }
                }
            }
            return m;
        }
    }
}