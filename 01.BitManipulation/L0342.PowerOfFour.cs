using System;

public class PowerOfFour {
    public PowerOfFour() {
        /*  1       000000000001 (0)
            4       000000000100 (2)
            16      000000010000 (4)
            64      000001000000 (6)
            256     000100000000 (8)
            1024    010000000000 (10)
        */
        Console.WriteLine(IsPowerOfFour(8));
    }
    public bool IsPowerOfFour(int n) {
        return IsPowerOfFour_AndWithHexDecNum_Method(n);
    }
    
    /* Method 1 : 
        1. Right shift 2 each loop until val is 1 and count number of right shift
        2. Left shift the mask value to counted times
        3. The mask value is each to num then value is power of four.
    */
    public bool IsPowerOfFour_ShiftMethod(int n) {
        if(n < 1)
            return false;
        int mask = n, count = 0;
        while(mask > 1) {
            mask = mask >> 2;
            count += 2;
        }
        mask = mask << count;
        return n == mask;
    }
    /* Method 2 :
        Check the number is power of 2 and modulo the number with 3 to get 1 then true else false
    */
    public bool IsPowerOfFour_ModuloMethod(int n) {
        
        return (n > 0) && ((n & n-1) == 0) && (n % 3 == 1);
    }
    /* Method 3 :
        Check the number is power of 2 and & the num with 0xaaaaaaaa (1010101010) this hexadeciaml number to get the 0 then its true else false
    */
    public bool IsPowerOfFour_AndWithHexDecNum_Method(int n) {
        return (n > 0) && ((n & n-1) == 0) && ((n & 0xaaaaaaaa) == 0);
    }
}