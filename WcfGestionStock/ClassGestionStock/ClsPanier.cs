//Tony
using System.Runtime.Serialization;

namespace WcfGestionStock.ClassGestionStock
{
    [DataContract]
    public class ClsPanier
    {       
        private int id;
        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int id_produit;
        [DataMember]
        public int Id_produit
        {
            get { return id_produit; }
            set { id_produit = value; }
        }

        private string nom_produit;
        [DataMember]
        public string Nom_produit
        {
            get { return nom_produit; }
            set { nom_produit = value; }
        }

        private string description;
        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private int quantite;
        [DataMember]
        public int Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }

        private decimal prix_vente;
        [DataMember]
        public decimal Prix_Vente
        {
            get { return prix_vente; }
            set { prix_vente = value; }
        }

        private int id_client;
        [DataMember]
        public int Id_Client
        {
            get { return id_client; }
            set { id_client = value; }
        }

        private decimal somme;
        [DataMember]
        public decimal Somme
        {
            get { return somme; }
            set { somme = value; }
        }


        public ClsPanier() { }
                
    }
}
