//Tony
using System;
using System.Runtime.Serialization;

namespace WcfGestionStock.ClassGestionStock
{    
    [DataContract]
    public class ClsCmdClient
    {
        private int id;
        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int id_utilisateur;
        [DataMember]
        public int Id_utilisateur
        {
            get { return id_utilisateur; }
            set { id_utilisateur = value; }
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

        private decimal prix_unitaire;
        [DataMember]
        public decimal Prix_unitaire
        {
            get { return prix_unitaire; }
            set { prix_unitaire = value; }
        }

        private int quantite;
        [DataMember]
        public int Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }

        private decimal prix_quantite;
        [DataMember]
        public decimal Prix_quantite
        {
            get { return prix_quantite; }
            set { prix_quantite = value; }
        }

        private DateTime date_cmd;
        [DataMember]
        public DateTime Date_cmd
        {
            get { return date_cmd; }
            set { date_cmd = value; }
        }

        private DateTime date_livraison;
        [DataMember]
        public DateTime Date_livraison
        {
            get { return date_livraison; }
            set { date_livraison = value; }
        }

        private decimal somme;
        [DataMember]
        public decimal Somme
        {
            get { return somme; }
            set { somme = value; }
        }

        public ClsCmdClient() { }
                
    }
}
