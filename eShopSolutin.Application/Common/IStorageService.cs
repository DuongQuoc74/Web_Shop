using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace eShpsolution.Application.Common
{
    public interface IStorageService // lưu file và lấy thông tin của file
    {
        string GetFileUrl(string fileName);
        Task SaveFileAsync(Stream mediaBinaryStream, string fileName);
        Task DeleteFileAsync(string fileName);
    }
}
