using FluentValidation.Results;

namespace NeoCode.Blog.Apllication.Notifications;

public interface INotificator
{
    void Handle(Notification notification);
    void Handle(List<ValidationFailure> failures);
    void HandleNotFoudResource();
    IEnumerable<Notification> GetNotifications();
    bool HasNotification { get; }
    bool IsNotFoundResource { get; }

}