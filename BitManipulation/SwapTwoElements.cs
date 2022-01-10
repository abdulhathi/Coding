using System;

public class SwapTwoElements {
    public void Swap() {
        int x = 2, y = 4;
                   //  X       Y       X      Y       Y      X       X
        x = x ^ y; //(0010 ^ 0100 =>  1001 ^ 0100 => 0010 ^ 1001 => 0100  
        y = x ^ y;
        x = x ^ y;
    }
}