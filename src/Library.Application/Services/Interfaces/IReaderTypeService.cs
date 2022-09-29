using Library.Domain.Models;

namespace Library.Application.Services.Interfaces;

public interface IReaderTypeService
{
    static Dictionary<int, List<ReaderType>> AssignDic() => throw new NotImplementedException();
    static void Assign(Dictionary<int, List<ReaderType>> rolesDic, int existingRole, ReaderType newRole, Reader reader) => throw new NotImplementedException();
}