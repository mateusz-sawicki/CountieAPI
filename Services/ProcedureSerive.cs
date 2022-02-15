using AutoMapper;
using CountieAPI.Entities;
using CountieAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountieAPI.Services
{
    public class ProcedureSerive : IProcedureService
    {
        private readonly CountieDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProcedureSerive(CountieDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IEnumerable<ProcedureDto> GetAll()
        {
            var procedures = _dbContext
                .Procedures
                .Include(p => p.Category)
                .ToList();

            var proceduresDtos = _mapper.Map<List<ProcedureDto>>(procedures);

            return proceduresDtos;
        }
        public ProcedureDto GetById(int id)
        {
            var procedure = _dbContext
                .Procedures
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);

            if (procedure == null)
                throw new Exception("Nie znaleziono procedury");

            var result = _mapper.Map<ProcedureDto>(procedure);
            return result;
        }
        public int Create(CreateProcedureDto dto)
        {
            var procedureEntity = _mapper.Map<Procedure>(dto);

            _dbContext.Procedures.Add(procedureEntity);
            _dbContext.SaveChanges();

            return procedureEntity.Id;
        }
        
        public bool Delete(int id)
        {
            var procedure = _dbContext
                .Procedures
                .FirstOrDefault(p => p.Id == id);

            if (procedure is null)
                return false;

            _dbContext.Procedures.Remove(procedure);
            _dbContext.SaveChanges();
            return true;
        }

        public void Update(ProcedureDto dto, int id)
        {
            var procedure = _dbContext
                .Procedures
                //.Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);

            procedure.Name = dto.Name;
            procedure.Description = dto.Description;
            procedure.Price = dto.Price;
            procedure.IsFavourite = dto.IsFavourite;

            /*Category category = _dbContext.Categories.Include(c => c.Id).ToList().SingleOrDefault(p => p.Id == dto.CategoryId);*/
            procedure.CategoryId = dto.CategoryId;

            _dbContext.SaveChanges();
        }


    }
}
