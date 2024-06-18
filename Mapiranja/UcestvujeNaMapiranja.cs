using FluentNHibernate.Mapping;
using SahovskaFederacija.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahovskaFederacija.Mapiranja
{
    class UcestvujeNaMapiranja : ClassMap<UcestvujeNa>
    {
        public UcestvujeNaMapiranja()
        {
            Table("UCESTVUJE_NA");

            CompositeId(x => x.Id)
                .KeyReference(x => x.SahistaUcestvujeNa, "RBR_SAHISTA")
                .KeyReference(x => x.UcestvujeNaSahovski_Turnir, "ID_SAHOVSKI_TURNIR");
        }
    }
}
