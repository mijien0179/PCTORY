﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace pctory
{
    static internal class FileIO
    {
        static public void FileOutput(ProcessInfoList procinfo)
        {           
            Stream wstream = new FileStream("C:\\a.dat", FileMode.Create);
            BinaryFormatter serial = new BinaryFormatter();
            serial.Serialize(wstream, procinfo);
            wstream.Close();
        }
        static public ProcessInfoList FileInput(string filePath)
        {

            Stream rstream = new FileStream("C:\\a.dat", FileMode.Open);
            BinaryFormatter deserial = new BinaryFormatter();
            ProcessInfoList proc = new ProcessInfoList();
            proc = (ProcessInfoList)deserial.Deserialize(rstream);
            rstream.Close();
            return proc;        
        }
    }
    
}
