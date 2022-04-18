using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Threading;
using System.IO;

namespace TGMTcs
{
    public class TGMTfile
    {

        public static void MoveFileAsync(string sourceFile, string destFile)
        {
            //Thread t = new Thread(new ThreadStart(File.Move))
        }

        public static string CorrectPath(string path)
        {
            if (path[path.Length - 1] != '\\')
            {
                path += '\\';
            }
            return path;
        }
    }
}
