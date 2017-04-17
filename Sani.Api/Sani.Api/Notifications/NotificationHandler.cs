using System.Collections.Generic;

namespace Sani.Api.Notifications
{
    public class NotificationHandler
    {
        private List<Notification> _notifications;

        public NotificationHandler()
        {
            _notifications = new List<Notification>();
        }

        public void Handle(string key, string value)
        {
            Notification notification = new Notification(key, value);
            this.Handle(notification);
        }

        public void Handle(Notification args)
        {
            _notifications.Add(args);
        }

        public bool HasNotifications()
        {
            return GetValue().Count > 0;
        }

        public IEnumerable<Notification> Notify()
        {
            return GetValue();
        }

        private List<Notification> GetValue()
        {
            return _notifications;
        }

        public void Dispose()
        {
            this._notifications = new List<Notification>();
        }
    }
}
