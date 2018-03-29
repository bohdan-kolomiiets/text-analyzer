using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TextAnalyzer.API.Models;
using TextAnalyzer.DAL.Entities;

namespace TextAnalyzer.API.APIInfrastructure
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<DataDTO, Data>().ReverseMap();
                config.CreateMap<Data, DataDTO>().ReverseMap();
            });
        }
    }
}