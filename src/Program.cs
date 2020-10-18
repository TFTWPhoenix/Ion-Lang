using System;

namespace ion
{
    class Program
    {
        static string[] args = Environment.GetCommandLineArgs();
        static void Main()
        {

            Console.WriteLine("Detecting options...");
            int i = 1;
            while(i < args.Length) {

                if(args[i] == "--enableTestingFeatures" || args[i] == "--enableUnstableFeatures") {

                    Options.testingFeatures = true;
                    Console.WriteLine("Enabled Testing/Unstable Features.");

                } else if (args[i].StartsWith("--otf-entrypoint=")) {

                    Options.onTheFlyExec = true;
                    Options.onTheFlyFile = args[i].Split("--otf-entrypoint=")[1];
                    Console.WriteLine("Using On-The-Fly execution for file: " + args[i].Split("--otf-entrypoint=")[1]);

                }
                i++;

            }
            string[] fileLines = {};
            if(Options.onTheFlyExec) {

                fileLines = System.IO.File.ReadAllLines(Options.onTheFlyFile);

            }
            
            BaseLanguageExec executor1 = new BaseLanguageExec();
            i = 0;
            while(i < fileLines.Length) {

                executor1.exec(fileLines[i]);
                i++;

            }


        }
    }
}
