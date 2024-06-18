﻿using FluentNHibernate.Conventions.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SahovskaFederacija.Entiteti;
using FluentNHibernate.Mapping;

namespace SahovskaFederacija.Mapiranja
{
    public class MajstorMapiranja : SubclassMap<SahovskaFederacija.Entiteti.Majstor>
    {
        MajstorMapiranja()
        {
            Table("MAJSTOR");

            // Primarni kljuc nasledjen iz klase Sahista
            KeyColumn("RBR");

            Map(x => x.Datum_Zvanja).Column("DATUM_ZVANJA");

            // mapiranje stranog kljuca ukoliko je MAJSTOR ujedno i SUDIJA na nekom mecu
            References(x => x.Sudija).Column("ID_SUDIJA").LazyLoad();
        }   
    }
}
