public class DiagnolMatrix {
    int[] diagMatrix = null;
    public DiagnolMatrix() {
        diagMatrix = new int[5];
    }
    public void AddOrUpdate(int row, int col, int val) {
        diagMatrix[row] = val;
    }
    public int Search(int row, int col) {
        return diagMatrix[row];
    }
}