using Library.Domain.Models;

namespace Library.Application.Utils;

public class ReaderTypeHelper
{
    public static Dictionary<int, List<ReaderType>> AssignDic()
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
    public static bool Assign(Dictionary<int, List<ReaderType>> rolesDic, int existingRole, ReaderType newRole, Reader reader)
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