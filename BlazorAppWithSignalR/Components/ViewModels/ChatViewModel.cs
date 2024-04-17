namespace BlazorAppWithSignalR.Components.ViewModels
{
    public class ChatViewModel
    {
        public string UserName { get; set; } = null!;
        public string? ProfileImageURL { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
