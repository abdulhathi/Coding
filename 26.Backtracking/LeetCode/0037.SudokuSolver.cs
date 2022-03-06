/*
 * @lc app=leetcode id=37 lang=csharp
 *
 * [37] Sudoku Solver
 */

// @lc code=start
public class SudokuSolver {
    public SudokuSolver() {
        char[][] board = { 
            new char[] {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
            new char[] {'6', '.', '.', '1', '9', '5', '.', '.', '.'}, 
            new char[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'}, 
            new char[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'}, 
            new char[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'}, 
            new char[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'}, 
            new char[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'}, 
            new char[] {'.', '.', '.', '4', '1', '9', '.', '.', '5'}, 
            new char[] {'.', '.', '.', '.', '8', '.', '.', '7', '9'}
        };
        SolveSudoku(board);
        foreach(var row in board)
            Console.WriteLine(string.Join(",",row));
    }
    /*  c = Column , r = Row
        Forumula to find the 9 cell = c/3 + (r - (r % 3))   */
    public void SolveSudoku(char[][] board) {
        char[][] updatedBoard = new char[board.Length][];
        var rowMap = new Dictionary<int, HashSet<char>>();
        var colMap = new Dictionary<int, HashSet<char>>();
        var nineCellMap = new Dictionary<int, HashSet<char>>();

        for(int r = 0; r < board.Length; r++) {
            rowMap.Add(r, new HashSet<char>());
            for(int c = 0; c < board[r].Length; c++) {
                int nineCellKey = (c/3 + (r - (r % 3)));
                if(!colMap.ContainsKey(c))
                    colMap.Add(c, new HashSet<char>());

                if(!nineCellMap.ContainsKey(nineCellKey))
                    nineCellMap.Add(nineCellKey, new HashSet<char>());

                if(board[r][c] != '.') {
                    char chr = board[r][c];
                    rowMap[r].Add(chr);
                    nineCellMap[nineCellKey].Add(chr);
                    colMap[c].Add(chr);
                }
            }
        }

        DFS(0, 0);
        Swap(updatedBoard, board);

        void DFS(int r, int col) {
            if(r == 9) {
                Swap(board, updatedBoard);
                return;
            }
            else {
                int c = col % 9;
                if(board[r][c] != '.') {
                    DFS(col/9, col+1);
                    return;
                }
                for(int t = 49; t < 58; t++) {
                    int nineCellKey = (c/3 + (r - (r % 3)));
                    char k = (char)t;

                    if(rowMap[r].Contains(k) || colMap[c].Contains(k) || nineCellMap[nineCellKey].Contains(k)) 
                        continue;

                    board[r][c] = k;
                    rowMap[r].Add(k);
                    colMap[c].Add(k);
                    nineCellMap[nineCellKey].Add(k);
                    DFS(col/9, col+1);
                    board[r][c] = '.';
                    rowMap[r].Remove(k);
                    colMap[c].Remove(k);
                    nineCellMap[nineCellKey].Remove(k);
                }
            }
        }
        
        void Swap(char[][] boardA, char[][] boardB) {
            for(int i = 0; i < boardA.Length; i++) {
                boardB[i] = new char[boardA[i].Length];
                for(int j = 0; j < boardA[i].Length; j++)
                    boardB[i][j] = boardA[i][j];
            }
        }
    }
}
// @lc code=end

