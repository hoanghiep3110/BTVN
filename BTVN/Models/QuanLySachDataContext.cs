using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BTVN.Models
{
    public partial class QuanLySachDataContext : DbContext
    {
        public QuanLySachDataContext()
            : base("name=QuanLySachDataContext")
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(e => e.ImageCover)
                .IsUnicode(false);
        }
    }
}
