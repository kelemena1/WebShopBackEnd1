using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]

        List<Felhasznalo> FelhasznaloLista_CS();

        [OperationContract]
        [WebInvoke (Method = "GET",
            RequestFormat =WebMessageFormat.Json,
            ResponseFormat =WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate ="/FelhasznaloLista/")]

        List<Felhasznalo> FelhasznaloLista_Web();
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Record
    {
        [DataMember]
        public int? Id { get; set; }

    }

    [DataContract]

    public class Felhasznalo:Record 
    {
        [DataMember]

        public string LoginNev { get; set; }

        [DataMember]

        public string HASH { get; set;}

        [DataMember]

        public string SALT { get; set;}

        [DataMember]

        public string Nev { get; set;}

        [DataMember]

        public byte Jog { get; set;}

        [DataMember]

        public bool Aktiv { get; set;}

        [DataMember]

        public string Email { get; set;}

        [DataMember]

        public string ProfilKep { get; set; }

        [OperationContract]

        public override string ToString()
        {
            return $"Id: {Id}\nLogin név: {LoginNev}\nHASH: {HASH}\nSALT: {SALT}\nNév: {Nev}\nJog: {Jog}\nAktív: {(Aktiv ? "Igen":"Nem")}\nE-mail: {Email}\nProfilkép utvonala: {ProfilKep}";
        }

    }
}
