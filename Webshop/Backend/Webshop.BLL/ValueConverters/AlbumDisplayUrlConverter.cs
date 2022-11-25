using AutoMapper;
using Webshop.BLL.Infrastructure.ViewModels;
using Webshop.DAL.Configurations.Interfaces;
using Webshop.DAL.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BLL.ValueResolvers
{
    public class AlbumDisplayUrlConverter : IValueConverter<Caff, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebshopConfigurationService _webshopConfiguration;

        public AlbumDisplayUrlConverter(IHttpContextAccessor httpContextAccessor, IWebshopConfigurationService webshopConfiguration)
        {
            _httpContextAccessor = httpContextAccessor;
            _webshopConfiguration = webshopConfiguration;
        }

        public string Convert(Caff sourceMember, ResolutionContext context)
        {
            var baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://" +
                $"{_httpContextAccessor.HttpContext.Request.Host}/{_webshopConfiguration.GetStaticFileRequestPath()}/{_webshopConfiguration.GetImagesSubdirectory()}";
            return sourceMember.Ciffs.Count > 0 ? baseUrl + sourceMember.Ciffs.First().DisplayPath : string.Empty;
        }
    }
}
