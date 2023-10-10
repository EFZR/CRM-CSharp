using AutoMapper;
using CRM.Application.DTO;
using CRM.Domain.Entity;

namespace CRM.Transversal.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customers, CustomersDTO>().ReverseMap();
        CreateMap<Customers, CustomersDTO>().ReverseMap()
            .ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.CustomerId))
            .ForMember(destination => destination.CompanyName, source => source.MapFrom(src => src.CompanyName))
            .ForMember(destination => destination.ContactName, source => source.MapFrom(src => src.ContactName))
            .ForMember(destination => destination.ContactTitle, source => source.MapFrom(src => src.ContactTitle))
            .ForMember(destination => destination.Address, source => source.MapFrom(src => src.Address))
            .ForMember(destination => destination.City, source => source.MapFrom(src => src.City))
            .ForMember(destination => destination.Region, source => source.MapFrom(src => src.Region))
            .ForMember(destination => destination.PostalCode, source => source.MapFrom(src => src.PostalCode))
            .ForMember(destination => destination.Country, source => source.MapFrom(src => src.Country))
            .ForMember(destination => destination.Phone, source => source.MapFrom(src => src.Phone))
            .ForMember(destination => destination.Fax, source => source.MapFrom(src => src.Fax));

        CreateMap<User, UserDTO>().ReverseMap()
            .ForMember(destination => destination.UserID, source => source.MapFrom(src => src.UserID))
            .ForMember(destination => destination.FirstName, source => source.MapFrom(src => src.FirstName))
            .ForMember(destination => destination.LastName, source => source.MapFrom(src => src.LastName))
            .ForMember(destination => destination.UserName, source => source.MapFrom(src => src.UserName))
            .ForMember(destination => destination.Password, source => source.MapFrom(src => src.Password))
            .ForMember(destination => destination.Token, source => source.MapFrom(src => src.Token));
    }
}
