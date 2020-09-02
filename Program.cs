using System;
using System.Text.Json.Serialization;
using System.IO;
using System.Collections.Generic;
using Pog_To_Json.Classes;
using System.Text.Json;

namespace Pog_To_Json
{
    class Program
    {
        static void Main(string[] args)
        {

            if(args.Length == 0)
            {
                Console.WriteLine("One of the arguments is empty, please specify in arguments input folder and output folder");
                Console.WriteLine("Press any key to exit . . .");
                Console.ReadLine();
                Environment.Exit(0);
            }

            //string[] files = Directory.GetFiles("D:/Games/IGG-HogsofWar/Maps/", "*.POG");
            string[] files = Directory.GetFiles(args[0], "*.POG");

            foreach(string file in files)
            {
                Console.WriteLine("Reading " + file);
                List<MapItemJson> mapElements = new List<MapItemJson>();

                byte[] lol = File.ReadAllBytes(file);
                int blocks = lol.Length / 94;

                for (int i = 1; i < blocks; i++)
                {
                    int endblock = i * 94 + 2;
                    int startblock = endblock - 94;

                    if (endblock < lol.Length)
                    {
                        mapElements.Add(new MapItemJson(new MapItem(lol[startblock..endblock])));
                        //MapItemJson jsonObject = new MapItemJson( new MapItem(lol[2..98]) );
                    }
                }

                string jsonstring = JsonSerializer.Serialize(mapElements, new JsonSerializerOptions { WriteIndented = true });
                jsonstring = jsonstring.Replace("\\u0000", "");

                File.WriteAllText(args[1] + ".JSON",jsonstring);

                Console.WriteLine("succesfully converted file -> " + args[1] + ".JSON" );
            } 
        }
    }
}
