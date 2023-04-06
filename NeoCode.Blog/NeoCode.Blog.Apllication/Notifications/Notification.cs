namespace NeoCode.Blog.Apllication.Notifications;

public class Notification
{
    public string Message { get; set; }

    public Notification(string message)
    {
        Message = message;
    }
}