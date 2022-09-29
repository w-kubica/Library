namespace Library.Application.Utils
{
    /// <summary>
    /// Klasa ta jest symulacją zachowania systemu zewnętrznego. Służy do generowania danych, które pochodzą od systemu zewnętrznego opisanego w treści zadania . 
    /// Ta klasa nie jest częścią mojego modułu - biblioteka. Jest tylko symulacja.
    /// Do operacji systemu zewnętrznego należy określenie daty wypożyczenia książki, daty zwrotu książki, terminu zwrotu książki oraz podjęciu decyzji o naliczeniu kary.
    /// </summary>
    public static class ExternalSystemHelper
    {
        public static DateTime GetDateReturned(DateTime issuedDate)
        {
            Random random = new Random();
            var dateReturned = issuedDate.AddDays(random.Next(57, 100)).Date;
            return dateReturned;
        }

        public static DateTime GetDueDate(DateTime issuedDate)
        {
            var dueDate = issuedDate.AddDays(60).Date;
            return dueDate;
        }

        public static DateTime GetIssuedDate()
        {
            var issuedDate = RandomDay().Date;
            return issuedDate;
        }

        public static bool GetIsCharged(decimal overdueFine)
        {
            bool isCharged = false;
            if (overdueFine > 0)
            {
                Random rng = new Random();
                isCharged = rng.Next(0, 2) > 0;
            }
            return isCharged;
        }

        private static DateTime RandomDay()
        {
            Random gen = new Random();
            DateTime start = new DateTime(2022, 1, 1);
            int range = (DateTime.Today - start).Days;
            var date = start.AddDays(gen.Next(range));
            return date.Date;
        }
    }
}
