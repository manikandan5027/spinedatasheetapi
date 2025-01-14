using datasheetapi.Adapters;
using datasheetapi.Dtos;
using datasheetapi.Models;

namespace tests.Adapters;
public class RevisionContainerReviewAdapterTests
{
    [Fact]
    public void ToDtoOrNull_WithNullRevisionContainerReview_ReturnsNull()
    {
        // Arrange
        RevisionContainerReview? revisionContainerReview = null;

        // Act
        var result = revisionContainerReview.ToDtoOrNull();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ToDtoOrNull_WithNonNullRevisionContainerReview_ReturnsRevisionContainerReviewDto()
    {
        // Arrange
        var revisionContainerReview = GetRevisionContainerReview(1);

        // Act
        var result = revisionContainerReview.ToDtoOrNull();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(revisionContainerReview.Id, result.Id);
        Assert.Equal(revisionContainerReview.CreatedDate, result.CreatedDate);
        Assert.Equal(revisionContainerReview.ModifiedDate, result.ModifiedDate);
        Assert.Equal(revisionContainerReview.Status.MapReviewStatusModelToDto(), result.Status);
        Assert.Equal(revisionContainerReview.ApproverId, result.ApproverId);
        Assert.Equal(revisionContainerReview.CommentResponsible, result.CommentResponsible);
        Assert.Equal(revisionContainerReview.Approved, result.Approved);
        Assert.Equal(revisionContainerReview.RevisionContainerVersion, result.RevisionContainerVersion);
        Assert.Equal(revisionContainerReview.RevisionContainerId, result.RevisionContainerId);
    }

    [Fact]
    public void ToDto_WithNullRevisionContainerReviews_ReturnsEmptyList()
    {
        // Arrange
        List<RevisionContainerReview>? revisionContainerReviews = null;

        // Act
        var result = revisionContainerReviews.ToDto();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToDto_WithNonNullRevisionContainerReviews_ReturnsListOfRevisionContainerReviewDtos()
    {
        // Arrange
        var revisionContainerReviews = new List<RevisionContainerReview>
                    { GetRevisionContainerReview(1), GetRevisionContainerReview(2),};

        // Act
        var result = revisionContainerReviews.ToDto();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(revisionContainerReviews.Count, result.Count);
        for (int i = 0; i < revisionContainerReviews.Count; i++)
        {
            Assert.Equal(revisionContainerReviews[i].Id, result[i].Id);
            Assert.Equal(revisionContainerReviews[i].CreatedDate, result[i].CreatedDate);
            Assert.Equal(revisionContainerReviews[i].ModifiedDate, result[i].ModifiedDate);
            Assert.Equal(revisionContainerReviews[i].Status.MapReviewStatusModelToDto(), result[i].Status);
            Assert.Equal(revisionContainerReviews[i].ApproverId, result[i].ApproverId);
            Assert.Equal(revisionContainerReviews[i].CommentResponsible, result[i].CommentResponsible);
            Assert.Equal(revisionContainerReviews[i].Approved, result[i].Approved);
            Assert.Equal(revisionContainerReviews[i].RevisionContainerVersion, result[i].RevisionContainerVersion);
            Assert.Equal(revisionContainerReviews[i].RevisionContainerId, result[i].RevisionContainerId);
        }
    }

    [Fact]
    public void ToModelOrNull_WithNullRevisionContainerReviewDto_ReturnsNull()
    {
        // Arrange
        RevisionContainerReviewDto? revisionContainerReviewDto = null;

        // Act
        var result = revisionContainerReviewDto.ToModelOrNull();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ToModelOrNull_WithNonNullRevisionContainerReviewDto_ReturnsRevisionContainerReview()
    {
        RevisionContainerReviewDto revisionContainerReviewDto = GetContainerReviewDto(1);

        // Act
        var result = revisionContainerReviewDto.ToModelOrNull();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(revisionContainerReviewDto.Id, result.Id);
        Assert.Equal(revisionContainerReviewDto.CreatedDate, result.CreatedDate);
        Assert.Equal(revisionContainerReviewDto.ModifiedDate, result.ModifiedDate);
        Assert.Equal(revisionContainerReviewDto.Status.MapReviewStatusDtoToModel(), result.Status);
        Assert.Equal(revisionContainerReviewDto.ApproverId, result.ApproverId);
        Assert.Equal(revisionContainerReviewDto.CommentResponsible, result.CommentResponsible);
        Assert.Equal(revisionContainerReviewDto.Approved, result.Approved);
        Assert.Equal(revisionContainerReviewDto.RevisionContainerVersion, result.RevisionContainerVersion);
        Assert.Equal(revisionContainerReviewDto.RevisionContainerId, result.RevisionContainerId);
        Assert.NotNull(result.Conversations);
        Assert.Empty(result.Conversations);
    }

    [Fact]
    public void ToModel_WithNonNullCreateContainerReviewDtos_ReturnsListOfRevisionContainerReviews()
    {
        // Arrange
        var revisionContainerReviewDto = new CreateContainerReviewDto()
        {
            RevisionContainerId = Guid.NewGuid(),
            Status = ReviewStatusDto.New
        };

        // Act
        var result = revisionContainerReviewDto.ToModel();

        // Assert
        Assert.NotNull(result);

        Assert.Equal(revisionContainerReviewDto.RevisionContainerId, result.RevisionContainerId);
        Assert.Equal(revisionContainerReviewDto.Status.MapReviewStatusDtoToModel(), result.Status);
    }

    private static RevisionContainerReview GetRevisionContainerReview(int version)
    {
        return new RevisionContainerReview
        {
            Id = Guid.NewGuid(),
            CreatedDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow,
            Status = ReviewStatusEnum.New,
            ApproverId = Guid.NewGuid(),
            CommentResponsible = new Guid(),
            Approved = false,
            RevisionContainerVersion = version,
            RevisionContainerId = Guid.NewGuid(),
            Conversations = new List<Conversation>(),
        };
    }

    private static RevisionContainerReviewDto GetContainerReviewDto(int version)
    {
        // Arrange
        return new RevisionContainerReviewDto
        {
            Id = Guid.NewGuid(),
            CreatedDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow,
            Status = ReviewStatusDto.New,
            ApproverId = Guid.NewGuid(),
            CommentResponsible = new Guid(),
            Approved = false,
            RevisionContainerVersion = version,
            RevisionContainerId = Guid.NewGuid(),
        };
    }
}
