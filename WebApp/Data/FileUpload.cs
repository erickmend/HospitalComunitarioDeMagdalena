using BlazorInputFile;

namespace WebApp.Data
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUpload(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> Upload(IFileListEntry file)
        {
            string path = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadedFiles", file.Name);
            MemoryStream memoryStream = new MemoryStream();
            await file.Data.CopyToAsync(memoryStream);
            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                memoryStream.WriteTo(fileStream);

            }
            return path;
        }
    }
}
