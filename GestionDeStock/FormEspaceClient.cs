using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace GestionDeStock
{    
    public partial class FormEspaceClient : Form
    {
        string Requete_Sql = "";
        string ClausewhereDate = "";
        public ServiceWCF.Service1Client sc;

        public FormEspaceClient()
        {
            InitializeComponent();
        }

        private void FormEspaceClient_Load(object sender, EventArgs e)
        {
            sc = new ServiceWCF.Service1Client();

            Requete_Sql = @"select * from utilisateur where id = " + PageAcceuil.NumUtilisateur;
            List<ServiceWCF.ClsUtilisateur> TableUtilisateur = new List<ServiceWCF.ClsUtilisateur>();
            TableUtilisateur.AddRange(sc.LireTableUtilisateurSql(Requete_Sql));
            dgvInfoClient.DataSource = TableUtilisateur;

            dgvInfoClient.Columns["Id"].DisplayIndex = 0;
            dgvInfoClient.Columns["Nom"].DisplayIndex = 1;
            dgvInfoClient.Columns["Prenom"].DisplayIndex = 2;
            dgvInfoClient.Columns["Mail"].DisplayIndex = 3;
            dgvInfoClient.Columns["Login"].DisplayIndex = 4;
            dgvInfoClient.Columns["MotDePasse"].DisplayIndex = 5;
            dgvInfoClient.Columns["Societe"].DisplayIndex = 6;
            dgvInfoClient.Columns["Service"].DisplayIndex = 7;

            dgvInfoClient.Columns["Id"].Visible = false;
            dgvInfoClient.Columns["Id_statut"].Visible = false;
            dgvInfoClient.Columns["MotDePasse"].Visible = false;
            dgvInfoClient.Columns["Societe"].Visible = false;
            dgvInfoClient.Columns["Service"].Visible = false;

            RafraichirPanier();
            RafraichirCmdClient();
        }

        //Panier
        #region rafraichir panier
        public void RafraichirPanier()
        {
            tabCtrlClient.SelectTab("tabPagePanier");
            Requete_Sql = @"select * from panier inner join produit on produit.id = id_produit where id_client = " + PageAcceuil.NumUtilisateur;
            List<ServiceWCF.ClsPanier> TablePanier = new List<ServiceWCF.ClsPanier>();
            TablePanier.AddRange(sc.LireTablePanierSql(Requete_Sql));
            dgvPanier.DataSource = TablePanier;

            dgvPanier.Columns["Id"].DisplayIndex = 0;
            dgvPanier.Columns["Id_produit"].DisplayIndex = 1;
            dgvPanier.Columns["quantite"].DisplayIndex = 2;
            dgvPanier.Columns["prix_vente"].DisplayIndex = 3;
            dgvPanier.Columns["id_client"].DisplayIndex = 4;

            dgvPanier.Columns["Id_produit"].Visible = false;
            dgvPanier.Columns["Id_client"].Visible = false;

            SommePrixPanier();
        }

        private decimal SommePrixPanier()
        {
            decimal somme = 0;
            Requete_Sql = @"select sum(prix_vente * quantite) as somme from panier where id_client = " + PageAcceuil.NumUtilisateur;          
            List<ServiceWCF.ClsPanier> lTablePanier = new List<ServiceWCF.ClsPanier>();
            lTablePanier.AddRange(sc.SommePanierSql(Requete_Sql));
            ServiceWCF.ClsPanier[] tabPanier = lTablePanier.ToArray();
            somme = tabPanier[0].Somme;
            lbSommePanier.Text = somme.ToString();
            return somme;
        }
        #endregion

        #region supprimer un article du panier
        private void btSupprimerArticle_Click(object sender, EventArgs e)
        {
            string id_panier = "";

            foreach (DataGridViewRow Lig in dgvPanier.SelectedRows)
            {
                id_panier = dgvPanier.Rows[Lig.Index].Cells["id"].Value.ToString();
            }

            Requete_Sql = "delete from panier where id = '" + id_panier + "'" ;
            sc.AjoutSupModifPanierSql(Requete_Sql);
            RafraichirPanier();
        }
        #endregion

        #region modifier la quantité d'un article du panier
        private void dgvPanier_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string id_panier = "";
            string quantite = "";
            string nomCol = dgvPanier.CurrentCell.OwningColumn.Name;

            foreach (DataGridViewRow Lig in dgvPanier.SelectedRows)
            {
                if (nomCol == "Quantite")
                {
                    id_panier = dgvPanier.Rows[Lig.Index].Cells["Id"].Value.ToString();
                    quantite = dgvPanier.Rows[Lig.Index].Cells[e.ColumnIndex].Value.ToString();
                    Requete_Sql = @"update panier set quantite = '" + quantite + "' where id = '" + id_panier + "'";

                    List<ServiceWCF.ClsPanier> lTablePanier = new List<ServiceWCF.ClsPanier>();
                    sc.AjoutSupModifPanierSql(Requete_Sql);
                    SommePrixPanier();
                }
                else
                {
                    RafraichirPanier();
                }                
            }            
        }
        #endregion


        // Commande client
        #region validation commande
        private void btValiderPanier_Click(object sender, EventArgs e)
        {
            string Txt = "";
            Requete_Sql = @"select * from panier where id_client = " + PageAcceuil.NumUtilisateur;

            List<ServiceWCF.ClsPanier> lTablePanier = new List<ServiceWCF.ClsPanier>();
            lTablePanier.AddRange(sc.LireTablePanierSql(Requete_Sql));
            ServiceWCF.ClsPanier[] tabCmdClient = lTablePanier.ToArray();

            List<ServiceWCF.ClsStockProduit> lTableStock = new List<ServiceWCF.ClsStockProduit>();
            ServiceWCF.ClsStockProduit clsp = new ServiceWCF.ClsStockProduit();
            int quantite_stock = 0;

            for (int i = 0; i < tabCmdClient.Length; i++)
            {
                Txt = "";
                Txt += tabCmdClient[i].Id_Client;
                Txt += ";";
                Txt += tabCmdClient[i].Id_produit;
                Txt += ";";
                Txt += DateTime.Today.ToShortDateString();
                Txt += ";";
                Txt += "null";
                Txt += ";";
                Txt += tabCmdClient[i].Prix_Vente ;
                Txt += ";";
                Txt += tabCmdClient[i].Quantite;
                Txt += ";";
                Txt += tabCmdClient[i].Somme;

                // Copie du produit panier dans la table Commande client
                Requete_Sql = @"insert into cmd_client set id_utilisateur = " + tabCmdClient[i].Id_Client + ", id_produit = " + tabCmdClient[i].Id_produit + ", date_cmd = current_date, date_livraison = null , prix_unitaire = " + tabCmdClient[i].Prix_Vente + ", quantite = " + tabCmdClient[i].Quantite + ", prix_quantite = " + tabCmdClient[i].Somme;
                sc.AjoutSupModifCmdClientSql(Requete_Sql);

                // Calcul de la quantité du stock
                quantite_stock = 0;
                Requete_Sql = @"select * from produit where id = " + tabCmdClient[i].Id_produit;

                lTableStock.AddRange(sc.LireStockProduitSql(Requete_Sql));
                ServiceWCF.ClsStockProduit[] tabstock = lTableStock.ToArray();
                quantite_stock = tabstock[i].Quantite_Stock - tabCmdClient[i].Quantite;

                Requete_Sql = @"update produit set quantite_stock = " + quantite_stock + " where id = " + tabstock[i].Id;
                sc.AjoutSupModifProduitSql(Requete_Sql);                
                RafraichirPanier();

                // Effacement du panier
                Requete_Sql = @"delete from panier where id_client = " + tabCmdClient[i].Id_Client;
                sc.AjoutSupModifPanierSql(Requete_Sql);
                RafraichirPanier();
            }
            RafraichirCmdClient();
        }
        #endregion

        #region rafraichir commande client
        private void tabPageCommande_Click(object sender, EventArgs e)
        {
            RafraichirCmdClient();
        }
        public void RafraichirCmdClient()
        {
            dgvCmdClient.ReadOnly = false;

            tabCtrlClient.SelectTab("tabPageCommande");            
            //Requete_Sql = @"select produit.nom_produit, produit.description,prix_unitaire, quantite, prix_quantite, date_cmd, date_livraison from cmd_client inner join produit on produit.id = cmd_client.id_produit where id_utilisateur = " + PageAcceuil.NumUtilisateur + ClausewhereDate;
            Requete_Sql = @"select * from cmd_client inner join produit on produit.id = cmd_client.id_produit where id_utilisateur = " + PageAcceuil.NumUtilisateur + ClausewhereDate;
            List<ServiceWCF.ClsCmdClient> TableCmdClient = new List<ServiceWCF.ClsCmdClient>();
            TableCmdClient.AddRange(sc.LireCmdClientSql(Requete_Sql));
            dgvCmdClient.DataSource = TableCmdClient;

            dgvCmdClient.Columns["Id"].DisplayIndex = 0;
            dgvCmdClient.Columns["id_utilisateur"].DisplayIndex = 1;
            dgvCmdClient.Columns["id_produit"].DisplayIndex = 2;
            dgvCmdClient.Columns["date_cmd"].DisplayIndex = 3;
            dgvCmdClient.Columns["date_livraison"].DisplayIndex = 4;
            dgvCmdClient.Columns["prix_unitaire"].DisplayIndex = 5;
            dgvCmdClient.Columns["quantite"].DisplayIndex = 6;
            dgvCmdClient.Columns["prix_quantite"].DisplayIndex = 7;            

            dgvCmdClient.Columns["Id"].Visible = false;
            dgvCmdClient.Columns["Id_utilisateur"].Visible = false;
            dgvCmdClient.Columns["Id_produit"].Visible = false;
            dgvCmdClient.Columns["Somme"].Visible = false;

            lbSommeCmd.Text = SommePrixCommande().ToString();

            dgvCmdClient.ReadOnly = true;
        }

        private decimal SommePrixCommande()
        {            
            decimal somme = 0;                           
            Requete_Sql = @"select sum(prix_quantite) as somme from cmd_client where id_utilisateur = " + PageAcceuil.NumUtilisateur;
            List<ServiceWCF.ClsPanier> lTableCmd = new List<ServiceWCF.ClsPanier>();
            lTableCmd.AddRange(sc.SommePanierSql(Requete_Sql));
            ServiceWCF.ClsPanier[] tabCmd = lTableCmd.ToArray();
            somme = tabCmd[0].Somme;
            return somme;
        }
        #endregion

        #region Dates historique des commandes
        private void rbAvantDate_CheckedChanged(object sender, EventArgs e)
        {
            dateCmdAvant.Visible = true;
            dateCmdApres.Visible = false;
            ClausewhereDate = " and date_cmd <= '" + string.Format("{0:u}", dateCmdAvant.Value).Substring(0, 10) + "' order by date_cmd";
            RafraichirCmdClient();
        }

        private void rdEntreDate_CheckedChanged(object sender, EventArgs e)
        {
            dateCmdAvant.Visible = true;
            dateCmdApres.Visible = true;            
            if (dateCmdAvant.Value > dateCmdApres.Value)
                ClausewhereDate = " and date_cmd between '" + string.Format("{0:u}", dateCmdApres.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dateCmdAvant.Value).Substring(0, 10) + "' order by date_cmd";
            else
                ClausewhereDate = " and date_cmd between '" + string.Format("{0:u}", dateCmdAvant.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dateCmdApres.Value).Substring(0, 10) + "' order by date_cmd";  
            RafraichirCmdClient();
        }

        private void rbApresDate_CheckedChanged(object sender, EventArgs e)
        {
            dateCmdAvant.Visible = false;
            dateCmdApres.Visible = true;
            ClausewhereDate = " and date_cmd >= '" + string.Format("{0:u}", dateCmdApres.Value).Substring(0, 10) + "' order by date_cmd";
            RafraichirCmdClient();
        }

        private void dateCmdAvant_ValueChanged(object sender, EventArgs e)
        {
            if (rbAvantDate.Checked == true)
                ClausewhereDate = " and date_cmd <= '" + string.Format("{0:u}", dateCmdAvant.Value).Substring(0, 10) + "' order by date_cmd";
            else
            {
                if (rdEntreDate.Checked == true)
                {
                    if (dateCmdAvant.Value > dateCmdApres.Value)
                        ClausewhereDate = " and date_cmd between '" + string.Format("{0:u}", dateCmdApres.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dateCmdAvant.Value).Substring(0, 10) + "' order by date_cmd";
                    else
                        ClausewhereDate = " and date_cmd between '" + string.Format("{0:u}", dateCmdAvant.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dateCmdApres.Value).Substring(0, 10) + "' order by date_cmd";
                }
                else
                {
                    if (rbApresDate.Checked == true)
                        ClausewhereDate = " and date_cmd >= '" + string.Format("{0:u}", dateCmdApres.Value).Substring(0, 10) + "' order by date_cmd";
                    else
                        ClausewhereDate = "";
                }
            }               
            RafraichirCmdClient();
        }
        private void dateCmdApres_ValueChanged(object sender, EventArgs e)
        {
            if (rbAvantDate.Checked == true)
                ClausewhereDate = " and date_cmd <= '" + string.Format("{0:u}", dateCmdAvant.Value).Substring(0, 10) + "' order by date_cmd";
            else
            {
                if (rdEntreDate.Checked == true)
                {
                    if (dateCmdAvant.Value > dateCmdApres.Value)
                        ClausewhereDate = " and date_cmd between '" + string.Format("{0:u}", dateCmdApres.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dateCmdAvant.Value).Substring(0, 10) + "' order by date_cmd";
                    else
                        ClausewhereDate = " and date_cmd between '" + string.Format("{0:u}", dateCmdAvant.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dateCmdApres.Value).Substring(0, 10) + "' order by date_cmd";
                }
                else
                {
                    if (rbApresDate.Checked == true)
                        ClausewhereDate = " and date_cmd >= '" + string.Format("{0:u}", dateCmdApres.Value).Substring(0, 10) + "' order by date_cmd";
                    else
                        ClausewhereDate = "";
                }
            }
            RafraichirCmdClient();
        }

        private void btCmdAttente_Click(object sender, EventArgs e)
        {
            ClausewhereDate = " and date_Livraison <=> null  order by date_cmd";
            RafraichirCmdClient();
        }
        #endregion


        // Généralité
        #region retour à l'accueil
        private void btRetourAccueil_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region catalogue
        private void btCatalogue_Click(object sender, EventArgs e)
        {
            FormCatalogue f = new FormCatalogue();
            f.ShowDialog();
            RafraichirPanier();
        }
        #endregion
     

        //Utilisateur (Client)
        #region Modification mot de passe
        private void chBoxModifMotDePass_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxModifMotDePass.Checked == true)
            {
                dgvInfoClient.Columns["MotDePasse"].Visible = true;
                chBoxModifMotDePass.Text = "Masquer votre mot de passe";
            }
            else
            {
                dgvInfoClient.Columns["MotDePasse"].Visible = false;
                chBoxModifMotDePass.Text = "Modifier votre mot de passe";
            }
            
            if (chBoxModifMotDePass.Checked == true)
            {
                //  Décryptage mot de passe
                //int lig = dgvInfoClient.CurrentCell.OwningRow.Index;
                /*string motdepasse = dgvInfoClient.Rows[lig].Cells[4].Value.ToString();
                byte[] protectedBytes = Convert.FromBase64String(motdepasse);
                byte[] bytes = ProtectedData.Unprotect(protectedBytes, null, DataProtectionScope.CurrentUser);
                string decmotdepasse = Encoding.UTF8.GetString(bytes);
                dgvInfoClient.Rows[lig].Cells[4].Value = decmotdepasse;*/
                //dgvInfoClient.Rows[lig].Cells[4].Value = "";

                dgvInfoClient.CurrentCell = dgvInfoClient[4, 0];
                dgvInfoClient.Rows[0].Cells[4].Value = "";
            }
        }
        #endregion

        #region Modification Info Utilisateur
        private void dgvInfoClient_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int col = dgvInfoClient.CurrentCell.OwningColumn.Index;
            string nomcol = dgvInfoClient.CurrentCell.OwningColumn.Name;
            string id_Table = dgvInfoClient.Rows[e.RowIndex].Cells[0].Value.ToString();
            string donnee_Table = dgvInfoClient.CurrentCell.Value.ToString();
            donnee_Table = donnee_Table.Replace("'", "''");

            // Cryptage mot de passe
            if (dgvInfoClient.Rows[0].Cells[4].Value.ToString() != "")
            {
                if (nomcol == "MotDePasse")
                {
                    /*byte[] bytes = Encoding.UTF8.GetBytes(donnee_Table);
                    byte[] protectedBytes = ProtectedData.Protect(bytes, null, DataProtectionScope.CurrentUser);
                    donnee_Table = Convert.ToBase64String(protectedBytes);*/
                }
                Requete_Sql = "update utilisateur set " + nomcol + " = '" + donnee_Table + "' where id = '" + PageAcceuil.NumUtilisateur + "'";
                sc.AjoutSupModifUtilisateurSql(Requete_Sql);
            }
        }
        #endregion

    }
}
