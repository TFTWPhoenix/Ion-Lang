using System;
namespace ion {

    public class BaseLanguageExec {

        string[] registers = new string[8192];
        public BaseLanguageExec() {



        }
        public void exec(string line) {

            if(line.StartsWith("//")) {
            }if(line.StartsWith("consout ")) {

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

            } else if (line.StartsWith("add ")) {

                string addend1 = line.Split(" = ")[1].Split("+")[0];
                string addend2 = line.Split(" = ")[1].Split("+")[1];

                int i = 0;
                while(i < registers.Length) {

                    addend1 = addend1.Replace("${" + i + "}",registers[i]);
                    i++;

                }

                i = 0;
                while(i < registers.Length) {

                    addend2 = addend2.Replace("${" + i + "}",registers[i]);
                    i++;

                }

                int result = int.Parse(addend1) + int.Parse(addend2);

                registers[int.Parse(line.Split("add ")[1].Split(" = ")[0])] = result.ToString();

            } else if (line.StartsWith("subtract ")) {

                string minuend = line.Split(" = ")[1].Split("-")[0];
                string subtrahend = line.Split(" = ")[1].Split("-")[1];

                int i = 0;
                while(i < registers.Length) {

                    minuend = minuend.Replace("${" + i + "}",registers[i]);
                    i++;

                }

                i = 0;
                while(i < registers.Length) {

                    subtrahend = subtrahend.Replace("${" + i + "}",registers[i]);
                    i++;

                }

                int result = int.Parse(minuend) - int.Parse(subtrahend);

                registers[int.Parse(line.Split("subtract ")[1].Split(" = ")[0])] = result.ToString();

            } else if (line.StartsWith("multiply ")) {

                string factor1 = line.Split(" = ")[1].Split("*")[0];
                string factor2 = line.Split(" = ")[1].Split("*")[1];

                int i = 0;
                while(i < registers.Length) {

                    factor1 = factor1.Replace("${" + i + "}",registers[i]);
                    i++;

                }

                i = 0;
                while(i < registers.Length) {

                    factor2 = factor2.Replace("${" + i + "}",registers[i]);
                    i++;

                }

                int result = int.Parse(factor1) * int.Parse(factor2);

                registers[int.Parse(line.Split("multiply ")[1].Split(" = ")[0])] = result.ToString();

            } else if (line.StartsWith("divide ")) {

                string dividend = line.Split(" = ")[1].Split("/")[0];
                string divisor = line.Split(" = ")[1].Split("/")[1];

                int i = 0;
                while(i < registers.Length) {

                    dividend = dividend.Replace("${" + i + "}",registers[i]);
                    i++;

                }

                i = 0;
                while(i < registers.Length) {

                    divisor = divisor.Replace("${" + i + "}",registers[i]);
                    i++;

                }

                int result = int.Parse(dividend) / int.Parse(divisor);

                registers[int.Parse(line.Split("divide ")[1].Split(" = ")[0])] = result.ToString();

            } else if (line.StartsWith("modulo ")) {

                string val1 = line.Split(" = ")[1].Split("%")[0];
                string val2 = line.Split(" = ")[1].Split("%")[1];

                int i = 0;
                while(i < registers.Length) {

                    val1 = val1.Replace("${" + i + "}",registers[i]);
                    i++;

                }

                i = 0;
                while(i < registers.Length) {

                    val2 = val2.Replace("${" + i + "}",registers[i]);
                    i++;

                }

                int result = int.Parse(val1) % int.Parse(val2);

                registers[int.Parse(line.Split("modulo ")[1].Split(" = ")[0])] = result.ToString();

            } else if (line.StartsWith("prc ")) {

                System.Diagnostics.Process prc = System.Diagnostics.Process.Start(line.Split("prc ")[1]);

            } else if (line.StartsWith("prcWaitForExit ")) {

                System.Diagnostics.Process prc = System.Diagnostics.Process.Start(line.Split("prcWaitForExit ")[1]);
                prc.WaitForExit();

            }
 
        } 

    }

}