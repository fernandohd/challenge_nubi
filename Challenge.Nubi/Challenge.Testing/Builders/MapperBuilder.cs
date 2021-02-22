using AutoMapper;
using Challenge.Api.Configuration;

namespace Challenge.Testing.Builders
{
    public static class MapperBuilder
    {
        public static IMapper GetMapper()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapping()));
            return new Mapper(configuration);
        }
    }
}
