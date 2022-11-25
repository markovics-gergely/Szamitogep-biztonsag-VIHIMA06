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
        Ciff SaveFile(Guid userId, string tempFilePath, string extension);

        void DeleteFile(string filePath);

        string SanitizeFilename(string fileName);
    }
}
