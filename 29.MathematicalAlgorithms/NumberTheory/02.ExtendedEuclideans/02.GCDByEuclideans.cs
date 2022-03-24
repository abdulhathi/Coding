// Greatest Common Divisor
public class GCDByEuclideans {
    public GCDByEuclideans() {
        Console.WriteLine(GCDByEuclidean(8,20));
    }
    // Optimized approach
    // Max(m,n) value % by Min(m,n) value. Now m = Min(m,n) , n = reminder of the mod operation.
    // Repeat this until reminder is 0. When reminder is 0 then last Min value is the GCD
    public int GCDByEuclidean(int m, int n) {
        if(n == 0)
            return m;
        return GCDByEuclidean(Math.Min(m,n), Math.Max(m,n) % Math.Min(m,n));
    }
}