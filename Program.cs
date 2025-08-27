using Fehrestoonak_V1;

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("welcome to Fehrestoonak Version1");

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine(">> Enter your work subject to save it,");
Console.WriteLine(">> Enter 'list' to see to-do list,");
Console.WriteLine(">> Enter 'done{id}' to change work status,");
Console.WriteLine(">> Enter '-del{id}' to delete work from list,");
Console.WriteLine(">> Enter 'help' to get help.");
Console.WriteLine();

Work work_class = new Work();
FixTextList fixText = new FixTextList();

for (; ; )
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(">>> ");
    Console.ForegroundColor= ConsoleColor.White;
    string input = Console.ReadLine().ToString();

    if (input.Length < 4)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error : The input value is not valid.");
    }
    else if (input.ToLower() == "list")
    {

        string test = File.ReadAllText("user_works.txt");
        if (!String.IsNullOrEmpty(File.ReadAllText("user_works.txt")))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(fixText.FixSpaces(" #", 2));
            Console.Write(" | ");
            Console.Write(fixText.FixSpaces("Subject", 30));
            Console.Write(" | ");
            Console.Write(fixText.FixSpaces("Status", 10));
            Console.Write(" | ");
            Console.Write(fixText.FixSpaces("Date Time", 18));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var work in work_class.GetList())
            {
                Console.Write(fixText.FixSpaces(work.Id, 2));
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" | ");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(fixText.FixSpaces(work.Subject, 30));
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" | ");

                if (work.Status.ToLower() == "done")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                Console.Write(fixText.FixSpaces(work.Status, 10));
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" | ");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(fixText.FixSpaces(work.Date, 18));
                Console.WriteLine();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error : to-do list is empty.");
        }
    }
    else if (input.ToLower() == "help")
    {
        Console.WriteLine(File.ReadAllText("Help.txt"));
    }
    else if (input.Substring(0,4).ToLower() == "done")
    {
        int Id = Convert.ToInt32(input.ToLower().Replace("done",""));

        if (work_class.Done(Id))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("This was done.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error : try again later.");
        }
    }
    else if (input.Substring(0, 4).ToLower() == "-del")
    {
        int Id = Convert.ToInt32(input.ToLower().Replace("-del", ""));

        if (work_class.Delete(Id))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("This was deleted.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error : try again later.");
        }
    }
    else
    {
        work_class.Add(input, DateTime.Now);
    }
}