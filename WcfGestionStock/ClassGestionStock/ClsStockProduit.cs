//Tony
using System.Runtime.Serialization;


namespace WcfGestionStock.ClassGestionStock
{
    [DataContract]
    public class ClsStockProduit
    {
        private int id;
        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nom_produit;
        [DataMember]
        public string Nom_Produit
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

        private decimal prix_vente;
        [DataMember]
        public decimal Prix_Vente
        {
            get { return prix_vente; }
            set { prix_vente = value; }
        }

        private int quantite_stock;
        [DataMember]
        public int Quantite_Stock
        {
            get { return quantite_stock; }
            set { quantite_stock = value; }
        }

        private int id_categorie;
        [DataMember]
        public int Id_Categorie
        {
            get { return id_categorie; }
            set { id_categorie = value; }
        }

        private int id_fournisseur;
        [DataMember]
        public int Id_Fournisseur
        {
            get { return id_fournisseur; }
            set { id_fournisseur = value; }
        }

        private decimal somme;
        [DataMember]
        public decimal Somme
        {
            get { return somme; }
            set { somme = value; }
        }

        private string nom_categorie;
        [DataMember]
        public string Nom_Categorie
        {
            get { return nom_categorie; }
            set { nom_categorie = value; }
        }


        public ClsStockProduit() { }


    }
}
