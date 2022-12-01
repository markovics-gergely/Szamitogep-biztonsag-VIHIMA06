using Webshop.DAL.Configurations;
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
        private const string caffSuffix = "caff_meta";
        private const string ciffSuffix = "ciff_meta";

        public FileRepository(IWebshopConfigurationService webshopConfiguration)
        {
            _webshopConfiguration = webshopConfiguration;
        }

        public void DeleteFile(string filePath)
        {
            File.Delete(filePath);
        }

        public Caff ReadMetadata(string path, string caffName, int ciffCount)
        {
            var caffMeta = File.ReadAllText($"{path}\\{caffName}_{caffSuffix}.txt");
            IList<Ciff> ciffs = new List<Ciff>();
            for (int i = 0; i < ciffCount; i++)
            {
                var ciffMeta = File.ReadAllText($"{path}\\{caffName}_{i}_{ciffSuffix}.txt");
                var ciffMetas = ciffMeta.Split("\n", StringSplitOptions.RemoveEmptyEntries);
                ciffs.Add(new Ciff
                {
                    Duration = int.Parse(ciffMetas[0].Split('=')[1]),
                    Caption = ciffMetas[1].Split('=')[1],
                    Tags = ciffMetas[2].Split('=')[1]
                });
            }

            var caffMetas = caffMeta.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            Caff caff = new Caff
            {
                Creator = caffMetas[0].Split('=')[1],
                CreationDate = DateTime.Parse(caffMetas[1].Split('=')[1]),
                Ciffs = ciffs,
            };
            return caff;
        }

        public string SanitizeFilename(string fileName)
        {
            var file = Path.GetFileName(fileName);
            var htmlEncoded = WebUtility.HtmlEncode(file);
            return htmlEncoded;
        }

        public string SaveFile(string tempFilePath, string extension, string relativeOutPath)
        {
            var fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
            var userDir = $"{_webshopConfiguration.GetStaticFilePhysicalPath()}{relativeOutPath}";
            var savePath = $"{userDir}\\{fileName}{extension}";
            if (!Directory.Exists(userDir))
            {
                Directory.CreateDirectory(userDir);
            }
            File.Copy(tempFilePath, savePath);
            File.Delete(tempFilePath);
            return savePath;
        }
    }
}
