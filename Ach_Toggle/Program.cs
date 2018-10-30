using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Ach_Toggle
{
    class Program
    {
        static void Main(string[] args)
        {

            //The filepath for the file you want altered needs to be changed here.
            //I would implement it where you drag and drop the file into the program, and
            //it grabs the file path and such. I currently have no clue on making that happen.

            var FilePath = (@"C:\test\AchFile.ach");
            var EditedFile = (@"C:\test\EditedAchFile.ach");

            using (var file = new StreamReader($"{FilePath}"))
            {
                string line;
                line = file.ReadLine();
                int achRecordSize = 94;
                int stringLength = line.Length;

                //Adding line Breaks
                if (achRecordSize != stringLength)
                {
                    using (var editFile = new StreamWriter($"{EditedFile}"))
                    {
                        for (int i = 0; i < stringLength; i += achRecordSize)
                        {
                            if (i + achRecordSize > stringLength) achRecordSize = stringLength - i;
                            editFile.WriteLine(line.Substring(i, achRecordSize));
                        }
                    }
                }
                //Removing line breaks.
                else
                    {
                     using (var editFile = new StreamWriter($"{EditedFile}"))
                    {
                        var CompleteLine = "";
                        
                        foreach(string NextLine in File.ReadLines($"{FilePath}"))
                        {
                            CompleteLine = CompleteLine + NextLine;
                        }
                        editFile.WriteLine(CompleteLine);
                    }
                }
            }
        }
    }
}
