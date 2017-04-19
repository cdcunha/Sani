using Sani.Api.Notifications;
using System;

namespace Sani.Api.Assertions
{
    public class VoluntarioAssertion : BaseAssertion
    {   
        public VoluntarioAssertion(Models.Voluntario voluntario, bool canIdNull = false) : base()
        {
            if (voluntario == null)
            {
                throw new Exception("O parâmetro voluntario não pode ser nulo [classe VoluntarioAssertion]");
            }

            if (!canIdNull)
            {
                if (voluntario.Id == Guid.Empty)
                    SetNofication("500", "O ID não pode ser nulo");
            }

            if (string.IsNullOrEmpty(voluntario.Nome))
                SetNofication("500", "Informe o Nome");
            
        }
    }
}
