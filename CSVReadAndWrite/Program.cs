using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CSVReadAndWrite
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Lines = File.ReadAllLines(@"../../../MOCK_DATA.csv");
            string OutPath = "../../../Out.json";
            List<Dictionary<string, string>> Output = new List<Dictionary<string, string>>();

            var ListofHeaders = Lines[0].Split(",");

            string Id = ListofHeaders[0];
            string FirstName = ListofHeaders[1];
            string LastName = ListofHeaders[2];
            string Email = ListofHeaders[3];
            string Gender = ListofHeaders[4];
            string IPAddress = ListofHeaders[5];

            for (int i = 1; i < Lines.ToList().Count(); i++)
            {
                Dictionary<string, string> Member = new Dictionary<string, string>();
                var Data = Lines[i].Split(",");
                Member.Add(Id, Data[0]);
                Member.Add(FirstName, Data[1]);
                Member.Add(LastName, Data[2]);
                Member.Add(Email, Data[3]);
                Member.Add(Gender, Data[4]);
                Member.Add(IPAddress, Data[5]);
                Output.Add(Member);
            }

            var Out = JsonSerializer.Serialize(Output);
            File.WriteAllText(OutPath, Out);
        }
    }
}
