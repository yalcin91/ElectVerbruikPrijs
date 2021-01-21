using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BusinessLayer.Exceptions;
using BusinessLayer.Model;

namespace BusinessLayer.Manager
{
    public class LeverancierManager
    {
        DbLeverancierManager DbLeverancierManager = new DbLeverancierManager();

        public List<Leverancier> _Leveranciers
        {
            get
            {
                return _Leveranciers = DbLeverancierManager.GetAllLeveranciers();
            }
            private set { }
        }

        public IReadOnlyList<Leverancier> GetAllLeveranciers()
        {
            var leveranciers = DbLeverancierManager.GetAllLeveranciers();
            return leveranciers;
        }

        public IReadOnlyList<Leverancier> GetAllLeveranciers(Func<Leverancier, bool> predicate)
        {
            var leveranciers = DbLeverancierManager.GetAllLeveranciers();
            return leveranciers;
        }

        public void VoegLeveranciers(Leverancier leveranciers)
        {
            if (_Leveranciers.Contains(leveranciers))
            {
                throw new LeverancierManagerException("Voeg Leverancier: Bestaat al");
            }
            else { _Leveranciers.Add(leveranciers); DbLeverancierManager.Create(leveranciers); }
            _Leveranciers = DbLeverancierManager.GetAllLeveranciers();
        }

        public void VerwijderLeveranciers(Leverancier leveranciers)
        {
            _Leveranciers = DbLeverancierManager.GetAllLeveranciers();
            if (!_Leveranciers.Any(x => x.Id == leveranciers.Id)) throw new LeverancierManagerException("Voeg Leverancier: Bestaat niet");
            else { _Leveranciers.Remove(leveranciers); DbLeverancierManager.Delete(leveranciers); }
        }

        public void UpdateLeveranciers(Leverancier leveranciers)
        {
            _Leveranciers = DbLeverancierManager.GetAllLeveranciers();
            DbLeverancierManager.Update(leveranciers);
            _Leveranciers = (List<Leverancier>)GetAllLeveranciers();
            _Leveranciers = DbLeverancierManager.GetAllLeveranciers();
        }
    }
}
