using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Demo.PL.helpers
{
    public class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);
            //make the filename unique
            string fileName = $"{Guid.NewGuid()}{file.FileName}";

            string filePath = Path.Combine(folderPath, fileName);

            var fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);
            return fileName;
        }

        public static void DeleteFile(string fileName, string folderName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName, fileName);

            if (File.Exists(filePath))
                File.Delete(filePath);
        }

    }

}
