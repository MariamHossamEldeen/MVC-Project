using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace PL.Helpers
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string FolderName)
        {

            // 1 - Get Located Folder Path
            //string folderPath = "C:\\Users\\maria\\OneDrive\\Documents\\C#\\PL\\PL\\wwwroot\\files\\images\\";
            //string folderPath = Directory.GetCurrentDirectory() + "\\wwwroot\\files\\" + FolderName;
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", FolderName);

            // 2 - Get File Name And Make It Unique
            string fileName = $"{Guid.NewGuid()}{file.FileName}";

            // 3 - Get File Path
            string filePath = Path.Combine(folderPath, fileName);

            // 4 - Save File As Streams (Stream : Data Per Time )
            using var fs = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fs);
            return fileName;

        }


        public static void DeleteFile(string fileName, string folderName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName, fileName);
            if (File.Exists(filePath))
                File.Delete(filePath);

        }
    }
}
