using MetierMemoire.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MetierMemoire.Service
{
    public class MemoireService
    {
        BdMemoireContext db = new BdMemoireContext();
        /// <summary>
        /// renvoie la liste de tous les memoires
        /// </summary>
        /// <returns></returns>
        public List<Memoire> GetAllMemoire()
        {
            return db.Memoires.ToList();
        }
        /// <summary>
        /// renvoie le memoire via son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Memoire GetMemoire(int? id)
        {

            return db.Memoires.Find(id);
        }
        /// <summary>
        /// ajoute un memoire
        /// </summary>
        /// <param name="mem">Le memoire enregistrer</param>
        public bool AddMemoire(Memoire mem)
        {
            try
            {
                db.Memoires.Add(mem);
                db.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                //todo: implementer le gestion des erreurs
                
            }
            return false;

        }
        /// <summary>
        /// Permet de modifier un memoire               
        /// </summary>
        public bool UpdateMemoire(Memoire mem)
        {
            try
            {
                db.Entry(mem).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception )
            {
            }
            return false;
        }
        /// <summary>
        ///permet de supprimer un memoire via son id
        ///
        public bool DeleteMemoire(int? id)
        {
            try
            {
                Memoire memoire = db.Memoires.Find(id);
                if (memoire != null)
                {
                    db.Memoires.Remove(memoire);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
            }
           return false;
        }
        /// <summary>
        /// permet de rechercher un memoire via son sujet, sa description ou son année
        /// </summary>
        /// <param name="mem"></param>
        /// <returns></returns>
        public List<Memoire> GetMemoireList(Memoire mem)
        {
            var query = db.Memoires.AsQueryable();
            if (mem != null)
            {
                if (!string.IsNullOrEmpty(mem.SujetMemoire))
                {
                    query = query.Where(m => m.SujetMemoire.Contains(mem.SujetMemoire));
                }
                if (!string.IsNullOrEmpty(mem.DescriptionMemoire))
                {
                    query = query.Where(m => m.DescriptionMemoire.Contains(mem.DescriptionMemoire));
                }
                if (mem.AnneeMemoire != 0)
                {
                    query = query.Where(m => m.AnneeMemoire == mem.AnneeMemoire);
                }
            }
            return query.ToList();
        }

    }
}