using List.Core;

namespace List.Runner;

internal class Program
{
    private class Data
    {
        public string Name { get; set; }
    }
    static void Main(string[] args)
    {
        SingleLinkedList<int> myList = [1, 2, 3, 4, 5, 6, 78, 9, 10];

        foreach (var element in myList)
        {
            Console.WriteLine(element);
            }

        var list = new SingleLinkedList<Data?>();
        list.Add(new Data());
        list.Add(null);
    }
}
