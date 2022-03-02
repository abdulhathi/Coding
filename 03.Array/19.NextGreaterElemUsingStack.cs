using System;

/*  Array : 5, 3, 2, 10, 6, 8 ,1, 4, 12, 7, 4                                 |  -  |
    Next greater element in this array.                                       |  4  | 
                      13 |                          __                        |  8  |       1.Pop()  2   -> 10
                      12 |                         |  |                       | 10  |       2.Pop()  3   -> 10
                      11 |           __            |  |                       |  -  |       3.Pop()  5   -> 10
    5   -> 10         10 |          |  |           |  |                       |  1  |       4.Push() 10 
    3   -> 10          9 |          |  |   __      |  |                       |  8  |       5.Push() 6   
    2   -> 10          8 |          |  |  |  |     |  |__                     | 10  |       6.Pop()  6   -> 8 
    10  -> 12          7 |          |  |__|  |     |  |  |                    |  -  |       7.Push() 8             
    6   -> 8           6 |  __      |  |  |  |     |  |  |                    |  6  |       8.Push() 1 
    8   -> 12          5 | |  |     |  |  |  |   __|  |  |__                  | 10  |       9.Pop()  1   -> 4
    1   -> 4           4 | |  |__   |  |  |  |  |  |  |  |  |                 |  -  |      10.Push() 4 
    4   -> 12          3 | |  |  |__|  |  |  |  |  |  |  |  |                 |  2  |      11.Pop()  4   -> 12  
    12  -> null        2 | |  |  |  |  |  |  |__|  |  |  |  |                 |  3  |      12.Pop()  8   -> 12
    7   -> null        1 | |  |  |  |  |  |  |  |  |  |  |  |                 |  5  |      13.Pop() 10   -> 12  
    4   -> null     -------------------------------------------------         -------    
                            5  3  2  10  6  8 1  4  12 7  4                    Stack
    
    int LastGreaterElem = 5, nextGreaterElem = 10
    When Pop() Formula is below. 
    if(nextGreaterElem > lastGreaterElem) 
        Sum += Math.Min(lastGreaterElem, nextGreaterElem) - stack.Pop();
    else
        Sum += Math.Min(lastGreaterElem, nextGreaterElem) - stack.Pop();
*/
public class NextGreaterElemUsingStack {
    public NextGreaterElemUsingStack() {
        FindNextGreaterElemUsingStack(new int[] {4,2,0,3,2,5});
        //{0,1,0,2,1,0,1,3,2,1,2,1});
        //{5, 3, 2, 10, 6, 8 ,1, 4, 12, 7, 4});
        int freeArea = FindMaxNonHistogramArea(new int[] {4,2,0,3,2,5});
        Console.WriteLine(freeArea);
    }
    public void FindNextGreaterElemUsingStack(int[] histogram) {
        int sum = 0;
        Stack<int> stack = new Stack<int>();
        Dictionary<int, int> nextGreaterElemMap = new Dictionary<int, int>();
        Dictionary<int, int> lastGreaterElemMap = new Dictionary<int, int>();
        stack.Push(0);
        nextGreaterElemMap.Add(0, 0);
        lastGreaterElemMap.Add(0, 0);
        for(int i = 1; i < histogram.Length; i++) {
            nextGreaterElemMap.Add(i, i);
            lastGreaterElemMap.Add(i, histogram[lastGreaterElemMap[i-1]] > histogram[i] ? lastGreaterElemMap[i-1] : i);
            while(stack.Count > 0 && histogram[i] > histogram[stack.Peek()])
                nextGreaterElemMap[stack.Pop()] = i;
            stack.Push(i);
        }
        for(int i = 0; i < histogram.Length; i++) {
            int x = histogram[FindParent(nextGreaterElemMap[i])], y = histogram[lastGreaterElemMap[i]];
            sum += Convert.ToInt32(Math.Abs(Math.Min(x,y) - histogram[i]));
        }
        Console.WriteLine(sum);

        int FindParent(int key) {
            if(nextGreaterElemMap[key] == key)
                return key;
            nextGreaterElemMap[key] = FindParent(nextGreaterElemMap[key]);
            return nextGreaterElemMap[key];
        }
    }

    public int FindMaxNonHistogramArea(int[] histogram) {
        //next greater element map
        var nge = new Dictionary<int, int>();
        //last greater element map
        var lge = new Dictionary<int, int>();
        var stack = new Stack<int>();
        int freeArea = 0;
        // Find the next greater element value from the forward direction
        for(int i = 0; i < histogram.Length; i++) {
            nge.Add(i, i);
            while(stack.Count > 0 && histogram[stack.Peek()] < histogram[i]) {
                nge[stack.Pop()] = i;
            }
            stack.Push(i);
        }

        // Find the last greater element value from the reverse direction
        stack = new Stack<int>();
        for(int i = histogram.Length-1; i >= 0; i--) {
            lge.Add(i, i);
            while(stack.Count > 0 && histogram[stack.Peek()] < histogram[i]) {
                lge[stack.Pop()] = i;
            }
            stack.Push(i);
        }
        // Find the non histogram maximum area
        for(int i = 0; i < histogram.Length; i++) {
            freeArea += Math.Abs(Math.Min(FindParentValue(i,nge), FindParentValue(i,lge)) - histogram[i]);
        }
        return freeArea;

        int FindParentValue(int child, Dictionary<int, int> map) {
            return histogram[FindParent(child, map)];
        }
        int FindParent(int child, Dictionary<int, int> map) {
            if(child == map[child])
                return map[child];
            map[child] = FindParent(map[child], map);
            return map[child];
        }
    }
}