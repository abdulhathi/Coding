using System;

public class StringPermutation {
    /*                                              str =  [A][B][C]
                            ()                      
                 K = 0    /                         temp = [1][0][0]
                 i = 0  /                           Res  = [A][B][C]
                       A
              K = 1  /    \
            i = 0,1 /      \
                   B
         K = 2    /  
    i = 0,1,2   /      
               C
K =3(length 3)/
      Print  /     
           ABC 

    */
    char[] str = {'A','B','C'};
    bool[] temp;
    char[] res;
    public StringPermutation() {
        temp = new bool[str.Length];
        res = new char[str.Length];
        GeneratePermuations(0);
    }
    public void GeneratePermuations(int k) {
        if(k == str.Length)
            Console.WriteLine(res);
        else {
            for(int i = 0; i < str.Length; i++) {
                if(temp[i] == false) {
                    temp[i] = true;
                    res[k] = str[i];
                    GeneratePermuations(k+1);
                    temp[i] = false;
                }
            }
        }
    }
}