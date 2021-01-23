using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Model
{
    public class Berekening
    {
        #region
        public virtual int Uren { get; set; }
        public virtual int Dagen { get; set; }
        public virtual double VermogenInWatt { get; set; }
        public virtual decimal PrijsPerKwh { get; set; }
        #endregion

        public decimal Formule(int uren, int dagen, double Vermogen, decimal prijsPerKwh )
        {
            double resultaat;
            decimal prijsTotaal;
            resultaat = uren * dagen * (Vermogen / 1000);
            prijsTotaal = (decimal)resultaat * prijsPerKwh;
            return prijsTotaal;
        }
    }
}
