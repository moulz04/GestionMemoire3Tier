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
        public bool AddMemoire(Memoire mem)
        {
            MemoireService service = new MemoireService();
            return service.AddMemoire(mem);
        }

        public bool DeleteMemoire(int? id)
        {
            MemoireService service = new MemoireService();
            return service.DeleteMemoire(id);
        }

        public List<Memoire> GetAllMemoire()
        {
            MemoireService service = new MemoireService();
            return service.GetAllMemoire();
        }

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

        public Memoire GetMemoire(int? id)
        {
            MemoireService service = new MemoireService();
            return service.GetMemoire(id);
        }

        public List<Memoire> GetMemoireList(Memoire mem)
        {
            MemoireService service = new MemoireService();
            return service.GetMemoireList(mem);
        }

        public bool UpdateMemoire(Memoire mem)
        {
            MemoireService service = new MemoireService();
            return service.UpdateMemoire(mem);
        }
    }
}
