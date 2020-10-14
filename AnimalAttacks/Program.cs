using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace AnimalAttacks
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> list = new List<Item>();
            var path = "./" + args[2];
            
            var lines = File.ReadAllLines(path);
            for (int i = 1; i < lines.Length; i++)
            {
                if (args[0]== "country")
                {
                    var split = lines[i].Split('\t');
                    list.Add(new Item(split[0], Int32.Parse(split[3]), 0));
                }
                else if (args[0] == "time_of_day")
                {
                    var split = lines[i].Split('\t');
                    list.Add(new Item(split[1], Int32.Parse(split[3]), 0));
                }
                else if (args[0] == "animal")
                {
                    var split = lines[i].Split('\t');
                    list.Add(new Item(split[2], Int32.Parse(split[3]), 0));
                }
                else
                {
                    Console.WriteLine($"{args[0]} ist eine falsche eingabe");
                }   
            }
            List<Item> sum = SumOfAttacks(list);
            list.Sort((x, y) => y.Attacks.CompareTo(x.Attacks));
            
            var maxValue = getMaxValue(list);
            CalculatPercentage(maxValue, sum);

            foreach (var item in sum)
            {
                Console.WriteLine(args[0] + " " + args[1]);
                Console.Write(item.Group, item.Attacks +":");
                for (int i = 0; i < item.Percent; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(" ");
                }
                Console.ResetColor();
                Console.WriteLine();
            }

        }

        static int getMaxValue(List<Item> list)
        {
            var maxValue = 0;
            foreach (var item in list)
            {
                if (maxValue < item.Attacks)
                {
                    maxValue = item.Attacks;
                }
            }
            return maxValue;
        }

        static List<Item> SumOfAttacks(List<Item> list)
        {
            List<Item> sum = new List<Item>();
            bool isFound = false;
            sum.Add(new Item(list[0].Group, list[0].Attacks, list[1].Percent));
            for (int i = 1; i < list.Count; i++)
            {
                isFound = false;
                for (int j = 0; j < sum.Count; j++)
                {
                    
                    if (sum[j].Group.CompareTo(list[i].Group) == 0)
                    {
                        isFound = true;
                        sum[j].Attacks += list[i].Attacks;
                        break;
                    }
                }
                if (!isFound)
                {
                    sum.Add(new Item(list[i].Group, list[i].Attacks, list[i].Percent));
                }
            }

            return sum;
        }

        static void CalculatPercentage(int maxValue, List<Item> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Percent = list[i].Attacks * 100 / maxValue;
            }
        }

    }
}
