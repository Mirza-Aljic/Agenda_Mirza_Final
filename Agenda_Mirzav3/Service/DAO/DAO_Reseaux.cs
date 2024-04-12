using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda_Mirzav3.AgendaMirzaDB;

namespace Agenda_Mirzav3.Service.DAO
{
    public class DAO_Reseaux
    {
        //recuperer les reseaux d'un contacte
        public List<SocialProfil> GetReseaux(int idContacte)
        {
            using (var db = new AgendaMirzaContext())
            {
                return db.SocialProfils.Where(r => r.ContactIdcontact == idContacte).ToList();
            }
        }
        //ajouter un reseau
        public void AddReseau(SocialProfil reseau)
        {
            using (var db = new AgendaMirzaContext())
            {
                db.SocialProfils.Add(reseau);
                db.SaveChanges();
            }
        }
        //supprimer un reseau
        public void DeleteReseau(int idReseau)
        {
            using (var db = new AgendaMirzaContext())
            {
                SocialProfil reseau = db.SocialProfils.Find(idReseau);
                db.SocialProfils.Remove(reseau);
                db.SaveChanges();
            }
        }
        //modifier un reseau
        public void UpdateReseau(SocialProfil reseau)
        {
            using (var db = new AgendaMirzaContext())
            {
                db.SocialProfils.Update(reseau);
                db.SaveChanges();
            }
        }
    }
}