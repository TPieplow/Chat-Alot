using Chat_Alot_Library.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chat_Alot_Library.DbContext;

public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<UserEntity>(options)
{
    public DbSet<MessageEntity> Messages { get; set; }
    public DbSet<FriendEntity> Friends { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<MessageEntity>()
            .HasOne(m => m.MessageSender)
            .WithMany(u => u.MessageSenders)
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<MessageEntity>()
            .HasOne(m => m.MessageReviever)
            .WithMany(u => u.MessageRecievers)
            .HasForeignKey(m =>m.RecieverId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<MessageEntity>()
            .HasIndex(m => m.SenderId)
            .HasDatabaseName("IX_SenderId");

        builder.Entity<MessageEntity>()
            .HasIndex(m => new { m.SenderId, m.RecieverId })
            .HasDatabaseName("IX_Sender_Reciever")
            .IsUnique();

        builder.Entity<MessageEntity>()
            .HasIndex(m => m.RecieverId)
            .HasDatabaseName("IX_RecieverId");

        builder.Entity<MessageEntity>()
            .HasIndex(m => m.SentAt)
            .HasFilter("[SentAt] IS NOT NULL")
            .IsDescending();

        base.OnModelCreating(builder);
    }
}
