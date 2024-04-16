using Chat_Alot_Library.DbContext;
using Chat_Alot_Library.Entities;
using Chat_Alot_Library.Repositories;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Infrastructure.Repositories;

public class MessageRepository(DataContext context) : BaseRepository<MessageEntity>(context)
{
    private readonly DataContext _context = context;


}
