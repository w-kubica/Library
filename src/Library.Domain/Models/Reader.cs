namespace Library.Domain.Models
{
    public class Reader
    {
        public int Id { get; set; }
        public string Pesel { get; set; }
        public ReaderType ReaderType { get; set; }
    }


}
