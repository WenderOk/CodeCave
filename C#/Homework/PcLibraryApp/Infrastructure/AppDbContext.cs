using PcLibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcLibraryApp.Infrastructure
{
    public class AppDbContext : DbContext
    {
        private static readonly object _fix = typeof(System.Data.SQLite.EF6.SQLiteProviderFactory);

        public AppDbContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new AppDbInitializer());
        }

        public DbSet<Component> Components { get; set; }
        public DbSet<PcBuild> Builds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настраиваем связь один-ко-многим
            modelBuilder.Entity<PcBuild>()
                .HasMany(b => b.Components) // У одной сборки много компонентов
                .WithOptional()             // Компонент при этом может не иметь сборки (опционально)
                .HasForeignKey(c => c.BuildId) // Внешний ключ в таблице компонентов
                .WillCascadeOnDelete(false);   // Если удалить сборку, детали не удаляются, а просто освобождаются (BuildId станет null)
        }
    }
}
