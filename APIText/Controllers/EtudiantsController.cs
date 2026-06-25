using APIText.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace APIText.Controllers
{
    public class EtudiantsController : ApiController
    {
        AppDbContext db = new AppDbContext();
        [HttpGet]
        public IHttpActionResult Get()
        {
           return Ok(db.Etudiants.ToList());
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var etudiant = db.Etudiants.Find(id);
            if (etudiant == null)
                return NotFound();
            return Ok(etudiant);
        }

        [HttpPost]
        public IHttpActionResult Post(Etudiant etudiant)
        {
            //Validation
            if(string.IsNullOrEmpty(etudiant.NomEtudiant))
                return BadRequest("Le nom de l'etudiant est obligatoire");
            if (string.IsNullOrEmpty(etudiant.PrenomEtudiant))
                return BadRequest("Le prenom de l'etudiant est obligatoire");
            if (string.IsNullOrEmpty(etudiant.EmailEtudiant))
                return BadRequest("L'email de l'etudiant est obligatoire");
            //le model state est un objet qui contient les erreurs de validation des données envoyées par le client
            //qui permet de vérifier si les données envoyées par le client sont valides ou non
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Etudiants.Add(etudiant);
            db.SaveChanges();

            return Ok(etudiant);

        }
        [HttpPut]
        public IHttpActionResult Put(int id , Etudiant etudiant)
        {
            var e = db.Etudiants.Find(id);
            if (e == null)
                return NotFound();
            e.NomEtudiant = etudiant.NomEtudiant;
            e.PrenomEtudiant = etudiant.PrenomEtudiant;
            e.EmailEtudiant = etudiant.EmailEtudiant;
            db.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id) {
            var e = db.Etudiants.Find(id);
            if (e == null)
                return NotFound();
            db.Etudiants.Remove(e);
            db.SaveChanges();
            return Ok();
        }

    }
}