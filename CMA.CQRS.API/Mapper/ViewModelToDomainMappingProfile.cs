using AutoMapper;
using CMA.CQRS.API.Models;
using CMA.CQRS.Domain.Commands.Model;

namespace CMA.CQRS.API.Mapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CreateUserDto, NewUserCommand>()
                .ConstructUsing(c => new NewUserCommand(c.Name, c.Address));
        }
    }
}
