using System;
using System.Collections.Generic;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace Proiect_C_.DBUtils
{
    internal class DBUtils
    {
        static List<string> files;
        public static void UnzipArchive(string password)
        {
            files = new List<string>();
            try
            {
                using (FileStream fileStream = new FileStream(@"./DBUtils/db_utils.zip", FileMode.Open))
                using (ZipFile zipFile = new ZipFile(fileStream))
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        zipFile.Password = password;
                    }

                    foreach (ZipEntry entry in zipFile)
                    {
                        if (!entry.IsFile)
                            continue;

                        string entryFileName = entry.Name;
                        string fullEntryPath = Path.Combine(@"./", entryFileName);
                        files.Add(entryFileName);
                        using (Stream zipStream = zipFile.GetInputStream(entry))
                        using (FileStream outputFileStream = File.Create(fullEntryPath))
                        {
                            byte[] buffer = new byte[4096];
                            int bytesRead;
                            while ((bytesRead = zipStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                outputFileStream.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }
        }
        public static void DeleteFiles()
        {
            foreach(var itm in files)
            {
                File.Delete(itm);
            }
        }
    }
}
