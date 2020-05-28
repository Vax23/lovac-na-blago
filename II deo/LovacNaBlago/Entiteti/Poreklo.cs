using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovacNaBlago.Entiteti
{
    public abstract class Poreklo
    {
        public virtual int Id { get; protected set; }
        public virtual string Tip { get; set; }

        public virtual Blago VezanoZa { get; set; }

        public Poreklo()
        {

        }
    }

    public class BlagoVitezovaTemplara : Poreklo
    {

    }

    public class BlagoNepoznatogPorekla : Poreklo
    {

    }

    public class GusarskoBlago : Poreklo
    {

    }

    public class BlagoNestalihCivilizacija : Poreklo
    {
        public virtual string TipCivilizacije { get; set; }
        public BlagoNestalihCivilizacija()
        {

        }
    }

    public class Atlantida : BlagoNestalihCivilizacija
    {
        
    }
}
