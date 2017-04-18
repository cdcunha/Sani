using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sani.Api.Models
{
    public interface IVoluntarioRepository
    {
        void Add(Voluntario voluntario);
        IEnumerable<Voluntario> GetAll();
        Voluntario Find(Guid id);
        void Remove(Guid id);
        void Update(Voluntario voluntario);
    }
}
