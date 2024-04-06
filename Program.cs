using unoia.src;

namespace unoia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: unoia");
                Environment.Exit(2);
            }
            else if(args.Length >= 1)
            {
                int n = args.Length;
                while (n>0) {
                    while (!args[n-1].EndsWith('/'))
                    {
                        Console.WriteLine("your uri must end with / please fix it or press q to leave as it is");
                        Console.Write($">{args[n-1]}");
                        string? input = Console.ReadLine();
                        if (input == "q" || input == "Q")
                        {
                            args[n - 1] += "/";
                            break;
                        }
                        
                        if(input.EndsWith('/'))
                            args[n-1] += input;
                    }
                    n--;
                }
                
                Listener lstnr = Listener.createListener();
                lstnr.listenTo(args);
                
                bool keeplistening =true;
                while (keeplistening)
                {
                    lstnr.start();
                    lstnr.displayRequestInfo();

                }
            }
        }
    }
}