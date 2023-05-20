using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace Demo.Pl.Helper
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string folderName) { 
        /// 1-Get Folder Path
        var folderPath=Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files" , folderName);
        ///2-Get ImageName and Extension and make it Unique
        var fileName = $"{Guid.NewGuid()}{Path.GetFileName(file.FileName)}";
        ///3-Get FilePath
        var filePath=Path.Combine(folderPath,fileName); 
            ///4-Save File As Stream
         using var fileStream=new FileStream(filePath,FileMode.Create);
            file.CopyTo(fileStream);
            return fileName;
        }

        public static void DeleteFile(string fileName, string folderName)
        {

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", folderName , fileName);

            if(File.Exists(filePath))
            
            File.Delete(filePath);
            

        }

    }
}
