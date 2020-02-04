using System;
using System.Xml;
using System.Collections.Generic;

namespace ParseXML
{
    class ExtractRefText
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();                                
            doc.Load("xml_doc.xml");
            XmlNodeList refs = doc.GetElementsByTagName("Reference");                               // Collect list NodeList of "Reference" nodes. 
            string[] targetRefCodes = new string[3] {"MWB", "TRV", "CAR"};                          // Create array of target RefCodes
            
            for(int i = 0; i < refs.Count; i++)                                                     // Iterate through all "Reference" nodes
            {
                string refCode = refs[i].Attributes[0].Value;                                       // Store current RefCode Value (eg. "CAR")
                string refTextValue = refs[i].InnerText;                                            // Store cirrent RefCode Inner Text (eg. 586..)
                
                foreach(string target in targetRefCodes)                                            // Iterate through target RefCode values
                    if(refCode == target)                                                           // Compare Current RefCode Value
                        Console.WriteLine("RefCode: {0}, Value: {1}", refCode, refTextValue);       // Print Result
            }
        }
    }
}
