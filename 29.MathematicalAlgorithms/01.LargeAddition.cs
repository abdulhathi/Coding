using System;

public class LargeAddition {
    /*      str1 = "135" str2 = "15"
        carry     1
                5 3 1
                5 1
                -----
                0 5 1
                _____
    */
    public LargeAddition() { 
        string str1 = "3333311111111111", str2 = "44422222221111";
        // string str1 = "135", str2 = "15";
        string sum = LargeAdditionFromString(str1, str2);
        Console.WriteLine(sum);
    }
    public string LargeAdditionFromString(string str1, string str2) {
        string result = "";
        int maxLen = Math.Max(str1.Length, str2.Length);
        int i = str1.Length-1, j = str2.Length-1, carry = 0, sum = 0;
        while(i >= 0 || j >= 0) {
            sum = (i >= 0 ? (int)str1[i]-'0' : 0) + 
                    (j >= 0 ? (int)str2[j]-'0' : 0) + carry; 
            result = (sum % 10) + result;
            carry = sum / 10;
            i--; j--;
        }
        while(carry > 0) {
            result = (carry % 10) + result;
            carry = carry / 10;
        }
        return result;
    }
}