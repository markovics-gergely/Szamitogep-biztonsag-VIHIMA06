using AutoMapper;
using Webshop.BLL.Infrastructure.ViewModels;
using Webshop.BLL.TypeConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BLL.MappingProfiles
{
    public class ListProfile : Profile
    {
        public ListProfile()
        {
            CreateMap(typeof(IEnumerable<>), typeof(EnumerableWithTotalViewModel<>)).ConvertUsing(typeof(EnumerableWithTotalConverter<,>));
        }
    }
}

