﻿using FluentNHibernate.Mapping;
using SahovskaFederacija.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahovskaFederacija.Mapiranja
{
    class OrganizujeMapiranja : ClassMap<Organizuje>
    {
        public OrganizujeMapiranja()
        {
            Table("ORGANIZUJE");

            CompositeId(x => x.Id)
                .KeyReference(x => x.OrganizatorOrganizuje, "ID_ORGANIZATOR")
                .KeyReference(x => x.OrganizujeSahovski_Turnir, "ID_SAHOVSKI_TURNIR");
        }
    }
}
