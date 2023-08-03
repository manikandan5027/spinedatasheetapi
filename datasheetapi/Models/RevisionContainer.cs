using System.ComponentModel.DataAnnotations.Schema;

namespace datasheetapi.Models;

public class RevisionContainer : BaseEntity
{
    public string RevisionContainerName { get; set; } = string.Empty;
    public int RevisionNumber { get; set; }
    public DateTimeOffset RevisionContainerDate { get; set; } = DateTimeOffset.Now;

    [NotMapped]
    public List<Guid> TagDataIds { get; set; } = new List<Guid>();
    public RevisionContainerReview? RevisionContainerReview { get; set; }
    public Guid ContractId { get; set; }
    public Contract? Contract { get; set; }
}