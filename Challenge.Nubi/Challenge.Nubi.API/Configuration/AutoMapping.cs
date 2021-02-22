using AutoMapper;
using Challenge.Nubi.Application.DataModels;
using Challenge.Nubi.Application.Entities;
using Challenge.Nubi.Application.Models;

namespace Challenge.Nubi.API.Configuration
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ExampleEntity, ExampleModel>();
            CreateMap<ExampleDataModel, ExampleModel>();
        }
    }
}
