using NHibernate;
using SahovskaFederacija.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SahovskaFederacija
{
    public class DTOManager // klasa koja nam pomaze da, na osnovu informacija koje stizu sa
                            // koriscnickog interfejsa, saznamo sta je izmenjeno i da onda
                            // izvrsimo odgovarajuce upite ka nasoj bazi
    {
        #region Sahovski_Turnir

        public static void obrisiSahovski_Turnir(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sahovski_Turnir turnir = s.Load<Sahovski_Turnir>(id);

                s.Delete(turnir);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static Sahovski_TurnirBasic vratiSahovski_Turnir(int id)
        {
            Sahovski_TurnirBasic t = new Sahovski_TurnirBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Sahovski_Turnir turnir = s.Load<Sahovski_Turnir>(id);

                t.Id = turnir.Id;
                t.Naziv = turnir.Naziv;
                t.Zemlja = turnir.Zemlja;
                t.Grad = turnir.Grad;
                t.Godina_Odrzavanja = turnir.Godina_Odrzavanja;
                t.Datum_Od = turnir.Datum_Od;
                t.Datum_Do = turnir.Datum_Do;

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return t;
        }

        public static void izmeniSahovski_Turnir(Sahovski_TurnirBasic turnir)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.Sahovski_Turnir t = s.Load<Sahovski_Turnir>(turnir.Id);

                t.Naziv = turnir.Naziv;
                t.Zemlja = turnir.Zemlja;
                t.Grad = turnir.Grad;
                t.Godina_Odrzavanja = turnir.Godina_Odrzavanja;
                t.Datum_Od = turnir.Datum_Od;
                t.Datum_Do = turnir.Datum_Do;

                s.SaveOrUpdate(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static List<Sahovski_TurnirPregled> vratiSveTurnire()
        {
            List<Sahovski_TurnirPregled> turniri = new List<Sahovski_TurnirPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<SahovskaFederacija.Entiteti.Sahovski_Turnir> sviTurniri = from t in s.Query<SahovskaFederacija.Entiteti.Sahovski_Turnir>()
                                                                                      select t;

                foreach (SahovskaFederacija.Entiteti.Sahovski_Turnir t in sviTurniri)
                {
                    turniri.Add(new Sahovski_TurnirPregled(t.Id, t.Naziv, t.Datum_Od, t.Datum_Do));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return turniri;
        }

        public static List<PartijaBasic> GetTurnirPartijeInfos(int turnirId)
        {
            List<PartijaBasic> partijeInfos = new List<PartijaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Partija> partije = from p in s.Query<Partija>()
                                               where p.SahovskiTurnir.Id == turnirId
                                               select p;

                foreach (Partija p in partije)
                {
                    partijeInfos.Add(new PartijaBasic(p.Id, p.Datum_Vreme_Odigravanja, p.Rezultat_Partije, p.Trajanje_Partije/*, p.Crne_Figure, p.Bele_Figure, p.SahovskiTurnir, p.Sudija*/));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return partijeInfos;
        } // partije odigrane na turniru

        public static List<SponzoriBasic> GetTurnirSponzoriInfos(int turnirId)
        {
            List<SponzoriBasic> sponzoriInfos = new List<SponzoriBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Sponzori> sponzori = from spo in s.Query<Sponzori>()
                                                 where spo.SahovskiTurnir.Id == turnirId
                                                 select spo;

                foreach (Sponzori spo in sponzori)
                {
                    sponzoriInfos.Add(new SponzoriBasic(spo.Sponzor));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return sponzoriInfos;
        } // sponzori na turniru

        // ...

        #region TakmicarskiNormalni

        public static void obrisiTakmicarskiNormalni(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                TakmicarskiNormalni turnir = s.Load<TakmicarskiNormalni>(id);

                s.Delete(turnir);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static TakmicarskiNormalniBasic vratiTakmicarskiNormalni(int id)
        {
            TakmicarskiNormalniBasic t = new TakmicarskiNormalniBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                TakmicarskiNormalni turnir = s.Load<TakmicarskiNormalni>(id);

                t.Id = turnir.Id;
                t.Naziv = turnir.Naziv;
                t.Zemlja = turnir.Zemlja;
                t.Grad = turnir.Grad;
                t.Godina_Odrzavanja = turnir.Godina_Odrzavanja;
                t.Datum_Od = turnir.Datum_Od;
                t.Datum_Do = turnir.Datum_Do;
                t.Region = turnir.Region;

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return t;
        }

        public static void izmeniTakmicarskiNormalni(TakmicarskiNormalniBasic turnir)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.TakmicarskiNormalni t = s.Load<TakmicarskiNormalni>(turnir.Id);

                t.Naziv = turnir.Naziv;
                t.Zemlja = turnir.Zemlja;
                t.Grad = turnir.Grad;
                t.Godina_Odrzavanja = turnir.Godina_Odrzavanja;
                t.Datum_Od = turnir.Datum_Od;
                t.Datum_Do = turnir.Datum_Do;
                t.Region = turnir.Region;

                s.SaveOrUpdate(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void sacuvajTakmicarskiNormalni(TakmicarskiNormalniBasic turnir)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.TakmicarskiNormalni t = new SahovskaFederacija.Entiteti.TakmicarskiNormalni();

                t.Naziv = turnir.Naziv;
                t.Zemlja = turnir.Zemlja;
                t.Grad = turnir.Grad;
                t.Godina_Odrzavanja = turnir.Godina_Odrzavanja;
                t.Datum_Od = turnir.Datum_Od;
                t.Datum_Do = turnir.Datum_Do;
                t.Region = turnir.Region;

                s.Save(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        // ...

        #endregion

        #region TakmicarskiBrzopotezni

        public static void obrisiTakmicarskiBrzopotezni(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                TakmicarskiBrzopotezni turnir = s.Load<TakmicarskiBrzopotezni>(id);

                s.Delete(turnir);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static TakmicarskiBrzopotezniBasic vratiTakmicarskiBrzopotezni(int id)
        {
            TakmicarskiBrzopotezniBasic t = new TakmicarskiBrzopotezniBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                TakmicarskiBrzopotezni turnir = s.Load<TakmicarskiBrzopotezni>(id);

                t.Id = turnir.Id;
                t.Naziv = turnir.Naziv;
                t.Zemlja = turnir.Zemlja;
                t.Grad = turnir.Grad;
                t.Godina_Odrzavanja = turnir.Godina_Odrzavanja;
                t.Datum_Od = turnir.Datum_Od;
                t.Datum_Do = turnir.Datum_Do;
                t.Region = turnir.Region;
                t.Max_Vreme_Trajanja = turnir.Max_Vreme_Trajanja;

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return t;
        }

        public static void izmeniTakmicarskiBrzopotezni(TakmicarskiBrzopotezniBasic turnir)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.TakmicarskiBrzopotezni t = s.Load<TakmicarskiBrzopotezni>(turnir.Id);

                t.Naziv = turnir.Naziv;
                t.Zemlja = turnir.Zemlja;
                t.Grad = turnir.Grad;
                t.Godina_Odrzavanja = turnir.Godina_Odrzavanja;
                t.Datum_Od = turnir.Datum_Od;
                t.Datum_Do = turnir.Datum_Do;
                t.Region = turnir.Region;
                t.Max_Vreme_Trajanja = turnir.Max_Vreme_Trajanja;

                s.SaveOrUpdate(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void sacuvajTakmicarskiBrzopotezni(TakmicarskiBrzopotezniBasic turnir)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.TakmicarskiBrzopotezni t = new SahovskaFederacija.Entiteti.TakmicarskiBrzopotezni();

                t.Naziv = turnir.Naziv;
                t.Zemlja = turnir.Zemlja;
                t.Grad = turnir.Grad;
                t.Godina_Odrzavanja = turnir.Godina_Odrzavanja;
                t.Datum_Od = turnir.Datum_Od;
                t.Datum_Do = turnir.Datum_Do;
                t.Region = turnir.Region;
                t.Max_Vreme_Trajanja = turnir.Max_Vreme_Trajanja;

                s.Save(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        // ...

        #endregion

        #region EgzibicioniNormalni

        public static void obrisiEgzibicioniNormalni(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                EgzibicioniNormalni turnir = s.Load<EgzibicioniNormalni>(id);

                s.Delete(turnir);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static EgzibicioniNormalniBasic vratiEgzibicioniNormalni(int id)
        {
            EgzibicioniNormalniBasic t = new EgzibicioniNormalniBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                EgzibicioniNormalni turnir = s.Load<EgzibicioniNormalni>(id);

                t.Id = turnir.Id;
                t.Naziv = turnir.Naziv;
                t.Zemlja = turnir.Zemlja;
                t.Grad = turnir.Grad;
                t.Godina_Odrzavanja = turnir.Godina_Odrzavanja;
                t.Datum_Od = turnir.Datum_Od;
                t.Datum_Do = turnir.Datum_Do;
                t.Tip = turnir.Tip;
                t.Novac_Namenjen = turnir.Novac_Namenjen;
                t.Prikupljen_Iznos = turnir.Prikupljen_Iznos;

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return t;
        }

        public static void izmeniEgzibicioniNormalni(EgzibicioniNormalniBasic turnir)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.EgzibicioniNormalni t = s.Load<EgzibicioniNormalni>(turnir.Id);

                t.Naziv = turnir.Naziv;
                t.Zemlja = turnir.Zemlja;
                t.Grad = turnir.Grad;
                t.Godina_Odrzavanja = turnir.Godina_Odrzavanja;
                t.Datum_Od = turnir.Datum_Od;
                t.Datum_Do = turnir.Datum_Do;
                t.Tip = turnir.Tip;
                t.Novac_Namenjen = turnir.Novac_Namenjen;
                t.Prikupljen_Iznos = turnir.Prikupljen_Iznos;

                s.SaveOrUpdate(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void sacuvajEgzibicioniNormalni(EgzibicioniNormalniBasic turnir)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.EgzibicioniNormalni t = new SahovskaFederacija.Entiteti.EgzibicioniNormalni();

                t.Naziv = turnir.Naziv;
                t.Zemlja = turnir.Zemlja;
                t.Grad = turnir.Grad;
                t.Godina_Odrzavanja = turnir.Godina_Odrzavanja;
                t.Datum_Od = turnir.Datum_Od;
                t.Datum_Do = turnir.Datum_Do;
                t.Tip = turnir.Tip;
                t.Novac_Namenjen = turnir.Novac_Namenjen;
                t.Prikupljen_Iznos = turnir.Prikupljen_Iznos;

                s.Save(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        // ...

        #endregion

        #region EgzibicioniBrzopotezni

        public static void obrisiEgzibicioniBrzopotezni(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                EgzibicioniBrzopotezni turnir = s.Load<EgzibicioniBrzopotezni>(id);

                s.Delete(turnir);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static EgzibicioniBrzopotezniBasic vratiEgzibicioniBrzopotezni(int id)
        {
            EgzibicioniBrzopotezniBasic t = new EgzibicioniBrzopotezniBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                EgzibicioniBrzopotezni turnir = s.Load<EgzibicioniBrzopotezni>(id);

                t.Id = turnir.Id;
                t.Naziv = turnir.Naziv;
                t.Zemlja = turnir.Zemlja;
                t.Grad = turnir.Grad;
                t.Godina_Odrzavanja = turnir.Godina_Odrzavanja;
                t.Datum_Od = turnir.Datum_Od;
                t.Datum_Do = turnir.Datum_Do;
                t.Tip = turnir.Tip;
                t.Novac_Namenjen = turnir.Novac_Namenjen;
                t.Prikupljen_Iznos = turnir.Prikupljen_Iznos;
                t.Max_Vreme_Trajanja = turnir.Max_Vreme_Trajanja;

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return t;
        }

        public static void izmeniEgzibicioniBrzopotezni(EgzibicioniBrzopotezniBasic turnir)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.EgzibicioniBrzopotezni t = s.Load<EgzibicioniBrzopotezni>(turnir.Id);

                t.Naziv = turnir.Naziv;
                t.Zemlja = turnir.Zemlja;
                t.Grad = turnir.Grad;
                t.Godina_Odrzavanja = turnir.Godina_Odrzavanja;
                t.Datum_Od = turnir.Datum_Od;
                t.Datum_Do = turnir.Datum_Do;
                t.Tip = turnir.Tip;
                t.Novac_Namenjen = turnir.Novac_Namenjen;
                t.Prikupljen_Iznos = turnir.Prikupljen_Iznos;
                t.Max_Vreme_Trajanja = turnir.Max_Vreme_Trajanja;

                s.SaveOrUpdate(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void sacuvajEgzibicioniBrzopotezni(EgzibicioniBrzopotezniBasic turnir)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.EgzibicioniBrzopotezni t = new SahovskaFederacija.Entiteti.EgzibicioniBrzopotezni();

                t.Naziv = turnir.Naziv;
                t.Zemlja = turnir.Zemlja;
                t.Grad = turnir.Grad;
                t.Godina_Odrzavanja = turnir.Godina_Odrzavanja;
                t.Datum_Od = turnir.Datum_Od;
                t.Datum_Do = turnir.Datum_Do;
                t.Tip = turnir.Tip;
                t.Novac_Namenjen = turnir.Novac_Namenjen;
                t.Prikupljen_Iznos = turnir.Prikupljen_Iznos;
                t.Max_Vreme_Trajanja = turnir.Max_Vreme_Trajanja;

                s.Save(t);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        // ...

        #endregion

        #endregion

        #region Sahista

        public static void obrisiSahista(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.Sahista sah = s.Load<SahovskaFederacija.Entiteti.Sahista>(id);

                s.Delete(sah);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static SahistaBasic vratiSahista(int id)
        {
            SahistaBasic sh = new SahistaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Sahista sah = s.Load<Sahista>(id);

                sh.Zemlja_Porekla = sah.Zemlja_Porekla;
                sh.Broj_Pasosa = sah.Broj_Pasosa;
                sh.Datum_Uclanjenja = sah.Datum_Uclanjenja;
                sh.Lime = sah.Lime;
                sh.Sslovo = sah.Sslovo;
                sh.Prezime = sah.Prezime;
                sh.Adresa = sah.Adresa;
                sh.Datum_Rodjenja = sah.Datum_Rodjenja;
                sh.Status = sah.Status;

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return sh;
        }

        public static void izmeniSahista(SahistaBasic sah)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.Sahista sh = s.Load<SahovskaFederacija.Entiteti.Sahista>(sah.Rbr);

                sh.Zemlja_Porekla = sah.Zemlja_Porekla;
                sh.Broj_Pasosa = sah.Broj_Pasosa;
                sh.Datum_Uclanjenja = sah.Datum_Uclanjenja;
                sh.Lime = sah.Lime;
                sh.Sslovo = sah.Sslovo;
                sh.Prezime = sah.Prezime;
                sh.Adresa = sah.Adresa;
                sh.Datum_Rodjenja = sah.Datum_Rodjenja;
                sh.Status = sah.Status;

                s.SaveOrUpdate(sh);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void sacuvajSahista(SahistaBasic sah)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.Sahista sh = new SahovskaFederacija.Entiteti.Sahista();

                sh.Zemlja_Porekla = sah.Zemlja_Porekla;
                sh.Broj_Pasosa = sah.Broj_Pasosa;
                sh.Datum_Uclanjenja = sah.Datum_Uclanjenja;
                sh.Lime = sah.Lime;
                sh.Sslovo = sah.Sslovo;
                sh.Prezime = sah.Prezime;
                sh.Adresa = sah.Adresa;
                sh.Datum_Rodjenja = sah.Datum_Rodjenja;
                sh.Status = sah.Status;

                s.SaveOrUpdate(sh);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static List<SahistaPregled> vratiSveSahiste()
        {
            List<SahistaPregled> sahisti = new List<SahistaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<SahovskaFederacija.Entiteti.Sahista> sviSahisti = from sah in s.Query<SahovskaFederacija.Entiteti.Sahista>()
                                                                                      select sah;

                foreach (SahovskaFederacija.Entiteti.Sahista sah in sviSahisti)
                {
                    sahisti.Add(new SahistaPregled(sah.Rbr, sah.Zemlja_Porekla, sah.Datum_Uclanjenja, sah.Lime, sah.Prezime, sah.Status));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return sahisti;
        }


        // ...

        #endregion

        #region Majstor

        public static void obrisiMajstor(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.Majstor sah = s.Load<SahovskaFederacija.Entiteti.Majstor>(id);

                s.Delete(sah);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static MajstorBasic vratiMajstor(int id)
        {
            MajstorBasic sh = new MajstorBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Majstor sah = s.Load<Majstor>(id);

                sh.Zemlja_Porekla = sah.Zemlja_Porekla;
                sh.Broj_Pasosa = sah.Broj_Pasosa;
                sh.Datum_Uclanjenja = sah.Datum_Uclanjenja;
                sh.Lime = sah.Lime;
                sh.Sslovo = sah.Sslovo;
                sh.Prezime = sah.Prezime;
                sh.Adresa = sah.Adresa;
                sh.Datum_Rodjenja = sah.Datum_Rodjenja;
                sh.Status = sah.Status;
                sh.Datum_Zvanja = sah.Datum_Zvanja;

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return sh;
        }

        public static void izmeniMajstor(MajstorBasic sah)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.Majstor sh = s.Load<SahovskaFederacija.Entiteti.Majstor>(sah.Rbr);

                sh.Zemlja_Porekla = sah.Zemlja_Porekla;
                sh.Broj_Pasosa = sah.Broj_Pasosa;
                sh.Datum_Uclanjenja = sah.Datum_Uclanjenja;
                sh.Lime = sah.Lime;
                sh.Sslovo = sah.Sslovo;
                sh.Prezime = sah.Prezime;
                sh.Adresa = sah.Adresa;
                sh.Datum_Rodjenja = sah.Datum_Rodjenja;
                sh.Status = sah.Status;
                sh.Datum_Zvanja = sah.Datum_Zvanja;

                s.SaveOrUpdate(sh);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void sacuvajMajstor(MajstorBasic sah)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.Majstor sh = new SahovskaFederacija.Entiteti.Majstor();

                sh.Zemlja_Porekla = sah.Zemlja_Porekla;
                sh.Broj_Pasosa = sah.Broj_Pasosa;
                sh.Datum_Uclanjenja = sah.Datum_Uclanjenja;
                sh.Lime = sah.Lime;
                sh.Sslovo = sah.Sslovo;
                sh.Prezime = sah.Prezime;
                sh.Adresa = sah.Adresa;
                sh.Datum_Rodjenja = sah.Datum_Rodjenja;
                sh.Status = sah.Status;
                SahovskaFederacija.Entiteti.Sudija sud = s.Load<SahovskaFederacija.Entiteti.Sudija>(sah.Sudija.Id);
                sh.Sudija = sud;

                s.SaveOrUpdate(sh);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        // ...

        #endregion

        #region Majstorski_Kandidat

        public static void obrisiMajstorski_Kandidat(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.Majstorski_Kandidat sah = s.Load<SahovskaFederacija.Entiteti.Majstorski_Kandidat>(id);

                s.Delete(sah);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static Majstorski_KandidatBasic vratiMajstorski_Kandidat(int id)
        {
            Majstorski_KandidatBasic sh = new Majstorski_KandidatBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Majstorski_Kandidat sah = s.Load<Majstorski_Kandidat>(id);

                sh.Zemlja_Porekla = sah.Zemlja_Porekla;
                sh.Broj_Pasosa = sah.Broj_Pasosa;
                sh.Datum_Uclanjenja = sah.Datum_Uclanjenja;
                sh.Lime = sah.Lime;
                sh.Sslovo = sah.Sslovo;
                sh.Prezime = sah.Prezime;
                sh.Adresa = sah.Adresa;
                sh.Datum_Rodjenja = sah.Datum_Rodjenja;
                sh.Status = sah.Status;
                sh.Broj_Partija_Do_Zvanja = sah.Broj_Partija_Do_Zvanja;

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return sh;
        }

        public static void izmeniMajstorski_Kandidat(Majstorski_KandidatBasic sah)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.Majstorski_Kandidat sh = s.Load<SahovskaFederacija.Entiteti.Majstorski_Kandidat>(sah.Rbr);

                sh.Zemlja_Porekla = sah.Zemlja_Porekla;
                sh.Broj_Pasosa = sah.Broj_Pasosa;
                sh.Datum_Uclanjenja = sah.Datum_Uclanjenja;
                sh.Lime = sah.Lime;
                sh.Sslovo = sah.Sslovo;
                sh.Prezime = sah.Prezime;
                sh.Adresa = sah.Adresa;
                sh.Datum_Rodjenja = sah.Datum_Rodjenja;
                sh.Status = sah.Status;
                sh.Broj_Partija_Do_Zvanja = sah.Broj_Partija_Do_Zvanja;

                s.SaveOrUpdate(sh);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void sacuvajMajstorski_Kandidat(Majstorski_KandidatBasic sah)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.Majstorski_Kandidat sh = new SahovskaFederacija.Entiteti.Majstorski_Kandidat();

                sh.Zemlja_Porekla = sah.Zemlja_Porekla;
                sh.Broj_Pasosa = sah.Broj_Pasosa;
                sh.Datum_Uclanjenja = sah.Datum_Uclanjenja;
                sh.Lime = sah.Lime;
                sh.Sslovo = sah.Sslovo;
                sh.Prezime = sah.Prezime;
                sh.Adresa = sah.Adresa;
                sh.Datum_Rodjenja = sah.Datum_Rodjenja;
                sh.Status = sah.Status;
                sh.Broj_Partija_Do_Zvanja = sah.Broj_Partija_Do_Zvanja;

                s.SaveOrUpdate(sh);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        // ...

        #endregion

        #region Organizator

        public static void obrisiOrganizator(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.Organizator o = s.Load<SahovskaFederacija.Entiteti.Organizator>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static OrganizatorBasic vratiOrganizator(int id)
        {
            OrganizatorBasic o = new OrganizatorBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Organizator org = s.Load<Organizator>(id);

                o.Jmbg = org.Jmbg;
                o.Adresa = org.Adresa;
                o.Lime = org.Lime;
                o.Sslovo = org.Sslovo;
                o.Prezime = org.Prezime;

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return o;
        }

        public static void izmeniOrganizator(OrganizatorBasic org)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.Organizator o = s.Load<SahovskaFederacija.Entiteti.Organizator>(org.Id);

                o.Jmbg = org.Jmbg;
                o.Adresa = org.Adresa;
                o.Lime = org.Lime;
                o.Sslovo = org.Sslovo;
                o.Prezime = org.Prezime;

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void sacuvajOrganizator(OrganizatorBasic org)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.Organizator o = new SahovskaFederacija.Entiteti.Organizator();

                o.Jmbg = org.Jmbg;
                o.Adresa = org.Adresa;
                o.Lime = org.Lime;
                o.Sslovo = org.Sslovo;
                o.Prezime = org.Prezime;
                SahovskaFederacija.Entiteti.Sudija sud = s.Load<SahovskaFederacija.Entiteti.Sudija>(org.Sudija.Id);
                o.Sudija = sud;

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static List<OrganizatorPregled> vratiSveOrganizatore()
        {
            List<OrganizatorPregled> organizatori = new List<OrganizatorPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<SahovskaFederacija.Entiteti.Organizator> sviOrganizatori = from o in s.Query<SahovskaFederacija.Entiteti.Organizator>()
                                                                              select o;

                foreach (SahovskaFederacija.Entiteti.Organizator o in sviOrganizatori)
                {
                    organizatori.Add(new OrganizatorPregled(o.Id, o.Lime, o.Prezime));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return organizatori;
        }

        // ...

        #endregion

        #region Partija

        public static void obrisiPartija(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.Partija p = s.Load<SahovskaFederacija.Entiteti.Partija>(id);

                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static PartijaBasic vratiPartija(int id)
        {
            PartijaBasic p = new PartijaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Partija par = s.Load<Partija>(id);

                p.Datum_Vreme_Odigravanja = par.Datum_Vreme_Odigravanja;
                p.Rezultat_Partije = par.Rezultat_Partije;
                p.Trajanje_Partije = par.Trajanje_Partije;

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return p;
        }

        public static void izmeniPartija(PartijaBasic par)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.Partija p = s.Load<SahovskaFederacija.Entiteti.Partija>(par.Id);

                p.Datum_Vreme_Odigravanja = par.Datum_Vreme_Odigravanja;
                p.Rezultat_Partije = par.Rezultat_Partije;
                p.Trajanje_Partije = par.Trajanje_Partije;

                s.SaveOrUpdate(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void sacuvajPartija(PartijaBasic par)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.Partija p = new SahovskaFederacija.Entiteti.Partija();

                p.Datum_Vreme_Odigravanja = par.Datum_Vreme_Odigravanja;
                p.Rezultat_Partije = par.Rezultat_Partije;
                p.Trajanje_Partije = par.Trajanje_Partije;

                SahovskaFederacija.Entiteti.Sahista crni = s.Load<SahovskaFederacija.Entiteti.Sahista>(par.Crne_Figure.Rbr);
                p.Crne_Figure = crni;
                SahovskaFederacija.Entiteti.Sahista beli = s.Load<SahovskaFederacija.Entiteti.Sahista>(par.Bele_Figure.Rbr);
                p.Bele_Figure = beli;
                SahovskaFederacija.Entiteti.Sahovski_Turnir turnir = s.Load<SahovskaFederacija.Entiteti.Sahovski_Turnir>(par.SahovskiTurnir.Id);
                p.SahovskiTurnir = turnir;
                SahovskaFederacija.Entiteti.Sudija sud = s.Load<SahovskaFederacija.Entiteti.Sudija>(par.Sudija.Id);
                p.Sudija = sud;

                s.SaveOrUpdate(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static List<PartijaPregled> vratiSvePartije()
        {
            List<PartijaPregled> partije = new List<PartijaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<SahovskaFederacija.Entiteti.Partija> svePartije = from p in s.Query<SahovskaFederacija.Entiteti.Partija>()
                                                                                      select p;

                foreach (SahovskaFederacija.Entiteti.Partija p in svePartije)
                {
                    partije.Add(new PartijaPregled(p.Id, p.Datum_Vreme_Odigravanja, p.Rezultat_Partije, p.Trajanje_Partije));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return partije;
        }

        public static List<PotezBasic> GetPartijaPotezInfos(int partijaId)
        {
            List<PotezBasic> potezInfos = new List<PotezBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Potez> potezi = from p in s.Query<Potez>()
                                                 where p.Partija.Id == partijaId
                                                 select p;

                foreach (Potez p in potezi)
                {
                    potezInfos.Add(new PotezBasic(p.Redni_Broj, p.Broj, p.Slovo, p.Figura, p.Vreme_Odigravanja));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return potezInfos;
        } // potezi u partiji

        // ...

        #endregion

        #region Potez 
        // proveriti (composite key)

        public static void obrisiPotez(int partijaId, int redniBroj) 
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.Partija partija = s.Load<SahovskaFederacija.Entiteti.Partija>(partijaId);

                var potezId = new { Partija = partija, Redni_Broj = redniBroj };

                SahovskaFederacija.Entiteti.Potez potez = s.Load<SahovskaFederacija.Entiteti.Potez>(potezId);

                s.Delete(potez);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static PotezBasic vratiPotez(int partijaId, int redniBroj)
        {
            PotezBasic p = new PotezBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.Partija partija = s.Load<SahovskaFederacija.Entiteti.Partija>(partijaId);

                var potezId = new { Partija = partija, Redni_Broj = redniBroj };

                Potez potez = s.Load<Potez>(potezId);

                p.Broj = potez.Broj;
                p.Slovo = potez.Slovo;
                p.Figura = potez.Figura;
                p.Vreme_Odigravanja = potez.Vreme_Odigravanja;

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return p;
        }

        public static void izmeniPotez(PotezBasic potez)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Partija partija = s.Load<Partija>(potez.Partija.Id);

                var potezId = new { Partija = partija, Redni_Broj = potez.Redni_Broj };

                Potez p = s.Load<Potez>(potezId);

                p.Broj = potez.Broj;
                p.Slovo = potez.Slovo;
                p.Figura = potez.Figura;
                p.Vreme_Odigravanja = potez.Vreme_Odigravanja;

                s.SaveOrUpdate(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void sacuvajPotez(PotezBasic potez)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.Potez p = new SahovskaFederacija.Entiteti.Potez();

                p.Broj = potez.Broj;
                p.Slovo = potez.Slovo;
                p.Figura = potez.Figura;
                p.Vreme_Odigravanja = potez.Vreme_Odigravanja;

                SahovskaFederacija.Entiteti.Partija partija = s.Load<SahovskaFederacija.Entiteti.Partija>(potez.Partija.Id);
                p.Partija = partija;

                s.SaveOrUpdate(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        // ...

        #endregion

        #region Sponzori
        // proveriti (composite key)

        public static void obrisiSponzor(int turnirId, string sponzorIme) 
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.Sahovski_Turnir turnir = s.Load<SahovskaFederacija.Entiteti.Sahovski_Turnir>(turnirId);

                var sponzorId = new { Sahovski_Turnir = turnir, Sponzor = sponzorIme };

                SahovskaFederacija.Entiteti.Sponzori sponzori = s.Load<SahovskaFederacija.Entiteti.Sponzori>(sponzorId);

                s.Delete(sponzori);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static SponzoriBasic vratiSponzor(int turnirId, string sponzorIme)
        {
            SponzoriBasic spo = new SponzoriBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.Sahovski_Turnir turnir = s.Load<SahovskaFederacija.Entiteti.Sahovski_Turnir>(turnirId);

                var sponzorId = new { Sahovski_Turnir = turnir, Sponzor = sponzorIme };

                SahovskaFederacija.Entiteti.Sponzori sponzori = s.Load<SahovskaFederacija.Entiteti.Sponzori>(sponzorId);

                spo.Sponzor = sponzori.Sponzor;

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return spo;
        }

        public static void izmeniSponzor(SponzoriBasic sponzor)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sahovski_Turnir turnir = s.Load<Sahovski_Turnir>(sponzor.SahovskiTurnir.Id);

                var sponzorId = new { Sahovski_Turnir = turnir, Sponzor = sponzor.Sponzor };

                SahovskaFederacija.Entiteti.Sponzori spo = s.Load<SahovskaFederacija.Entiteti.Sponzori>(sponzorId);

                spo.Sponzor = sponzor.Sponzor;

                s.SaveOrUpdate(spo);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void sacuvajSponzor(SponzoriBasic sponzor)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.Sponzori spo = new SahovskaFederacija.Entiteti.Sponzori();

                spo.Sponzor = sponzor.Sponzor;

                SahovskaFederacija.Entiteti.Sahovski_Turnir turnir = s.Load<SahovskaFederacija.Entiteti.Sahovski_Turnir>(sponzor.SahovskiTurnir.Id);
                spo.SahovskiTurnir = turnir;

                s.SaveOrUpdate(spo);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        // ...

        #endregion

        #region Sudija

        public static void obrisiSudija(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SahovskaFederacija.Entiteti.Sudija sd = s.Load<SahovskaFederacija.Entiteti.Sudija>(id);

                s.Delete(sd);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static SudijaBasic vratiSudija(int id)
        {
            SudijaBasic sd = new SudijaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Sudija sud = s.Load<Sudija>(id);

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return sd;
        }

        public static List<PartijaBasic> GetSudijaPartijeInfos(int sudijaId) // partije koje je sudio sudija
        {
            List<PartijaBasic> partijeInfos = new List<PartijaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Partija> partije = from p in s.Query<Partija>()
                                               where p.Sudija.Id == sudijaId
                                               select p;

                foreach (Partija p in partije)
                {
                    partijeInfos.Add(new PartijaBasic(p.Id, p.Datum_Vreme_Odigravanja, p.Rezultat_Partije, p.Trajanje_Partije/*, p.Crne_Figure, p.Bele_Figure, p.SahovskiTurnir, p.Sudija*/));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return partijeInfos;
        }

        #endregion

        #region UcestvujeNa

        public static void dodajUcestvujeNa(UcestvujeNaBasic ucestvujeNa)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                UcestvujeNa u = new UcestvujeNa();
                u.Id = new UcestvujeNaId();
                u.Id.SahistaUcestvujeNa = s.Load<Sahista>(ucestvujeNa.Id.SahistaUcestvujeNa.Rbr);
                u.Id.UcestvujeNaSahovski_Turnir = s.Load<Sahovski_Turnir>(ucestvujeNa.Id.UcestvujeNaSahovski_Turnir.Id);

                s.SaveOrUpdate(u);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                // handle exceptions 
            }
        }

        public static List<UcestvujeNaBasic> vratiUcestvujeNa(int idSahista, int idSahovski_Turnir)
        {
            List<UcestvujeNaBasic> ucestvujeNa = new List<UcestvujeNaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<UcestvujeNa> uc = from u in s.Query<UcestvujeNa>()
                                         where u.Id.SahistaUcestvujeNa.Rbr == idSahista
                                         where u.Id.UcestvujeNaSahovski_Turnir.Id == idSahovski_Turnir
                                         select u;

                foreach (UcestvujeNa u in uc)
                {
                    UcestvujeNaIdBasic id = new UcestvujeNaIdBasic();
                    id.SahistaUcestvujeNa = DTOManager.vratiSahista(u.Id.SahistaUcestvujeNa.Rbr);
                    id.UcestvujeNaSahovski_Turnir = DTOManager.vratiSahovski_Turnir(u.Id.UcestvujeNaSahovski_Turnir.Id);
                    ucestvujeNa.Add(new UcestvujeNaBasic(id));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return ucestvujeNa;
        }

        public static void izmeniUcestvujeNa(UcestvujeNaBasic ucestvujeNa)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                UcestvujeNaId id = new UcestvujeNaId();
                id.SahistaUcestvujeNa = s.Load<Sahista>(ucestvujeNa.Id.SahistaUcestvujeNa.Rbr);
                id.UcestvujeNaSahovski_Turnir = s.Load<Sahovski_Turnir>(ucestvujeNa.Id.UcestvujeNaSahovski_Turnir.Id);
                UcestvujeNa u = s.Load<UcestvujeNa>(id);

                s.SaveOrUpdate(u);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        #endregion

        #region Igra

        public static void dodajIgra(bool figure /* 0 za bele, 1 za crne figure */, IgraBasic igra)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Igra i = new Igra();
                i.Id = new IgraId();
                i.Id.SahistaIgra = s.Load<Sahista>(igra.Id.SahistaIgra.Rbr);
                i.Id.IgraPartija = s.Load<Partija>(igra.Id.IgraPartija.Id);

                if (figure)
                {
                    i.Id.IgraPartija.Crne_Figure = i.Id.SahistaIgra;
                }
                else
                {
                    i.Id.IgraPartija.Bele_Figure = i.Id.SahistaIgra;
                }

                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                // handle exceptions 
            }
        }

        public static List<IgraBasic> vratiIgra(int idSahista, int idPartija)
        {
            List<IgraBasic> igra = new List<IgraBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Igra> ig = from i in s.Query<Igra>()
                                              where i.Id.SahistaIgra.Rbr == idSahista
                                              where i.Id.IgraPartija.Id == idPartija
                                              select i;

                foreach (Igra u in ig)
                {
                    IgraIdBasic id = new IgraIdBasic();
                    id.SahistaIgra = DTOManager.vratiSahista(u.Id.SahistaIgra.Rbr);
                    id.IgraPartija = DTOManager.vratiPartija(u.Id.IgraPartija.Id);
                    igra.Add(new IgraBasic(id));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return igra;
        }

        public static void izmeniIgra(IgraBasic igra)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IgraId id = new IgraId();
                id.SahistaIgra = s.Load<Sahista>(igra.Id.SahistaIgra.Rbr);
                id.IgraPartija = s.Load<Partija>(igra.Id.IgraPartija.Id);
                Igra i = s.Load<Igra>(id);

                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        #endregion

        #region Organizuje

        public static void dodajOrganizuje(OrganizujeBasic organizuje)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Organizuje o = new Organizuje();
                o.Id = new OrganizujeId();
                o.Id.OrganizatorOrganizuje = s.Load<Organizator>(organizuje.Id.OrganizatorOrganizuje.Id);
                o.Id.OrganizujeSahovski_Turnir = s.Load<Sahovski_Turnir>(organizuje.Id.OrganizujeSahovski_Turnir.Id);

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                // handle exceptions 
            }
        }

        public static List<OrganizujeBasic> vratiOrganizuje(int idOrganizator, int idSahovski_Turnir)
        {
            List<OrganizujeBasic> organizuje = new List<OrganizujeBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Organizuje> org = from o in s.Query<Organizuje>()
                                              where o.Id.OrganizatorOrganizuje.Id == idOrganizator
                                              where o.Id.OrganizujeSahovski_Turnir.Id == idSahovski_Turnir
                                              select o;

                foreach (Organizuje o in org)
                {
                    OrganizujeIdBasic id = new OrganizujeIdBasic();
                    id.OrganizatorOrganizuje = DTOManager.vratiOrganizator(o.Id.OrganizatorOrganizuje.Id);
                    id.OrganizujeSahovski_Turnir = DTOManager.vratiSahovski_Turnir(o.Id.OrganizujeSahovski_Turnir.Id);
                    organizuje.Add(new OrganizujeBasic(id));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return organizuje;
        }

        public static void izmeniOrganizuje(OrganizujeBasic organizuje)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                OrganizujeId id = new OrganizujeId();
                id.OrganizatorOrganizuje = s.Load<Organizator>(organizuje.Id.OrganizatorOrganizuje.Id);
                id.OrganizujeSahovski_Turnir = s.Load<Sahovski_Turnir>(organizuje.Id.OrganizujeSahovski_Turnir.Id);
                Organizuje o = s.Load<Organizuje>(id);

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        #endregion
    }
}
