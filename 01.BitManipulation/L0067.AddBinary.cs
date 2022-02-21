using System;
using System.Collections.Generic;

public class AddBinaryString {
    public AddBinaryString() {

    }
public string AddBinary(string a, string b) {
        char carry = '0';
        int length = Math.Max(a.Length, b.Length);
        string sum = "";
        for(int i = 0; i < length; i++) {
            if(i < a.Length && i >= b.Length)
                b = "0" + b;
            else if(i < b.Length && i >= a.Length)
                a = "0" + a;
        }
        for(int i = length-1; i >= 0; i--) {
            if(a[i] == '1' && b[i] == '1' && carry == '1') {
                sum = '1' + sum;
                carry = '1';
            }
            else if(a[i] == '1' && b[i] == '1' && carry == '0') {
                sum = '0' + sum;
                carry = '1';
            }
            else if((a[i] == '1' || b[i] == '1') && carry == '1') {
                sum = '0' + sum;
                carry = '1';
            }
            else if((a[i] == '1' || b[i] == '1') && carry == '0') {
                sum = '1' + sum;
                carry = '0';
            }
            else {
                if(carry == '1') {
                    sum = '1' + sum;
                    carry = '0';
                }
                else
                    sum = '0' + sum;
            }
        }
        if(carry == '1')
            sum = '1' + sum;
        return sum;
    }
}