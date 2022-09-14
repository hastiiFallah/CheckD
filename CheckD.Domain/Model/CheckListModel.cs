namespace CheckD.Domain.Model
{
    public class CheckListModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public bool IsForTommorow { get; set; }
        public CheckListModel(Guid id, string description, bool isdone, bool isfortommorow)
        {
            Id = id;
            Description = description;
            IsDone = isdone;
            IsForTommorow = isfortommorow;
        }
    }
}
