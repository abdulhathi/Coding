using System;

public class FindDuplicateNums {
    int[] arr = {3,6,8,8,10,12,15,15,15,20,20,20};
    public FindDuplicateNums() {
        FindDuplicate();
        FindingDuplicate();
    }
    public void FindDuplicate() {
        int num = arr[0], count = 1;
        for(int i = 1; i < arr.Length; i++) {
            if(num == arr[i])
                count++;
            else if(count > 1) {
                Console.WriteLine($"{num} found in {count} times.");
                count = 1;
            }
            num = arr[i];
        }
        if(count > 1) {
            Console.WriteLine($"{num} found in {count} times.");
            count = 1;
        }
    }
    public void FindingDuplicate() {
        int j = 0;
        for(int i = 0; i < arr.Length - 1; i++) {
            if(arr[i] == arr[i+1]) {
                j = i + 1;
                while(j < arr.Length && arr[i] == arr[j]) 
                    j++;
                Console.WriteLine($"{arr[i]} apprears {j-i} times.");
                i = j - 1;
            }
        }
    }
}