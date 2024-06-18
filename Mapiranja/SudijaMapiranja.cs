﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using SahovskaFederacija.Entiteti;

namespace SahovskaFederacija.Mapiranja
{
    public class SudijaMapiranja : ClassMap<SahovskaFederacija.Entiteti.Sudija>
    {
        public SudijaMapiranja()
        {
            Table("SUDIJA");

            // ID se generise pomocu sekvence
            Id(x => x.Id, "ID").GeneratedBy.SequenceIdentity("SUDIJA_SEQ");

            // mapiranje veze 1:N izmedju SUDIJA i PARTIJA
            HasMany(x => x.SudjenePartije).KeyColumn("ID_SUDIJA").Cascade.All().Inverse();
        }
    }
}
