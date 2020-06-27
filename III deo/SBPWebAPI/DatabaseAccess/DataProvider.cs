using DatabaseAccess.DTOs;
using DatabaseAccess;
using DatabaseAccess.Entiteti;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DatabaseAccess.Mapiranja;
using System.Runtime.InteropServices;

namespace DatabaseAccess
{
    public class DataProvider
    {
        #region Zastita

        #region Duh

        public static List<DuhView> VratiSveDuhove()
        {
            List<DuhView> duhovi = new List<DuhView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Duh> sviDuhovi = from o in s.Query<Duh>() select o;

                foreach (Duh d in sviDuhovi)
                {
                    duhovi.Add(new DuhView(d));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return duhovi;
        }

        public static DuhView VratiJednogDuha(int id)
        {
            DuhView duhView;

            try
            {
                ISession s = DataLayer.GetSession();

                Duh d = s.Load<Duh>(id);
                duhView = new DuhView(d);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return duhView;
        }

        public static void DodajDuha(DuhView d)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Duh duh = new Duh
                {
                    Naziv = d.ZastitaNaziv
                };

                s.SaveOrUpdate(duh);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }


        public static DuhView AzurirajDuha(DuhView d)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Duh duh = s.Load<Duh>(d.ZastitaId);

                duh.Naziv = d.ZastitaNaziv;


                s.Update(duh);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return d;
        }


