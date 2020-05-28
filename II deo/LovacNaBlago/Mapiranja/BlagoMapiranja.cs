using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LovacNaBlago.Entiteti;

namespace LovacNaBlago.Mapiranja
{
    public class BlagoMapiranja:ClassMap<LovacNaBlago.Entiteti.Blago>
    {
        public BlagoMapiranja()
        {
            //Mapiranje tabele
            Table("BLAGO");

            //Mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //Mapiranje svojstava
            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Mapa, "MAPA");

            //Mapiranje veze 1:N Blago-Predmet
            HasMany(x => x.Predmeti).KeyColumn("ID_BLAGA").Cascade.All().Inverse();

            //Mapiranje veze 1:N Blago-Legenda
            HasMany(x => x.Legende).KeyColumn("ID_BLAGA").Cascade.All().Inverse();

            //Mapiranje veze 1:N Blago-Lokacija
            HasMany(x => x.Lokacije).KeyColumn("ID_BLAGA").Cascade.All().Inverse();

            //Mapiranje veze 1:N Blago-Lovac
            HasMany(x => x.Lovci).KeyColumn("ID_BLAGA").Cascade.All().Inverse();

            //Mapiranje veze 1:1 Blago-Poreklo
            References(x => x.JePorekla, "ID_POREKLA").Unique();
        }
    }
}
