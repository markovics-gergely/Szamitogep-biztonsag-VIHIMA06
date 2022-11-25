﻿using Webshop.DAL.Configurations;
using Webshop.DAL.Configurations.Interfaces;
using Webshop.DAL.Domain;
using Webshop.DAL.Repository.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.DAL.Repository.Implementations
{
    public class FileRepository : IFileRepository
    {
        private readonly IWebshopConfigurationService _webshopConfiguration;

        public FileRepository(IWebshopConfigurationService webshopConfiguration)
        {
            _webshopConfiguration = webshopConfiguration;
        }

        public void DeleteFile(string filePath)
        {
            File.Delete(filePath);
        }

        public string SanitizeFilename(string fileName)
        {
            var file = Path.GetFileName(fileName);
            var htmlEncoded = WebUtility.HtmlEncode(file);
            return htmlEncoded;
        }

        public Ciff SaveFile(Guid userId, string tempFilePath, string extension)
        {
            var fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
            var userDir = $"{_webshopConfiguration.GetStaticFilePhysicalPath()}\\{_webshopConfiguration.GetImagesSubdirectory()}\\{userId}";
            var savePath = $"{userDir}\\{fileName}{extension}";
            if (!Directory.Exists(userDir))
            {
                Directory.CreateDirectory(userDir);
            }
            File.Copy(tempFilePath, savePath);
            File.Delete(tempFilePath);
            var attributes = new FileInfo(savePath);
            return new Ciff
            {
                DisplayPath = $"/{userId}/{fileName}{extension}",
                PhysicalPath = savePath,
                Size = attributes.Length / Math.Pow(1024, 2),
            };
        }
    }
}
