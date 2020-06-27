using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.Mapiranja
{
    public class ObicnaNalazistaZlataMapiranja:ClassMap<DatabaseAccess.Entiteti.ObicnaNalazistaZlata>
    {
        public ObicnaNalazistaZlataMapiranja()
        {
            //Mapiranje tabele
            Table("OBICNA_NALAZISTA_ZLATA");

            //Mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //Mapiranje svojstava
            Map(x => x.Ime, "IME");
            Map(x => x.ZemljaNalazenja, "ZEMLJA_NALAZENJA");
            Map(x => x.ImeNalazaca, "IME_NALAZACA");
            Map(x => x.DatumOtkrivanja, "DATUM_OTKRIVANJA");
            //Map(x => x.Tip, "TIP");

            //Mapiranje podklasa
            DiscriminateSubClassesOnColumn("TIP");
        }
    }

    class ZlatneZileMapiranja : SubclassMap<ZlatneZile>
    {
        ZlatneZileMapiranja()
        {
            DiscriminatorValue("Zlatne zile");
        }
    }

    class ZlatonosneRekeMapiranja : SubclassMap<ZlatonosneReke>
    {
        ZlatonosneRekeMapiranja()
        {
            Map(x => x.ImeReke, "IME_REKE");
            DiscriminatorValue("Zlatonosne reke");
        }
    }
}
