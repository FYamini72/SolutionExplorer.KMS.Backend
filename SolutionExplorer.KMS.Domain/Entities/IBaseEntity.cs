namespace SolutionExplorer.KMS.Domain.Entities
{
    public interface IBaseEntity
    {
        int Id { get; set; }

        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }

        int? CreatedByUserId { get; set; }
        int? ModifiedByUserId { get; set; }
    }

    /// => CRUD
    public interface ILogCreateEvent { }
    public interface ILogUpdateEvent { }
    public interface ILogDeleteEvent { }
}
