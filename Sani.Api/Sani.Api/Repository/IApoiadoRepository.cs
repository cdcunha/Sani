using MongoDB.Bson;
using Sani.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sani.Api.Repository
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