        public static void ObrisiDuha(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Duh d = s.Load<Duh>(id);

                s.Delete(d);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #region Kletva

        public static List<KletvaView> VratiSveKletve()
        {
            List<KletvaView> kletve = new List<KletvaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Kletva> sveKletve = from o in s.Query<Kletva>() select o;

                foreach (Kletva k in sveKletve)
                {
                    kletve.Add(new KletvaView(k));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return kletve;
        }

        public static void DodajKletvu(KletvaView k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Kletva kletva = new Kletva
                {
                    Naziv = k.ZastitaNaziv
                };

                s.SaveOrUpdate(kletva);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static KletvaView AzurirajKletvu(KletvaView kletva)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Kletva k = s.Load<Kletva>(kletva.ZastitaId);
                k.Naziv = kletva.ZastitaNaziv;

                s.SaveOrUpdate(k);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return kletva;
        }

        public static void ObrisiKletvu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Kletva k = s.Load<Kletva>(id);

                s.Delete(k);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #region Zmaj

        public static List<ZmajView> VratiSveZmajeve()
        {
            List<ZmajView> zmajevi = new List<ZmajView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Zmaj> sviZmajevi = from o in s.Query<Zmaj>() select o;

                foreach (Zmaj z in sviZmajevi)
                {
                    zmajevi.Add(new ZmajView(z));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zmajevi;
        }

        public static void DodajZmaja(ZmajView z)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zmaj zmaj = new Zmaj
                {
                    Naziv = z.ZastitaNaziv
                };

                s.SaveOrUpdate(zmaj);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static ZmajView AzurirajZmaja(ZmajView zmaj)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zmaj z = s.Load<Zmaj>(zmaj.ZastitaId);
                z.Naziv = zmaj.ZastitaNaziv;

                s.SaveOrUpdate(z);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zmaj;
        }

        public static void ObrisiZmaja(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zmaj z = s.Load<Zmaj>(id);

                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #endregion

        #region Blago

        public static List<BlagoView> VratiBlagoSaPoreklom(int porekloID)
        {
            List<BlagoView> blaga = new List<BlagoView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Blago> svaBlaga = from o in s.Query<Blago>() 
                                              where o.JePorekla.Id==porekloID
                                              select o;

                foreach (Blago b in svaBlaga)
                {
                    var bp = new BlagoView(b);
                    bp.Predmeti = b.Predmeti.Select(b => new PredmetView(b)).ToList();
                    bp.Legende = b.Legende.Select(b => new LegendaView(b)).ToList();
                    bp.Lokacije = b.Lokacije.Select(b => new LokacijaView(b)).ToList();
                    bp.Predmeti = b.Predmeti.Select(b => new PredmetView(b)).ToList();
                    bp.Lovci = b.Lovci.Select(b => new LovacView(b)).ToList();
                    bp.Porekla = new PorekloView(b.JePorekla);
                   
                    blaga.Add(bp);
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return blaga;
        }

        public static List<BlagoView> VratiSvaBlaga()
        {
            List<BlagoView> blaga = new List<BlagoView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Blago> svaBlaga = from o in s.Query<Blago>() select o;
                
                foreach (Blago b in svaBlaga)
                {
                    blaga.Add(new BlagoView(b));
                }
                
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return blaga;
        }

        public static BlagoView VratiJednoBlago(int id)
        {
            BlagoView blagoView;

            try
            {
                ISession s = DataLayer.GetSession();

                Blago blago = s.Load<Blago>(id);
                blagoView = new BlagoView(blago);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return blagoView;
        }

        public static void DodajBlagoSaPoreklom(BlagoView b)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Blago blago = new Blago();
                Poreklo p = s.Load<Poreklo>(b.Porekla.PorekloId);

                blago.Naziv = b.BlagoNaziv;
                blago.Mapa = b.BlagoMapa;
                blago.JePorekla = p;
                

                s.SaveOrUpdate(blago);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        

        public static BlagoView AzurirajBlago(BlagoView b)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Blago blago = s.Load<Blago>(b.BlagoId);

                blago.Naziv = b.BlagoNaziv;
                blago.Mapa = b.BlagoMapa;


                s.Update(blago);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return b;
        }

        public static void ObrisiBlago(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Blago b = s.Load<Blago>(id);

                s.Delete(b);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
      
        #endregion

        #region Predmet

        #region Knjiga
        
        public static List<KnjigaView> VratiKnjige()
        {
            List<KnjigaView> knjige = new List<KnjigaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Knjiga> sveKnjige = from o in s.Query<Knjiga>() select o;

                foreach (Knjiga k in sveKnjige)
                {
                    knjige.Add(new KnjigaView(k));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return knjige;
        }

        public static List<KnjigaView> VratiKnjiguSaBlagom(int blagoID)
        {
            List<KnjigaView> knjige = new List<KnjigaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Knjiga> sveKnjige = from o in s.Query<Knjiga>()
                                              where o.PripadaBlagu.Id == blagoID
                                              select o;

                foreach (Knjiga k in sveKnjige)
                {
                    var knjiga = new KnjigaView(k);
                    knjiga.Blaga = new BlagoView(k.PripadaBlagu);
                    knjige.Add(knjiga);
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return knjige;
        }

        public static void DodajKnjiguSaBlagom(KnjigaView k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Knjiga knjiga = new Knjiga();
                Blago b = s.Load<Blago>(k.Blaga.BlagoId);

                knjiga.Naziv = k.PredmetNaziv;
                knjiga.Materijal = k.PredmetMaterijal;
                knjiga.PripadaBlagu = b;
                

                s.SaveOrUpdate(knjiga);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }


        public static KnjigaView AzurirajKnjigu(KnjigaView k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Knjiga knjiga = s.Load<Knjiga>(k.PredmetId);

                knjiga.Naziv = k.PredmetNaziv;
                knjiga.Materijal = k.PredmetMaterijal;

                s.Update(knjiga);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return k;
        }


        public static void ObrisiKnjigu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Knjiga k = s.Load<Knjiga>(id);

                s.Delete(k);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #region Krst


        public static List<KrstView> VratiKrstSaBlagom(int blagoID)
        {
            List<KrstView> krstevi = new List<KrstView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Krst> sviKrstevi = from o in s.Query<Krst>()
                                                where o.PripadaBlagu.Id == blagoID
                                                select o;

                foreach (Krst k in sviKrstevi)
                {
                    var krst = new KrstView(k);
                    krst.Blaga = new BlagoView(k.PripadaBlagu);
                    krstevi.Add(krst);
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return krstevi;
        }

        public static List<KrstView> VratiSveKrstove()
        {
            List<KrstView> krstovi = new List<KrstView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Krst> sviKrstovi = from o in s.Query<Krst>() select o;

                foreach (Krst k in sviKrstovi)
                {
                    krstovi.Add(new KrstView(k));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return krstovi;
        }

        public static void DodajKrstSaBlagom(KrstView k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Krst krst = new Krst();
                Blago b = s.Load<Blago>(k.Blaga.BlagoId);

                krst.Naziv = k.PredmetNaziv;
                krst.Materijal = k.PredmetMaterijal;
                krst.PripadaBlagu = b;

                s.SaveOrUpdate(krst);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }


        public static KrstView AzurirajKrst(KrstView k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Krst krst = s.Load<Krst>(k.PredmetId);

                krst.Naziv = k.PredmetNaziv;


                s.Update(krst);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return k;
        }


        public static void ObrisiKrst(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Krst k = s.Load<Krst>(id);

                s.Delete(k);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #region Lobanja

        public static List<LobanjaView> VratiLobanjuSaBlagom(int blagoID)
        {
            List<LobanjaView> lobanje = new List<LobanjaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Lobanja> sveLobanje = from o in s.Query<Lobanja>()
                                               where o.PripadaBlagu.Id == blagoID
                                               select o;

                foreach (Lobanja l in sveLobanje)
                {
                    var lobanja = new LobanjaView(l);
                    lobanja.Blaga = new BlagoView(l.PripadaBlagu);
                    lobanje.Add(lobanja);
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return lobanje;
        }

        public static List<LobanjaView> VratiSveLobanje()
        {
            List<LobanjaView> lobanje = new List<LobanjaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Lobanja> sveLobanje = from o in s.Query<Lobanja>() select o;

                foreach (Lobanja l in sveLobanje)
                {
                    lobanje.Add(new LobanjaView(l));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return lobanje;
        }

        public static void DodajLobanjuSaBlagom(LobanjaView l)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Lobanja lobanja = new Lobanja();
                Blago b = s.Load<Blago>(l.Blaga.BlagoId);

                lobanja.Naziv = l.PredmetNaziv;
                lobanja.Materijal = l.PredmetMaterijal;
                lobanja.PripadaBlagu = b;
                

                s.SaveOrUpdate(lobanja);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }


        public static LobanjaView AzurirajLobanju(LobanjaView l)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Lobanja lobanja = s.Load<Lobanja>(l.PredmetId);

                lobanja.Naziv = l.PredmetNaziv;


                s.Update(lobanja);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return l;
        }


        public static void ObrisiLobanju(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Lobanja l = s.Load<Lobanja>(id);

                s.Delete(l);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #region Mac

        public static List<MacView> VratiMacSaBlagom(int blagoID)
        {
            List<MacView> macevi = new List<MacView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Mac> sviMacevi = from o in s.Query<Mac>()
                                                  where o.PripadaBlagu.Id == blagoID
                                                  select o;

                foreach (Mac m in sviMacevi)
                {
                    var mac = new MacView(m);
                    mac.Blaga = new BlagoView(m.PripadaBlagu);
                    macevi.Add(mac);
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return macevi;
        }

        public static List<MacView> VratiSveMaceve()
        {
            List<MacView> macevi = new List<MacView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Mac> sviMacevi = from o in s.Query<Mac>() select o;

                foreach (Mac m in sviMacevi)
                {
                    macevi.Add(new MacView(m));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return macevi;
        }

        public static void DodajMacSaBlagom(MacView m)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Mac mac = new Mac();
                Blago b = s.Load<Blago>(m.Blaga.BlagoId);

                mac.Naziv = m.PredmetNaziv;
                mac.Materijal = m.PredmetMaterijal;
                mac.PripadaBlagu = b;
                

                s.SaveOrUpdate(mac);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }


        public static MacView AzurirajMac(MacView m)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Mac mac = s.Load<Mac>(m.PredmetId);

                mac.Naziv = m.PredmetNaziv;


                s.Update(mac);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return m;
        }


        public static void ObrisiMac(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Mac m = s.Load<Mac>(id);

                s.Delete(m);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #endregion

        #region Poreklo

        #region Blago nestalih civilizacija

        public static List<BlagoNestalihCivilizacijaView> VratiSveBNC()
        {
            List<BlagoNestalihCivilizacijaView> bnc = new List<BlagoNestalihCivilizacijaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<BlagoNestalihCivilizacija> sviBNC = from o in s.Query<BlagoNestalihCivilizacija>() select o;

                foreach (BlagoNestalihCivilizacija b in sviBNC)
                {
                    bnc.Add(new BlagoNestalihCivilizacijaView(b));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return bnc;
        }

        public static BlagoNestalihCivilizacijaView VratiJednoBNC(int id)
        {
            BlagoNestalihCivilizacijaView bncView;

            try
            {
                ISession s = DataLayer.GetSession();

                BlagoNestalihCivilizacija bnc = s.Load<BlagoNestalihCivilizacija>(id);
                bncView = new BlagoNestalihCivilizacijaView(bnc);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return bncView;
        }


        public static void DodajBNC(BlagoNestalihCivilizacijaView bnc)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                BlagoNestalihCivilizacija blagoNC = new BlagoNestalihCivilizacija()
                {
                    TipCivilizacije = bnc.BNCTipCivilizacije
                };

                s.SaveOrUpdate(blagoNC);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static BlagoNestalihCivilizacijaView AzurirajBNC(BlagoNestalihCivilizacijaView bnc)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                BlagoNestalihCivilizacija blagoNC = s.Load<BlagoNestalihCivilizacija>(bnc.PorekloId);

                blagoNC.TipCivilizacije = bnc.BNCTipCivilizacije;


                s.Update(blagoNC);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return bnc;
        }

        public static void ObrisiBNC(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                BlagoNestalihCivilizacija bnc = s.Load<BlagoNestalihCivilizacija>(id);

                s.Delete(bnc);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #region Blago vitezova Templara

        public static List<BlagoVitezovaTemplaraView> VratiSveBVT()
        {
            List<BlagoVitezovaTemplaraView> bvt = new List<BlagoVitezovaTemplaraView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<BlagoVitezovaTemplara> sviBVT = from o in s.Query<BlagoVitezovaTemplara>() select o;

                foreach (BlagoVitezovaTemplara b in sviBVT)
                {
                    bvt.Add(new BlagoVitezovaTemplaraView(b));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return bvt;
        }

        public static void DodajBVT(BlagoVitezovaTemplaraView bvt)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                BlagoVitezovaTemplara blagoVT = new BlagoVitezovaTemplara();

                s.SaveOrUpdate(blagoVT);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void ObrisiBVT(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                BlagoVitezovaTemplara bvt = s.Load<BlagoVitezovaTemplara>(id);

                s.Delete(bvt);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #region Blago nepoznatog porekla

        public static List<BlagoNepoznatogPoreklaView> VratiSveBNP()
        {
            List<BlagoNepoznatogPoreklaView> bnp = new List<BlagoNepoznatogPoreklaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<BlagoNepoznatogPorekla> sviBNP = from o in s.Query<BlagoNepoznatogPorekla>() select o;

                foreach (BlagoNepoznatogPorekla b in sviBNP)
                {
                    bnp.Add(new BlagoNepoznatogPoreklaView(b));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return bnp;
        }

        public static void DodajBNP(BlagoNepoznatogPoreklaView bnp)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                BlagoNepoznatogPorekla blagoNP = new BlagoNepoznatogPorekla();

                s.SaveOrUpdate(blagoNP);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void ObrisiBNP(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                BlagoNepoznatogPorekla bnp = s.Load<BlagoNepoznatogPorekla>(id);

                s.Delete(bnp);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #region Gusarsko blago

        public static List<GusarskoBlagoView> VratiSveGB()
        {
            List<GusarskoBlagoView> gb = new List<GusarskoBlagoView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<GusarskoBlago> svoGB = from o in s.Query<GusarskoBlago>() select o;

                foreach (GusarskoBlago b in svoGB)
                {
                    gb.Add(new GusarskoBlagoView(b));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return gb;
        }

        public static void DodajGB(GusarskoBlagoView gb)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                GusarskoBlago gusarsko = new GusarskoBlago();

                s.SaveOrUpdate(gusarsko);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void ObrisiGB(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                GusarskoBlago gb = s.Load<GusarskoBlago>(id);

                s.Delete(gb);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #endregion

        #region Lokacija

        #region Grobnica
        
        public static List<GrobnicaView> VratiSveGrobnice()
        {
            List<GrobnicaView> grobnice = new List<GrobnicaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Grobnica> sveGrobnice = from o in s.Query<Grobnica>() select o;

                foreach (Grobnica g in sveGrobnice)
                {
                    grobnice.Add(new GrobnicaView(g));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return grobnice;
        }

        public static List<GrobnicaView> VratiGrobnicuSaBlagom(int blagoID)
        {
            List<GrobnicaView> grobnice = new List<GrobnicaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Grobnica> sveGrobnice = from o in s.Query<Grobnica>()
                                              where o.VezanaZa.Id == blagoID
                                              select o;

                foreach (Grobnica g in sveGrobnice)
                {
                    var grobnica = new GrobnicaView(g);
                    grobnica.Blaga = new BlagoView(g.VezanaZa);
                    grobnice.Add(grobnica);
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return grobnice;
        }

        public static void DodajGrobnicuSaBlagom(GrobnicaView g)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Grobnica grobnica = new Grobnica();
                Blago b = s.Load<Blago>(g.Blaga.BlagoId);

                grobnica.Naziv = g.LokacijaNaziv;
                grobnica.ZemljaNalazenja = g.LokacijaZemlja;
                grobnica.VezanaZa = b;



                s.SaveOrUpdate(grobnica);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }


        public static GrobnicaView AzurirajGrobnicu(GrobnicaView g)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Grobnica grobnica = s.Load<Grobnica>(g.LokacijaId);

                grobnica.Naziv = g.LokacijaNaziv;
                grobnica.ZemljaNalazenja = g.LokacijaZemlja;


                s.Update(grobnica);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return g;
        }


        public static void ObrisiGrobnicu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Grobnica g = s.Load<Grobnica>(id);

                s.Delete(g);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #region GradDuhova

        public static List<GradDuhovaView> VratiSveGradoveDuhova()
        {
            List<GradDuhovaView> gradoviDuhova = new List<GradDuhovaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<GradDuhova> sviGradoviDuhova = from o in s.Query<GradDuhova>() select o;

                foreach (GradDuhova gd in sviGradoviDuhova)
                {
                    gradoviDuhova.Add(new GradDuhovaView(gd));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return gradoviDuhova;
        }

        public static List<GradDuhovaView> VratiGradDuhovaSaBlagom(int blagoID)
        {
            List<GradDuhovaView> gradoviDuhova = new List<GradDuhovaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<GradDuhova> sviGradoviDuhova = from o in s.Query<GradDuhova>()
                                                    where o.VezanaZa.Id == blagoID
                                                    select o;

                foreach (GradDuhova g in sviGradoviDuhova)
                {
                    var gradD = new GradDuhovaView(g);
                    gradD.Blaga = new BlagoView(g.VezanaZa);
                    gradoviDuhova.Add(gradD);
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return gradoviDuhova;
        }


        public static void DodajGradDuhovaSaBlagom(GradDuhovaView gd)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                GradDuhova gradDuhova = new GradDuhova();
                Blago b = s.Load<Blago>(gd.Blaga.BlagoId);

                gradDuhova.Naziv = gd.LokacijaNaziv;
                gradDuhova.ZemljaNalazenja = gd.LokacijaZemlja;
                gradDuhova.VezanaZa = b;



                s.SaveOrUpdate(gradDuhova);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }


        public static GradDuhovaView AzurirajGradDuhova(GradDuhovaView gd)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                GradDuhova gradDuhova = s.Load<GradDuhova>(gd.LokacijaId);

                gradDuhova.Naziv = gd.LokacijaNaziv;
                gradDuhova.ZemljaNalazenja = gd.LokacijaZemlja;


                s.Update(gradDuhova);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return gd;
        }


        public static void ObrisiGradDuhova(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                GradDuhova gd = s.Load<GradDuhova>(id);

                s.Delete(gd);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #region Pecina

        public static List<PecinaView> VratiPecinuSaBlagom(int blagoID)
        {
            List<PecinaView> pecine = new List<PecinaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Pecina> svePecine = from o in s.Query<Pecina>()
                                                           where o.VezanaZa.Id == blagoID
                                                           select o;

                foreach (Pecina p in svePecine)
                {
                    var pecina = new PecinaView(p);
                    pecina.Blaga = new BlagoView(p.VezanaZa);
                    pecine.Add(pecina);
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return pecine;
        }

        public static List<PecinaView> VratiSvePecine()
        {
            List<PecinaView> pecine = new List<PecinaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Pecina> svePecine = from o in s.Query<Pecina>() select o;

                foreach (Pecina p in svePecine)
                {
                    pecine.Add(new PecinaView(p));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return pecine;
        }

        public static void DodajPecinuSaBlagom(PecinaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Pecina pecina = new Pecina();
                Blago b = s.Load<Blago>(p.Blaga.BlagoId);

                pecina.Naziv = p.LokacijaNaziv;
                pecina.ZemljaNalazenja = p.LokacijaZemlja;
                pecina.VezanaZa = b;



                s.SaveOrUpdate(pecina);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }


        public static PecinaView AzurirajPecinu(PecinaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Pecina pecina = s.Load<Pecina>(p.LokacijaId);

                pecina.Naziv = p.LokacijaNaziv;
                pecina.ZemljaNalazenja = p.LokacijaZemlja;


                s.Update(pecina);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }


        public static void ObrisiPecinu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Pecina p = s.Load<Pecina>(id);

                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #region Ostrvo

        public static List<OstrvoView> VratiOstrvoSaBlagom(int blagoID)
        {
            List<OstrvoView> ostrva = new List<OstrvoView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Ostrvo> svaOstrva = from o in s.Query<Ostrvo>()
                                                where o.VezanaZa.Id == blagoID
                                                select o;

                foreach (Ostrvo o in svaOstrva)
                {
                    var ostrvo = new OstrvoView(o);
                    ostrvo.Blaga = new BlagoView(o.VezanaZa);
                    ostrva.Add(ostrvo);
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return ostrva;
        }

        public static List<OstrvoView> VratiSvaOstrva()
        {
            List<OstrvoView> ostrva = new List<OstrvoView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Ostrvo> svaOstrva = from o in s.Query<Ostrvo>() select o;

                foreach (Ostrvo o in svaOstrva)
                {
                    ostrva.Add(new OstrvoView(o));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return ostrva;
        }

        public static void DodajOstrvoSaBlagom(OstrvoView o)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ostrvo ostrvo = new Ostrvo();
                Blago b = s.Load<Blago>(o.Blaga.BlagoId);


                ostrvo.Naziv = o.LokacijaNaziv;
                ostrvo.ZemljaNalazenja = o.LokacijaZemlja;
                ostrvo.VezanaZa = b;



                s.SaveOrUpdate(ostrvo);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }


        public static OstrvoView AzurirajOstrvo(OstrvoView o)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ostrvo ostrvo = s.Load<Ostrvo>(o.LokacijaId);

                ostrvo.Naziv = o.LokacijaNaziv;
                ostrvo.ZemljaNalazenja = o.LokacijaZemlja;


                s.Update(ostrvo);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return o;
        }


        public static void ObrisiOstrvo(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ostrvo o = s.Load<Ostrvo>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #region Piramida

        public static List<PiramidaView> VratiPiramiduSaBlagom(int blagoID)
        {
            List<PiramidaView> piramide = new List<PiramidaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Piramida> svePiramide = from o in s.Query<Piramida>()
                                                where o.VezanaZa.Id == blagoID
                                                select o;

                foreach (Piramida p in svePiramide)
                {
                    var piramida = new PiramidaView(p);
                    piramida.Blaga = new BlagoView(p.VezanaZa);
                    piramide.Add(piramida);
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return piramide;
        }

        public static List<PiramidaView> VratiSvePiramide()
        {
            List<PiramidaView> piramide = new List<PiramidaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Piramida> svePiramide = from o in s.Query<Piramida>() select o;

                foreach (Piramida p in svePiramide)
                {
                    piramide.Add(new PiramidaView(p));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return piramide;
        }

        public static PiramidaView VratiJednuPiramidu(int id)
        {
            PiramidaView piramidaView;

            try
            {
                ISession s = DataLayer.GetSession();

                Piramida p = s.Load<Piramida>(id);
                piramidaView = new PiramidaView(p);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return piramidaView;
        }

        public static void DodajPiramiduSaBlagom(PiramidaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Piramida piramida = new Piramida();


                Blago b = s.Load<Blago>(p.Blaga.BlagoId);

                piramida.Naziv = p.LokacijaNaziv;
                piramida.ZemljaNalazenja = p.LokacijaZemlja;
                piramida.VezanaZa = b;



                s.SaveOrUpdate(piramida);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }


        public static PiramidaView AzurirajPiramidu(PiramidaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Piramida piramida = s.Load<Piramida>(p.LokacijaId);

                piramida.Naziv = p.LokacijaNaziv;
                piramida.ZemljaNalazenja = p.LokacijaZemlja;


                s.Update(piramida);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }


        public static void ObrisiPiramidu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Piramida p = s.Load<Piramida>(id);

                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #region UkletiZamak

        public static List<UkletiZamakView> VratiUkletiZamakSaBlagom(int blagoID)
        {
            List<UkletiZamakView> ukletiZamkovi = new List<UkletiZamakView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<UkletiZamak> sviUkletiZamkovi = from o in s.Query<UkletiZamak>()
                                                    where o.VezanaZa.Id == blagoID
                                                    select o;

                foreach (UkletiZamak p in sviUkletiZamkovi)
                {
                    var ukletiZamak = new UkletiZamakView(p);
                    ukletiZamak.Blaga = new BlagoView(p.VezanaZa);
                    ukletiZamkovi.Add(ukletiZamak);
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return ukletiZamkovi;
        }

        public static List<UkletiZamakView> VratiSveUkleteZamkove()
        {
            List<UkletiZamakView> ukletiZamkovi = new List<UkletiZamakView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<UkletiZamak> sviUkletiZamkovi = from o in s.Query<UkletiZamak>() select o;

                foreach (UkletiZamak uz in sviUkletiZamkovi)
                {
                    ukletiZamkovi.Add(new UkletiZamakView(uz));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return ukletiZamkovi;
        }

        public static void DodajUkletiZamakSaBlagom(UkletiZamakView uz)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                UkletiZamak ukletiZamak = new UkletiZamak();
                Blago b = s.Load<Blago>(uz.Blaga.BlagoId);

                ukletiZamak.Naziv = uz.LokacijaNaziv;
                ukletiZamak.ZemljaNalazenja = uz.LokacijaZemlja;
                ukletiZamak.VezanaZa = b;



                s.SaveOrUpdate(ukletiZamak);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }


        public static UkletiZamakView AzurirajUkletiZamak(UkletiZamakView uz)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                UkletiZamak ukletiZamak = s.Load<UkletiZamak>(uz.LokacijaId);

                ukletiZamak.Naziv = uz.LokacijaNaziv;
                ukletiZamak.ZemljaNalazenja = uz.LokacijaZemlja;


                s.Update(ukletiZamak);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return uz;
        }


        public static void ObrisiUkletiZamak(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                UkletiZamak uz = s.Load<UkletiZamak>(id);

                s.Delete(uz);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #endregion

        #region Lovac

        public static List<LovacView> VratiLovcaSaBlagom(int blagoID)
        {
            List<LovacView> lovci = new List<LovacView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Lovac> sviLovci = from o in s.Query<Lovac>()
                                              where o.TragaZa.Id==blagoID
                                              select o;

                foreach (Lovac l in sviLovci)
                {
                    var lovac = new LovacView(l);
                    lovac.Blaga = new BlagoView(l.TragaZa);
                    lovci.Add(lovac);
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return lovci;
        }

        public static List<LovacView> VratiLovca()
        {
            List<LovacView> lovci = new List<LovacView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Lovac> sviLovci = from o in s.Query<Lovac>() select o;

                foreach (Lovac l in sviLovci)
                {
                    lovci.Add(new LovacView(l));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return lovci;
        }



        public static void DodajLovcaSaBlagom(LovacView l)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Lovac lovac = new Lovac();
                Blago b = s.Load<Blago>(l.Blaga.BlagoId);

                lovac.Ime = l.LovacIme;
                lovac.PocetakTrazenja = l.LovacPocetakTrazenja;
                lovac.KrajTrazenja = l.LovacKrajTrazenja;
                lovac.TragaZa = b;
                

                s.SaveOrUpdate(lovac);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }


        public static LovacView AzurirajLovca(LovacView l)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Lovac lovac = s.Load<Lovac>(l.LovacId);

                lovac.Ime = l.LovacIme;
                lovac.PocetakTrazenja = l.LovacPocetakTrazenja;
                lovac.KrajTrazenja = l.LovacKrajTrazenja;


                s.Update(lovac);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return l;
        }


        public static void ObrisiLovca(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Lovac l = s.Load<Lovac>(id);

                s.Delete(l);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #region Legenda

        public static List<LegendaView> VratiLegenduSaBlagom(int blagoID)
        {
            List<LegendaView> legende = new List<LegendaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Legenda> sveLegende = from o in s.Query<Legenda>()
                                                    where o.VezanaZa.Id == blagoID
                                                    select o;

                foreach (Legenda l in sveLegende)
                {
                    var legenda = new LegendaView(l);
                    legenda.Blaga = new BlagoView(l.VezanaZa);
                    legende.Add(legenda);
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return legende;
        }

        public static List<LegendaView> VratiSveLegende()
        {
            List<LegendaView> legende = new List<LegendaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Legenda> sveLegende = from o in s.Query<Legenda>() select o;

                foreach (Legenda l in sveLegende)
                {
                    
                    legende.Add(new LegendaView(l));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return legende;
        }

        public static LegendaView VratiJednuLegendu(int id)
        {
            LegendaView legendaView;

            try
            {
                ISession s = DataLayer.GetSession();

                Legenda l = s.Load<Legenda>(id);
                legendaView = new LegendaView(l);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return legendaView;
        }

        public static void DodajLegenduSaBlagom(LegendaView l)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Legenda legenda = new Legenda();
                Blago b = s.Load<Blago>(l.Blaga.BlagoId);

                legenda.Naziv = l.LegendaNaziv;
                legenda.Prica = l.LegendaPrica;
                legenda.VezanaZa = b;



                s.SaveOrUpdate(legenda);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static LegendaView AzurirajLegendu(LegendaView l)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Legenda legenda = s.Load<Legenda>(l.LegendaId);

                legenda.Naziv = l.LegendaNaziv;
                legenda.Prica = l.LegendaPrica;


                s.Update(legenda);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return l;
        }

        public static void ObrisiLegendu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Legenda l = s.Load<Legenda>(id);

                s.Delete(l);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #region Obicna nalazista zlata

        #region Zlatne zile

        public static List<ZlatneZileView> VratiSveZlatneZile()
        {
            List<ZlatneZileView> zlatneZile = new List<ZlatneZileView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ZlatneZile> sveZlatneZile = from o in s.Query<ZlatneZile>() select o;

                foreach (ZlatneZile zz in sveZlatneZile)
                {
                    zlatneZile.Add(new ZlatneZileView(zz));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zlatneZile;
        }

        public static void DodajZlatnuZilu(ZlatneZileView zz)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZlatneZile zlatnaZila = new ZlatneZile
                {
                    Ime = zz.ONZIme,
                    ZemljaNalazenja = zz.ONZZemljaNalazenja,
                    ImeNalazaca = zz.ONZImeNalazaca,
                    DatumOtkrivanja = zz.ONZDatumOtkrivanja
                };

                s.SaveOrUpdate(zlatnaZila);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }


        public static ZlatneZileView AzurirajZlatnuZilu(ZlatneZileView zz)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZlatneZile zlatnaZilaA = s.Load<ZlatneZile>(zz.ONZId);

                zlatnaZilaA.Ime = zz.ONZIme;
                zlatnaZilaA.ZemljaNalazenja = zz.ONZZemljaNalazenja;
                zlatnaZilaA.ImeNalazaca = zz.ONZImeNalazaca;
                zlatnaZilaA.DatumOtkrivanja = zz.ONZDatumOtkrivanja;


                s.Update(zlatnaZilaA);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zz;
        }


        public static void ObrisiZlatnuZilu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZlatneZile z = s.Load<ZlatneZile>(id);

                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #region Zlatonosne reke

        public static List<ZlatonosneRekeView> VratiSveZlatonosneReke()
        {
            List<ZlatonosneRekeView> zlatonosneReke = new List<ZlatonosneRekeView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ZlatonosneReke> sveZlatonosneReke = from o in s.Query<ZlatonosneReke>() select o;

                foreach (ZlatonosneReke zr in sveZlatonosneReke)
                {
                    zlatonosneReke.Add(new ZlatonosneRekeView(zr));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zlatonosneReke;
        }

        public static void DodajZlatonosnuReku(ZlatonosneRekeView zr)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZlatonosneReke zlatonosnaReka = new ZlatonosneReke
                {
                    Ime = zr.ONZIme,
                    ZemljaNalazenja = zr.ONZZemljaNalazenja,
                    ImeNalazaca = zr.ONZImeNalazaca,
                    DatumOtkrivanja = zr.ONZDatumOtkrivanja,
                    ImeReke = zr.ONZImeReke
                };

                s.SaveOrUpdate(zlatonosnaReka);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }


        public static ZlatonosneRekeView AzurirajZlatonosnuReku(ZlatonosneRekeView zr)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZlatonosneReke zlatonosnaRekaA = s.Load<ZlatonosneReke>(zr.ONZId);

                zlatonosnaRekaA.Ime = zr.ONZIme;
                zlatonosnaRekaA.ZemljaNalazenja = zr.ONZZemljaNalazenja;
                zlatonosnaRekaA.ImeNalazaca = zr.ONZImeNalazaca;
                zlatonosnaRekaA.DatumOtkrivanja = zr.ONZDatumOtkrivanja;
                zlatonosnaRekaA.ImeReke = zr.ONZImeReke;


                s.Update(zlatonosnaRekaA);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return zr;
        }


        public static void ObrisiZlatonosnuReku(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ZlatonosneReke z = s.Load<ZlatonosneReke>(id);

                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #endregion

        #region Definise

        public static List<DefiniseView> VratiDefinisanja(int idZastite, int idLokacije, int idLegende)
        {
            List<DefiniseView> def = new List<DefiniseView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Definise> svaDefinisanja = from o in s.Query<Definise>()
                                                       where (o.DefLegenda.Id==idLegende && o.DefLokacija.Id==idLokacije && o.DefZastita.Id==idZastite)
                                                       select o;

                foreach (Definise d in svaDefinisanja)
                {
                    var definisanje = new DefiniseView(d);
                    definisanje.Legende = new LegendaView(d.DefLegenda);
                    definisanje.Lokacije = new LokacijaView(d.DefLokacija);
                    definisanje.Zastite = new ZastitaView(d.DefZastita);
                    def.Add(definisanje);
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return def;
        }

        public static void DodajDefinisanje(DefiniseView d)
        {
            try
            {
                ISession s = DataLayer.GetSession();

               

                Definise def = new Definise();
                Legenda l = s.Load<Legenda>(d.Legende.LegendaId);
                Piramida p = s.Load<Piramida>(d.Lokacije.LokacijaId);
                Duh duh = s.Load<Duh>(d.Zastite.ZastitaId);

                def.DefLegenda = l;
                def.DefLokacija = p;
                def.DefZastita = duh;
                
                s.Save(def);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }


        public static DefiniseView AzurirajDefinisanje(DefiniseView d)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Definise def = s.Load<Definise>(d.DefiniseId);
                Legenda l = s.Load<Legenda>(d.Legende.LegendaId);
                Piramida p = s.Load<Piramida>(d.Lokacije.LokacijaId);
                Duh duh = s.Load<Duh>(d.Zastite.ZastitaId);

                def.DefLegenda = l;
                def.DefLokacija = p;
                def.DefZastita = duh;

                s.Update(def);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return d;
        }


        public static void ObrisiDefinisanje(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Definise d = s.Load<Definise>(id);

                s.Delete(d);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion
    }
}
