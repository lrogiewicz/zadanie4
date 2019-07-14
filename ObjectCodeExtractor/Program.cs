using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeCorp.Training.Services;
using System.Text.RegularExpressions;


namespace ObjectCodeExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            LegacyObjectMetadataProvider.V1 metadataProviderVersion1 = new LegacyObjectMetadataProvider.V1();
            string metadata = metadataProviderVersion1.ProvideMetadata();
            Console.WriteLine($"Getting product code from {metadata}");
            string code = GetCode(metadata);
            Console.WriteLine($"Recognized code as [{code}]");

            ObjectCodeValidator validator = new ObjectCodeValidator();
            validator.AssertCodeIsValid(code, metadata); //tu walidujemy czy Wasza logika zadziałała

            Console.WriteLine($"Code [{code}] is valid");
            Console.ReadKey();

        }

        static string GetCode(string metadata)
        {
            Regex rx = new Regex("_...~");
            //metadata = Console.ReadLine();
            MatchCollection matches = rx.Matches(metadata);
            return matches[1].ToString();
        }
    }
}
