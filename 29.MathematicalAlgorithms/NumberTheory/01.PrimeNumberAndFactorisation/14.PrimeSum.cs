public class PrimeSum {
    public PrimeSum() {
        var result = GetPrimeSum(1048574);
        Console.WriteLine(string.Join(",",result));
    }
    public List<int> GetPrimeSum(int A) {
        HashSet<int> pairPrimeSum = new HashSet<int>();
        bool[] primeSieve = Enumerable.Range(0, A+1).Select(x=>true).ToArray();
        var primes = new HashSet<int>();

        primeSieve[0] = primeSieve[1] = false;
        for(uint i = 2; i <= A; i++) {
            if(primeSieve[i]) {
                primes.Add((int)i);
                for(uint j = i*i; j <= A; j = j + i)
                    primeSieve[j] = false;
            }
        }
        foreach(var prime in primes) {
            if(primes.Contains(Math.Abs(prime-A))) {
                pairPrimeSum.Add(prime);
                pairPrimeSum.Add(Math.Abs(prime-A));
            }
        }
        return pairPrimeSum.OrderBy(x=>x).ToList();
    }
}
