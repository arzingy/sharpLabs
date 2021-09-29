using System;
using System.Xml;
using System.Xml.Schema;

namespace XML
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xd = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationType = ValidationType.DTD;
            using (XmlReader reader = XmlReader.Create("Lab_work.xml",
            settings))
            {
                try
                {
                    xd.Load(reader);
                }
                catch (XmlSchemaException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            using (XmlReader reader = new XmlTextReader("Lab_work.xml"))
            {
                bool next_line = true;
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            for (int i = 0; i < reader.AttributeCount; i++)
                            {
                                reader.MoveToNextAttribute();
                                Console.WriteLine(@" {0} = {1}", reader.Name, reader.Value);
                            }
                            reader.MoveToElement();
           
                            if (next_line)
                            {
                                Console.WriteLine("///////////////////////////////////");
                                next_line = false;
                            }
                            else next_line = true;

                            break;

                    }
                }
            }

        }
    }
}
