using System;

namespace MyBlogSite.AdminPanel.Services
{
    public class SaveImageService: ISaveImageInterface
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public SaveImageService(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public string SaveImage(IFormFile newFile)
        {
            string uniqueName = string.Empty;
            if (newFile.FileName != null)
            {
                string uplodFolder = Path.Combine(webHostEnvironment.WebRootPath, "photos");
                uniqueName = Guid.NewGuid().ToString() + "_" + newFile.FileName;
                string filePath = Path.Combine(uplodFolder, uniqueName);
                FileStream fileStream = new FileStream(filePath, FileMode.Create);
                newFile.CopyTo(fileStream);
                fileStream.Close();
            }

            return uniqueName;
        }
        public void DeleteImage(string fileName)
        {
            string uplodFolder = Path.Combine(webHostEnvironment.WebRootPath, "photos");
            string filePath = Path.Combine(uplodFolder, fileName);
            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
        }
    }
}
