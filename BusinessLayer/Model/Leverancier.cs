using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using BusinessLayer.Exceptions;

namespace BusinessLayer.Model
{
    public class Leverancier
    {
        #region Properties
        public long Id { get; set; }
        public string Naam { get; set; }
        public decimal PrijsKHW { get; set; }
        public string MaatschappelijkeZetel { get; set; }
        public DateTime ToekenningLeveringvergunning { get; set; }
        public DateTime PublicatiebeslissingInBelGischStaatsblad { get; set; }
        public DateTime AutoTimeCreation { get; set; }
        public virtual Leverancier leverancier { get; set; }
        public virtual ICollection<Leverancier> _Leveranciel { get; set; }
        public Leverancier()
        {
            _Leveranciel = new HashSet<Leverancier>();
        }
        #endregion

        #region For WPF interface INotifyProperyChanged
        // Deze code kan altijd in een class gecopieerd worden
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region CTR
        //public Leverancier() { }
        public Leverancier(long id) => SetId(id);
        public Leverancier(long id, string naam) : this(id) => SetNaam(naam);

        public Leverancier(long id, string naam, decimal prijs) : this(id, naam) => SetPrijs(prijs);
        public Leverancier(long id, string naam, decimal prijs, string maatschappelijkeZetel) : this(id, naam, prijs) => SetMaatschappelijkeZetel(maatschappelijkeZetel);

        public Leverancier(long id, string naam, decimal prijs, string maatschappelijkeZetel, DateTime toekenningLeveringvergunning) : this(id, naam, prijs, maatschappelijkeZetel) => SetToekenningLeveringvergunning(toekenningLeveringvergunning);

        public Leverancier(long id, string naam, decimal prijs, string maatschappelijkeZetel, DateTime toekenningLeveringvergunning, DateTime publicatiebeslissingInBelGischStaatsblad) : this(id, naam, prijs, maatschappelijkeZetel, toekenningLeveringvergunning) => SetPublicatiebeslissingInBelGischStaatsblad(publicatiebeslissingInBelGischStaatsblad);
        #endregion

        #region Methods
        public void SetId(long id)
        {
            if (id <= 0) throw new LeverancierException("ID invalid");
            Id = id;
        }

        public void SetNaam(string naam)
        {
            if (naam.Trim().Length < 3) throw new LeverancierException("Naam invalid");
            Naam = naam;
            NotifyPropertyChanged("Naam");
        }

        public void SetPrijs(decimal prijs)
        {
            if (prijs <= 0) throw new LeverancierException("Prijs invalid");
            PrijsKHW = prijs;
            NotifyPropertyChanged("PrijsKHW");
        }

        public void SetMaatschappelijkeZetel(string maatschappelijkeZetel)
        {
            if (maatschappelijkeZetel.Trim().Length < 5) throw new LeverancierException("maatschappelijkeZetel invalid");
            MaatschappelijkeZetel = maatschappelijkeZetel;
            NotifyPropertyChanged("MaatschappelijkeZetel");
        }

        public void SetToekenningLeveringvergunning(DateTime toekenningLeveringvergunning)
        {
            if (toekenningLeveringvergunning < DateTime.Parse("1/1/1900")) throw new LeverancierException("toekenningLeveringvergunning invalid");
            ToekenningLeveringvergunning = toekenningLeveringvergunning;
            NotifyPropertyChanged("ToekenningLeveringvergunning");
        }

        public void SetPublicatiebeslissingInBelGischStaatsblad(DateTime publicatiebeslissingInBelGischStaatsblad)
        {
            if (publicatiebeslissingInBelGischStaatsblad < DateTime.Parse("1/1/1900")) throw new LeverancierException("toekenningLeveringvergunning invalid");
            PublicatiebeslissingInBelGischStaatsblad = publicatiebeslissingInBelGischStaatsblad;
            NotifyPropertyChanged("PublicatiebeslissingInBelGischStaatsblad");
        }
        #endregion
    }
}
