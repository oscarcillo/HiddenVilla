using System;
using System.IO;
using System.Threading.Tasks;
using HiddenVilla.Server.Service.IService;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;

namespace HiddenVilla.Server.Service
{
    public class FileUpload : IFileUpload
    {

        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUpload(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadFile(IBrowserFile file)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(file.Name);
                var fileName = Guid.NewGuid() + fileInfo.Extension;
                var folderDirectory = $"{_webHostEnvironment.WebRootPath}\\RoomImages";
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "RoomImages", fileName);

                var memoryStream = new MemoryStream();
                await file.OpenReadStream().CopyToAsync(memoryStream);

                if (!Directory.Exists(folderDirectory)) Directory.CreateDirectory(folderDirectory);

                await using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
                memoryStream.WriteTo(fileStream);

                return $"RoomImages/{fileName}";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteFile(string filename)
        {
            try
            {
                var path = $"{_webHostEnvironment.WebRootPath}\\RoomImages\\{filename}";
                if (File.Exists(path))
                {  
                    File.Delete(path);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}