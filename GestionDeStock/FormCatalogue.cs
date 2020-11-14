//Tony
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDeStock
{  

    public partial class FormCatalogue  : Form
    {
        public ServiceWCF.Service1Client sc;
        //ClsRequete Requete = new ClsRequete();
        DataTable TableArticle = new DataTable();
        string Requete_Sql = "";
        //string ColProduit = "produit.id,nom_produit,description,prix_vente,quantite_stock";
        string Jointure = "";
        string ClauseWhere = "";
        string Id_Produit = "";
        string NumCateg = "0";


        public FormCatalogue()
        {
            InitializeComponent();
        }

        private void FormCatalogue_Load(object sender, EventArgs e)
        {
            sc = new ServiceWCF.Service1Client();
            

            Requete_Sql = @"select * from categorie";
            List<ServiceWCF.ClsStockProduit> TableCateg = new List<ServiceWCF.ClsStockProduit>();
            TableCateg.AddRange(sc.LireCategorieSql(Requete_Sql));
            dgvCategorie.DataSource = TableCateg;

            dgvCategorie.Columns["id"].DisplayIndex = 0;
            dgvCategorie.Columns["nom_produit"].DisplayIndex = 1;
            dgvCategorie.Columns["description"].DisplayIndex = 2;
            dgvCategorie.Columns["prix_vente"].DisplayIndex = 3;
            dgvCategorie.Columns["quantite_stock"].DisplayIndex = 4;
            dgvCategorie.Columns["somme"].DisplayIndex = 5;
            dgvCategorie.Columns["id_categorie"].DisplayIndex = 6;
            dgvCategorie.Columns["id_fournisseur"].DisplayIndex = 7;            
            
            dgvCategorie.Columns["id"].Visible = false;
            dgvCategorie.Columns["nom_produit"].Visible = false;            
            dgvCategorie.Columns["description"].Visible = false;
            dgvCategorie.Columns["prix_vente"].Visible = false;
            dgvCategorie.Columns["quantite_stock"].Visible = false;
            dgvCategorie.Columns["somme"].Visible = false;
            dgvCategorie.Columns["id_categorie"].Visible = false;            
            dgvCategorie.Columns["id_fournisseur"].Visible = false;
            

            Requete_Sql = @"select * from produit";
            List<ServiceWCF.ClsStockProduit> TableProduit = new List<ServiceWCF.ClsStockProduit>();
            TableProduit.AddRange(sc.LireStockProduitSql(Requete_Sql));
            dgvArticle.DataSource = TableProduit;

            dgvArticle.Columns["id"].DisplayIndex = 0;
            dgvArticle.Columns["nom_produit"].DisplayIndex = 1;
            dgvArticle.Columns["description"].DisplayIndex = 2;
            dgvArticle.Columns["prix_vente"].DisplayIndex = 3;
            dgvArticle.Columns["quantite_stock"].DisplayIndex = 4;
            dgvArticle.Columns["somme"].DisplayIndex = 5;
            dgvArticle.Columns["id_categorie"].DisplayIndex = 6;
            dgvArticle.Columns["id_fournisseur"].DisplayIndex = 7;

            dgvArticle.Columns["id"].Visible = false;
            dgvArticle.Columns["somme"].Visible = false;
            dgvArticle.Columns["nom_categorie"].Visible = false;


            if (PageAcceuil.ConfirmationConnection == true)
            {
                switch (PageAcceuil.Id_Statut)
                {
                    case 1: // client
                        {                            
                            btPanier.Visible = true;                            
                            btAjouterCategorie.Visible = false;
                            dgvArticle.ReadOnly = true;
                            dgvArticle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            dgvCategorie.ReadOnly = true;
                            break;
                        }

                    case 2: // employé
                        {                            
                            switch (PageAcceuil.Service)
                            {
                                case "Informatique":
                                    {
                                        btPanier.Visible = true;                                        
                                        btAjouterCategorie.Visible = true;
                                        dgvArticle.ReadOnly = false;
                                        dgvArticle.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                                        dgvCategorie.ReadOnly = false;
                                        break;
                                    }

                                case "Gestion":
                                case "Magasin":
                                    {
                                        btPanier.Visible = false;
                                        btAjouterCategorie.Visible = true;
                                        dgvArticle.ReadOnly = false;
                                        dgvArticle.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                                        dgvCategorie.ReadOnly = false;
                                        break;
                                    }

                                default:
                                    {
                                        btPanier.Visible = false;
                                        btAjouterCategorie.Visible = false;
                                        dgvArticle.ReadOnly = false;
                                        dgvArticle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                                        dgvCategorie.ReadOnly = false;
                                        break;
                                    }
                            }
                            break;
                        }
                }
            }
            else
            {                
                btPanier.Visible = false;
                dgvArticle.ReadOnly = true;
                dgvCategorie.ReadOnly = true;
            }             
        }

        #region rafraichir datagrid Produit
        private void RefreschProduit()
        {
            int i = 1;
            ClauseWhere = "where prix_vente != 0 and id_categorie in (";

            foreach (DataGridViewRow Lig in dgvCategorie.SelectedRows)
            {
                NumCateg = dgvCategorie.Rows[Lig.Index].Cells["Id"].Value.ToString();
                if (NumCateg == "")
                    i--;

                if (i > 1)
                {
                    ClauseWhere = ClauseWhere + "," + NumCateg;
                }
                else
                    ClauseWhere = ClauseWhere + NumCateg;
                i++;
            }

            if (NumCateg == "0" || NumCateg == "")
                ClauseWhere = "";
            else
                ClauseWhere = ClauseWhere + ")";

            Requete_Sql = @"select * from produit " + Jointure + " " + ClauseWhere;
            List<ServiceWCF.ClsStockProduit> TableProduit = new List<ServiceWCF.ClsStockProduit>();
            TableProduit.AddRange(sc.LireStockProduitSql(Requete_Sql));
            dgvArticle.DataSource = TableProduit;

            dgvArticle.Columns["Id"].Visible = false;
            dgvArticle.Columns["Id_categorie"].Visible = false;
            dgvArticle.Columns["Id_fournisseur"].Visible = false;
                        
            try
            {
                Id_Produit = dgvArticle.Rows[0].Cells["Id"].Value.ToString();
            }
            catch (Exception)
            {
                Id_Produit = "";
            }
            
        }
        #endregion

        #region categorie Selectionner, Ajouter
        private void dgvCategorie_CurrentCellChanged(object sender, EventArgs e) // afficher les produits 
        {
            RefreschProduit();
        }
        private void btAjouterCategorie_Click(object sender, EventArgs e)  // Ajouter
        {
            Requete_Sql = "insert into categorie values (null,null)";
            sc.AjoutSupModifProduitSql(Requete_Sql);

            Requete_Sql = "select * from categorie";
            List<ServiceWCF.ClsStockProduit> TableCateg = new List<ServiceWCF.ClsStockProduit>();
            TableCateg.AddRange(sc.LireCategorieSql(Requete_Sql));
            dgvArticle.DataSource = TableCateg;
            dgvArticle.Columns["Id"].Visible = false;
        }

        private void dgvCategorie_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string nomcol = dgvCategorie.CurrentCell.OwningColumn.Name;
            string donnee_Table = dgvCategorie.CurrentCell.Value.ToString();
            donnee_Table = donnee_Table.Replace("'", "''");
            NumCateg = dgvCategorie.Rows[e.RowIndex].Cells["Id"].Value.ToString();

            Requete_Sql = "update categorie set " + nomcol + " = '" + donnee_Table + "' where id = " + NumCateg ;
            sc.AjoutSupModifProduitSql(Requete_Sql);
        }

        private void btTouteCategorie_Click(object sender, EventArgs e)
        {
            Requete_Sql = @"select * from produit where prix_vente != 0";
            List<ServiceWCF.ClsStockProduit> TableProduit = new List<ServiceWCF.ClsStockProduit>();
            TableProduit.AddRange(sc.LireStockProduitSql(Requete_Sql));
            dgvArticle.DataSource = TableProduit;

            dgvArticle.Columns["Id"].Visible = false;
            dgvArticle.Columns["Id_categorie"].Visible = false;
            dgvArticle.Columns["Id_fournisseur"].Visible = false;
        }
        #endregion

        #region retour 
        private void btCatalogue_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Ajouter au panier
        private void btPanier_Click(object sender, EventArgs e)
        {
            int lig = dgvArticle.CurrentCell.OwningRow.Index;
            Id_Produit = dgvArticle.Rows[lig].Cells["Id"].Value.ToString(); 
            Requete_Sql = @"insert into panier (id,id_produit,quantite,panier.prix_vente,id_client) select null,id as id_produit,1,prix_vente," + PageAcceuil.NumUtilisateur + " from produit where id = " + Id_Produit;
            sc.AjoutSupModifPanierSql(Requete_Sql);

            this.Close();
        }
        #endregion
                
    }
}
