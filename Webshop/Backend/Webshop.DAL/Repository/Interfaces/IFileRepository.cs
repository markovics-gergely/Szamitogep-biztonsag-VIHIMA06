using Webshop.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.DAL.Repository.Interfaces
{
    public interface IFileRepository
    {
        string SaveFile(string tempFilePath, string extension, string relativeOutPath);

        Caff ReadMetadata(string path, string caffName, int ciffCount);

        void DeleteFile(string filePath);

        string SanitizeFilename(string fileName);
    }
}
