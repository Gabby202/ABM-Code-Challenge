using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ParseEDIFACT
{
    class locElements
    {
        static void Main(string[] args)
        {
            StreamReader reader = File.OpenText("EDIFACT.txt");         // Open txt file
            string headerLine = reader.ReadLine();                      // store UNA segment for the option of parsing to extract deliminators to use. 
            string segment;                                             // Line of data 
            char[] deliminators = {'+'};                                // array of deliminators to split segments. 
            List<List<String>> matrix= new List<List<String>>();        // 2D List of variable size to index tokenized data
            List<string> targetElements = new List<string>();           // List of variable size to store desired data to be extracted

            while ((segment = reader.ReadLine()) != null)               // Each index of matrix holds a new List containing tokenized data from a segment
                matrix.Add(segment.Split(deliminators).ToList());       // Each new list contains the new line element ID in the first index
                                                                        
            for (int k = 0; k < matrix.Count; k++)                      
                    if(matrix[k][0] == "LOC")                           // Iterate initial list for target element ID. 
                        for (int l = 1; l < matrix[k].Count; l++)       
                                targetElements.Add(matrix[k][l]);       // Extract elements from matrix into list of variable size 

            string[] locElements = targetElements.ToArray();            // Convert list to fixed array 
        }
    }
}                                                                      
