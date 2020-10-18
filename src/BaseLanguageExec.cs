using System;
namespace ion {

    public class BaseLanguageExec {

        string[] registers = new string[8192];
        public BaseLanguageExec() {



        }
        public void exec(string line) {

            if(line.StartsWith("consout ")) {

                string output = line.Split("consout ")[1];
                int i = 0;
                while(i < registers.Length) {

                    output = output.Replace("${" + i + "}",registers[i]);
                    i++;

                }

                Console.Write(output);

            } else if (line.StartsWith("consoutln ")){

                string output = line.Split("consoutln ")[1];
                int i = 0;
                while(i < registers.Length) {

                    output = output.Replace("${" + i + "}",registers[i]);
                    i++;

                }

                Console.WriteLine(output);

            } else if (line.StartsWith("runseparate ")) {

                BaseLanguageExec exec2 = new BaseLanguageExec();
                exec2.exec(line.Split("runseparate ")[1]);

            } else if (line.StartsWith("reg ")) {

                registers[int.Parse(line.Split(" ")[1])] = line.Split(" = ")[1];

            }

        }

    }

}