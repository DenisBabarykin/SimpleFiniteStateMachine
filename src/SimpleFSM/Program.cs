using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFSM
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (!ArgsAreValid(args))
                    return;

                var inputStrings = File.ReadAllLines(args[0]).Select(s => s.Trim()).ToList();
                var fsmTasks = FsmTasksBuilder.Build(inputStrings);
                var outputStrings = FsmTasksProcessor.Process(fsmTasks);
                File.WriteAllLines(args[1], outputStrings);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e} occured with message: {e.Message}");
            }
        }

        static bool ArgsAreValid(string[] args)
        {
            bool res = false;
            switch (args.Count())
            {
                case 1:
                    if (args[0] == "-help")
                        Console.WriteLine("The first command line arg must be input filename and the second - output filename. For example 'SimpleFSM.exe input.txt output.txt'.");
                    else
                        Console.WriteLine("Incorrect args. Use '-help' arg for help.");
                    break;
                case 2:
                    if (File.Exists(args[0]))
                        res = true;
                    else
                        Console.WriteLine("File with input data doesn't exist. Use '-help' arg for help.");
                    break;
                default:
                    Console.WriteLine("Incorrect args. Use '-help' arg for help.");
                    break;
            }
            return res;
        }
    }
}
