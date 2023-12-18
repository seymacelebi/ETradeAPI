using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Services;


public interface IFileService
{
    Task<List<(string fileName, string path)>> UploadFileAsync(string path, IFormFileCollection files);
    Task<string> FileRenameAsync (string fileName);
    Task<bool> CopyFileAsync(string path, IFormFile file);
}
