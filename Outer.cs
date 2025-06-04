/*
 Kod zawiera komentarze w jezyku polskim (dominujacy dla komentarzy), i jezyku angielskim.
 The code contains comments in Polish (the dominant language for comments) and English.

Outer Open License – Wsad Edition v1.0
This project, including its code, language, documentation, compilers, interpreters, and any related files, is licensed under the Outer Open License – Wsad Edition.
You are free to:
Use it for any purpose
Download, copy, and distribute it
Modify and build upon it
Sell original or modified versions
Include it in commercial or non-commercial projects

You are not required to:
Credit the original author (although a mention would be appreciated)
Include this license in redistributed versions (but it’s encouraged)

Disclaimer of Warranty and Liability:
This project is provided as is, without any warranties.
The author (Wsad) is not responsible for any damage, data loss, legal issues, broken code, side effects, crashes, or reality glitches caused by the use of this code.
You use it at your own risk.
Don’t sue me. Seriously.
Have fun and do whatever you want.
– Wsad
Outer Open License – Wsad Edition v1.0
Released: 2025-05-19


 Made in Poland
 BY Gabriel Zapałowicz

*/
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace Outer
{
    internal class Program
    {
        static void Main()
        {

            string version = "CDXDAWSKIM - B516";
            string compilation = "Windows_universal_system/outer compilation";


            // Slownik do przechowywania zmiennych
            var stringList = new Dictionary<string, string>();

            var intList = new Dictionary<string, int>();

            var floatList = new Dictionary<string, float>();

           

            string lines;
            var lines_string = new List<string>();

            // Wczytanie pliku do tablicy linii
            var code_list = File.ReadAllLines(@"main.ou");



            for (int ii = 0; ii < code_list.Length; ii++)
            {
                code_list[ii].Trim();


                if (code_list[ii].ToLower().Trim() == "")
                {
                    continue;
                }

                //Gropu\\ Write--------------------------------------------------------------------


                //WYSWIETLANIE W KONSOLI TEXT Write
                if (code_list[ii].ToLower().StartsWith("write"))
                {
                    //przypisuje do lines tekst do wyswietlenia i go wypisuje
                    lines = code_list[ii].Substring(5).TrimStart();
                    Console.Write(lines);
                }


                //WYSWIETLANIE W KONSOLI TEXT WriteLine\\
                if (code_list[ii].StartsWith("linewrite"))
                {
                    //przypisuje do lines tekst do wyświetlenia i go wypisuje w linii
                    lines = code_list[ii].Substring(10).TrimStart();
                    Console.WriteLine(lines);
                }

                if (code_list[ii].ToLower().StartsWith("debug"))
                {
                    lines = code_list[ii].Substring(5).Trim();

                    if (intList.ContainsKey(lines))
                    {
                        Console.Write(intList[lines]);
                    }

                    if (stringList.ContainsKey(lines))
                    {
                        Console.Write(stringList[lines]);
                    }

                    if (floatList.ContainsKey(lines))
                    {
                        Console.Write(floatList[lines]);
                    }
                }

                if (code_list[ii].ToLower().StartsWith("lndebug"))
                {
                    lines = code_list[ii].Substring(7).Trim();

                    if (intList.ContainsKey(lines))
                    {
                        Console.WriteLine(intList[lines]);
                    }

                    if (stringList.ContainsKey(lines))
                    {
                        Console.WriteLine(stringList[lines]);
                    }

                    if (floatList.ContainsKey(lines))
                    {
                        Console.WriteLine(floatList[lines]);
                    }
                }


                //Group\\ String--------------------------------------------------------------------


                //TWORZENIE NOWEGO STRING I DODAWANIE GO DO LISTY STRING\\
                if (code_list[ii].ToLower().StartsWith("create string"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(13).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    stringList.Add(lines_string[0], lines_string[1]);

                    lines_string.Clear();

                }

                if (code_list[ii].ToLower().StartsWith("add string"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(10).Trim();

                    lines_string.Clear();

                    lines_string.AddRange(lines.Split(" "));

                    stringList[lines_string[0]] += stringList[lines_string[1]] + stringList[lines_string[2]];

                    lines_string.Clear();
                }


                if (code_list[ii].ToLower().StartsWith("add clear string"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(16).Trim();

                    lines_string.Clear();

                    lines_string.AddRange(lines.Split(" "));

                    stringList[lines_string[0]] = stringList[lines_string[1]] + stringList[lines_string[2]];

                    lines_string.Clear();
                }


                if (code_list[ii].ToLower().StartsWith("string +="))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(9).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    stringList[lines_string[0]] += lines_string[1];

                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("add space"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(9).Trim();

                    stringList[lines] += " ";

                }

                if (code_list[ii].ToLower().StartsWith("substring"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(9).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    stringList[lines_string[0]] = stringList[lines_string[0]].Substring(int.Parse(lines_string[1]));

                    lines_string.Clear();
                }


                //WYSWIETLANIE W KONSOLI Write Z Listy string\\
                if (code_list[ii].ToLower().StartsWith("debug string"))
                {
                    lines = code_list[ii].Substring(12).Trim();

                    Console.Write(stringList[lines]);
                }


                //WYSWIETLANIE W KONSOLI WriteLine Z Listy string\\
                if (code_list[ii].ToLower().StartsWith("debug line string"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(17).Trim();

                    Console.WriteLine("\n" + stringList[lines]);
                }


                if (code_list[ii].ToLower().StartsWith("string clear"))
                {
                    lines = code_list[ii].Substring(12).Trim();

                    stringList[lines] = "";
                }


                if (code_list[ii].ToLower().StartsWith("math"))
                {
                    lines_string.AddRange(code_list[ii].Substring(5).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

                    string variableName = lines_string[0]; // The variable name (e.g., "x")
                    string equation = string.Join(" ", lines_string.Skip(2)); // The equation part (e.g., "2*3/10")

                    // Evaluate the equation
                    try
                    {
                        var dataTable = new System.Data.DataTable();
                        var result = dataTable.Compute(equation, null); // Perform the calculation

                        if (intList.ContainsKey(variableName))
                        {
                            intList[variableName] = (int)Convert.ToDouble(result); // Update the existing variable
                        }
                        else
                        {
                            intList.Add(variableName, (int)Convert.ToDouble(result)); // Add a new variable
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error evaluating equation: {ex.Message}");
                    }
                }





                //Group\\ Int--------------------------------------------------------------------


                //TWORZENIE NOWEGO INT I DODAWANIE GO DO LISTY INT\\
                if (code_list[ii].ToLower().StartsWith("create int"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(10).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    intList.Add(lines_string[0], int.Parse(lines_string[1]));

                    lines_string.Clear();
                }

                //WYSWIETLANIE W KONSOLI Write Z Listy INT\\
                if (code_list[ii].ToLower().StartsWith("debug int"))
                {
                    lines = code_list[ii].Substring(9).Trim();

                    Console.Write(intList[lines]);
                }

                //WYSWIETLANIE W KONSOLI WriteLine Z Listy INT\\
                if (code_list[ii].ToLower().StartsWith("debug line int"))
                {
                    lines = code_list[ii].Substring(14).Trim();

                    Console.WriteLine("\n" + intList[lines]);
                }


                //Math\\ Int--------------------------------------------------------------------


                //DODAWANIE\\
                if (code_list[ii].ToLower().StartsWith("add clear int"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(13).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    intList[lines_string[0]] = intList[lines_string[1]] + intList[lines_string[2]];
                    lines_string.Clear();

                }

                if (code_list[ii].ToLower().StartsWith("add int"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(7).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    intList[lines_string[0]] += intList[lines_string[1]] + intList[lines_string[2]];

                    lines_string.Clear();

                }


                //MNOZENIE\\
                if (code_list[ii].ToLower().StartsWith("multiply int"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(12).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    intList[lines_string[0]] *= (intList[lines_string[1]] * intList[lines_string[2]]);

                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("multiply clear int"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(18).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    intList[lines_string[0]] = intList[lines_string[1]] * intList[lines_string[2]];

                    lines_string.Clear();
                }


                //DZIELENIE\\
                if (code_list[ii].ToLower().StartsWith("divide int"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(10).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    intList[lines_string[0]] /= (intList[lines_string[1]] / intList[lines_string[2]]);

                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("divide clear int"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(17).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    intList[lines_string[0]] = (intList[lines_string[1]] / intList[lines_string[2]]);

                    lines_string.Clear();
                }


                //ODEJMOWANIE\\
                if (code_list[ii].ToLower().StartsWith("sub int"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(7).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    intList[lines_string[0]] -= (intList[lines_string[1]] - intList[lines_string[2]]);

                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("sub clear int"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(13).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    intList[lines_string[0]] = (intList[lines_string[1]] - intList[lines_string[2]]);

                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("int +="))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(6).Trim();
                    lines_string.Clear();

                    lines_string.AddRange(lines.Split(" "));

                    intList[lines_string[0]] += int.Parse(lines_string[1]);
                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("int -="))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(7).Trim();
                    lines_string.Clear();

                    lines_string.AddRange(lines.Split(" "));

                    intList[lines_string[0]] -= int.Parse(lines_string[1]);
                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("int *="))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(6).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    intList[lines_string[0]] *= int.Parse(lines_string[1]);
                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("int /="))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(6).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    intList[lines_string[0]] /= int.Parse(lines_string[1]);
                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("int =="))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(6).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    intList[lines_string[0]] = int.Parse(lines_string[1]);
                    lines_string.Clear();
                }




                //Group\\ Float--------------------------------------------------------------------


                //TWORZENIE NOWEGO FLOAT I DODAWANIE GO DO LISTY FLOAT\\
                if (code_list[ii].ToLower().StartsWith("create float"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(12).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    floatList.Add(lines_string[0], float.Parse(lines_string[1]));

                    lines_string.Clear();
                }

                //WYSWIETLANIE W KONSOLI Write Z Listy FLOAT\\
                if (code_list[ii].ToLower().StartsWith("debug float"))
                {
                    lines = code_list[ii].Substring(11).Trim();

                    Console.Write(floatList[lines]);
                }

                //WYSWIETLANIE W KONSOLI WriteLine Z Listy FLOAT\\
                if (code_list[ii].ToLower().StartsWith("debug line float"))
                {
                    lines = code_list[ii].Substring(16).Trim();

                    Console.WriteLine("\n" + floatList[lines]);
                }


                //Math\\ Float--------------------------------------------------------------------


                //DODAWANIE\\
                if (code_list[ii].ToLower().StartsWith("add clear float"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(15).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    floatList[lines_string[0]] = floatList[lines_string[1]] + floatList[lines_string[2]];

                    lines_string.Clear();

                }

                if (code_list[ii].ToLower().StartsWith("add float"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(9).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    floatList[lines_string[0]] += floatList[lines_string[1]] + floatList[lines_string[2]];

                    lines_string.Clear();

                }


                //MNOZENIE\\
                if (code_list[ii].ToLower().StartsWith("multiply float"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(14).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    floatList[lines_string[0]] *= (floatList[lines_string[1]] * floatList[lines_string[2]]);

                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("multiply clear float"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(20).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    floatList[lines_string[0]] = floatList[lines_string[1]] * floatList[lines_string[2]];

                    lines_string.Clear();
                }


                //DZIELENIE\\
                if (code_list[ii].ToLower().StartsWith("divide float"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(12).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    floatList[lines_string[0]] /= (floatList[lines_string[1]] / floatList[lines_string[2]]);

                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("divide clear float"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(19).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    floatList[lines_string[0]] = (floatList[lines_string[1]] / floatList[lines_string[2]]);

                    lines_string.Clear();
                }


                //ODEJMOWANIE\\
                if (code_list[ii].ToLower().StartsWith("sub float"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(9).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    floatList[lines_string[0]] -= (floatList[lines_string[1]] - floatList[lines_string[2]]);

                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("sub clear float"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(15).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    floatList[lines_string[0]] = (floatList[lines_string[1]] - floatList[lines_string[2]]);

                    lines_string.Clear();
                }


                if (code_list[ii].ToLower().StartsWith("float +="))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(8).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    floatList[lines_string[0]] += float.Parse(lines_string[1]);
                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("float -="))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(8).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    floatList[lines_string[0]] -= float.Parse(lines_string[1]);
                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("float *="))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(8).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    floatList[lines_string[0]] *= float.Parse(lines_string[1]);
                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("float /="))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(8).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    floatList[lines_string[0]] /= float.Parse(lines_string[1]);
                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("float =="))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(8).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    floatList[lines_string[0]] = float.Parse(lines_string[1]);
                    lines_string.Clear();
                }



                //Group\\ IF--------------------------------------------------------------------


                //------------------IF INT--------------------------------\\
                if (code_list[ii].ToLower().StartsWith("if int =="))
                {
                    lines = code_list[ii].Substring(9).Trim();
                    lines_string.Clear();

                    lines_string.AddRange(lines.Split(" "));

                    if (intList[lines_string[0]] == intList[lines_string[1]])
                    {
                        continue;
                    }
                    else
                    {
                        ii += int.Parse(lines_string[2]);
                    }

                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("if int !="))
                {
                    lines = code_list[ii].Substring(9).Trim();
                    lines_string.Clear();

                    lines_string.AddRange(lines.Split(" "));

                    if (intList[lines_string[0]] != intList[lines_string[1]])
                    {
                        continue;
                    }
                    else
                    {
                        ii += int.Parse(lines_string[2]);
                    }

                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("if int <"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(8).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    if (intList[lines_string[0]] < intList[lines_string[1]])
                    {
                        continue;
                    }
                    else
                    {
                        ii += int.Parse(lines_string[2]);
                    }

                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("if int >"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(8).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    if (intList[lines_string[0]] > intList[lines_string[1]])
                    {
                        continue;
                    }
                    else
                    {
                        ii += int.Parse(lines_string[2]);
                    }

                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("if int even"))
                {
                    lines = code_list[ii].Substring(12);

                    lines_string.Clear();

                    lines_string.AddRange(lines.Split(" "));

                    if (intList[lines_string[0]] % 2 == 0)
                    {
                        continue;
                    }
                    else
                    {
                        ii += int.Parse(lines_string[1]);
                    }

                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("if int odd"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(11);

                    lines_string.AddRange(lines.Split(" "));

                    if (intList[lines_string[0]] % 2 != 0)
                    {
                        continue;
                    }
                    else
                    {
                        ii += int.Parse(lines_string[1]);
                    }

                    lines_string.Clear();
                }



                //------------------IF FLOAT--------------------------------\\
                if (code_list[ii].ToLower().StartsWith("if float =="))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(11).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    if (floatList[lines_string[0]] == floatList[lines_string[1]])
                    {
                        continue;
                    }
                    else
                    {
                        ii += int.Parse(lines_string[2]);
                    }

                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("if float !="))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(11).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    if (floatList[lines_string[0]] != floatList[lines_string[1]])
                    {
                        continue;
                    }
                    else
                    {
                        ii += int.Parse(lines_string[2]);
                    }

                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("if float <"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(10).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    if (floatList[lines_string[0]] < floatList[lines_string[1]])
                    {
                        continue;
                    }
                    else
                    {
                        ii += int.Parse(lines_string[2]);
                    }

                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("if float >"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(10).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    if (floatList[lines_string[0]] > floatList[lines_string[1]])
                    {
                        continue;
                    }
                    else
                    {
                        ii += int.Parse(lines_string[2]);
                    }

                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("if float even"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(13).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    if (floatList[lines_string[0]] % 2 == 0)
                    {
                        continue;
                    }
                    else
                    {
                        ii += int.Parse(lines_string[1]);
                    }

                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("if float odd"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(12).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    if (floatList[lines_string[0]] % 2 != 0)
                    {
                        continue;
                    }
                    else
                    {
                        ii += int.Parse(lines_string[1]);
                    }

                    lines_string.Clear();
                }




                //------------------IF STRING--------------------------------\\
                if (code_list[ii].ToLower().StartsWith("if string =="))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(12).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    if (stringList[lines_string[0]] == stringList[lines_string[1]])
                    {
                        continue;
                    }
                    else
                    {
                        ii += int.Parse(lines_string[2]);
                    }

                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("if string int =="))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(16).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    if (stringList[lines_string[0]] == intList[lines_string[1]].ToString())
                    {
                        continue;
                    }
                    else
                    {
                        ii += int.Parse(lines_string[2]);
                    }

                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("if string int !="))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(16).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    if (stringList[lines_string[0]] != intList[lines_string[1]].ToString())
                    {
                        continue;
                    }
                    else
                    {
                        ii += int.Parse(lines_string[2]);
                    }

                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("if string !="))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(12).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    if (stringList[lines_string[0]] != stringList[lines_string[1]])
                    {
                        continue;
                    }
                    else
                    {
                        ii += int.Parse(lines_string[2]);
                    }

                    lines_string.Clear();
                }


                //------------------IF FILE--------------------------------\\

                if (code_list[ii].ToLower().StartsWith("exist file"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(10).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    if (File.Exists(lines_string[0]))
                    {
                        continue;
                    }
                    else
                    {
                        ii += int.Parse(lines_string[1]);
                    }

                    lines_string.Clear();
                }

                if (code_list[ii].ToLower().StartsWith("!exist file"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(11).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    if (!File.Exists(lines_string[0]))
                    {
                        continue;
                    }
                    else
                    {
                        ii += int.Parse(lines_string[1]);
                    }

                    lines_string.Clear();
                }


                //Group\\ SET and ReadLine--------------------------------------------------------------------

                if (code_list[ii].StartsWith("SET"))
                {
                    lines = code_list[ii].Substring(3).Trim();
                    lines_string.Clear();
                    lines_string.AddRange(lines.Split(" "));

                    // Sprawdzenie, czy lines_string zawiera przynajmniej dwa elementy
                    if (lines_string.Count >= 2)
                    {
                        string varX = lines_string[0];
                        string varY = lines_string[1];

                        // Sprawdzamy, czy istnieją odpowiednie klucze w słownikach
                        if (intList.ContainsKey(varX) && intList.ContainsKey(varY))
                        {
                            intList[varX] = intList[varY];
                        }
                        else if (intList.ContainsKey(varX) && floatList.ContainsKey(varY))
                        {
                            intList[varX] = (int)floatList[varY];
                        }
                        else if (intList.ContainsKey(varX) && stringList.ContainsKey(varY))
                        {
                            intList[varX] = int.Parse(stringList[varY].ToString());
                        }

                        else if (floatList.ContainsKey(varX) && intList.ContainsKey(varY))
                        {
                            floatList[varX] = intList[varY];
                        }
                        else if (floatList.ContainsKey(varX) && floatList.ContainsKey(varY))
                        {
                            floatList[varX] = floatList[varY];
                        }
                        else if (floatList.ContainsKey(varX) && stringList.ContainsKey(varY))
                        {
                            floatList[varX] = float.Parse(stringList[varY].ToString());
                        }

                        else if (stringList.ContainsKey(varX) && intList.ContainsKey(varY))
                        {
                            stringList[varX] = intList[varY].ToString();
                        }
                        else if (stringList.ContainsKey(varX) && floatList.ContainsKey(varY))
                        {
                            stringList[varX] = floatList[varY].ToString();
                        }
                        else if (stringList.ContainsKey(varX) && stringList.ContainsKey(varY))
                        {
                            stringList[varX] = stringList[varY].ToString();
                        }
                    }
                    lines_string.Clear();
                }



                if (code_list[ii].ToLower().StartsWith("console readline"))
                {
                    lines = code_list[ii].Substring(16).Trim();

                    lines_string.Clear();

                    if (stringList.ContainsKey(lines))
                    {
                        stringList[lines] = Console.ReadLine();
                    }

                    if (intList.ContainsKey(lines))
                    {
                        intList[lines] = int.Parse(Console.ReadLine());
                    }

                    if (floatList.ContainsKey(lines))
                    {
                        floatList[lines] = float.Parse(Console.ReadLine());
                    }
                }


                //Group\\ Useful--------------------------------------------------------------------


                // Czyszczenie konsoli\\
                if (code_list[ii].ToLower().StartsWith("clear"))
                {
                    Console.Clear();
                }




                //Zmiana koloru text \\

                if (code_list[ii].ToLower().StartsWith("change color console"))
                {
                    lines = code_list[ii].Substring(20).Trim();

                    if (lines.ToLower() == "blue")
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else if (lines.ToLower() == "black")
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (lines.ToLower() == "red")
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else if (lines.ToLower() == "magenta")
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                    }
                    else if (lines.ToLower() == "cyan")
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                    }
                    else if (lines.ToLower() == "green")
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    else if (lines.ToLower() == "dark green")
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }
                    else if (lines.ToLower() == "dark blue")
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                    }
                    else if (lines.ToLower() == "dark cyan")
                    {
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                    }
                    else if (lines.ToLower() == "dark gray")
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    else if (lines.ToLower() == "dark magenta")
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    }
                    else if (lines.ToLower() == "dark red")
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    }
                    else if (lines.ToLower() == "dark yellow")
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (lines.ToLower() == "gray")
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }
                    else if (lines.ToLower() == "white")
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else if (lines.ToLower() == "yellow")
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }


                }

                if (code_list[ii].ToLower().StartsWith("change color text"))
                {
                    lines = code_list[ii].Substring(17).Trim();

                    if (lines.ToLower() == "blue")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (lines.ToLower() == "black")
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else if (lines.ToLower() == "red")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (lines.ToLower() == "magenta")
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    else if (lines.ToLower() == "cyan")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else if (lines.ToLower() == "green")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (lines.ToLower() == "dark green")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    else if (lines.ToLower() == "dark blue")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }
                    else if (lines.ToLower() == "dark cyan")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    }
                    else if (lines.ToLower() == "dark gray")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    else if (lines.ToLower() == "dark magenta")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    }
                    else if (lines.ToLower() == "dark red")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    else if (lines.ToLower() == "dark yellow")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (lines.ToLower() == "gray")
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (lines.ToLower() == "white")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (lines.ToLower() == "yellow")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }


                }

                // Dzwiek konsoli \\
                if (code_list[ii].ToLower().StartsWith("beep"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(4).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    Console.Beep(int.Parse(lines_string[0]), int.Parse(lines_string[1]));

                    lines_string.Clear();
                }

                // Widocznosc kursora \\
                if (code_list[ii].ToLower().StartsWith("cursor off"))
                {
                    Console.CursorVisible = false;
                }

                if (code_list[ii].ToLower().StartsWith("cursor on"))
                {
                    Console.CursorVisible = true;
                }

                // Rozmiery konsoli \\
                if (code_list[ii].ToLower().StartsWith("width"))
                {
                    lines = code_list[ii].Substring(5).Trim();

                    Console.WindowWidth = int.Parse(lines);
                }

                if (code_list[ii].ToLower().StartsWith("height"))
                {
                    lines = code_list[ii].Substring(6).Trim();

                    Console.WindowHeight = int.Parse(lines);
                }

                //Resetuje kolor konsoli \\
                if (code_list[ii].ToLower().StartsWith("reset color"))
                {
                    Console.ResetColor();
                }

                //Title konsoli \\
                if (code_list[ii].ToLower().StartsWith("title"))
                {
                    lines = code_list[ii].Substring(5).Trim();

                    Console.Title = lines;
                }

                // Console Buffer \\ 
                if (code_list[ii].ToLower().StartsWith("buffer height"))
                {
                    lines = code_list[ii].Substring(13).Trim();

                    Console.BufferHeight = int.Parse(lines);
                }

                if (code_list[ii].ToLower().StartsWith("buffer width"))
                {
                    lines = code_list[ii].Substring(12).Trim();

                    Console.BufferWidth = int.Parse(lines);
                }

                //import\\

                if (code_list[ii].StartsWith("IMPORT UTF8"))
                {
                    Console.OutputEncoding = Encoding.UTF8;
                }

                if (code_list[ii].StartsWith("IMPORT ASCII"))
                {
                    Console.OutputEncoding = System.Text.Encoding.ASCII;
                }

                if (code_list[ii].StartsWith("IMPORT UNICODE"))
                {
                    Console.OutputEncoding = System.Text.Encoding.Unicode;
                }



                if (code_list[ii].StartsWith("main line error"))
                {
                    lines = code_list[ii].Substring(15).Trim();
                    ConsoleColor colorConsole = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine(lines);
                    Console.ForegroundColor = colorConsole;

                }

                if (code_list[ii].StartsWith("#"))
                {
                    continue;
                }


                if (code_list[ii].ToLower().StartsWith("delay"))
                {
                    lines = code_list[ii].Substring(5).Trim();

                    Thread.Sleep(int.Parse(lines));
                }

                //Group\\ RandomValue--------------------------------------------------------------------

                if (code_list[ii].StartsWith("randomInt"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(9).Trim();
                    lines_string.AddRange(lines.Split(" "));

                    Random random = new Random();

                    intList[lines_string[0]] = random.Next(intList[lines_string[1]], intList[lines_string[2]]);





                    lines_string.Clear();

                }

                if (code_list[ii].StartsWith("randomFloat"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(11).Trim();
                    lines_string.AddRange(lines.Split(" "));

                    Random random = new Random();

                    intList[lines_string[0]] = random.Next(intList[lines_string[1]], intList[lines_string[2]]);

                    lines_string.Clear();
                }

                //Group\\ Date--------------------------------------------------------------------

                if (code_list[ii].ToLower().StartsWith("year"))
                {
                    lines = code_list[ii].Substring(4).Trim();

                    if (intList.ContainsKey(lines))
                    {
                        intList[lines] = DateTime.Now.Year;
                    }

                    if (floatList.ContainsKey(lines))
                    {
                        floatList[lines] = DateTime.Now.Year;
                    }

                    if (stringList.ContainsKey(lines))
                    {
                        stringList[lines] = DateTime.Now.Year.ToString();
                    }

                }

                if (code_list[ii].ToLower().StartsWith("day"))
                {
                    lines = code_list[ii].Substring(3).Trim();

                    if (intList.ContainsKey(lines))
                    {
                        intList[lines] = DateTime.Now.Day;
                    }

                    if (floatList.ContainsKey(lines))
                    {
                        floatList[lines] = DateTime.Now.Day;
                    }

                    if (stringList.ContainsKey(lines))
                    {
                        stringList[lines] = DateTime.Now.Day.ToString();
                    }

                }

                if (code_list[ii].ToLower().StartsWith("month"))
                {
                    lines = code_list[ii].Substring(5).Trim();

                    if (intList.ContainsKey(lines))
                    {
                        intList[lines] = DateTime.Now.Month;
                    }

                    if (floatList.ContainsKey(lines))
                    {
                        floatList[lines] = DateTime.Now.Month;
                    }

                    if (stringList.ContainsKey(lines))
                    {
                        stringList[lines] = DateTime.Now.Month.ToString();
                    }

                }


                //Group\\ Function--------------------------------------------------------------------

                if (code_list[ii].StartsWith("FUN"))
                {
                    continue;
                }

                if (code_list[ii].StartsWith("GO"))
                {
                    lines = code_list[ii].Substring(2).Trim();

                    ii = 0;

                    while (code_list[ii] != lines)
                    {
                        ii++;
                    }
                }


                //Group\\ File--------------------------------------------------------------------


                if (code_list[ii].ToLower().StartsWith("create file"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(12);
                    lines_string.AddRange(lines.Split(" "));

                    if (intList.ContainsKey(lines_string[1]))
                    {
                        File.WriteAllText(lines_string[0], intList[lines_string[1]].ToString());
                    }

                    if (stringList.ContainsKey(lines_string[1]))
                    {
                        File.WriteAllText(lines_string[0], stringList[lines_string[1]]);
                    }

                    if (floatList.ContainsKey(lines_string[1]))
                    {
                        File.WriteAllText(lines_string[0], floatList[lines_string[1]].ToString());
                    }

                    lines_string.Clear();

                }

                if (code_list[ii].ToLower().StartsWith("open file"))
                {
                    lines_string.Clear();
                    lines = code_list[ii].Substring(9).Trim();

                    lines_string.AddRange(lines.Split(" "));

                    if (intList.ContainsKey(lines_string[1]))
                    {
                        intList[lines_string[1]] = int.Parse(File.ReadAllText(lines_string[0]));
                    }

                    if (floatList.ContainsKey(lines_string[1]))
                    {
                        floatList[lines_string[1]] = float.Parse(File.ReadAllText(lines_string[0]));
                    }

                    if (stringList.ContainsKey(lines_string[1]))
                    {
                        stringList[lines_string[1]] = File.ReadAllText(lines_string[0]);
                    }


                    lines_string.Clear();
                }




                //Group\\ Break--------------------------------------------------------------------

                if (code_list[ii].StartsWith("BreakScripts"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nEnd Script, compilation " + DateTime.Now + ", BreakScripts -, version: " + version + ", compilation: " + compilation + "\n Presh any key to close this window");
                    Console.ReadLine();
                }

                if (code_list[ii].StartsWith("BreakClearScripts"))
                {
                    Console.ReadLine();
                }



            }

            Console.ReadLine();
        }
    }
}

    
