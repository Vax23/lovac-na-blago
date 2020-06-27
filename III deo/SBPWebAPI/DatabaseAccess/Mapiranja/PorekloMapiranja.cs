using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.Mapiranja
{
    public class PorekloMapiranja:ClassMap<DatabaseAccess.Entiteti.Poreklo>
    {
        public PorekloMapiranja()
        {
            //Mapiranje tabele
            Table("POREKLO");

            //Mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            
            

            //
            HasOne(x => x.VezanoZa).PropertyRef(x => x.JePorekla);

            //Mapiranje veze 1:1 Blago-Poreklo
            DiscriminateSubClassesOnColumn("TIP");
        }
    }

    class BlagoVitezovaTemplaraMapiranja : SubclassMap<BlagoVitezovaTemplara>
    {
        BlagoVitezovaTemplaraMapiranja()
        {
            DiscriminatorValue("Blago vitezova Templara");
        }
    }

    class BlagoNepoznatogPoreklaMapiranja : SubclassMap<BlagoNepoznatogPorekla>
    {
        BlagoNepoznatogPoreklaMapiranja()
        {
            DiscriminatorValue("Blago nepoznatog porekla");
        }
    }

    class GusarskoBlagoMapiranja : SubclassMap<GusarskoBlago>
    {
        GusarskoBlagoMapiranja()
        {
            DiscriminatorValue("Gusarsko blago");
        }
    }

    class BlagoNestalihCivilizavijaMapiranja : SubclassMap<BlagoNestalihCivilizacija>
    {
        BlagoNestalihCivilizavijaMapiranja()
        {
            Map(x => x.TipCivilizacije, "TIP_CIVILIZACIJE");
            DiscriminatorValue("Blago nestalih civilizacija");
        }
    }

    
}
