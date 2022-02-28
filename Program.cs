using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

int headerLen = 30;
if (args != null && args.Count() > 0)
{
    Console.WriteLine();
    for(int i = 0; i < args.Length; i++) {
        // foreach(var type in Assembly.GetExecutingAssembly().GetTypes())
            // Console.WriteLine(type.Name);
        var arg = args[i];
        if(arg.Contains(".")) {
            arg = arg.Substring(arg.IndexOf(".")+1);
            // Console.WriteLine(arg);
        }
        var type = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Name.Contains(arg)).FirstOrDefault();
        if(type != null)
            InvokeType(type);
    }
}
Console.WriteLine();   

void InvokeType(Type type)
{
    if(type != null)
    {
        PrintHeader(type.FullName);
        System.Reflection.ConstructorInfo cinfo = type.GetConstructor(Type.EmptyTypes);
        if (cinfo != null)
        {
            var instance = cinfo.Invoke(new object[0]);
            Console.WriteLine();
        }
    }
} 
void PrintHeader(string FullName)
{
    string header = FullName;
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    string space = "";
    for (int i = 0; i < headerLen - header.Length; i++)
        space += " ";
    string head = string.Format("{0}{1} : ", header, space);
    Console.WriteLine(head);
    Console.ResetColor();
}