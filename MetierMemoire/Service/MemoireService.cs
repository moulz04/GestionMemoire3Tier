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
        readonly BdMemoireContext db = new BdMemoireContext();

        /// <summary>
        /// Cette methode renvoie la liste de tous les memoires disponibles dans la base de données
        /// </summary>
        /// <returns></returns>

        public List<Memoire> GetAllMemoire()
        {
            return db.Memoires.ToList();
        }

        /// <summary>
        /// Renvoie le memoire correspondant à l'identifiant passé en paramètre
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public Memoire GetMemoire(int? id)
        {
            return db.Memoires.Find(id);
        }


        /// <summary>
        /// Permet l'engeristrement d'un memoire dans la base de données
        /// </summary>
        /// <param name="memo"></param>
        /// <returns></returns>

        public bool AddMemoire(Memoire memo)
        {
            try
            {
                db.Memoires.Add(memo);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'ajout du mémoire : " + ex.Message);
            }
            return false;
        }



        /// <summary>
        /// Permet de modifier un memoire dans la base de données
        /// </summary>
        /// <param name="memo"></param>
        /// <returns></returns>
        public bool EditMemoire(Memoire memo)
        {
            try
            {
                db.Entry(memo).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la modification du mémoire : " + ex.Message);
            }
            return false;
        }



        /// <summary>
        /// Permet de supprimer un memoire dans la base de données
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteMemoire(Memoire memo)
        {
            try
            {
                
                {
                    db.Entry(memo).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la suppression du mémoire : " + ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Permet la recherche des memoires dans la base de données en fonction du sujet et de l'année du memoire
        /// </summary>
        /// <param name="memo"></param>
        /// <returns></returns>
        public List<Memoire> GetMemoireList(MemoireModel memo)
        {
            var liste = db.Memoires.ToList();

            if(!string.IsNullOrEmpty(memo.SujetMemoire))
            {
                liste = liste.Where(a => a.SujetMemoire.ToLower().Contains(memo.SujetMemoire.ToLower())).ToList();
            }
            if (memo.AnneeMemoire!=null)
            {
                liste = liste.Where(a => a.AnneeMemoire==memo.AnneeMemoire).ToList();
            }

            return liste;
        }

    }
}