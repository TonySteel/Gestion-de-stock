//Tony
using System;
using System.Runtime.Serialization;

namespace WcfGestionStock.ClassGestionStock
{
    [DataContract]
    public class ClsCmdFournisseur
    {
        private int id;
        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int id_fournisseur;
        [DataMember]
        public int Id_fournisseur
        {
            get { return id_fournisseur; }
            set { id_fournisseur = value; }
        }

        private string societe;
        [DataMember]
        public string Societe
        {
            get { return societe; }
            set { societe = value; }
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

        private decimal quantite;
        [DataMember]
        public decimal Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }
        
        private decimal somme;
        [DataMember]
        public decimal Somme
        {
            get { return somme; }
            set { somme = value; }
        }

        private DateTime date_cmd;
        [DataMember]
        public DateTime Date_cmd
        {
            get { return date_cmd; }
            set { date_cmd = value; }
        }

        private DateTime date_reception;
        [DataMember]
        public DateTime Date_reception
        {
            get { return date_reception; }
            set { date_reception = value; }
        }

        public ClsCmdFournisseur() { }

    }
}
