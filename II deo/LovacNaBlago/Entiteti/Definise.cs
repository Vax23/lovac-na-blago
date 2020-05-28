using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovacNaBlago.Entiteti
{
    public class Definise
    {
        public virtual int Id { get; protected set; }

        public virtual Legenda DefLegenda { get; set; }
        public virtual Lokacija DefLokacija { get; set; }
        public virtual Zastita DefZastita { get; set; }
        
        public Definise()
        {

        }
    }
}