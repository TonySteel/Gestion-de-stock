using System.Runtime.Serialization;

namespace WcfGestionStock.ClassGestionStock
{
    [DataContract]
    public class ClsFournisseur
    {
        private int id;
        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string societe;
        [DataMember]
        public string Societe
        {
            get { return societe; }
            set { societe = value; }
        }

        private string mail;
        [DataMember]
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }


        public ClsFournisseur() { }
    }
}
