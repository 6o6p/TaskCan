using Domain.Models.Boards;

namespace DataAccess
{
    public interface IDataContext
    {
        void AddBoard(Board board);
        Board GetBoard();
    }
}