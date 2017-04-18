using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sani.Api.Models
{
    public interface IApoiadoRepository
    {
        void Add(Apoiado apoiado);
        IEnumerable<Apoiado> GetAll();
        Apoiado Find(Guid id);
        void Remove(Guid id);
        void Update(Apoiado apoiado);
    }
}
