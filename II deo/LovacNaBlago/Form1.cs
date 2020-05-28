using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;
using LovacNaBlago.Entiteti;

namespace LovacNaBlago
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdUcitajPoreklo_Click(object sender, EventArgs e)
        {
            try
            {

                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o poreklu sa zadatim id-jem
                LovacNaBlago.Entiteti.BlagoNestalihCivilizacija p = s.Load<LovacNaBlago.Entiteti.BlagoNestalihCivilizacija>(2);

                MessageBox.Show("Tip civilizacije: " + p.TipCivilizacije);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmdDodajNovoPoreklo_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                GusarskoBlago gb = new GusarskoBlago()
                {
                    
                };
                

                s.Save(gb);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdIzmeniPoreklo_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Entiteti.BlagoNestalihCivilizacija bnc;

                bnc = s.Load<Entiteti.BlagoNestalihCivilizacija>(62);

                bnc.TipCivilizacije = "Maje";

                s.SaveOrUpdate(bnc);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdUcitajZastitu_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o zastiti sa zadatim id-jem
                LovacNaBlago.Entiteti.Zastita z = s.Load<LovacNaBlago.Entiteti.Zastita>(2);

                MessageBox.Show("Naziv zastite: " + z.Naziv);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodajNovuZastitu_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
               
                Duh d = new Duh()
                {
                    Naziv = "Flying Dutchman"
                };

                s.Save(d);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdIzmeniZastitu_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Zastita z;
                
                z = s.Load<Entiteti.Zastita>(64);

                z.Naziv = "Duppy";
                
                s.SaveOrUpdate(z);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdUcitajNalazisteZlata_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitajaju se podaci o nalazistu sa zadatim id-jem
                LovacNaBlago.Entiteti.ObicnaNalazistaZlata onz = s.Load<LovacNaBlago.Entiteti.ObicnaNalazistaZlata>(9);

                MessageBox.Show("Ime nalazista: " + onz.Ime);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodajNovoNalaziste_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                
                ZlatonosneReke zr = new ZlatonosneReke()
                {
                    Ime = "Moponeng",
                    ZemljaNalazenja = "Juzna afrika",
                    ImeNalazaca = "Jonny",
                    DatumOtkrivanja = new DateTime(1994, 07, 26)
                };
                

                s.Save(zr);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdIzmeniNalaziste_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.ZlatonosneReke zr;
                
                zr = s.Load<Entiteti.ZlatonosneReke>(61);

                zr.ImeReke = "Narin";

                s.SaveOrUpdate(zr);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdUcitajLokaciju_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o lokaciji sa zadatim id-jem
                LovacNaBlago.Entiteti.Lokacija l = s.Load<LovacNaBlago.Entiteti.Lokacija>(13);

                MessageBox.Show("Naziv lokacije: " + l.Naziv);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodajNovuLokaciju_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                
                Entiteti.Blago b = new Entiteti.Blago()
                {
                    Naziv = "Blago-nova lokacija"
                };

                Piramida p = new Piramida()
                {
                    Naziv = "Khafre",
                    ZemljaNalazenja = "Afrika"
                };

                s.Save(b);

                p.VezanaZa = b;
                s.Save(p);

                b.Lokacije.Add(p);

                s.Save(b);
                
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdIzmeniLokaciju_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Lokacija l;

                l = s.Load<LovacNaBlago.Entiteti.Lokacija>(41);

                l.Naziv = "Novi naziv";

                s.SaveOrUpdate(l);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdUcitajBlago_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o blagu sa zadatim id-jem
                LovacNaBlago.Entiteti.Blago b = s.Load<LovacNaBlago.Entiteti.Blago>(7);

                MessageBox.Show("Naziv blaga: "+b.Naziv);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodajNovoBlago_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                
                BlagoNepoznatogPorekla bnp = new BlagoNepoznatogPorekla()
                {
                    
                };

                Blago b = new Blago()
                {
                    Naziv = "Za brisanje"
                };
                
                s.Save(bnp);
                b.JePorekla = bnp;
                s.Save(b);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdIzmeniBlago_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Blago b;

                b = s.Load<LovacNaBlago.Entiteti.Blago>(83);

                b.Mapa = "Ne postoji";

                s.SaveOrUpdate(b);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdUcitajPredmet_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o predmetu sa zadatim id-jem
                LovacNaBlago.Entiteti.Predmet p = s.Load<LovacNaBlago.Entiteti.Predmet>(11);

                MessageBox.Show("Naziv predmeta: "+p.Naziv);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodajNoviPredmet_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                
                Entiteti.Blago b = new Entiteti.Blago()
                {
                    Naziv = "Blago-novi predmet"
                };

                Lobanja l = new Lobanja()
                {
                    Naziv = "Test lobanja"
                };

                s.Save(b);

                l.PripadaBlagu = b;
                s.Save(l);

                b.Predmeti.Add(l);

                s.Save(b);
                
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdIzmeniPredmet_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Predmet p;

                p = s.Load<LovacNaBlago.Entiteti.Predmet>(82);

                p.Materijal = "Zlato";

                s.SaveOrUpdate(p);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdUcitajLegendu_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o legendi sa zadatim id-jem
                LovacNaBlago.Entiteti.Legenda l = s.Load<LovacNaBlago.Entiteti.Legenda>(11);

                MessageBox.Show("Naziv legende: "+l.Naziv);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodajNovuLegendu_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                
                Entiteti.Blago b = new Entiteti.Blago()
                {
                    Naziv = "Blago-nova legenda"
                };

                Legenda l = new Legenda()
                {
                    Naziv = "Studiranje u doba korone",
                    Prica = "Test prica"
                };

                s.Save(b);

                l.VezanaZa = b;
                s.Save(l);

                b.Legende.Add(l);

                s.Save(b);
               
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdObrisiLegendu_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LovacNaBlago.Entiteti.Legenda l = s.Load<LovacNaBlago.Entiteti.Legenda>(41);

                s.Delete(l);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdObrisiPredmet_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LovacNaBlago.Entiteti.Predmet p = s.Load<LovacNaBlago.Entiteti.Predmet>(81);

                s.Delete(p);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdObrisiLokaciju_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LovacNaBlago.Entiteti.Lokacija l = s.Load<LovacNaBlago.Entiteti.Lokacija>(61);

                s.Delete(l);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdObrisiBlago_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LovacNaBlago.Entiteti.Blago b = s.Load<LovacNaBlago.Entiteti.Blago>(126);

                s.Delete(b);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdObrisiPoreklo_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LovacNaBlago.Entiteti.Poreklo p = s.Load<LovacNaBlago.Entiteti.Poreklo>(82);

                s.Delete(p);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdObrisiZastitu_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LovacNaBlago.Entiteti.Zastita z = s.Load<LovacNaBlago.Entiteti.Zastita>(41);

                s.Delete(z);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdObrisiNalaziste_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LovacNaBlago.Entiteti.ObicnaNalazistaZlata onz = s.Load<LovacNaBlago.Entiteti.ObicnaNalazistaZlata>(41);

                s.Delete(onz);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdIzmeniLegendu_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Legenda l;
                
                l = s.Load<LovacNaBlago.Entiteti.Legenda>(81);

                l.Prica = "Veoma teska prica";

                s.SaveOrUpdate(l);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdUcitajBlagaBezMape_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se sva blaga koja nemaju mapu
                IQuery q = s.CreateQuery("from Blago as o where o.Mapa='Ne postoji'");

                IList<Blago> blaga = q.List<Blago>();

                foreach (Blago b in blaga)
                {
                    MessageBox.Show("Id blaga: " + b.Id + " \n" + "Naziv blaga: " + b.Naziv);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdUcitajPredmeteOdZlata_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se svi predmeti od zlata
                IQuery q = s.CreateQuery("from Predmet as p where p.Materijal='Zlato'");
                

                IList<Predmet> predmeti = q.List<Predmet>();

                foreach (Predmet p in predmeti)
                {
                    MessageBox.Show("Id predmeta: " + p.Id + " \n" + "Naziv predmeta: " + p.Naziv);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdUcitajKletve_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se sve zastite ciji je tip kletva
                IQuery q = s.CreateQuery("from Zastita as z where Tip='Kletva'");

                IList<Zastita> zastite = q.List<Zastita>();

                foreach (Zastita z in zastite)
                {
                    MessageBox.Show("Id zastite: " + z.Id + " \n" + "Naziv zastite: " + z.Naziv);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdUcitajPecine_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se sve lokacije ciji je tip pecina
                IQuery q = s.CreateQuery("from Lokacija as l where Tip='Pecina'");

                IList<Lokacija> lokacije = q.List<Lokacija>();

                foreach (Lokacija l in lokacije)
                {
                    MessageBox.Show("Id lokacije: " + l.Id + " \n" + "Naziv lokacije: " + l.Naziv);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdUcitajZlatneZile_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se sva nalazista ciji je tip zlatne zile
                IQuery q = s.CreateQuery("from ObicnaNalazistaZlata as onz where Tip='Zlatne zile'");

                IList<ObicnaNalazistaZlata> zile = q.List<ObicnaNalazistaZlata>();

                foreach (ObicnaNalazistaZlata onz in zile)
                {
                    MessageBox.Show("Id nalazista: " + onz.Id + " \n" + "Ime nalazista: " + onz.Ime);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void cmdOneToManyPredmet_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LovacNaBlago.Entiteti.Blago b = s.Load<LovacNaBlago.Entiteti.Blago>(4);

                foreach (Predmet p in b.Predmeti)
                {
                    MessageBox.Show("Naziv blaga: " + b.Naziv + "\n" + "Naziv predmeta: " + p.Naziv);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdOneToManyLegenda_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LovacNaBlago.Entiteti.Blago b = s.Load<LovacNaBlago.Entiteti.Blago>(1);

                foreach (Legenda l in b.Legende)
                {
                    MessageBox.Show("Naziv blaga: " + b.Naziv + "\n" + "Naziv legende: " + l.Naziv);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdOneToManyLokacija_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LovacNaBlago.Entiteti.Blago b = s.Load<LovacNaBlago.Entiteti.Blago>(4);

                foreach (Lokacija l in b.Lokacije)
                {
                    MessageBox.Show("Naziv blaga: " + b.Naziv + "\n" + "Naziv lokacije: " + l.Naziv);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void cmdManyToOneBlagoLokacija_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LovacNaBlago.Entiteti.Lokacija l = s.Load<LovacNaBlago.Entiteti.Lokacija>(5);

                //Veza many to one 1:N Blago-Lokacija
                MessageBox.Show("Naziv lokacije: " + l.Naziv + "\n" + "Vezana za blago: " + l.VezanaZa.Naziv);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdManyToOneBlagoPredmet_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LovacNaBlago.Entiteti.Predmet p = s.Load<LovacNaBlago.Entiteti.Predmet>(9);

                //Veza many to one 1:N Blago-Predmet
                MessageBox.Show("Naziv predmeta: " + p.Naziv + "\n" + "Vezan za blago: " + p.PripadaBlagu.Naziv);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdManyToOneBlagoLegenda_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LovacNaBlago.Entiteti.Legenda l = s.Load<LovacNaBlago.Entiteti.Legenda>(1);

                //Veza many to one 1:N Blago-Legenda
                MessageBox.Show("Naziv legende: " + l.Naziv + "\n" + "Vezana za blago: " + l.VezanaZa.Naziv);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdOneToOneBlago_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LovacNaBlago.Entiteti.Poreklo p = s.Load<LovacNaBlago.Entiteti.Poreklo>(5);

                //Veza one to one 1:N Blago-Poreklo
                MessageBox.Show("Id porekla: " + p.Id + "\n" + "Vezano za blago: " + p.VezanoZa.Naziv);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdOneToOnePoreklo_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LovacNaBlago.Entiteti.Blago b = s.Load<LovacNaBlago.Entiteti.Blago>(5);

                //Veza one to one 1:N Blago-Poreklo
                MessageBox.Show("Naziv blaga: " + b.Naziv + "\n" + "Ima poreklo sa id-jem: " + b.JePorekla.Id);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void cmdUcitajLovca_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o lovcu sa zadatim id-jem
                LovacNaBlago.Entiteti.Lovac l = s.Load<LovacNaBlago.Entiteti.Lovac>(7);

                MessageBox.Show(l.Ime);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodajLovca_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
               
                Entiteti.Blago b = new Entiteti.Blago()
                {
                    Naziv = "Blago-novi lovac"
                };

                Lovac l = new Lovac()
                {
                    Ime = "Aleksandar",
                    PocetakTrazenja=new DateTime(2016,04,19),
                    KrajTrazenja=new DateTime(2019,02,06)
                };

                s.Save(b);

                l.TragaZa = b;
                s.Save(l);

                b.Lovci.Add(l);

                s.Save(b);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdOneToManyLovac_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LovacNaBlago.Entiteti.Blago b = s.Load<LovacNaBlago.Entiteti.Blago>(10);

                foreach (Lovac l in b.Lovci)
                {
                    MessageBox.Show("Naziv blaga: " + b.Naziv + "\n" + "Naziv lovca: " + l.Ime);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdManyToOneBlagoLovac_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LovacNaBlago.Entiteti.Lovac l = s.Load<LovacNaBlago.Entiteti.Lovac>(5);

                //Veza many to one 1:N Blago-Lovac
                MessageBox.Show("Ime lovca: " + l.Ime + "\n" + "Traga za blagom: " + l.TragaZa.Naziv);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdUcitajLovceUpit_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se svi lovci koji tragaju za blagom sa olimpa
                ISQLQuery q = s.CreateSQLQuery("SELECT * FROM LOVAC WHERE ID_BLAGA=5");
                q.AddEntity(typeof(Lovac));


                IList<Lovac> lovci = q.List<Lovac>();

                foreach (Lovac l in lovci)
                {
                    MessageBox.Show("Ime lovca: "+l.Ime);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdIzmeniLovca_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Lovac l;

                l = s.Load<LovacNaBlago.Entiteti.Lovac>(37);

                l.KrajTrazenja = new DateTime(2020, 03, 08);

                s.SaveOrUpdate(l);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdObrisiLovca_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LovacNaBlago.Entiteti.Lovac l = s.Load<LovacNaBlago.Entiteti.Lovac>(51);

                s.Delete(l);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdLegendaUpit_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se sve legende koje su vezane za blago akatora
                ISQLQuery q = s.CreateSQLQuery("SELECT * FROM LEGENDA WHERE ID_BLAGA=4");
                q.AddEntity(typeof(Legenda));


                IList<Legenda> legende = q.List<Legenda>();

                foreach (Legenda l in legende)
                {
                    MessageBox.Show("Naziv legende: " + l.Naziv);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdUcitajDefinisanje_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci definisanju zavisnosti sa zadatim id-jem
                LovacNaBlago.Entiteti.Definise d = s.Load<LovacNaBlago.Entiteti.Definise>(7);

                MessageBox.Show("Id definisanja: "+d.Id);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdManyToManyLegendaZastita_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Legenda l1 = s.Load<Legenda>(7);

                foreach (Entiteti.Zastita z1 in l1.Zastite)
                {
                    MessageBox.Show("Naziv zastite: "+z1.Naziv);
                }


                Entiteti.Zastita z2 = s.Load<Entiteti.Zastita>(7);

                foreach (Legenda l2 in z2.Legende)
                {
                    MessageBox.Show("Naziv legende: "+l2.Naziv);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdManyToManyLegendaLokacija_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Legenda l1 = s.Load<Legenda>(7);

                foreach (Entiteti.Lokacija lok1 in l1.Lokacije)
                {
                    MessageBox.Show("Naziv lokacije: " + lok1.Naziv);
                }


                Entiteti.Lokacija lok2 = s.Load<Entiteti.Lokacija>(7);

                foreach (Legenda l2 in lok2.Legende)
                {
                    MessageBox.Show("Naziv legende: " + l2.Naziv);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdManyToManyZastitaLokacija_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zastita z1 = s.Load<Zastita>(7);

                foreach (Entiteti.Lokacija lok1 in z1.Lokacije)
                {
                    MessageBox.Show("Naziv lokacije: " + lok1.Naziv);
                }


                Entiteti.Lokacija lok2 = s.Load<Entiteti.Lokacija>(7);

                foreach (Zastita z2 in lok2.Zastite)
                {
                    MessageBox.Show("Naziv zastite: " + z2.Naziv);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdDodajDefinisanje_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                
                Legenda l = new Legenda()
                {
                    Naziv = "Nova leg-def",
                    Prica="Nova leg-def prica"
                };
                
                Piramida p = new Piramida()
                {
                    Naziv = "Nova lok-def",
                    ZemljaNalazenja="Nova Lok-def"
                };

                Duh duh = new Duh()
                {
                    Naziv = "Nova Zas-def"
                };

                s.Save(l);
                s.Save(p);
                s.Save(duh);

                Definise d = new Definise();

                d.DefLegenda=l;
                d.DefLokacija=p;
                d.DefZastita=duh;

                s.Save(d);

                s.Flush();
                s.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdIzmeniDefinisanje_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Definise d;

                d = s.Load<LovacNaBlago.Entiteti.Definise>(41);

                UkletiZamak uz;

                uz = s.Load<Entiteti.UkletiZamak>(41);

                d.DefLokacija = uz;

                s.SaveOrUpdate(d);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdObrisiDefinisanje_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LovacNaBlago.Entiteti.Definise d = s.Load<LovacNaBlago.Entiteti.Definise>(42);

                s.Delete(d);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }
