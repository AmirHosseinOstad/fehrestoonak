using Fehrestoonak_V1;

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("welcome to Fehrestoonak Version1");

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine(">> Enter your work subject to save it");
Console.WriteLine(">> Enter 'list' to see to-do list");
Console.WriteLine(">> Enter 'change{id}' to change work status");
Console.WriteLine(">> Enter 'help' to get help");
Console.WriteLine();

Work work_class = new Work();

for (; ; )
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(">>> ");
    Console.ForegroundColor= ConsoleColor.White;
    string input = Console.ReadLine().ToString();

    if (input == "list")
    {
        Console.WriteLine(work_class.GetList());
    }
    else if (input == "help")
    {

    }
    else if (input.Substring(0,6) == "change")
    {
        int Id = Convert.ToInt32(input.Replace("change",""));
        Console.WriteLine(Id);
    }
    else
    {
        work_class.Add(input, DateTime.Now);
    }
}