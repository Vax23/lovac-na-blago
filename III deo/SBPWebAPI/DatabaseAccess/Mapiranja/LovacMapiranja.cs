using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mapiranja
{
    public class LovacMapiranja:ClassMap<Lovac>
    {
        public LovacMapiranja()
        {
            //Mapiranja tabele
            Table("LOVAC");

            //Mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //Mapiranje svojstava
            Map(x => x.Ime, "IME");
            Map(x => x.PocetakTrazenja, "POCETAK_TRAZENJA");
            Map(x => x.KrajTrazenja, "KRAJ_TRAZENJA");

            //Mapiranje veze 1:N Blago-Lovac
            References(x => x.TragaZa).Column("ID_BLAGA").LazyLoad();
        }
    }
}
