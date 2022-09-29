namespace Library.Infrastructure.Repositories
{
    public class ExternalSystemService
    {
        public static DateTime GettingDateReturned(DateTime issuedDate)
        {
            Random random = new Random();
            var dateReturned = (issuedDate.AddDays(random.Next(57, 100))).Date;
            return dateReturned;
        }

        public static DateTime GettingDueDate(DateTime issuedDate)
        {
            var dueDate = (issuedDate.AddDays(60)).Date;
            return dueDate;
        }

        public static DateTime GettingIssuedDate()
        {
            var issuedDate = RandomDay().Date;
            return issuedDate;
        }

        public static bool GettingIsCharged(decimal overdueFine)
        {
            bool isCharged = false;
            if (overdueFine > 0)
            {
                Random rng = new Random();
                isCharged = rng.Next(0, 2) > 0;
            }
            return isCharged;
        }

        public static DateTime RandomDay()
        {
            Random gen = new Random();
            DateTime start = new DateTime(2022, 1, 1);
            int range = (DateTime.Today - start).Days;
            var date = start.AddDays(gen.Next(range));
            return date.Date;
        }
    }
}
