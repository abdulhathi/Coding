/*
	8	2	7	3	4	Substract Result
1	1	1	1	1	1	71623
2	1	1	1	1	1	60512
3	1		1	1	1	50401
4	1		1		1	40300
5	1		1			30200
6	1		1			20100
7	1		1			10000
8	1					0
*/

public class PartitioningIntoMinNumOfDeciBinaryNums {
    public PartitioningIntoMinNumOfDeciBinaryNums() {
        int maxPart = MinPartitions("82734");
        Console.WriteLine(maxPart);
    }
    public int MinPartitions(string n) {
        int maxNum = 0;
        foreach(var chr in n)
            if(maxNum < (chr - '0'))
                maxNum = (chr - '0');
        return maxNum;
    }
}