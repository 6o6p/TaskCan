using Domain.Models.Boards;

namespace DataAccess
{
    public interface IDataContext
    {
        Board GetBoard();
    }
}