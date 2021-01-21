using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BusinessLayer.Data;
using BusinessLayer.Model;

using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Manager
{
    public class DbLeverancierManager
    {
        public void Create(Leverancier leverancier)
        {
            using (var context = new DataContext())
            {
                context.Set<Leverancier>().Add(leverancier);
                context.SaveChanges();
            }
        }

        public void Update(Leverancier leverancier)
        {
            using (var context = new DataContext())
            {
                context.Entry(leverancier).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Leverancier leverancier)
        {
            using (var context = new DataContext())
            {
                context.Set<Leverancier>().Remove(leverancier);
                context.SaveChanges();
            }
        }

        public List<Leverancier> GetAllLeveranciers()
        {
            using (var context = new DataContext())
            {
                var leveranciers = context.Leverancier
                    .ToList();
                return leveranciers;
            }
        }
    }
}
