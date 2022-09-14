namespace CheckD.Domain.Command
{
    public interface IDeleteCheckListCommand
    {
        Task Execute(Guid id);
    }
}
