public class ExtendedEuclids {
    public ExtendedEuclids() {
        var current = FindXYGCD(6,7);
        Console.WriteLine($"X: {current.X} Y: {current.Y} GCD: {current.GCD}");
    }

    // Ax + By = GCD(A,B)
    // Formula for X = Y1
    // Formula for Y = (X1 - Math.Ceiling(A/B)*Y1)
    public static (int X, int Y, int GCD) FindXYGCD(int A, int B) {
        int x = 1, y = 1;
        if(B == 0) {
            // AX + BY = GCD; AX + 0 = GCD; X = GCD/A;
            int gcd = Math.Max(A, B);
            x = gcd / A;
            y = 0;
            return (x, y, gcd);
        }
        var current = FindXYGCD(B, A%B);
        // Console.WriteLine($"X: {current.X} Y: {current.Y} GCD: {current.GCD}");
        x = current.Y;
        y = current.X - ((A/B) * current.Y);
        return (x, y, current.GCD);
    }
}