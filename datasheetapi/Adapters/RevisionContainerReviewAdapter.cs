namespace datasheetapi.Adapters;
public static class RevisionContainerReviewAdapter
{
    public static RevisionContainerReviewDto? ToDtoOrNull(this RevisionContainerReview? revisionContainerReview)
    {
        if (revisionContainerReview is null) { return null; }
        return revisionContainerReview.ToDto();
    }

    public static RevisionContainerReviewDto ToDto(this RevisionContainerReview revisionContainerReview)
    {
        return new RevisionContainerReviewDto
        {
            Id = revisionContainerReview.Id,
            CreatedDate = revisionContainerReview.CreatedDate,
            ModifiedDate = revisionContainerReview.ModifiedDate,
            Status = revisionContainerReview.Status.MapReviewStatusModelToDto(),
            ApproverId = revisionContainerReview.ApproverId,
            CommentResponsible = revisionContainerReview.CommentResponsible,
            Approved = revisionContainerReview.Approved,
            RevisionContainerVersion = revisionContainerReview.RevisionContainerVersion,
            RevisionContainerId = revisionContainerReview.RevisionContainerId,
        };
    }

    public static List<RevisionContainerReviewDto> ToDto(this List<RevisionContainerReview>? revisionContainerReviews)
    {
        if (revisionContainerReviews is null) { return new List<RevisionContainerReviewDto>(); }
        return revisionContainerReviews.Select(ToDto).ToList();
    }

    public static RevisionContainerReview? ToModelOrNull(this RevisionContainerReviewDto? revisionContainerReviewDto)
    {
        if (revisionContainerReviewDto is null) { return null; }
        return revisionContainerReviewDto.ToModel();
    }

    public static RevisionContainerReview ToModel(this RevisionContainerReviewDto revisionContainerReviewDto)
    {
        return new RevisionContainerReview
        {
            Id = revisionContainerReviewDto.Id,
            CreatedDate = revisionContainerReviewDto.CreatedDate,
            ModifiedDate = revisionContainerReviewDto.ModifiedDate,
            Status = revisionContainerReviewDto.Status.MapReviewStatusDtoToModel(),
            ApproverId = revisionContainerReviewDto.ApproverId,
            CommentResponsible = revisionContainerReviewDto.CommentResponsible,
            Approved = revisionContainerReviewDto.Approved,
            RevisionContainerVersion = revisionContainerReviewDto.RevisionContainerVersion,
            RevisionContainerId = revisionContainerReviewDto.RevisionContainerId,
        };
    }

    public static RevisionContainerReview ToModel(this CreateContainerReviewDto dto)
    {
        return new RevisionContainerReview
        {
            RevisionContainerId = dto.RevisionContainerId,
            Status = dto.Status.MapReviewStatusDtoToModel(),
        };
    }
}
