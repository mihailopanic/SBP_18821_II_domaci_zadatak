using SahovskaFederacija.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahovskaFederacija
{
    #region Sahovski_Turnir

    public class Sahovski_TurnirBasic
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Zemlja { get; set; }
        public string Grad { get; set; }
        public int Godina_Odrzavanja { get; set; }
        public DateTime Datum_Od { get; set; }
        public DateTime Datum_Do { get; set; }
        public virtual IList<PartijaBasic> Partije { get; set; }
        public virtual IList<SponzoriBasic> Sponzori { get; set; }
        public virtual IList<OrganizujeBasic> OrganizatorOrganizuje { get; set; }
        public virtual IList<UcestvujeNaBasic> SahistaUcestvujeNa { get; set; }

        public Sahovski_TurnirBasic()
        {
            Partije = new List<PartijaBasic>();
            Sponzori = new List<SponzoriBasic>();
            OrganizatorOrganizuje = new List<OrganizujeBasic>();
            SahistaUcestvujeNa = new List<UcestvujeNaBasic>();
        }

        public Sahovski_TurnirBasic(int id,
                                    string naziv,
                                    string zemlja,
                                    string grad,
                                    int godina,
                                    DateTime datum_od,
                                    DateTime datum_do) : this()
        {
            this.Id = id;
            this.Naziv = naziv;
            this.Zemlja = zemlja;
            this.Grad = grad;
            this.Godina_Odrzavanja = godina;
            this.Datum_Od = datum_od;
            this.Datum_Do = datum_do;
        }
    }

    public class Sahovski_TurnirPregled
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public DateTime Datum_Od { get; set; }
        public DateTime Datum_Do { get; set; }

        public Sahovski_TurnirPregled() { }

        public Sahovski_TurnirPregled(int id,
                                    string naziv,
                                    DateTime datum_od,
                                    DateTime datum_do)
        {
            this.Id = id;
            this.Naziv = naziv;
            this.Datum_Od = datum_od;
            this.Datum_Do = datum_do;
        }
    }

    #region TakmicarskiNormalni

    public class TakmicarskiNormalniBasic : Sahovski_TurnirBasic
    {
        public string Region { get; set; }

        public TakmicarskiNormalniBasic() { }

        public TakmicarskiNormalniBasic(string region, int id,
                                    string naziv,
                                    string zemlja,
                                    string grad,
                                    int godina,
                                    DateTime datum_od,
                                    DateTime datum_do) : base(id, naziv, zemlja, grad, godina, datum_od, datum_do)
        {
            this.Region = region;
        }
    }

    public class TakmicarskiNormalniPregled : Sahovski_TurnirPregled
    {
        public string Region { get; set; }

        public TakmicarskiNormalniPregled() { }

        public TakmicarskiNormalniPregled(string region, int id,
                                    string naziv,
                                    DateTime datum_od,
                                    DateTime datum_do) : base(id, naziv, datum_od, datum_do)
        {
            this.Region = region;
        }
    }

    #endregion

    #region TakmicarskiBrzopotezni

    public class TakmicarskiBrzopotezniBasic : Sahovski_TurnirBasic
    {
        public string Region { get; set; }
        public int Max_Vreme_Trajanja { get; set; }

        public TakmicarskiBrzopotezniBasic() { }

        public TakmicarskiBrzopotezniBasic(string region,
                                    int vreme,
                                    int id,
                                    string naziv,
                                    string zemlja,
                                    string grad,
                                    int godina,
                                    DateTime datum_od,
                                    DateTime datum_do) : base(id, naziv, zemlja, grad, godina, datum_od, datum_do)
        {
            this.Region = region;
            this.Max_Vreme_Trajanja = vreme;
        }
    }

    public class TakmicarskiBrzopotezniPregled : Sahovski_TurnirPregled
    {
        public string Region { get; set; }
        public int Max_Vreme_Trajanja { get; set; }

        public TakmicarskiBrzopotezniPregled() { }

        public TakmicarskiBrzopotezniPregled(string region,
                                    int vreme,
                                    int id,
                                    string naziv,
                                    DateTime datum_od,
                                    DateTime datum_do) : base(id, naziv, datum_od, datum_do)
        {
            this.Region = region;
            this.Max_Vreme_Trajanja = vreme;
        }
    }

    #endregion

    #region EgzibicioniNormalni

    public class EgzibicioniNormalniBasic : Sahovski_TurnirBasic
    {
        public string Tip { get; set; }
        public string Novac_Namenjen { get; set; }
        public int Prikupljen_Iznos { get; set; }

        public EgzibicioniNormalniBasic() { }

        public EgzibicioniNormalniBasic(string tip, string novac_namenjen, int iznos, int id,
                                    string naziv,
                                    string zemlja,
                                    string grad,
                                    int godina,
                                    DateTime datum_od,
                                    DateTime datum_do) : base(id, naziv, zemlja, grad, godina, datum_od, datum_do)
        {
            this.Tip = tip;
            this.Novac_Namenjen = novac_namenjen;
            this.Prikupljen_Iznos = iznos;
        }
    }

    public class EgzibicioniNormalniPregled : Sahovski_TurnirPregled
    {
        public string Tip { get; set; }
        public string Novac_Namenjen { get; set; }
        public int Prikupljen_Iznos { get; set; }

        public EgzibicioniNormalniPregled() { }

        public EgzibicioniNormalniPregled(string tip, string novac_namenjen, int iznos, int id,
                                    string naziv,
                                    DateTime datum_od,
                                    DateTime datum_do) : base(id, naziv, datum_od, datum_do)
        {
            this.Tip = tip;
            this.Novac_Namenjen = novac_namenjen;
            this.Prikupljen_Iznos = iznos;
        }
    }

    #endregion

    #region EgzibicioniBrzopotezni

    public class EgzibicioniBrzopotezniBasic : Sahovski_TurnirBasic
    {
        public string Tip { get; set; }
        public string Novac_Namenjen { get; set; }
        public int Prikupljen_Iznos { get; set; }
        public int Max_Vreme_Trajanja { get; set; }

        public EgzibicioniBrzopotezniBasic() { }

        public EgzibicioniBrzopotezniBasic(string tip, string novac_namenjen, int iznos, int vreme, int id,
                                    string naziv,
                                    string zemlja,
                                    string grad,
                                    int godina,
                                    DateTime datum_od,
                                    DateTime datum_do) : base(id, naziv, zemlja, grad, godina, datum_od, datum_do)
        {
            this.Tip = tip;
            this.Novac_Namenjen = novac_namenjen;
            this.Prikupljen_Iznos = iznos;
            this.Max_Vreme_Trajanja = vreme;
        }
    }

    public class EgzibicioniBrzopotezniPregled : Sahovski_TurnirPregled
    {
        public string Tip { get; set; }
        public string Novac_Namenjen { get; set; }
        public int Prikupljen_Iznos { get; set; }
        public int Max_Vreme_Trajanja { get; set; }

        public EgzibicioniBrzopotezniPregled() { }

        public EgzibicioniBrzopotezniPregled(string tip, string novac_namenjen, int iznos, int vreme, int id,
                                    string naziv,
                                    DateTime datum_od,
                                    DateTime datum_do) : base(id, naziv, datum_od, datum_do)
        {
            this.Tip = tip;
            this.Novac_Namenjen = novac_namenjen;
            this.Prikupljen_Iznos = iznos;
            this.Max_Vreme_Trajanja = vreme;
        }
    }

    #endregion 

    #endregion

    #region Sahista

    public class SahistaBasic
    {
        public int Rbr { get; set; }
        public string Zemlja_Porekla { get; set; }
        public string Broj_Pasosa { get; set; }
        public DateTime Datum_Uclanjenja { get; set; }
        public string Lime { get; set; }
        public char Sslovo { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public DateTime Datum_Rodjenja { get; set; }
        public string Status { get; set; }
        public IList<UcestvujeNaBasic> UcestvujeNaSahovski_Turnir { get; set; }
        public IList<IgraBasic> IgraPartija { get; set; }

        public SahistaBasic()
        {
            UcestvujeNaSahovski_Turnir = new List<UcestvujeNaBasic>();

            IgraPartija = new List<IgraBasic>();
        }

        public SahistaBasic(int rbr,
                             string zemlja_Porekla,
                             string broj_Pasosa,
                             DateTime datum_Uclanjenja,
                             string lime,
                             char sslovo,
                             string prezime,
                             string adresa,
                             DateTime datum_Rodjenja,
                             string status)
        {
            Rbr = rbr;
            Zemlja_Porekla = zemlja_Porekla;
            Broj_Pasosa = broj_Pasosa;
            Datum_Uclanjenja = datum_Uclanjenja;
            Lime = lime;
            Sslovo = sslovo;
            Prezime = prezime;
            Adresa = adresa;
            Datum_Rodjenja = datum_Rodjenja;
            Status = status;
        }
    }

    public class SahistaPregled
    {
        public int Rbr { get; set; }
        public string Zemlja_Porekla { get; set; }
        public DateTime Datum_Uclanjenja { get; set; }
        public string Lime { get; set; }
        public string Prezime { get; set; }
        public string Status { get; set; }

        public SahistaPregled() { }

        public SahistaPregled(int rbr,
                             string zemlja_Porekla,
                             DateTime datum_Uclanjenja,
                             string lime,
                             string prezime,
                             string status)
        {
            Rbr = rbr;
            Zemlja_Porekla = zemlja_Porekla;
            Datum_Uclanjenja = datum_Uclanjenja;
            Lime = lime;
            Prezime = prezime;
            Status = status;
        }
    }

    #endregion

    #region Majstor

    public class MajstorBasic : SahistaBasic
    {
        public DateTime Datum_Zvanja { get; set; }
        public SudijaBasic Sudija { get; set; }

        public MajstorBasic() { }

        public MajstorBasic(DateTime datum_Zvanja, // SudijaBasic sudija,
                             int rbr,
                             string zemlja_Porekla,
                             string broj_Pasosa,
                             DateTime datum_Uclanjenja,
                             string lime,
                             char sslovo,
                             string prezime,
                             string adresa,
                             DateTime datum_Rodjenja,
                             string status) : base(rbr, zemlja_Porekla, broj_Pasosa, datum_Uclanjenja, lime, sslovo, prezime, adresa, datum_Rodjenja, status)
        {
            Datum_Zvanja = datum_Zvanja;
            // Sudija = sudija;
        }
    }

    public class MajstorPregled : SahistaPregled
    {
        public DateTime Datum_Zvanja { get; set; }
        public SudijaPregled Sudija { get; set; }

        public MajstorPregled() { }

        public MajstorPregled(DateTime datum_Zvanja, // SudijaPregled sudija, 
                             int rbr,
                             string zemlja_Porekla,
                             DateTime datum_Uclanjenja,
                             string lime,
                             string prezime,
                             string status) : base(rbr, zemlja_Porekla, datum_Uclanjenja, lime, prezime, status)
        {
            Datum_Zvanja = datum_Zvanja;
            // Sudija = sudija;
        }
    }

    #endregion

    #region Majstorski_Kandidat

    public class Majstorski_KandidatBasic : SahistaBasic
    {
        public int Broj_Partija_Do_Zvanja { get; set; }

        public Majstorski_KandidatBasic() { }

        public Majstorski_KandidatBasic(int br,
                             int rbr,
                             string zemlja_Porekla,
                             string broj_Pasosa,
                             DateTime datum_Uclanjenja,
                             string lime,
                             char sslovo,
                             string prezime,
                             string adresa,
                             DateTime datum_Rodjenja,
                             string status) : base(rbr, zemlja_Porekla, broj_Pasosa, datum_Uclanjenja, lime, sslovo, prezime, adresa, datum_Rodjenja, status)
        {
            Broj_Partija_Do_Zvanja = br;
        }
    }

    public class Majstorski_KandidatPregled : SahistaPregled
    {
        public int Broj_Partija_Do_Zvanja { get; set; }

        public Majstorski_KandidatPregled() { }

        public Majstorski_KandidatPregled(int br,
                             int rbr,
                             string zemlja_Porekla,
                             DateTime datum_Uclanjenja,
                             string lime,
                             string prezime,
                             string status) : base(rbr, zemlja_Porekla, datum_Uclanjenja, lime, prezime, status)
        {
            Broj_Partija_Do_Zvanja = br;
        }
    }

    #endregion

    #region Organizator

    public class OrganizatorBasic
    {
        public int Id { get; set; }
        public string Jmbg { get; set; }
        public string Adresa { get; set; }
        public string Lime { get; set; }
        public char Sslovo { get; set; }
        public string Prezime { get; set; }
        public SudijaBasic Sudija { get; set; }
        public IList<OrganizujeBasic> OrganizujeSahovski_Turnir { get; set; }

        public OrganizatorBasic()
        {
            OrganizujeSahovski_Turnir = new List<OrganizujeBasic>();
        }

        public OrganizatorBasic(int id, string jmbg, string adresa, string lime, char sslovo, string prezime /*, SudijaBasic sudija*/)
        {
            Id = id;
            Jmbg = jmbg;
            Adresa = adresa;
            Lime = lime;
            Sslovo = sslovo;
            Prezime = prezime;
            // Sudija = sudija;
        }
    }

    public class OrganizatorPregled
    {
        public int Id { get; set; }
        public string Lime { get; set; }
        public string Prezime { get; set; }
        public SudijaPregled Sudija { get; set; }

        public OrganizatorPregled() { }

        public OrganizatorPregled(int id, string lime, string prezime /*, SudijaPregled sudija*/) : this ()
        {
            Id = id;
            Lime = lime;
            Prezime = prezime;
            //Sudija = sudija;
        }
    }

    #endregion

    #region Partija

    public class PartijaBasic
    {
        public virtual int Id { get; set; }
        public virtual DateTime Datum_Vreme_Odigravanja { get; set; }
        public virtual string Rezultat_Partije { get; set; }
        public virtual int Trajanje_Partije { get; set; }
        public virtual SahistaBasic Crne_Figure { get; set; }
        public virtual SahistaBasic Bele_Figure { get; set; }
        public virtual Sahovski_TurnirBasic SahovskiTurnir { get; set; }
        public virtual IList<PotezBasic> Potezi { get; set; }
        public virtual IList<IgraBasic> SahistaIgra { get; set; }
        public virtual SudijaBasic Sudija { get; set; }

        public PartijaBasic()
        {
            Potezi = new List<PotezBasic>();
            SahistaIgra = new List<IgraBasic>();
        }

        public PartijaBasic(int id, DateTime datum_Vreme_Odigravanja, string rezultat_Partije, int trajanje_Partije /*, SahistaBasic crne_Figure, SahistaBasic bele_Figure, Sahovski_TurnirBasic sahovskiturnir, SudijaBasic sudija*/) : this()
        {
            Id = id;
            Datum_Vreme_Odigravanja = datum_Vreme_Odigravanja;
            Rezultat_Partije = rezultat_Partije;
            Trajanje_Partije = trajanje_Partije;
            /*Crne_Figure = crne_Figure;
            Bele_Figure = bele_Figure;
            SahovskiTurnir = sahovskiturnir;
            Sudija = sudija;*/
        }
    }

    public class PartijaPregled
    {
        public virtual int Id { get; set; }
        public virtual DateTime Datum_Vreme_Odigravanja { get; set; }
        public virtual string Rezultat_Partije { get; set; }
        public virtual int Trajanje_Partije { get; set; }
        public virtual SahistaPregled Crne_Figure { get; set; }
        public virtual SahistaPregled Bele_Figure { get; set; }
        public virtual Sahovski_TurnirPregled SahovskiTurnir { get; set; }
        public virtual SudijaPregled Sudija { get; set; }

        public PartijaPregled() { }

        public PartijaPregled(int id, DateTime datum_Vreme_Odigravanja, string rezultat_Partije, int trajanje_Partije /*, SahistaPregled crne_Figure, SahistaPregled bele_Figure, Sahovski_TurnirPregled sahovskiturnir, SudijaPregled sudija*/) : this()
        {
            Id = id;
            Datum_Vreme_Odigravanja = datum_Vreme_Odigravanja;
            Rezultat_Partije = rezultat_Partije;
            Trajanje_Partije = trajanje_Partije;
            /*Crne_Figure = crne_Figure;
            Bele_Figure = bele_Figure;
            SahovskiTurnir = sahovskiturnir;
            Sudija = sudija;*/
        }
    }

    #endregion

    #region Potez

    public class PotezBasic
    {
        public int Redni_Broj { get; set; }
        public int Broj { get; set; }
        public char Slovo { get; set; }
        public string Figura { get; set; }
        public int Vreme_Odigravanja { get; set; }
        public PartijaBasic Partija { get; set; }

        public PotezBasic() { }

        public PotezBasic(int redni_Broj, int broj, char slovo, string figura, int vreme_Odigravanja /*, PartijaBasic partija*/)
        {
            Redni_Broj = redni_Broj;
            Broj = broj;
            Slovo = slovo;
            Figura = figura;
            Vreme_Odigravanja = vreme_Odigravanja;
            //Partija = partija;
        }
    }

    public class PotezPregled
    {
        public int Redni_Broj { get; set; }
        public int Broj { get; set; }
        public char Slovo { get; set; }
        public string Figura { get; set; }
        public int Vreme_Odigravanja { get; set; }
        public PartijaPregled Partija { get; set; }

        public PotezPregled() { }

        public PotezPregled(int redni_Broj, int broj, char slovo, string figura, int vreme_Odigravanja /*, PartijaPregled partija*/)
        {
            Redni_Broj = redni_Broj;
            Broj = broj;
            Slovo = slovo;
            Figura = figura;
            Vreme_Odigravanja = vreme_Odigravanja;
            //Partija = partija;
        }
    }

    #endregion

    #region Sponzori

    public class SponzoriBasic
    {
        public string Sponzor { get; set; }
        public Sahovski_TurnirBasic SahovskiTurnir { get; set; }

        public SponzoriBasic() { }

        public SponzoriBasic(string sponzor /*, Sahovski_TurnirBasic sahovskiTurnir*/)
        {
            Sponzor = sponzor;
            // SahovskiTurnir = sahovskiTurnir;
        }
    }

    public class SponzoriPregled
    {
        public string Sponzor { get; set; }
        public Sahovski_TurnirPregled SahovskiTurnir { get; set; }

        public SponzoriPregled() { }

        public SponzoriPregled(string sponzor /*, Sahovski_TurnirPregled sahovskiTurnir*/)
        {
            Sponzor = sponzor;
            //SahovskiTurnir = sahovskiTurnir;
        }
    }

    #endregion

    #region Sudija

    public class SudijaBasic
    {
        public int Id { get; set; }
        public IList<PartijaBasic> SudjenePartije { get; set; }

        public SudijaBasic()
        {
            SudjenePartije = new List<PartijaBasic>();
        }

        public SudijaBasic(int id) : this()
        {
            Id = id;
        }
    }

    public class SudijaPregled
    {
        public int Id { get; set; }

        public SudijaPregled() { }

        public SudijaPregled(int id) : this()
        {
            Id = id;
        }
    }

    #endregion

    #region Igra

    public class IgraBasic
    {
        public IgraIdBasic Id;

        public IgraBasic() { }

        public IgraBasic(IgraIdBasic id)
        {
            Id = id;
        }
    }

    public class IgraPregled
    {
        public IgraId Id;

        public IgraPregled() { }

        public IgraPregled(IgraId id)
        {
            Id = id;
        }
    }

    public class IgraIdBasic
    {
        public SahistaBasic SahistaIgra { get; set; }
        public PartijaBasic IgraPartija { get; set; }

        public IgraIdBasic() { }
    }

    #endregion

    #region Organizuje

    public class OrganizujeBasic
    {
        public OrganizujeIdBasic Id;

        public OrganizujeBasic() { }

        public OrganizujeBasic(OrganizujeIdBasic id)
        {
            Id = id;
        }
    }

    public class OrganizujePregled
    {
        public OrganizujeId Id;

        public OrganizujePregled() { }

        public OrganizujePregled(OrganizujeId id)
        {
            Id = id;
        }
    }

    public class OrganizujeIdBasic
    {
        public OrganizatorBasic OrganizatorOrganizuje { get; set; }
        public Sahovski_TurnirBasic OrganizujeSahovski_Turnir { get; set; }

        public OrganizujeIdBasic() { }
    }

    #endregion

    #region UcestvujeNa

    public class UcestvujeNaBasic
    {
        public UcestvujeNaIdBasic Id;

        public UcestvujeNaBasic() { }

        public UcestvujeNaBasic(UcestvujeNaIdBasic id)
        {
            Id = id;
        }
    }

    public class UcestvujeNaPregled
    {
        public UcestvujeNaId Id;

        public UcestvujeNaPregled() { }

        public UcestvujeNaPregled(UcestvujeNaId id)
        {
            Id = id;
        }
    }

    public class UcestvujeNaIdBasic
    {
        public SahistaBasic SahistaUcestvujeNa { get; set; }
        public Sahovski_TurnirBasic UcestvujeNaSahovski_Turnir { get; set; }

        public UcestvujeNaIdBasic() { }
    }

    #endregion
}
