using Library.Domain.Models;

namespace Library.Application.Utils;

public static class ReaderTypeHelper
{
    public static Dictionary<ReaderType, List<ReaderType>> PossibleReaderTypes()
    {
        var studentRole = new List<ReaderType>
        {
            ReaderType.Employee,
            ReaderType.Lecturer,
            ReaderType.Student
        };
        var lectureRole = new List<ReaderType>
        {
            ReaderType.Employee,
            ReaderType.Lecturer
        };
        var employeeRole = new List<ReaderType> { ReaderType.Employee };

        return new Dictionary<ReaderType, List<ReaderType>>
        {
            {ReaderType.Student, studentRole},
            {ReaderType.Lecturer, lectureRole},
            {ReaderType.Employee, employeeRole}
        };
    }

    public static bool Assign(Dictionary<ReaderType, List<ReaderType>> rolesDic, ReaderType existingRole, ReaderType newRole, Reader reader)
    {
        bool isAssign;
        if (rolesDic.ContainsKey(existingRole))
        {
            var possibleReaderTypes = rolesDic[existingRole];

            if (possibleReaderTypes.Contains(newRole))
            {
                reader.ReaderType = newRole;
                isAssign = true;
            }
            else
            {
                isAssign = false;
            }
        }
        else
        {
            isAssign = false;
        }
        return isAssign;
    }
}