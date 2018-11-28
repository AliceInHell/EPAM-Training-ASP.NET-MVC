using System;
using UrlToXmlConverter;
using NLog;

namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            FileRepository fileRepository = new FileRepository();
            fileRepository.Load("./Source.txt");

            UrlValidator validator = new UrlValidator();
            ILogger logger = LogManager.GetCurrentClassLogger();
            UrlConverter converter = new UrlConverter(validator, logger);

            XmlSerializer xmlSerializer = new XmlSerializer();
            xmlSerializer.Serialize(converter.Convert(fileRepository.Provide()), "./Result.txt");

            Console.ReadLine();
        }
    }
}
