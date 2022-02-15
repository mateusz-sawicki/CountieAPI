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
            CreateMap<CreateProcedureDto, Procedure>()
                .ReverseMap();

            CreateMap<Procedure, ProcedureDto>()
                .ForMember(m => m.CategoryId, c => c.MapFrom(s => s.Category.Id))
                .ForMember(m => m.CategoryName, c => c.MapFrom(s => s.Category.Name))
                .ForMember(m => m.Name, c => c.MapFrom(s => s.Name))
                .ReverseMap();

            CreateMap<CreatePlannerDto, Planner>()
                .ReverseMap();

            CreateMap<Planner, PlannerDto>()
                .ForMember(m => m.DailySummary, c => c.MapFrom(s => s.Procedure.Price))
                .ReverseMap();

            CreateMap<CreateCategoryDto, Category>()
                .ReverseMap();

            CreateMap<Category, CategoryDto>()
                .ReverseMap();
        }
    }
}
