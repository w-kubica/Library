using Library.Domain.Models;
using Library.Domain.Repositories;
using Library.Infrastructure.Data;
using Library.Infrastructure.DTO;
using Library.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly LibraryContext _context;

        public ReaderRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reader>> GetAllAsync()
        {
            var readers = await _context.Readers.ToListAsync();
            return readers.Select(a => a.ToDomain());
        }

        public async Task<Reader> GetByIdAsync(int id)
        {
            var reader = await _context.Readers.SingleOrDefaultAsync(x => x.Id == id);
            return reader.ToDomain();
        }

        public async Task AddAsync(Reader reader)
        {
            var dto = reader.ToInfrastructure();
            await _context.Readers.AddAsync(dto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Reader reader)
        {
            var dto = reader.ToInfrastructureUpdate();
            _context.Entry(dto).Property(x => x.ReaderType).IsModified = true;

            var existingReader = await GetByIdAsync(reader.Id);
            var existingReaderType = (int)existingReader.ReaderType;

            var newReaderType = reader.ReaderType;

            var readerTypesDic = PossibilitiesOfAssigningARoleDictionary();

            AssignARole(readerTypesDic, existingReaderType, newReaderType, dto);

            //_context.Entry(dto).CurrentValues.SetValues(dto.ReaderType);
            //_context.Readers.Update(dto);
            await _context.SaveChangesAsync();
        }

        private static void AssignARole(Dictionary<int, List<ReaderType>> rolesDic, int readerRole, ReaderType newRole, ReaderDb dto)
        {
            if (rolesDic.ContainsKey(readerRole))
            {
                var possibleReaderTypes = rolesDic[readerRole];

                if (possibleReaderTypes.Contains(newRole))
                {
                    dto.ReaderType = newRole;
                }
                else
                {
                    throw new Exception("A role cannot be changed. Incorrect data.");
                }
            }
            else
            {
                throw new Exception("Wrong data on the database.");
            }
        }

        private static Dictionary<int, List<ReaderType>> PossibilitiesOfAssigningARoleDictionary()
        {
            var studentRole = new List<ReaderType>();
            studentRole.Add(ReaderType.Employee);
            studentRole.Add(ReaderType.Lecturer);
            studentRole.Add(ReaderType.Student);

            var lectureRole = new List<ReaderType>();
            lectureRole.Add(ReaderType.Employee);
            lectureRole.Add(ReaderType.Lecturer);

            var employeeRole = new List<ReaderType>();
            employeeRole.Add(ReaderType.Employee);


            var rolesDic = new Dictionary<int, List<ReaderType>>();
            rolesDic.Add((int)ReaderType.Student, studentRole);
            rolesDic.Add((int)ReaderType.Lecturer, lectureRole);
            rolesDic.Add((int)ReaderType.Employee, employeeRole);
            return rolesDic;
        }

        public async Task DeleteAsync(Reader reader)
        {
            var dto = reader.ToInfrastructure();
            _context.Readers.Remove(dto);
            await _context.SaveChangesAsync();
        }
    }
}
