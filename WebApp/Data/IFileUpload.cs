using BlazorInputFile;

namespace WebApp.Data
{
    public interface IFileUpload
    {
        Task<string> Upload(IFileListEntry file);
    }
}
