using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.FtpClient;

namespace mantis_tests
{
    public class FtpHelper : HelperBase
    {
        private FtpClient ftpClient;
        public FtpHelper(ApplicationManger manger) : base(manger) {
            ftpClient = new FtpClient();
            ftpClient.Host = "localhost";
            ftpClient.Credentials = new System.Net.NetworkCredential("mantis", "mantis");
            ftpClient.Connect();
        }

        public void BackUpFile(string path)
        {
            string backupPath = path + ".bak";
            if (ftpClient.FileExists(backupPath))
            {
                return;
            }
            ftpClient.Rename(path, backupPath);
        }

        public void RestoreBackupFile(string path)
        {
            string backupPath = path + ".bak";
            if (!ftpClient.FileExists(backupPath))
            {
                return;
            }
            if (ftpClient.FileExists(path))
            {
                ftpClient.DeleteFile(path);
            }
            ftpClient.Rename(backupPath, path);

        }

        public void UploadFile(string path, Stream localFile)
        {
            if (ftpClient.FileExists(path))
            {
                ftpClient.DeleteFile(path);
            }
            using (Stream ftpStream = ftpClient.OpenWrite(path))
            {
                byte[] bytes = new byte[8 * 1024];
                int count = localFile.Read(bytes, 0, bytes.Length);
                while (count > 0)
                {
                    ftpStream.Write(bytes, 0, count);
                    count = localFile.Read(bytes, 0, bytes.Length);
                }

            }
        }
    }
}
