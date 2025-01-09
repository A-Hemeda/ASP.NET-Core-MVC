namespace MVC.PL.Helper
{
    public static class Documentsettings
    {
        public static string UploudFile(IFormFile file , string folderName)
        {
            //1. get located folder path
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files",folderName);

            //2. Get file Name and make it unique
            var fileName = $"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}";

            //3.Get file path

            var filePath = Path.Combine(folderPath, fileName);
            //4. using
            using var fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);
            return fileName;
        }

        public static void DeleteFile(string folderName, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", folderName, fileName);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        //var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", "Images");
        //var filePath = Path.Combine(folderPath, imageToBeDeleted);
        //System.IO.File.Delete(filePath);
    }
}
