using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mapiranja
{
    public class DefiniseMapiranja:ClassMap<Definise>
    {
        public DefiniseMapiranja()
        {
            //Mapiranje tabele
            Table("DEFINISE");

            //Mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //Mapiranje veze 1:1 Definise-Legenda
            References(x => x.DefLegenda, "ID_LEGENDE").Unique();

            //Mapiranje veze 1:1 Definise-Lokacija
            References(x => x.DefLokacija, "ID_LOKACIJE").Unique();

            //Mapiranje veze 1:1 Definise-Zastita
            References(x => x.DefZastita, "ID_ZASTITE").Unique();


        }
    }
}
