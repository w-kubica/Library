namespace Library.Domain.Models
{
    public class Reader
    {
        public int Id { get; set; }
        public string Pesel { get; set; }
        public ReaderType ReaderType { get; set; }

        public Reader(int id, string pesel, ReaderType readerType)
        {
            (Id, Pesel, ReaderType) = (id, pesel, readerType);
        }

        public Reader(string pesel, ReaderType readerType)
        {
            (Pesel, ReaderType) = (pesel, readerType);
        }
        public Reader(int id, ReaderType readerType)
        {
            (Id, ReaderType) = (id, readerType);
        }
    }
}
