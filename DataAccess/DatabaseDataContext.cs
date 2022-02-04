using System.Linq;
using DataAccess.ContextFactories;
using DataAccess.Models.Boards;
using DataAccess.Models.Teams;
using Domain.Models.Boards;

namespace DataAccess
{
    public sealed class DatabaseDataContext : IDataContext
    {
        private PostgreContext _context;

        public DatabaseDataContext(bool inMemory)
        {
            //Для простоты примера используем параметр inMemory
            //В реальном проекте следовало бы передавать IContextFactory в параметре и просто вызвать CreateContext()
            _context = inMemory 
                ? new InMemoryContextFactory().CreateContext()
                : new DatabaseContextFactory().CreateContext();
        }
        
        public void AddBoard(Board board)
        {
            _context.Add(new BoardEntity
            {
                Id = board.Id,
                UserId = board.UserId,
                Title = board.Title,
                Description = board.Description,
                Owner = new UserEntity
                {
                    Name = board.Owner.Name,
                },
            });
            _context.SaveChanges();
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