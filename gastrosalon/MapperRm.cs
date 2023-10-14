using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gastrosalon
{
    public class MapperRm
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                //Configuring Employee and EmployeeDTO
                cfg.CreateMap<Product, CsvColumns>()
                //Provide Mapping Configuration of FullName and Name Property
                .ForMember(dest => dest.Symbol, act => act.MapFrom(src => src.Itemcode))

                //Provide Mapping Dept of FullName and Department Property
                .ForMember(dest => dest.EAN, act => act.MapFrom(src => src.Code));
                //Any Other Mapping Configuration ....
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
        }
}
