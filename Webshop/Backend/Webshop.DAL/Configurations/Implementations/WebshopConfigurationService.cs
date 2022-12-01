using Webshop.DAL.Configurations.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.DAL.Configurations.Implementations
{
    public class WebshopConfigurationService : IWebshopConfigurationService
    {
        private readonly WebshopConfiguration _config;
        private readonly string _defaultContentPath;
        private const string _staticRequestPath = "files";
        private const string _imagesRelativePath = "images";
        private const string _caffsRelativePath = "caffs"; 
        private const string _caffMetaRelativePath = "caffs\\metadata";

        public WebshopConfigurationService(IOptions<WebshopConfiguration> options, IHostingEnvironment environment)
        {
            _defaultContentPath = environment.WebRootPath;
            _config = options.Value;
        }

        public int GetMaxUploadCount()
        {
            return _config.MaxUploadCount;
        }

        public int GetMaxUploadSize()
        {
            return _config.MaxUploadCount;
        }

        public string GetStaticFilePhysicalPath()
        {
            var webroot = string.IsNullOrWhiteSpace(_config.StaticFilePath) ? _defaultContentPath : _config.StaticFilePath;
            return webroot;
        }

        public string GetImagesSubdirectory()
        {
            return _imagesRelativePath;
        }

        public string GetStaticFileRequestPath()
        {
            return _staticRequestPath;
        }

        public string GetCaffsSubdirectory()
        {
            return _caffsRelativePath;
        }

        public string GetCaffMetaSubdirectory()
        {
            return _caffMetaRelativePath;
        }
    }
}
