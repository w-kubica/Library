using Library.Application.Services.Interfaces;
using Library.Domain.Models;

namespace Library.Application.Utils
{
    public static class OverdueFineHelper
    {
        public static int CalculateDaysOfDelay(DateTime dateReturned, DateTime dueDate)
        {
            var daysOfDelay = (dateReturned - dueDate).Days;
            if (daysOfDelay < 0)
            {
                daysOfDelay = 0;
            }
            return daysOfDelay;
        }

        public static decimal Calculate(ReaderType readerType, int daysOfDelay)
        {
            decimal overdueFine;
            if (readerType == ReaderType.Lecturer)
            {
                overdueFine = ForLecturers(daysOfDelay);
            }
            else if (readerType == ReaderType.Student)
            {
                overdueFine = ForStudents(daysOfDelay);
            }
            else if (readerType == ReaderType.Employee)
            {
                overdueFine = ForEmployees(daysOfDelay);
            }
            else
            {
                throw new Exception("Bad reader ID");
            }

            return overdueFine;
        }
        private static decimal ForEmployees(int daysOfDelay)
        {
            decimal overdueFine;
            if (daysOfDelay <= 28)
            {
                overdueFine = 0;
            }
            else
            {
                overdueFine = daysOfDelay * 5;
            }

            return overdueFine;
        }

        private static decimal ForStudents(int daysOfDelay)
        {
            decimal overdueFine;
            if (daysOfDelay <= 7)
            {
                overdueFine = daysOfDelay * 1;
            }
            else if (daysOfDelay > 7 && daysOfDelay <= 14)

            {
                overdueFine = daysOfDelay * 2;
            }
            else if (daysOfDelay > 14 && daysOfDelay <= 28)
            {
                overdueFine = daysOfDelay * 5;
            }
            else
            {
                overdueFine = daysOfDelay * 10;
            }

            return overdueFine;
        }

        private static decimal ForLecturers(int daysOfDelay)
        {
            decimal overdueFine;
            if (daysOfDelay <= 3)
            {
                overdueFine = 0;
            }
            else if (daysOfDelay > 3 && daysOfDelay <= 14)
            {
                overdueFine = daysOfDelay * 2;
            }
            else if (daysOfDelay > 14 && daysOfDelay <= 28)
            {
                overdueFine = daysOfDelay * 5;
            }
            else
            {
                overdueFine = daysOfDelay * 10;
            }

            return overdueFine;
        }
    }
}
