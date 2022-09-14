using CheckD.Domain.Model;

namespace CheckD.Domain.Queries
{
    public interface IGetAllCheckList
    {
        Task<IEnumerable<CheckListModel>> Execute();
    }
}
