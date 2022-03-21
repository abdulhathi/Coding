using System;

public class RobotRoomCleaner {
    public class Robot {
        public int[][] grid = {
            new int[] {0,1,0},
            new int[] {1,1,1},
            new int[] {0,1,0}
        };
        public int x = 1; public int y = 1;
        public int direction = 0;
        // Returns true if the cell in front is open and robot moves into the cell.
        // Returns false if the cell in front is blocked and robot stays in the current cell.
        public bool Move() {
            if(direction == 0 && (x - 1 < 0 || grid[x-1][y] == 0)) 
                return false;
            else if(direction == 1 && (y + 1 >= grid[0].Length || grid[x][y+1] == 0)) 
                return false;
            else if(direction == 2 && (x + 1 >= grid.Length || grid[x+1][y] == 0))
                return false;
            else if(direction == 3 && (y - 1 < 0 || grid[x][y-1] == 0))
                return false;
            else {
                SwitchDirection();
                return true;
            }
        }
        // Robot will stay in the same cell after calling turnLeft/turnRight.
        // Each turn will be 90 degrees.
        public void TurnLeft() {
            direction--;
        }
        public void TurnRight() {
            direction++;
        }
    
        // Clean the current cell.
        public void Clean(){
            grid[x][y] = 2;
        }
        public void SwitchDirection() {
            switch (direction) {
                case 0:
                    x -= 1;
                    break;
                case 1:
                    y += 1;
                    break;
                case 2:
                    x += 1;
                    break;
                case 3:
                    y -= 1;
                    break;
                default:
                    break;
            }
        }
    }
    public RobotRoomCleaner() {
        Robot robot = new Robot();
        CleanRoom(robot);
    }
     public void CleanRoom(Robot robot) {
        var roomMap = new Dictionary<int, Dictionary<int, bool>>();
        Clean(robot, 0,0);
        
        void Clean(Robot currRobot, int row, int col) {
            currRobot.Clean();
            if(!roomMap.ContainsKey(row))
                roomMap.Add(row, new Dictionary<int, bool>());
            if(!roomMap[row].ContainsKey(col))
                roomMap[row].Add(col, false);
            roomMap[row][col] = true;
            
            if(!IsRoomVisited(row-1, col) && currRobot.Move()) {
                Clean(currRobot, row-1, col);
                GoBack();
            }
            currRobot.TurnRight();
            if(!IsRoomVisited(row, col+1) && currRobot.Move()) {
                currRobot.TurnLeft();
                Clean(currRobot, row, col+1);
                GoBack();
            }
            
            currRobot.TurnRight();
            if(!IsRoomVisited(row+1, col) && currRobot.Move()) {
                currRobot.TurnLeft();
                currRobot.TurnLeft();
                Clean(currRobot, row+1, col);
                GoBack();
            }
            
            currRobot.TurnRight();
            if(!IsRoomVisited(row, col-1) && currRobot.Move()) {
                currRobot.TurnLeft();
                currRobot.TurnLeft();
                currRobot.TurnLeft();
                Clean(currRobot, row, col-1);
                GoBack();
            }
            
            currRobot.TurnRight();
            
            void GoBack() {
                currRobot.Move();
                currRobot.TurnRight();
                currRobot.TurnRight();
            }
        }
        
        bool IsRoomVisited(int row, int col) {
            if(roomMap.ContainsKey(row) && roomMap[row].ContainsKey(col))
                return true;
            return false;
        }
    }
}