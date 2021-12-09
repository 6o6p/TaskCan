using System.Linq;
using Domain.Models.Boards;

namespace DataAccess
{
    public sealed class DatabaseDataContext : IDataContext
    {
        private PostgreContext _context;

        public DatabaseDataContext()
        {
            _context = new PostgreContext();
        }

        public Board GetBoard()
        {
            //При обращении к таблицам используется Linq
            var entity = _context.Boards.FirstOrDefault();

            //В реальных проектах обычно используют Automapper для преобразования одних моделей в другие
            //Для простоты в данном случае просто перекладываем данные из одной модели в другую (Automapper делает тоже самое)
            return entity is not null
                ? new Board
                {
                    Id = entity.Id,
                    UserId = entity.UserId,
                    Title = entity.Title,
                    Description = entity.Description,
                }
                : new Board();
        }
    }
}