using System;

public class MatrixMultiplication {
    public MatrixMultiplication() {
        int[][] matrixA = { 
            new int[] {1, 3},
            new int[] {5, 3}
        };
        int[][] matrixB = { 
            new int[] {3, -2},
            new int[] {-1, 6}
        };
        int[][] result = MutiplyTwoMatrix(matrixA, matrixB);
        foreach(var row in result) {
            Console.WriteLine(string.Join(" ", row));
        }
    }
    public int[][] MutiplyTwoMatrix(int[][] matrixA, int[][] matrixB) {
        int[][] matrix = new int[matrixB.Length][];
        for(int r = 0; r < matrixA.Length; r++) {
            matrix[r] = new int[matrixB.Length];
            for(int c = 0; c < matrixB.Length; c++) {
                for(int k = 0; k < matrixA.Length; k++) {
                    matrix[r][c] += (matrixA[r][k] * matrixB[k][c]);
                }
            }   
        }
        return matrix;
    }
}