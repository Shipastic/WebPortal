using Application.UseCases.DTO;
using AutoMapper;
using Entities.Models;


namespace Application.UseCases.MappingDTO
{
    public class ContractorProfile : Profile
    {
        public ContractorProfile()
        {
            CreateMap<Contractor, ContractorDTO>();
            CreateMap<ContractorDTO, Contractor>();
        }
    }
}
