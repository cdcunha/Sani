using Sani.Api.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sani.Api.Assertions
{
    public class ApoiadoAssertion
    {
        public NotificationHandler Notifications { get; private set; }

        public ApoiadoAssertion(Models.Apoiado apoiado, bool canIdNull = false)
        {
            if (apoiado == null)
            {
                throw new Exception("O parâmetro apoiado não pode ser nulo [classe VoluntarioAssertion]");
            }
            Notifications = new NotificationHandler();

            if (!canIdNull)
            {
                if (apoiado.Id == Guid.Empty)
                    SetNofication("500", "O ID não pode ser nulo");
            }

            if (string.IsNullOrEmpty(apoiado.Nome))
                SetNofication("500", "Informe o Nome");

            if (!apoiado.DataNascimento.HasValue)
                SetNofication("500", "Informe a Data de Nascimento");
        }

        private void SetNofication(string key, string value)
        {
            Notifications.Handle(key, value);
        }
    }
}
