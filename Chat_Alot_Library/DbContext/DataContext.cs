using Chat_Alot_Library.Entities;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chat_Alot_Library.DbContext;

public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<UserEntity>(options)
{
    public DbSet<MessageEntity> Messages { get; set; }
    public DbSet<FriendEntity> Friends { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<ServerEntity> Servers { get; set; }
    public DbSet<ChannelEntity> Channels { get; set; }
    public DbSet<MutualFriendEntity> MutualFriends { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // UserEntity
        builder.Entity<UserEntity>()
            .HasIndex(u => u.Email)
            .HasDatabaseName("IX_Email");

        builder.Entity<UserEntity>()
            .HasIndex(u => u.Id)
            .HasDatabaseName("IX_Id");

        builder.Entity<UserEntity>()
            .HasIndex(u => new { u.Id, u.Email })
            .HasDatabaseName("IX_Id_Email")
            .IsUnique();

        // FriendEntity 
        builder.Entity<FriendEntity>()
            .HasIndex(f => f.Id)
            .HasDatabaseName("IX_Id");

        builder.Entity<FriendEntity>()
            .HasIndex(f => f.UserId)
            .HasDatabaseName("IX_UserId");

        builder.Entity<FriendEntity>()
       .HasOne(f => f.User)
       .WithMany(u => u.Friends)
       .HasForeignKey(f => f.UserId)
       .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<FriendEntity>()
            .HasOne(f => f.Friend)
            .WithMany()
            .HasForeignKey(f => f.FriendId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<FriendEntity>()
        .HasMany(f => f.MutualFriends)
        .WithMany()
        .UsingEntity<MutualFriendEntity>(
            j => j
                .HasOne(mf => mf.MutualFriend)
                .WithMany()
                .HasForeignKey(mf => mf.MutualFriendId),
            j => j
                .HasOne(mf => mf.Friend)
                .WithMany()
                .HasForeignKey(mf => mf.FriendId),
            j =>
            {
                j.ToTable("MutualFriends");
                j.HasKey(mf => new { mf.FriendId, mf.MutualFriendId });
            });

        // MessageEntity
        builder.Entity<MessageEntity>()
            .HasOne(m => m.MessageSender)
            .WithMany(u => u.MessageSenders)
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<MessageEntity>()
            .HasOne(m => m.MessageReviever)
            .WithMany(u => u.MessageRecievers)
            .HasForeignKey(m => m.RecieverId)
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

       // Channel Entity
        builder.Entity<ChannelEntity>()
            .HasIndex(c => c.Id)
            .HasDatabaseName("IX_ChannelId");

        builder.Entity<ChannelEntity>()
            .HasIndex(c => c.ServerId)
            .HasDatabaseName("IX_ServerId");

        builder.Entity<ChannelEntity>()
            .HasOne(c => c.Server)
            .WithMany(s => s.Channels)
            .HasForeignKey(c => c.ServerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Server Entity
        builder.Entity<ServerEntity>()
            .HasMany(s => s.Members)
            .WithMany(u => u.Servers)
            .UsingEntity<ServerUser>(
            j => j
                 .HasOne(su => su.User)
                 .WithMany()
                 .HasForeignKey(su => su.UserId),
            j => j
                .HasOne(su => su.Server)
                .WithMany()
                .HasForeignKey(su => su.ServerId),
            j =>
            {
                j.ToTable("ServerUser");
                j.HasKey(su => new { su.ServerId, su.UserId });
            });

        base.OnModelCreating(builder);
    }
}
