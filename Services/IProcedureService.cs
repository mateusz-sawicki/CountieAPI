using CountieAPI.Models;

namespace CountieAPI.Services
{
    public interface IProcedureService
    {
        public int Create(CreateProcedureDto dto);
        public bool Delete(int id);
        public IEnumerable<ProcedureDto> GetAll();
        public ProcedureDto GetById(int id);
        public void Update(ProcedureDto dto, int id);
    }
}
