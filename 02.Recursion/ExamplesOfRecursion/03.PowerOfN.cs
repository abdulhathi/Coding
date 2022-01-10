using System;

public class PowerOfN {
    public static int Power(int m, int n) {
        if(n == 0) 
            return 1;
        return Power(m, n-1) * m;
    }

    // 2 * 2 = 4 * 2 = 8 * 2 = 16 * 2 = 32 * 2 = 64 * 2 = 128 * 2 = 256 * 2 = 512
    /*                  
                        P(2,9)  ==> 512
                        /
                      P(4,4) * 2   ==> 256 * 2 ==> 512 
                      /
                    P(16,2) ==> 256
                    /
                  P(256,1)  ==> 256
                  /
                P(256*256,0) * 256 ==> 1 * 256      
                /
               --> 1 
    */
    public static int Power_New(int m, int n) {
        if(n == 0)
            return 1;
        if(n % 2 == 0)
            return Power_New(m*m, n/2);
        else
            return Power_New(m*m, (n-1)/2) * m;
    }
}