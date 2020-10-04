using MarsRover.Entity;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace MarsRover.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string size = string.Empty;
            string position = string.Empty;
            string directive = string.Empty;

            #region size
            do
            {
                Console.Write("Size: ");
                size = Console.ReadLine().ToUpper();
            }
            while (!Regex.Match(size, "[0-9]* [0-9]*").Success); 
            #endregion

            while (true)
            {
                #region position
                do
                {
                    Console.Write("Position: ");
                    position = Console.ReadLine().ToUpper();
                }
                while (!Regex.Match(position, "[0-9]* [0-9]* [NSEW]{1}$").Success);
                #endregion
                #region directive
                do
                {
                    Console.Write("Directives: ");
                    directive = Console.ReadLine().ToUpper();
                }
                while (!Regex.Match(directive, "[LRM]*").Success); 
                #endregion

                Rover marsRover = new Rover(int.Parse(GetDataPart(size, 0)),int.Parse(GetDataPart(size, 1)));
                RoverStatus result = marsRover.Move(int.Parse(GetDataPart(position, 0)), int.Parse(GetDataPart(position, 1)), GetDataPart(position, 2), directive);
                if (result.IsError) Console.Write(result.Message);

                else Console.Write($"{result.Position.x} {result.Position.y} {result.Position.direction}");
                Console.WriteLine();
            }
        }

        static string GetDataPart(string data,int index)
        {
            var arr = data.Split(' ');
            return arr[index];
        }

    }
}
