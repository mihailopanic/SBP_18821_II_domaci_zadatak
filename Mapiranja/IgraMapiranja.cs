using FluentNHibernate.Mapping;
using SahovskaFederacija.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahovskaFederacija.Mapiranja
{
    class IgraMapiranja : ClassMap<Igra>
    {
        public IgraMapiranja()
        {
            Table("IGRA");

            CompositeId(x => x.Id)
                .KeyReference(x => x.SahistaIgra, "RBR_SAHISTA")
                .KeyReference(x => x.IgraPartija, "ID_PARTIJA");
        }
    }
}
