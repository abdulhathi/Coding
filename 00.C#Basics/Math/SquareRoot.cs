using System;

public class SquareRoot {
    public SquareRoot() {
        Console.WriteLine(-10 * -20);
        Console.WriteLine(Math.Sqrt(12));
        SqureValues(48);
    }
    public void SqureValues(int n) {
        for(int i = 0; i <= n; i++) {
            var sqrt = Math.Sqrt(i);
            // if(Math.Ceiling(sqrt) == Math.Floor(sqrt))
                Console.WriteLine($"{i} - square root : {Math.Ceiling(sqrt)}");
        }
    }
}