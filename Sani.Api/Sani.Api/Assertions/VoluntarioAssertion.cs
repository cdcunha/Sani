using Sani.Api.Notifications;
using System;

namespace Sani.Api.Assertions
{
    public class VoluntarioAssertion
    {
        public bool HasNotification { get; private set; }
        public NotificationHandler Notifications { get; private set; }

        public VoluntarioAssertion(Models.Voluntario voluntario, bool canIdNull = false)
        {
            if (voluntario == null)
            {
                throw new Exception("O parâmetro voluntario não pode ser nulo [classe VoluntarioAssertion]");
            }
            Notifications = new NotificationHandler();

            if (!canIdNull)
            {
                if (voluntario.Id == Guid.Empty)
                    SetNofication("500", "O ID não pode ser nulo");
            }

            if (string.IsNullOrEmpty(voluntario.Nome))
                SetNofication("500", "Informe o Nome");
            
        }

        private void SetNofication(string key, string value)
        {
            Notifications.Handle(key, value);
            if (HasNotification)
                HasNotification = false;
        }
    }
}
