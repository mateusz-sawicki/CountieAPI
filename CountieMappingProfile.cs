using AutoMapper;
using CountieAPI.Entities;
using CountieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountieAPI
{
    public class CountieMappingProfile : Profile
    {
        public CountieMappingProfile()
        {
            CreateMap<CreateProcedureDto, Procedure>();

            CreateMap<Procedure, ProcedureDto>()
                .ForMember(m => m.CategoryId, c => c.MapFrom(s => s.Category.Id))
                .ForMember(m => m.Name, c => c.MapFrom(s => s.Name));

            CreateMap<CreatePlannerDto, Planner>();

            CreateMap<Planner, PlannerDto>()
                .ForMember(m => m.ProcedureName, c => c.MapFrom(p => p.Procedure.Name));
        }
    }
}
