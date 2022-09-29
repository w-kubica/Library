namespace Library.Application.DTO
{
    public class UpdateBorrowedDto
    {
        public int Id { get; set; }

        public UpdateBorrowedDto(int id)
        {
            (Id) = (id);
        }
        public UpdateBorrowedDto()
        {

        }
    }
}
