using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.DAL.Configurations.Interfaces
{
    public interface IWebshopConfigurationService
    {
        int GetMaxUploadCount();

        int GetMaxUploadSize();

        string GetStaticFilePhysicalPath();

        string GetStaticFileRequestPath();

        string GetImagesSubdirectory();
    }
}
