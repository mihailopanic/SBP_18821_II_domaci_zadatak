using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using SahovskaFederacija.Entiteti;

namespace SahovskaFederacija.Mapiranja
{
    public class SponzoriMapiranja : ClassMap<SahovskaFederacija.Entiteti.Sponzori>
    {
        public SponzoriMapiranja()
        {
            Table("SPONZORI");

            CompositeId()
                .KeyReference(x => x.SahovskiTurnir, "ID_SAHOVSKI_TURNIR")
                .KeyProperty(x => x.Sponzor, "SPONZOR");
        }
    }
}
