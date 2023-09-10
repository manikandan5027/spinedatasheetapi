using AutoMapper;

namespace datasheetapi.Adapters;
public static class CommentAdapter
{
    public static Conversation ToModel(this CreateCommentDto commentDto,
                            Guid reviewId,
                            Guid azureUniqueId)
    {
        MessageDto messageDto = new MessageDto();
        messageDto.Text = commentDto.Text;
        return new Conversation
        {
            Property = commentDto.Property,
            ConversationLevel = commentDto.ConversationLevel,
            ConversationStatus = commentDto.ConversationStatus,
            TagDataReviewId = reviewId,
            Messages = new List<Message> { messageDto.ToMessageModel(azureUniqueId) },
            Participants = new List<Participant> { ToParticipantModel(azureUniqueId) }
        };
    }

    public static ConversationDto ToDto(this Conversation conversation,
                            Dictionary<Guid, string> userIdNameMap)
    {
        return new ConversationDto
        {
            Id = conversation.Id,
            CreatedDate = conversation.CreatedDate,
            ModifiedDate = conversation.ModifiedDate,
            Property = conversation.Property,
            ConversationLevel = conversation.ConversationLevel,
            ConversationStatus = conversation.ConversationStatus,
            Messages = ToMessageDtos(conversation.Messages, userIdNameMap),
            Participants = ToParticipantDtos(conversation.Participants, userIdNameMap),
        };
    }

    public static Message ToMessageModel(
                    this MessageDto messageDto,
                    Guid azureUniqueId)
    {
        return new Message
        {
            Text = messageDto.Text,
            UserId = azureUniqueId,
            CreatedDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow
        };
    }

    public static List<GetMessageDto> ToMessageDtos(this List<Message> messages,
                                                    Dictionary<Guid, string> userIdNameMap)
    {
        //TODO: Handle the null userid in dict
        return messages.Select(message =>
            ToMessageDto(message, userIdNameMap[message.UserId])).ToList();
    }

    public static GetMessageDto ToMessageDto(
                    this Message message,
                    string commenterName)
    {
        return new GetMessageDto
        {
            Id = message.Id,
            Text = message.SoftDeleted ? "" : message.Text,
            UserId = message.UserId,
            CommenterName = commenterName,
            IsEdited = message.IsEdited,
            SoftDeleted = message.SoftDeleted,
            CreatedDate = message.CreatedDate,
            ModifiedDate = message.ModifiedDate
        };
    }

    public static Participant ToParticipantModel(Guid azureUniqueId)
    {
        return new Participant
        {
            UserId = azureUniqueId,
            CreatedDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow
        };
    }

    public static List<UserDto> ToParticipantDtos(this List<Participant> participants,
                                                    Dictionary<Guid, string> userIdNameMap)
    {
        return participants.Select(user =>
            ToParticipantDto(user, userIdNameMap[user.UserId])).ToList();
    }

    public static UserDto ToParticipantDto(
                    Participant participant,
                    string commenterName)
    {
        return new UserDto
        {
            UserId = participant.UserId,
            UserName = commenterName
        };
    }
}
