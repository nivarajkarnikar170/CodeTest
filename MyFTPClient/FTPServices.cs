using MyFTPClient.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyFTPClient
{
    public static class FTPServices
    {
        public static string FTPServerAddress { get { return Settings.Default.FTPServerAddress; } }
        public static string FTPServerUserName { get { return Settings.Default.FTPServerUserName; } }
        public static string FTPServerPassword { get { return Settings.Default.FTPServerPassword; } }

        public static bool ListAndDownloadCSV(string downloadDestination, string downloadType)
        {
            try
            {
                //FtpWebRequest Initialization
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FTPServerAddress);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(FTPServerUserName, FTPServerPassword);

            
                //FtpWebResponse Initialization and Use StreamReader to Read from ResponseStream
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {

                    Stream responseStream = response.GetResponseStream();
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        string fileName = reader.ReadLine();
                        int countSpecifiedFileType = 0;
                        if (string.IsNullOrEmpty(fileName))
                        {
                            return false; //no file found
                        }

                        Console.WriteLine(string.Format("{0} files from {1} \n", downloadType.ToUpper(), FTPServerAddress));

                        while ((fileName = reader.ReadLine()) != null)
                        {
                            if (fileName.Contains("." + downloadType))
                            {
                                countSpecifiedFileType++;
                                var downloadSuccess = DownloadFile(fileName, downloadDestination + fileName);
                                if (downloadSuccess)
                                    Console.WriteLine(fileName);
                                else
                                    Console.WriteLine(string.Format("{0} : Sorry this file could not be downloaded from {1}", fileName, FTPServerAddress));
                            }
                        }
                        if (countSpecifiedFileType == 0) {
                            Console.WriteLine(string.Format("Files of type {0} not found in {1}!!!", downloadType.ToUpper(), FTPServerAddress));                            
                        }
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return false;
            }
            Console.WriteLine(string.Format("\n {0} Files Saved At {1}.", downloadType.ToUpper(), FTPServerAddress, downloadDestination));
            return true;
        }

        public static bool DownloadFile(string fileName, string downloadDestination)
        {
            const int buffer_size = 1024;
            byte[] buffer = new byte[buffer_size];
            int bytesRead = 0;
            try
            {
                //FtpWebRequest Initialization for Download
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FTPServerAddress + fileName);
                request.Method = WebRequestMethods.Ftp.DownloadFile;          
                request.Credentials = new NetworkCredential(FTPServerUserName, FTPServerPassword);

            
                //FtpWebResponse Initialization and Use StreamReader to Read from ResponseStream
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    Stream responseStream = response.GetResponseStream();
                    //create directory if does not already exist
                    Directory.CreateDirectory(Path.GetDirectoryName(downloadDestination));
                    using (FileStream fs = new FileStream(downloadDestination, FileMode.Create))
                    {
                        while (true)
                        {
                            bytesRead = responseStream.Read(buffer, 0, buffer.Length);
                            if (bytesRead == 0)
                                break;
                            fs.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
    }
}
