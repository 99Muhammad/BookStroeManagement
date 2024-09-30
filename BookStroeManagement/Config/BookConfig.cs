using BookStroeManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStroeManagement.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        void IEntityTypeConfiguration<Book>.Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.BookID);
            builder.Property(x => x.BookID).ValueGeneratedOnAdd().IsRequired();
        }
    }
}
