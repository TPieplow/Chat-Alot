﻿namespace Chat_Alot_Library.Entities;

public class MessageEntity
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public DateTime SentAt { get; set; }

    public UserEntity? MessageSender { get; set; }
    public string SenderId { get; set; } = null!;

    public UserEntity? MessageReviever { get; set; }
    public string RecieverId { get; set; } = null!;
}
