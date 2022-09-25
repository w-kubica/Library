using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Models;

namespace Library.Infrastructure.Mappers
{
    public static class ReaderProfile
    {
        public static ReaderDb ToInfrastructure(this Reader reader) =>
            new(reader.Id,reader.Pesel,reader.ReaderType);

        public static Reader ToDomain(this ReaderDb reader) =>
            new(reader.Id, reader.Pesel, reader.ReaderType);
    }
}
