using System.Collections.Generic;

namespace Alex.Business.Core.Notifications {
    public interface INotifier {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
