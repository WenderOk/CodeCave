using System.Data.Entity;

namespace PcLibraryApp.Infrastructure
{
    public class AppDbInitializer : IDatabaseInitializer<AppDbContext>
    {
        public void InitializeDatabase(AppDbContext context)
        {
            // Если файла БД нет, EF создаст пустой файл
            if (!context.Database.Exists())
            {
                context.Database.Create();
                CreateTables(context);
            }
            else
            {
                // Если файл есть, проверим, создана ли таблица Components
                try
                {
                    // Простой быстрый запрос для проверки существования таблицы
                    context.Database.ExecuteSqlCommand("SELECT 1 FROM Components LIMIT 1;");
                }
                catch
                {
                    // Если упало с ошибкой — таблицы нет, создаем её
                    CreateTables(context);
                }
            }
        }

        private void CreateTables(AppDbContext context)
        {
            // 1. Сначала создаем таблицу сборок, так как на нее будет ссылаться таблица компонентов
            string createBuildsTable = @"
            CREATE TABLE IF NOT EXISTS PcBuilds (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL
            );";

            // 2. Создаем таблицу компонентов с колонкой BuildId
            string createComponentsTable = @"
            CREATE TABLE IF NOT EXISTS Components (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Category TEXT NOT NULL,
                Manufacturer TEXT NOT NULL,
                Model TEXT NOT NULL,
                Price REAL NOT NULL,
                Description TEXT,
                BuildId INTEGER NULL,
                FOREIGN KEY (BuildId) REFERENCES PcBuilds (Id) ON DELETE SET NULL
            );";

            // Выполняем SQL-команды
            context.Database.ExecuteSqlCommand(createBuildsTable);
            context.Database.ExecuteSqlCommand(createComponentsTable);
        }
    }
}
