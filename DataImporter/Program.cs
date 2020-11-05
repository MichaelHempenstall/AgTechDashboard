using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace DataImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading File");

            //check parameters (FarmName,MachineName,Filename) 
            //if (args.Count != 3)
            //{
            //    Console.WriteLine("Parameters Incorrect");
            //    Console.WriteLine("FarmName MachineName Filename");
            //}
            //else
            //{
            //    //FileData.Loadfile();

            //    //GetOrCreateFarmId();

            //    //GetOrCreateMachineId();

            //    //LoadFileToDatabase();
            //}
        }

        private static void GetOrCreateFarmId()
        {
            throw new NotImplementedException();
        }

        private static void Loadfile()
        {
            throw new NotImplementedException();
        }
    }
}
