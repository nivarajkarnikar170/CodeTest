using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyFTPClient
{
    class Program
    {        
        static void Main(string[] args)
        {
            var downloadDestination = @"C:\Users\nrajkarnikar\Desktop\audio\"; // or @"D:\audio\"
            var downloadType = "png";    //change to "csv" or desired type

            if (!FTPServices.ListAndDownloadCSV(downloadDestination, downloadType)) {
                Console.WriteLine("Sorry files could not be fetched!!!");                
            }
            Console.ReadKey();
        }
    }
}
