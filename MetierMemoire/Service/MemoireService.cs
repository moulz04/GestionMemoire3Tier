using MetierMemoire.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetierMemoire.Service
{
    public class MemoireService
    {
        BdMemoireContext db = new BdMemoireContext();

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
            catch (Exception)
            {
                //todo implementer la gestion des erreurs
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
                db.Entry(memo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //todo implementer la gestion des erreurs
            }
            return false;
        }



        /// <summary>
        /// Permet de supprimer un memoire dans la base de données
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteMemoire(int id)
        {
            try
            {
                var memo = db.Memoires.Find(id);
                if (memo != null)
                {
                    db.Memoires.Remove(memo);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                //todo implementer la gestion des erreurs
            }
            return false;
        }
    }
}