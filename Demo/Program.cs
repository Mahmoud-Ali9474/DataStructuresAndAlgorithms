using System.Runtime.InteropServices;

internal class Program
{
    private static void Main(string[] args)
    {
        var list = new DataStructures.List.List<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(5);
        foreach (int item in list)
        {
            System.Console.WriteLine(item);
        }
        // System.Console.WriteLine(list[4]);
        System.Console.WriteLine(list.ToString());
        Console.ReadLine();
    }
}