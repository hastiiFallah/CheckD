using CheckD.Domain.Model;

namespace CheckD.Domain.Command
{
    public interface ICreateCheckListCommand
    {
        Task Execute(CheckListModel checkListModel);
    }
}
