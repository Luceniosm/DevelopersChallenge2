using AutoMapper;

namespace Aplicacao.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
                //cfg.AddProfile<DtoToDomainMappingProfile>();
            });
        }
    }
}
