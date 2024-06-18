﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SahovskaFederacija.Entiteti;
using FluentNHibernate.Mapping;
using FluentNHibernate.Conventions.Helpers;

namespace SahovskaFederacija.Mapiranja
{
    public class PotezMapiranja : ClassMap<SahovskaFederacija.Entiteti.Potez>
    {
        public PotezMapiranja()
        {
            Table("POTEZ");

            CompositeId()
                .KeyReference(x => x.Partija, "ID_PARTIJA")
                .KeyProperty(x => x.Redni_Broj, "REDNI_BROJ");

            Map(x => x.Broj, "BROJ");
            Map(x => x.Slovo, "SLOVO");
            Map(x => x.Figura, "FIGURA");
            Map(x => x.Vreme_Odigravanja, "VREME_ODIGRAVANJA");
        }
    }
}
