using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using DatabaseAccess.Mapiranja;

namespace DatabaseAccess
{
    class DataLayer
    {
        private static ISessionFactory _factory = null;
        private static readonly object objLock = new object();

        //Funkcija na yahtev otvara sesiju
        public static ISession GetSession()
        {
            //Ukoliko session factory nije kreiran
            if (_factory == null)
            {
                lock (objLock)
                {
                    if (_factory == null)
                        _factory = CreateSessionFactory();
                }
            }
            return _factory.OpenSession();
        }

        //Konfiguracija i kreiranje session factory
        private static ISessionFactory CreateSessionFactory()
        {
            try
            {
                var cfg = OracleManagedDataClientConfiguration.Oracle10
                    .ConnectionString(c =>
                    c.Is("DATA SOURCE=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;PERSIST SECURITY INFO=True; USER ID=S16648;Password=cokolada"));

                return Fluently.Configure()
                    .Database(cfg.ShowSql())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PorekloMapiranja>())
                    .BuildSessionFactory();

            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
