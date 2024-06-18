using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using SahovskaFederacija.Entiteti;

namespace SahovskaFederacija
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdUcitavanjeSahovskiTurnir_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o sahovskom turniru sa id-jem 21
                SahovskaFederacija.Entiteti.Sahovski_Turnir p = s.Load<SahovskaFederacija.Entiteti.Sahovski_Turnir>(21);

                MessageBox.Show(p.Naziv); // Chess open Nis

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreiranjeSahovskogTurnira_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Sahista sah = new Entiteti.Sahista
                {
                    Zemlja_Porekla = "Srbija",
                    Broj_Pasosa = "121212121",
                    Datum_Uclanjenja = DateTime.Parse("2020-02-20 00:00:00"),
                    Lime = "Ivan",
                    Sslovo = 'I', // char
                    Prezime = "Ivanovic",
                    Adresa = "Srbija, Nis, Bulevar Zorana Djindjica 5/5",
                    Datum_Rodjenja = DateTime.Parse("2000-01-01 00:00:00")
                };

                s.Save(sah);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdManyToOne_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                // ucitavaju se podaci o partiji za zadatim id-jem
                Partija p = s.Load<Partija>(22);

                MessageBox.Show(p.Trajanje_Partije.ToString()); // 32
                MessageBox.Show(p.SahovskiTurnir.Naziv); // Chess open Nis

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdOneToMany_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                // ucitavaju se podaci o sahovskom turniru sa zadatim id-jem
                SahovskaFederacija.Entiteti.Sahovski_Turnir p = s.Load<SahovskaFederacija.Entiteti.Sahovski_Turnir>(21);

                foreach (Partija o in p.Partije)
                {
                    MessageBox.Show(o.Rezultat_Partije + " " + o.Trajanje_Partije);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreiranjeSahovskogTurniraSub_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Sahista sah = new Entiteti.Sahista
                {
                    Zemlja_Porekla = "Srbija",
                    Broj_Pasosa = "121212121",
                    Datum_Uclanjenja = DateTime.Parse("2020-02-20 00:00:00"),
                    Lime = "Ivan",
                    Sslovo = 'I', // char
                    Prezime = "Ivanovic",
                    Adresa = "Srbija, Nis, Bulevar Zorana Djindjica 5/5",
                    Datum_Rodjenja = DateTime.Parse("2000-01-01 00:00:00")
                };

                TakmicarskiNormalni t = new TakmicarskiNormalni()
                {
                    Naziv = "Chess open Beograd",
                    Zemlja = "Srbija",
                    Grad = "Beograd",
                    Godina_Odrzavanja = 2022,
                    Datum_Od = DateTime.Parse("2022-05-09 00:00:00"),
                    Datum_Do = DateTime.Parse("2022-05-11 00:00:00"),
                    Region = "Regionalni"
                };

                TakmicarskiBrzopotezni t1 = new TakmicarskiBrzopotezni()
                {
                    Naziv = "Chess open Novi Sad",
                    Zemlja = "Srbija",
                    Grad = "Novi Sad",
                    Godina_Odrzavanja = 2023,
                    Datum_Od = DateTime.Parse("2010-05-09 00:00:00"),
                    Datum_Do = DateTime.Parse("2010-05-11 00:00:00"), 
                    Region = "Internacionalni",
                    Max_Vreme_Trajanja = 20
                };

                s.Save(sah);
                s.Save(t);
                s.Save(t1);

                UcestvujeNa un1 = new UcestvujeNa();
                un1.Id.SahistaUcestvujeNa = sah;
                un1.Id.UcestvujeNaSahovski_Turnir = t;

                //sah.UcestvujeNaSahovski_Turnir.Add(un1);
                //t.SahistaUcestvujeNa.Add(un1);
                //s.Save(sah);
                //s.Save(t);
                s.Save(un1);

                UcestvujeNa un2 = new UcestvujeNa();
                un2.Id.SahistaUcestvujeNa = sah;
                un2.Id.UcestvujeNaSahovski_Turnir = t1;

                //sah.UcestvujeNaSahovski_Turnir.Add(un2);
                //t1.SahistaUcestvujeNa.Add(un2);
                //s.Save(sah);
                //s.Save(t1);
                s.Save(un2);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdManyToMany_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Organizator r1 = s.Load<Organizator>(21);

                foreach (Organizuje o1 in r1.OrganizujeSahovski_Turnir)
                {
                    MessageBox.Show(o1.Id.OrganizujeSahovski_Turnir.Naziv); // Chess open Nis, turniri u kojima je ucestvovao
                }
                 
                Sahovski_Turnir r2 = s.Load<Sahovski_Turnir>(21);

                foreach (Organizuje o2 in r2.OrganizatorOrganizuje)
                {
                    MessageBox.Show(o2.Id.OrganizatorOrganizuje.Lime + " " + o2.Id.OrganizatorOrganizuje.Prezime); // Mihailo Panic,
                }                                                                                                  // ko su organizatori turnira

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdManyToMany2_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Organizator o = new Entiteti.Organizator()
                {
                    Jmbg = "4444333322221",
                    Adresa = "Srbija, Nis, Bulevar Zorana Djindjica 4/4",
                    Lime = "Damjan",
                    Sslovo = 'D',
                    Prezime = "Damjanovic"
                };

                TakmicarskiNormalni sah = new TakmicarskiNormalni()
                {
                    Naziv = "Chess open Kragujevac",
                    Zemlja = "Srbija",
                    Grad = "Kragujevac",
                    Godina_Odrzavanja = 2021,
                    Datum_Od = DateTime.Parse("2021-05-09 00:00:00"),
                    Datum_Do = DateTime.Parse("2021-05-11 00:00:00"),
                    Region = "Regionalni"
                };

                s.Save(sah);
                s.Save(o);

                Organizuje org = new Organizuje();
                org.Id.OrganizujeSahovski_Turnir = sah;
                org.Id.OrganizatorOrganizuje = o;

                // sah.OrganizatorOrganizuje.Add(org);
                // o.OrganizujeSahovski_Turnir.Add(org);
                // s.Save(sah);
                // s.Save(o);

                s.Save(org);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdTablePerClassInheritance_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IList<Sahista> sahisti = s.QueryOver<Sahista>()
                                                .Where(p => p.Rbr == 21)
                                                .List<Sahista>();

                Majstor m = (Majstor)sahisti[0]; 

                MessageBox.Show(m.Lime + " " + m.Prezime); // Mitar Mitrovic

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreiranjeMajstora_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Majstor m = new Majstor()
                {
                    //Status = "Majstor",
                    Zemlja_Porekla = "Srbija",
                    Broj_Pasosa = "888889999",
                    Datum_Uclanjenja = DateTime.Parse("2021-05-09 00:00:00"),
                    Lime = "Nikola",
                    Sslovo = 'N',
                    Prezime = "Nikolic",
                    Adresa = "Srbija, Nis, Bulevar Zorana Djindjica 3/3",
                    Datum_Rodjenja = DateTime.Parse("2001-01-09 00:00:00"),
                    Datum_Zvanja = DateTime.Parse("2022-05-09 00:00:00")
                };

                s.Save(m);
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdTablePerClassHierarchyInheritance_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IList<Sahovski_Turnir> turniri = s.QueryOver<Sahovski_Turnir>()
                                                .List<Sahovski_Turnir>();

                foreach (Sahovski_Turnir t in turniri)
                {
                    if (t.GetType() == typeof(TakmicarskiNormalni))
                    {
                        TakmicarskiNormalni t1 = (TakmicarskiNormalni)t;
                    }
                    else if (t.GetType() == typeof(TakmicarskiBrzopotezni))
                    {
                        TakmicarskiBrzopotezni t2 = (TakmicarskiBrzopotezni)t;
                    }
                    else if (t.GetType() == typeof(EgzibicioniNormalni))
                    {
                        EgzibicioniNormalni t3 = (EgzibicioniNormalni) t;
                    }
                    else
                    {
                        EgzibicioniBrzopotezni t4 = (EgzibicioniBrzopotezni) t;
                    }
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreiranjePodklaseSahovskogTurnira_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                // kolona NACIN_ODIGRAVANJA_ZNACAJ automatski dobija vrednost "TakmicarskiNormalni"
                TakmicarskiNormalni t = new TakmicarskiNormalni()
                {
                    Naziv = "Chess open Subotica",
                    Zemlja = "Srbija",
                    Grad = "Subotica",
                    Godina_Odrzavanja = 2019,
                    Datum_Od = DateTime.Parse("2019-05-09 00:00:00"),
                    Datum_Do = DateTime.Parse("2019-05-11 00:00:00"),
                    Region = "Regionalni"
                };

                s.Save(t);
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdGet_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Partija t = s.Get<Partija>(21);

                if (t != null)
                {
                    MessageBox.Show(t.SahovskiTurnir.Naziv); // Chess open Nis
                }
                else
                {
                    MessageBox.Show("Ne postoji partija sa zadatim id-jem/Partija nije odigrana na turniru.");
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Partija p = s.Get<Partija>(21);

                // obrada podataka o partiji

                s.Refresh(p);
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreiranjeUpita_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("from Partija");

                IList<Partija> partije = q.List<Partija>();

                foreach (Partija p in partije)
                {
                    MessageBox.Show(p.Rezultat_Partije);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreiranjeUpita2_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                // Partije gde je pobedio sahista sa crnim figurama
                IQuery q = s.CreateQuery("from Partija as p where p.Rezultat_Partije = 'MatC'");
                
                IList<Partija> partije = q.List<Partija>();

                foreach (Partija p in partije)
                {
                    MessageBox.Show("Id partije: " + p.Id +
                                    ", Rbr igraca sa crnim figurama: " + p.Crne_Figure.Rbr.ToString() +
                                    ", Rbr igraca sa belim figurama: " + p.Bele_Figure.Rbr.ToString());
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreiranjeUpitaSaImenovanimParametrima_Click(object sender, EventArgs e)
        {
            //...
        }

        private void cmdKreiranjeUpitaSaParametrima_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                // paramterizovani upit
                IQuery q = s.CreateQuery("from Partija as p where p.Rezultat_Partije = ? and p.Trajanje_Partije >= ?");
                q.SetParameter(0, "MatC");
                q.SetInt32(1, 40);

                IList<Partija> partije = q.List<Partija>();

                foreach (Partija p in partije)
                {
                    MessageBox.Show(p.Id + " " + p.Rezultat_Partije + " " + p.Trajanje_Partije);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreiranjeUpitaSaImenovanimParametrima_Click_1(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                // paramterizovani upit
                IQuery q = s.CreateQuery("select p.Sudija from Partija as p "
                                        + " where p.Rezultat_Partije = :rez and p.Trajanje_Partije >= :vreme");
                q.SetString("rez", "MatC");
                q.SetInt32("vreme", 40);

                IList<Entiteti.Sudija> sudije = q.List<Entiteti.Sudija>();

                foreach (Entiteti.Sudija sud in sudije)
                {                     
                    MessageBox.Show(sud.Id.ToString());
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreiranjeUpitaSaImenovanimParametrima2_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                // paramterizovani upit
                IQuery q = s.CreateQuery("select p.SahovskiTurnir from Partija as p "
                                        + " where p.Rezultat_Partije = :rez and p.Trajanje_Partije >= :vreme "
                                        + " and p.SahovskiTurnir.Grad = :grad");
                q.SetString("rez", "MatC");
                q.SetInt32("vreme", 40);
                q.SetString("grad", "Nis");

                IList<Entiteti.Sahovski_Turnir> turniri = q.List<Entiteti.Sahovski_Turnir>();

                foreach (Entiteti.Sahovski_Turnir t in turniri)
                {
                    MessageBox.Show(t.Naziv); // Chess open Nis
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdEnumerable_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("from Partija");

                IEnumerable<Partija> partije = q.Enumerable<Partija>();

                foreach (Partija p in partije)
                {
                    if (p.Trajanje_Partije >= 40)
                        break;
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdScalar_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("select sum(p.Trajanje_Partije) from Partija p ");

                // za slucaj da upit vraca samo jednu vrednost
                Int64 trajanje = q.UniqueResult<Int64>();

                MessageBox.Show(trajanje.ToString());

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdUnique_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("select sah from Sahista sah where sah.Rbr = 21 ");

                // za slucaj da upit vraca samo jednu vrednost
                Sahista sah = q.UniqueResult<Sahista>();

                MessageBox.Show(sah.Adresa);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdVisestrukiRezultati_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("select sah.Lime, sum(sah.Rbr), count(sah) from Sahista sah "
                                        + " group by sah.Lime ");

                // za slucaj da upit vraca visestruku vrednost
                IList<object[]> result = q.List<object[]>();

                foreach (object[] r in result)
                {
                    string lime = (string)r[0];
                    Int64 sumarbr = (Int64)r[1];
                    long broj = (long)r[2];

                    MessageBox.Show(lime + " " + broj.ToString() + " " + sumarbr.ToString());
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdStranicenje_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("from Sahista");
                q.SetFirstResult(2);
                q.SetMaxResults(2);

                IList<Sahista> sahiste = q.List<Sahista>();

                foreach (Sahista sah in sahiste)
                {
                    MessageBox.Show(sah.Rbr.ToString());
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreiranjeCriteria_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ICriteria c = s.CreateCriteria<Partija>();

                c.Add(Expression.Ge("Trajanje_Partije", 40));
                c.Add(Expression.Eq("Rezultat_Partije", "MatC"));

                IList<Partija> partije = c.List<Partija>();

                foreach (Partija p in partije)
                {
                    MessageBox.Show(p.Id.ToString());
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdQueryOver_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IList<Partija> partije = s.QueryOver<Partija>()
                                                .Where(x => x.Trajanje_Partije >= 40)
                                                .Where(x => x.Rezultat_Partije  == "MatC")
                                                .List<Partija>();

                foreach (Partija p in partije)
                {
                    MessageBox.Show(p.Id.ToString());
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdNativeSQL_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ISQLQuery q = s.CreateSQLQuery("SELECT P.* FROM PARTIJA P");
                q.AddEntity(typeof(Partija));

                IList<Partija> partije = q.List<Partija>();

                foreach (Partija p in partije)
                {
                    MessageBox.Show(p.Id.ToString());
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                
                Partija p = s.Load<Partija>(21);

                //objekat se modifikuje potpuno nezavisno od sesije
                p.Trajanje_Partije = 44;

                //originalna sesija se zatvara i raskida se veza izmedju objekta i sesije
                s.Close();

                //otvara se nova sesija
                ISession s1 = DataLayer.GetSession();

                //poziva se Update i objekat se povezuje sa novom sesijom
                s1.Update(p);

                s1.Flush();
                s1.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sahista sah = s.Load<Sahista>(25);

                //brise se objekat iz baze ali ne i instanca objekta u memroiji
                s.Delete(sah);
                //s.Delete("from Sahista");

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdTransakcija_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sahovski_Turnir turnir = s.Load<Sahovski_Turnir>(66);

                ITransaction t = s.BeginTransaction();

                s.Delete(turnir);

                //t.Commit();
                t.Rollback();

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdLINQ_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IList<Partija> partije = (from p in s.Query<Partija>()
                                              where (p.Trajanje_Partije >= 40 && p.Rezultat_Partije == "MatC")
                                              select p).ToList<Partija>();

                foreach (Partija p in partije)
                {
                    MessageBox.Show(p.Id.ToString());
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdLINQ1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Partija> partije = from p in s.Query<Partija>()
                                                  where (p.Rezultat_Partije == "MatC" || p.Rezultat_Partije == "Remi")
                                                  orderby p.Trajanje_Partije, p.Rezultat_Partije.Length 
                                                  select p;

                foreach (Partija p in partije)
                {
                    MessageBox.Show(p.Id.ToString());
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdLINQ2_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Partija> partije = s.Query<Partija>()
                                                    .Where(p => (p.Rezultat_Partije == "MatC" || p.Rezultat_Partije == "Remi"))
                                                    .OrderBy(p => p.Trajanje_Partije).ThenBy(p => p.Rezultat_Partije.Length)
                                                    .Select(p => p);

                foreach (Partija p in partije)
                {
                    MessageBox.Show(p.Id.ToString());
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdUcestvujeNa_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sahista sah = s.Load<Sahista>(61);
                Sahovski_Turnir turnir = s.Load<Sahovski_Turnir>(66);

                UcestvujeNa un = new UcestvujeNa();
                un.Id.SahistaUcestvujeNa = sah;
                un.Id.UcestvujeNaSahovski_Turnir = turnir;

                //sah.UcestvujeNaSahovski_Turnir.Add(un);
                //turnir.SahistaUcestvujeNa.Add(un);
                //s.Save(sah);
                //s.Save(turnir);

                s.Save(un);
                s.Flush();
                s.Close();
            }   
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
    }
}
