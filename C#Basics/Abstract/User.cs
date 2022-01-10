using System;

public abstract class User { 
    public string FullName { get; set; } = "";
    public void Print() { 
        Console.Write(FullName);
    }
    public User() { }
    public abstract void PrintHello();
}