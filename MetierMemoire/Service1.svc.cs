
using MetierMemoire.Model;
using MetierMemoire.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MetierMemoire
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        readonly MemoireService memoireService = new MemoireService();

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<Memoire> GetAllMemoire()
        {
            MemoireService service = new MemoireService();
            return service.GetAllMemoire();
        }

        public Memoire GetMemoire(int? id)
        {
            MemoireService service = new MemoireService();
            return service.GetMemoire(id);
        }

        public bool AddMemoire(Memoire memo)
        {
            MemoireService service = new MemoireService();
           return service.AddMemoire(memo);
            //return memoireService.AddMemoire(memo);
        }

        public bool EditMemoire(Memoire memo)
        {
            MemoireService service = new MemoireService();
            return service.EditMemoire(memo);

            //return memoireService.EditMemoire(memo);
        }

        public bool DeleteMemoire(int id)
        {
            MemoireService service = new MemoireService();
            return service.DeleteMemoire(id);
        }
    }
}
