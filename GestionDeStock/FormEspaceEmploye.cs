using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace GestionDeStock
{
    public partial class FormEspaceEmploye : Form
    {
        string Requete_Sql = "";
        //DataTable TableUtilisateur = new DataTable();
        string ClausewhereDate = "";
        string Clausewhere = "";
        DataTable TableStock = new DataTable();
        DataTable TableCmd = new DataTable();
        public ServiceWCF.Service1Client sc;

        public FormEspaceEmploye()
        {
            InitializeComponent();
        }

        private void FormEspaceEmploye_Load(object sender, EventArgs e)
        {
            sc = new ServiceWCF.Service1Client();

            Requete_Sql = @"select * from utilisateur where id = " + PageAcceuil.NumUtilisateur;
            List<ServiceWCF.ClsUtilisateur> TableUtilisateur = new List<ServiceWCF.ClsUtilisateur>();
            TableUtilisateur.AddRange(sc.LireTableUtilisateurSql(Requete_Sql));
            ServiceWCF.ClsUtilisateur[] tabUtil = TableUtilisateur.ToArray();            
            dgvInfoEmploye.DataSource = TableUtilisateur;

            dgvInfoEmploye.Columns["Id"].DisplayIndex = 0;
            dgvInfoEmploye.Columns["Nom"].DisplayIndex = 1;
            dgvInfoEmploye.Columns["Prenom"].DisplayIndex = 2;
            dgvInfoEmploye.Columns["Mail"].DisplayIndex = 3;
            dgvInfoEmploye.Columns["Login"].DisplayIndex = 4;
            dgvInfoEmploye.Columns["MotDePasse"].DisplayIndex = 5;
            dgvInfoEmploye.Columns["Societe"].DisplayIndex = 6;
            dgvInfoEmploye.Columns["Service"].DisplayIndex = 7;

            dgvInfoEmploye.Columns["Id"].Visible = false;
            dgvInfoEmploye.Columns["Id_statut"].Visible = false;
            dgvInfoEmploye.Columns["Societe"].Visible = false;
            dgvInfoEmploye.Columns["MotDePasse"].Visible = false;

            tabCtrlService.SelectTab("tabPage" + PageAcceuil.Service);

            switch (PageAcceuil.Service)
            {
                case "DRH":
                    Clausewhere = "where id_statut = 2";
                    RafraichirUtilisateur();
                    RafraichirFournisseur();
                    break;
                case "Gestion":
                    Clausewhere = "where id_statut = 1";
                    dgvGestionCompte.ReadOnly = false;
                    dgvGestionCmd.ReadOnly = false;
                    RafraichirGestion();
                    break;
                case "Comptabilite":
                    dgvComptaProduit.ReadOnly = false;
                    dgvComptaCmdClient.ReadOnly = false;
                    dgvComptaCmdFournisseur.ReadOnly = false;
                    break;
                case "Magasin":
                    dgvMagStock.ReadOnly = false;
                    dgvMagCmdFournisseur.ReadOnly = false;
                    break;
                case "Informatique":
                    break;
                default:
                    break;
            }
        }


        #region selection des onglets
        private void tabCtrlService_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexTab = tabCtrlService.SelectedIndex;
            switch (indexTab)
            {
                case 0: // DRH
                    Clausewhere = "where id_statut = 2";
                    RafraichirUtilisateur();
                    RafraichirFournisseur();
                    break;
                case 1: // Gestion
                    Clausewhere = "where id_statut = 1";
                    dgvGestionCompte.ReadOnly = false;
                    dgvGestionCmd.ReadOnly = false;
                    RafraichirGestion();
                    break;
                case 2: // Comptabilité
                    dgvComptaProduit.ReadOnly = false;
                    dgvComptaCmdClient.ReadOnly = false;
                    dgvComptaCmdFournisseur.ReadOnly = false;
                    RafraichirCompta();
                    RafraichirGraphCompta();
                    break;
                case 3: // Magasin
                    dgvMagStock.ReadOnly = false;
                    dgvMagCmdFournisseur.ReadOnly = false;
                    RafraichirStock();
                    RafraichirCmdFournisseur();
                    break;               
                case 4: // informatique
                    break;

                default :
                    break;
            }
        }
        #endregion

        // DRH
        #region DRH
        void RafraichirUtilisateur()
        {
            dgvDRHEmploye.ReadOnly = false;

            // Employés
            if (rbDRHEmploye.Checked == true)
                ClausewhereDate = "where id_statut = 2";
            if (rbDRHClient.Checked == true)
                ClausewhereDate = "where id_statut = 1";

            //Requete_Sql = @"select nom, prenom, mail, service from utilisateur " + ClausewhereDate;
            Requete_Sql = @"select * from utilisateur " + ClausewhereDate;
            List<ServiceWCF.ClsUtilisateur> TableUtilisateur = new List<ServiceWCF.ClsUtilisateur>();
            TableUtilisateur.AddRange(sc.LireTableUtilisateurSql(Requete_Sql));
            dgvDRHEmploye.DataSource = TableUtilisateur;
            dgvDRHEmploye.Columns["Id"].Visible = false;

            dgvDRHEmploye.ReadOnly = true;
        }

        void RafraichirFournisseur()
        {
            // Fournisseur/Client
            Requete_Sql = @"select * from fournisseur ";
            dgvDRHFournisseur.DataSource = sc.LireFournisseurSql(Requete_Sql);

            Requete_Sql = @"select * from fournisseur "; // + Clausewhere;            
            List<ServiceWCF.ClsFournisseur> Tablefournisseur = new List<ServiceWCF.ClsFournisseur>();
            Tablefournisseur.AddRange(sc.LireFournisseurSql(Requete_Sql));
            dgvDRHFournisseur.DataSource = Tablefournisseur;
            dgvDRHFournisseur.Columns["Id"].Visible = false;
        }
        
        private void rbDRHEmploye_CheckedChanged(object sender, EventArgs e)
        {
            RafraichirUtilisateur();
            RafraichirFournisseur();
        }
        private void rbDRHClient_CheckedChanged(object sender, EventArgs e)
        {
            RafraichirUtilisateur();
            RafraichirFournisseur();
        }
        #endregion


        // Gestion
        #region Gestion
        void RafraichirGestion()
        {            
            // Compte 
            if (rbGestionClient.Checked == true)
            {
                if(Clausewhere == "")
                    Clausewhere = "where id_statut = 1";
                //Requete_Sql = @"select id, nom, prenom, mail from utilisateur " + Clausewhere;
                Requete_Sql = @"select * from utilisateur " + Clausewhere;
                grpBoxGestionCompte.Text = "Comptes Clients";
                lbGestionCompte.Text = "Client";
                List<ServiceWCF.ClsUtilisateur> TableUtilisateur = new List<ServiceWCF.ClsUtilisateur>();
                TableUtilisateur.AddRange(sc.LireTableUtilisateurSql(Requete_Sql));
                dgvGestionCompte.DataSource = TableUtilisateur;

                dgvGestionCompte.Columns["Id"].DisplayIndex = 0;
                dgvGestionCompte.Columns["Nom"].DisplayIndex = 1;
                dgvGestionCompte.Columns["Prenom"].DisplayIndex = 2;
                dgvGestionCompte.Columns["Mail"].DisplayIndex = 3;
                dgvGestionCompte.Columns["Login"].DisplayIndex = 4;
                dgvGestionCompte.Columns["MotDePasse"].DisplayIndex = 5;
                dgvGestionCompte.Columns["Societe"].DisplayIndex = 6;
                dgvGestionCompte.Columns["Service"].DisplayIndex = 7;

                dgvGestionCompte.Columns["Id"].Visible = false;
                dgvGestionCompte.Columns["Login"].Visible = false;
                dgvGestionCompte.Columns["MotDePasse"].Visible = false;
                dgvGestionCompte.Columns["Id_statut"].Visible = false;
                dgvGestionCompte.Columns["Societe"].Visible = false;
                dgvGestionCompte.Columns["Service"].Visible = false;
            }
            if (rbGestionFournisseur.Checked == true)
            {   
                Requete_Sql = @"select * from fournisseur " + Clausewhere;
                grpBoxGestionCompte.Text = "Fournisseurs";
                lbGestionCompte.Text = "Socièté";
                List<ServiceWCF.ClsFournisseur> TableUtilisateur = new List<ServiceWCF.ClsFournisseur>();
                TableUtilisateur.AddRange(sc.LireFournisseurSql(Requete_Sql));
                dgvGestionCompte.DataSource = TableUtilisateur;

                dgvGestionCompte.Columns["Id"].DisplayIndex = 0;
                dgvGestionCompte.Columns["Societe"].DisplayIndex = 1;
                dgvGestionCompte.Columns["Mail"].DisplayIndex = 2;

                dgvGestionCompte.Columns["Id"].Visible = false;
                dgvGestionCompte.Columns["Societe"].Visible = true;
            }
            Clausewhere = "";

            // Commande
            string idtxt = "";
            int nbItem = dgvGestionCompte.RowCount - 1;
            
            if (rbGestionFournisseur.Checked == true)
            {
                Requete_Sql = @"select * from cmd_fournisseur ";
                idtxt = "id_fournisseur";
                Requete_Sql = Requete_Sql + Clausewhere;
                List<ServiceWCF.ClsCmdFournisseur> TableCmdFournisseur = new List<ServiceWCF.ClsCmdFournisseur>();
                TableCmdFournisseur.AddRange(sc.LireCmdFournisseurSql(Requete_Sql));
                dgvGestionCmd.DataSource = TableCmdFournisseur;

                dgvGestionCmd.Columns["Id"].DisplayIndex = 0;
                dgvGestionCmd.Columns["id_fournisseur"].DisplayIndex = 1;
                dgvGestionCmd.Columns["nom_produit"].DisplayIndex = 2;
                dgvGestionCmd.Columns["description"].DisplayIndex = 3;
                dgvGestionCmd.Columns["date_cmd"].DisplayIndex = 4;
                dgvGestionCmd.Columns["date_reception"].DisplayIndex = 5;
                dgvGestionCmd.Columns["prix_unitaire"].DisplayIndex = 6;
                dgvGestionCmd.Columns["quantite"].DisplayIndex = 7;

                dgvGestionCmd.Columns["Id"].Visible = false;                
                dgvGestionCmd.Columns["Id_fournisseur"].Visible = false;
                dgvGestionCmd.Columns["somme"].Visible = false;
                dgvGestionCmd.Columns["societe"].Visible = false;
            }                
            if (rbGestionClient.Checked == true)
            {
                Requete_Sql = @"select * from cmd_client ";                
                idtxt = "id_utilisateur";
                Requete_Sql = Requete_Sql + Clausewhere;
                List<ServiceWCF.ClsCmdClient> TableCmdClient = new List<ServiceWCF.ClsCmdClient>();
                TableCmdClient.AddRange(sc.LireCmdClientSql(Requete_Sql));
                dgvGestionCmd.DataSource = TableCmdClient;

                dgvGestionCmd.Columns["Id"].DisplayIndex = 0;
                dgvGestionCmd.Columns["id_utilisateur"].DisplayIndex = 1;
                dgvGestionCmd.Columns["id_produit"].DisplayIndex = 2;
                dgvGestionCmd.Columns["prix_unitaire"].DisplayIndex = 3;
                dgvGestionCmd.Columns["quantite"].DisplayIndex = 4;
                dgvGestionCmd.Columns["prix_quantite"].DisplayIndex = 5;
                dgvGestionCmd.Columns["date_cmd"].DisplayIndex = 6;
                dgvGestionCmd.Columns["date_livraison"].DisplayIndex = 7;

                dgvGestionCmd.Columns["Id"].Visible = false;
                dgvGestionCmd.Columns["Id_Utilisateur"].Visible = false;
                dgvGestionCmd.Columns["Id_produit"].Visible = false;
                dgvGestionCmd.Columns["somme"].Visible = false;

            }
            for (int lig = 0; lig < nbItem; lig++)
            {
                if (lig == 0)
                    Clausewhere = "where ";
                else
                    Clausewhere = Clausewhere + " or ";
                Clausewhere = Clausewhere + idtxt + " = " + dgvGestionCompte.Rows[lig].Cells["Id"].Value.ToString();
            }
            Clausewhere = "";
        }

        private void rbGestionClient_CheckedChanged(object sender, EventArgs e) // Client
        {
            Clausewhere = "";
            btGestionAjCompte.Visible = false;
            tbGestionCompte.Clear();
            RafraichirGestion();
        }
        private void rbGestionClient_Click(object sender, EventArgs e)
        {
            tbGestionCompte.Clear();
            RafraichirGestion();
        }

        private void rbGestionFournisseur_CheckedChanged(object sender, EventArgs e) // Fournisseur
        {
            btGestionAjCompte.Visible = true;
            tbGestionCompte.Clear();
            RafraichirGestion();
        }    
        private void rbGestionFournisseur_Click(object sender, EventArgs e)
        {
            tbGestionCompte.Clear();
            RafraichirGestion();
        }
        #endregion

        #region Comptes utilisateurs (Gestion)
        private void tbGestionCompte_TextChanged(object sender, EventArgs e) // Selection compte individuel
        {
            if (tbGestionCompte.Text != "")
            {
                if (rbGestionClient.Checked == true)
                    Clausewhere = "where id_statut = 1 and nom like '%" + tbGestionCompte.Text + "%'";                    
                if (rbGestionFournisseur.Checked == true)
                    Clausewhere = "where societe like '%" + tbGestionCompte.Text + "%'"; 
                RafraichirGestion();
            }
            Clausewhere = "";
        }
        private void btGestionAjCompte_Click(object sender, EventArgs e) // Ajouter Compte
        {
            if (rbGestionFournisseur.Checked == true)
                Requete_Sql = @"insert into fournisseur set id = null, societe = '', mail = null";
            sc.AjoutSupModifFournisseurSql(Requete_Sql);           
            RafraichirGestion();
        }

        private void btGestionSupCompte_Click(object sender, EventArgs e) // Supprimer Compte
        {
            int numlig = dgvGestionCompte.CurrentCell.OwningRow.Index;
            if (rbGestionClient.Checked == true)
                Requete_Sql = @"delete from utilisateur where id = '" + dgvGestionCompte.Rows[numlig].Cells[0].Value.ToString() + "'";
            if (rbGestionFournisseur.Checked == true)
                Requete_Sql = @"delete from fournisseur where id = '" + dgvGestionCompte.Rows[numlig].Cells[0].Value.ToString() + "'";
            sc.AjoutSupModifFournisseurSql(Requete_Sql);

            if (tbGestionCompte.Text != "")
            {
                if (rbGestionClient.Checked == true)
                    Clausewhere = "where id_statut = 1 and nom like '%" + tbGestionCompte.Text + "%'";
                if (rbGestionFournisseur.Checked == true)
                    Clausewhere = "where societe like '%" + tbGestionCompte.Text + "%'";
                RafraichirGestion();
            }
            Clausewhere = "";
        }

        private void dgvGestionCompte_CellValueChanged(object sender, DataGridViewCellEventArgs e) // Modifier Compte
        {
            int numlig = dgvGestionCompte.CurrentCell.OwningRow.Index;
            if (rbGestionClient.Checked == true)
            {                       
                Requete_Sql = @"update utilisateur set login = '" + dgvGestionCompte.Rows[numlig].Cells[1].Value.ToString() + "', nom = '" + dgvGestionCompte.Rows[numlig].Cells[2].Value.ToString() + "', prenom = '" + dgvGestionCompte.Rows[numlig].Cells[3].Value.ToString() + "', mail = '" + dgvGestionCompte.Rows[numlig].Cells[4].Value.ToString() + "'";
                Clausewhere = " where id = " + dgvGestionCompte.Rows[numlig].Cells[0].Value.ToString();
            }
            if (rbGestionFournisseur.Checked == true)
            {
                Requete_Sql = @"update fournisseur set societe = '" + dgvGestionCompte.Rows[numlig].Cells[1].Value.ToString() + "', mail = '" + dgvGestionCompte.Rows[numlig].Cells[2].Value.ToString() + "'";
                Clausewhere = " where id = " + dgvGestionCompte.Rows[numlig].Cells[0].Value.ToString();                
            }
            Requete_Sql = Requete_Sql + Clausewhere;
            sc.AjoutSupModifFournisseurSql(Requete_Sql);

           
            if (rbGestionClient.Checked == true)            
                Clausewhere = "where id_statut = 1 and nom like '%" + tbGestionCompte.Text + "%'";
            if (rbGestionFournisseur.Checked == true)
                Clausewhere = "where societe like '%" + tbGestionCompte.Text + "%'";
            RafraichirGestion();
        }
        #endregion

        #region Commandes
        private void dgvGestionCmd_CellValueChanged(object sender, DataGridViewCellEventArgs e) // Modifier commande
        {
            int numlig = dgvGestionCmd.CurrentCell.OwningRow.Index;
            string nomCol = dgvGestionCmd.CurrentCell.OwningColumn.Name;
            string annee = "";
            string mois = "";
            string jour = "";
            string datetxt = "";
            string clausewhere = "";

            if (rbGestionClient.Checked == true) // client
            {
                switch (nomCol)
                {
                    case "Id_utilisateur": 
                        Requete_Sql = @"update cmd_client set id_utilisateur = " + dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString();
                        break;

                    case "Id_produit":
                        Requete_Sql = @"update cmd_client set id_produit = " + dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString();
                        break;

                    case "Date_cmd":
                        jour = dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString().Substring(0, 2);
                        mois = dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString().Substring(3, 2);
                        annee = dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString().Substring(6, 4);
                        datetxt = annee + "-" + mois + "-" + jour;                        
                        Requete_Sql = @"update cmd_client set date_cmd = '" + datetxt + "'";
                        break;

                    case "Date_livraison":
                        jour = dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString().Substring(0, 2);
                        mois = dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString().Substring(3, 2);
                        annee = dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString().Substring(6, 4);
                        datetxt = annee + "-" + mois + "-" + jour;
                        Requete_Sql = @"update cmd_client set date_livraison = '" + datetxt + "'";
                        break;
                    case "Prix_unitaire":
                        Requete_Sql = @"update cmd_client set prix_unitaire = " + dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString();
                        break;

                    case "Quantite":                        
                        clausewhere = " where id = " + dgvGestionCmd.Rows[numlig].Cells["id"].Value.ToString();
                        Requete_Sql = @"update cmd_client set prix_quantite = (select sum(prix_unitaire * " + dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString() + ") as somme from cmd_client" + clausewhere + ")" + clausewhere;
                        sc.AjoutSupModifCmdClientSql(Requete_Sql);

                        Requete_Sql = @"update cmd_client set quantite = " + dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString();
                        break;

                    case "Prix_quantite":
                        clausewhere = " where id = " + dgvGestionCmd.Rows[numlig].Cells["id"].Value.ToString();
                        Requete_Sql = @"update cmd_client set prix_unitaire = (select sum(" + dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString() +" / quantite) as somme from cmd_client" + clausewhere + ")" + clausewhere;
                        sc.AjoutSupModifCmdClientSql(Requete_Sql);
                        Requete_Sql = @"update cmd_client set prix_quantite = " + dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString();
                        break;

                    default:
                        Requete_Sql = "";
                        break;
                }
                clausewhere = " where id = " + dgvGestionCmd.Rows[numlig].Cells["id"].Value.ToString();
                Requete_Sql = Requete_Sql + clausewhere;
                sc.AjoutSupModifCmdClientSql(Requete_Sql);
            }

            if (rbGestionFournisseur.Checked == true) // fournisseur
            {
                switch (nomCol)
                {
                    case "Id_fournisseur":
                        Requete_Sql = @"update cmd_fournisseur set id_fournisseur = " + dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString();
                        break;

                    case "Nom_produit":
                        Requete_Sql = @"update cmd_fournisseur set nom_produit = " + dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString();
                        break;

                    case "Description":
                        Requete_Sql = @"update cmd_fournisseur set description = " + dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString();
                        break;

                    case "Date_cmd":
                        jour = dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString().Substring(0, 2);
                        mois = dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString().Substring(3, 2);
                        annee = dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString().Substring(6, 4);
                        datetxt = annee + "-" + mois + "-" + jour;
                        Requete_Sql = @"update cmd_fournisseur set date_cmd = '" + datetxt + "'";
                        break;

                    case "Date_reception":
                        jour = dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString().Substring(0, 2);
                        mois = dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString().Substring(3, 2);
                        annee = dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString().Substring(6, 4);
                        datetxt = annee + "-" + mois + "-" + jour;
                        Requete_Sql = @"update cmd_fournisseur set date_reception = '" + datetxt + "'";
                        break;

                    case "Prix_unitaire":
                        Requete_Sql = @"update cmd_fournisseur set prix_unitaire = " + dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString();
                        break;

                    case "Quantite":                       
                        Requete_Sql = @"update cmd_client set quantite = " + dgvGestionCmd.Rows[numlig].Cells[nomCol].Value.ToString();
                        break;

                    default:
                        Requete_Sql = "";
                        break;
                }
                clausewhere = " where id = " + dgvGestionCmd.Rows[numlig].Cells["id"].Value.ToString();
                Requete_Sql = Requete_Sql + clausewhere;
                sc.AjoutSupModifCmdFournisseurSql(Requete_Sql);
            }

                    

            if (tbGestionCompte.Text != "")
            {
                if (rbGestionClient.Checked == true)
                    Clausewhere = "where id_statut = 1 and login like '%" + tbGestionCompte.Text + "%'";
                if (rbGestionFournisseur.Checked == true)
                    Clausewhere = "where societe like '%" + tbGestionCompte.Text + "%'";
                RafraichirGestion();
            }
            Clausewhere = "";
        }

        private void btGestionSupCmd_Click(object sender, EventArgs e) // Supprimer Commande
        {
            int numlig = dgvGestionCmd.CurrentCell.OwningRow.Index;
            if (rbGestionClient.Checked == true)
                Requete_Sql = @"delete from cmd_client where id = " + dgvGestionCmd.Rows[numlig].Cells["id"].Value.ToString();
            if (rbGestionFournisseur.Checked == true)
                Requete_Sql = @"delete from cmd_fournisseur where id = " + dgvGestionCmd.Rows[numlig].Cells["id"].Value.ToString();
            sc.AjoutSupModifCmdClientSql(Requete_Sql);

            if (tbGestionCompte.Text != "")
            {
                if (rbGestionClient.Checked == true)
                    Clausewhere = "where id_statut = 1 and login like '%" + tbGestionCompte.Text + "%'";
                if (rbGestionFournisseur.Checked == true)
                    Clausewhere = "where societe like '%" + tbGestionCompte.Text + "%'";
                RafraichirGestion();
            }
            Clausewhere = "";
        }
        #endregion


        // Comptabilité
        #region Compatbilité
        void RafraichirCompta()
        {
            // Produits            
            //Requete_Sql = @"select id, nom_produit, prix_vente, quantite_stock from produit ";
            Requete_Sql = @"select * from produit ";
            List<ServiceWCF.ClsStockProduit> TableStock = new List<ServiceWCF.ClsStockProduit>();
            TableStock.AddRange(sc.LireStockProduitSql(Requete_Sql));                    
            dgvComptaProduit.DataSource = TableStock;

            dgvComptaProduit.Columns["Id"].Visible = false;
            dgvComptaProduit.Columns["id_categorie"].Visible = false;
            dgvComptaProduit.Columns["id_fournisseur"].Visible = false;
            dgvComptaProduit.Columns["Nom_Categorie"].Visible = false;
            dgvComptaProduit.Columns["Description"].Visible = false;
            dgvComptaProduit.Columns["Somme"].Visible = false;

            // Commandes Client
            //Requete_Sql = @"select id, id_produit, date_cmd, date_livraison, prix_unitaire, quantite, prix_quantite from cmd_client " + ClausewhereDate;
            Requete_Sql = @"select * from cmd_client " + ClausewhereDate;
            List<ServiceWCF.ClsCmdClient> TableCmdClient = new List<ServiceWCF.ClsCmdClient>();
            TableCmdClient.AddRange(sc.LireCmdClientSql(Requete_Sql));
            sc.AjoutSupModifCmdClientSql(Requete_Sql);
            dgvComptaCmdClient.DataSource = TableCmdClient;

            dgvComptaCmdClient.Columns["Id"].Visible = false;
            dgvComptaCmdClient.Columns["id_utilisateur"].Visible = false;
            dgvComptaCmdClient.Columns["id_produit"].Visible = false;
            dgvComptaCmdClient.Columns["Nom_produit"].Visible = false;
            dgvComptaCmdClient.Columns["Description"].Visible = false;
            dgvComptaCmdClient.Columns["Somme"].Visible = false;

            // Commandes Fournisseur
            //Requete_Sql = @"select id, nom_produit, date_cmd, date_reception, prix_unitaire, quantite from cmd_Fournisseur " + ClausewhereDate;
            Requete_Sql = @"select * from cmd_Fournisseur " + ClausewhereDate;
            List<ServiceWCF.ClsCmdFournisseur> TableCmdFournisseur = new List<ServiceWCF.ClsCmdFournisseur>();
            TableCmdFournisseur.AddRange(sc.LireCmdFournisseurSql(Requete_Sql));
            sc.AjoutSupModifCmdFournisseurSql(Requete_Sql);
            dgvComptaCmdFournisseur.DataSource = TableCmdFournisseur;

            dgvComptaCmdFournisseur.Columns["Id"].Visible = false;
            dgvComptaCmdFournisseur.Columns["id_fournisseur"].Visible = false;
            dgvComptaCmdFournisseur.Columns["description"].Visible = false;
            dgvComptaCmdFournisseur.Columns["Nom_produit"].Visible = false;
            dgvComptaCmdFournisseur.Columns["Societe"].Visible = false;
            dgvComptaCmdFournisseur.Columns["Somme"].Visible = false;
        }
        void RafraichirGraphCompta()
        {
            decimal somme = 0;
            decimal benefice = 0;
            int nbItem = 0;

            // Gain        
            if (ClausewhereDate != "")
            {
                ClausewhereDate = ClausewhereDate.Replace("where", "");
                ClausewhereDate = " and " + ClausewhereDate;
            }


            nbItem = dgvComptaCmdClient.RowCount;
            for (int i = 0; i < nbItem - 1; i++)
            {
                Requete_Sql = @"select sum(prix_unitaire * quantite) as somme from cmd_client where id = " + dgvComptaCmdClient.Rows[i].Cells["Id"].Value.ToString() + ClausewhereDate;
                List<ServiceWCF.ClsCmdClient> lTableCmdClient = new List<ServiceWCF.ClsCmdClient>();                
                lTableCmdClient.AddRange(sc.SommeCmdClientSql(Requete_Sql));
                ServiceWCF.ClsCmdClient[] tabCmd = lTableCmdClient.ToArray();
                somme = somme + tabCmd[0].Somme;
                benefice = somme;
            }
            lbComptaGain.Text = somme.ToString();
            chartCompta.Series["Gain"].Points.Clear();
            chartCompta.Series["Gain"].Points.AddY(somme);

            // Dépense
            nbItem = dgvComptaCmdFournisseur.RowCount;
            for (int i = 0; i < nbItem - 1; i++)
            {               
                Requete_Sql = @"select sum(prix_unitaire * quantite) as somme from cmd_fournisseur where id = " + dgvComptaCmdFournisseur.Rows[i].Cells["Id"].Value.ToString() + ClausewhereDate;
                List<ServiceWCF.ClsCmdFournisseur> lTableCmdFournisseur = new List<ServiceWCF.ClsCmdFournisseur>();
                lTableCmdFournisseur.AddRange(sc.SommeCmdFournisseurSql(Requete_Sql));
                ServiceWCF.ClsCmdFournisseur[] tabCmd = lTableCmdFournisseur.ToArray();
                somme = somme + tabCmd[0].Somme;
            }            
            lbComptaDepense.Text = somme.ToString();
            chartCompta.Series["Depense"].Points.Clear();
            chartCompta.Series["Depense"].Points.AddY(somme);
            benefice = benefice - somme;

            // Valeur du stock
            nbItem = dgvComptaProduit.RowCount;
            for (int i = 0; i < nbItem-1; i++)
            {
                Requete_Sql = @"select sum(prix_vente * quantite_stock) as somme from produit where id = " + dgvComptaProduit.Rows[i].Cells["Id"].Value.ToString();
                List <ServiceWCF.ClsStockProduit> lTableStock = new List<ServiceWCF.ClsStockProduit>();
                lTableStock.AddRange(sc.SommeProduitSql(Requete_Sql));
                ServiceWCF.ClsStockProduit[] tabstock = lTableStock.ToArray();
                somme = somme + tabstock[0].Somme;
            }
            lbComptaValStock.Text = somme.ToString();
            chartCompta.Series["Valeur stock"].Points.Clear();
            chartCompta.Series["Valeur stock"].Points.AddY(somme);

            // Bénéfice            
            lbComptaBenefice.Text = benefice.ToString();
            chartCompta.Series["Benefice"].Points.Clear();
            chartCompta.Series["Benefice"].Points.AddY(benefice);
        }


        private void dgvComptaProduit_CellValueChanged(object sender, DataGridViewCellEventArgs e) // Modifier un prix de vente article
        {
            string nomcol = dgvComptaProduit.CurrentCell.OwningColumn.Name;
            int numlig = dgvComptaProduit.CurrentCell.OwningRow.Index;
            string clauseWhere = " where id = " + dgvComptaProduit.Rows[numlig].Cells["Id"].Value.ToString();
            if (nomcol == "Prix_Vente")
            {
                Requete_Sql = @"update produit set prix_vente = '" + dgvComptaProduit.Rows[numlig].Cells["Prix_Vente"].Value.ToString() + "'";
                Requete_Sql = Requete_Sql + clauseWhere;
                sc.AjoutSupModifProduitSql(Requete_Sql);
            }
            else
                MessageBox.Show("Vous n'êtes pas autorisé à changer ce paramètre !");

            RafraichirCompta();
        }
        
        private void dgvComptaCmdClient_CellValueChanged(object sender, DataGridViewCellEventArgs e) // Modifier un prix unitaire article commande client
        {
            string nomcol = dgvComptaCmdClient.CurrentCell.OwningColumn.Name;
            int numlig = dgvComptaCmdClient.CurrentCell.OwningRow.Index;
            string clauseWhere = " where id = " + dgvComptaCmdClient.Rows[numlig].Cells["Id"].Value.ToString();
            if (nomcol == "Prix_unitaire")
            {
                Requete_Sql = @"update cmd_client set prix_unitaire = " + dgvComptaCmdClient.Rows[numlig].Cells["Prix_unitaire"].Value.ToString();
                Requete_Sql = Requete_Sql + clauseWhere;
                sc.AjoutSupModifCmdClientSql(Requete_Sql);

                Requete_Sql = @"update cmd_client set prix_quantite = (select sum(prix_unitaire * quantite) as somme from cmd_client where id = " + dgvComptaCmdClient.Rows[numlig].Cells["Id"].Value.ToString() + ")" + clauseWhere;
                sc.AjoutSupModifCmdClientSql(Requete_Sql);
            }
            else
            {
                if (nomcol == "Prix_quantite")
                {
                    Requete_Sql = @"update cmd_client set prix_quantite = " + dgvComptaCmdClient.Rows[numlig].Cells["Prix_quantite"].Value.ToString();
                    Requete_Sql = Requete_Sql + clauseWhere;
                    sc.AjoutSupModifCmdClientSql(Requete_Sql);

                    Requete_Sql = @"update cmd_client set prix_unitaire = (select sum(prix_quantite / quantite) as somme from cmd_client where id = " + dgvComptaCmdClient.Rows[numlig].Cells["Id"].Value.ToString() + ")" + clauseWhere;
                    sc.AjoutSupModifCmdClientSql(Requete_Sql);
                }
                else
                    MessageBox.Show("Vous n'êtes pas autorisé à changer ce paramètre !");
            }
            RafraichirCompta();
        }

        private void dgvComptaCmdFournisseur_CellValueChanged(object sender, DataGridViewCellEventArgs e) // Modifier un prix unitaire article commande fournisseur
        {
            string nomcol = dgvComptaCmdFournisseur.CurrentCell.OwningColumn.Name;
            int numlig = dgvComptaCmdFournisseur.CurrentCell.OwningRow.Index;
            string clauseWhere = " where id = " + dgvComptaCmdFournisseur.Rows[numlig].Cells["Id"].Value.ToString();
            if (nomcol == "Prix_unitaire")
            {
                Requete_Sql = @"update cmd_Fournisseur set prix_unitaire = " + dgvComptaCmdFournisseur.Rows[numlig].Cells["Prix_unitaire"].Value.ToString();
                Requete_Sql = Requete_Sql + clauseWhere;
                sc.AjoutSupModifCmdFournisseurSql(Requete_Sql);
            }
            else
                MessageBox.Show("Vous n'êtes pas autorisé à changer ce paramètre !");

            RafraichirCompta();
        }
        #endregion

        #region Hitorique Compta
        
        private void rbComptaAvant_CheckedChanged(object sender, EventArgs e) // avant
        {
            string txtDate = "date_cmd";
            dtComptaAvant.Visible = true;
            dtComptaApres.Visible = false;
            ClausewhereDate = "where " + txtDate + " <= '" + string.Format("{0:u}", dtComptaAvant.Value).Substring(0, 10) + "'";
            RafraichirCompta();
            ClausewhereDate = "where " + txtDate + " <= '" + string.Format("{0:u}", dtComptaAvant.Value).Substring(0, 10) + "'";
            RafraichirGraphCompta();
        }

        private void rbComptaEntre_CheckedChanged(object sender, EventArgs e)  // entre
        {
            string txtDate = "date_cmd";
            dtComptaAvant.Visible = true;
            dtComptaApres.Visible = true;
            if (dtComptaAvant.Value > dtComptaApres.Value)
                ClausewhereDate = "where " + txtDate + " between '" + string.Format("{0:u}", dtComptaApres.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dtComptaAvant.Value).Substring(0, 10) + "'";
            else
                ClausewhereDate = "where " + txtDate + " between '" + string.Format("{0:u}", dtComptaAvant.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dtComptaApres.Value).Substring(0, 10) + "'";
            RafraichirCompta();

            if (dtComptaAvant.Value > dtComptaApres.Value)
                ClausewhereDate = "where " + txtDate + " between '" + string.Format("{0:u}", dtComptaApres.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dtComptaAvant.Value).Substring(0, 10) + "'";
            else
                ClausewhereDate = "where " + txtDate + " between '" + string.Format("{0:u}", dtComptaAvant.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dtComptaApres.Value).Substring(0, 10) + "'";
            RafraichirGraphCompta();
        }

        private void rbComptaApres_CheckedChanged(object sender, EventArgs e)  // aprés
        {
            string txtDate = "date_cmd";
            dtComptaAvant.Visible = false;
            dtComptaApres.Visible = true;
            ClausewhereDate = "where " + txtDate + " >= '" + string.Format("{0:u}", dtComptaApres.Value).Substring(0, 10) + "'";
            RafraichirCompta();
            ClausewhereDate = "where " + txtDate + " >= '" + string.Format("{0:u}", dtComptaApres.Value).Substring(0, 10) + "'";
            RafraichirGraphCompta();
        }

        private void dtComptaAvant_ValueChanged(object sender, EventArgs e)
        {
            string txtDate = "date_cmd";
            if (rbComptaAvant.Checked == true && rbComptaApres.Checked == true)
            { // entre
                if (dtComptaAvant.Value > dtComptaApres.Value)
                    ClausewhereDate = "where " + txtDate + " between '" + string.Format("{0:u}", dtComptaApres.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dtComptaAvant.Value).Substring(0, 10) + "'";
                else
                    ClausewhereDate = "where " + txtDate + " between '" + string.Format("{0:u}", dtComptaAvant.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dtComptaApres.Value).Substring(0, 10) + "'";
                RafraichirCompta();

                if (dtComptaAvant.Value > dtComptaApres.Value)
                    ClausewhereDate = "where " + txtDate + " between '" + string.Format("{0:u}", dtComptaApres.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dtComptaAvant.Value).Substring(0, 10) + "'";
                else
                    ClausewhereDate = "where " + txtDate + " between '" + string.Format("{0:u}", dtComptaAvant.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dtComptaApres.Value).Substring(0, 10) + "'";
            }
            else
            {
                if (rbComptaAvant.Checked == false && rbComptaApres.Checked == true)
                { // aprés
                    ClausewhereDate = "where " + txtDate + " >= '" + string.Format("{0:u}", dtComptaApres.Value).Substring(0, 10) + "'";
                    RafraichirCompta();
                    ClausewhereDate = "where " + txtDate + " >= '" + string.Format("{0:u}", dtComptaApres.Value).Substring(0, 10) + "'";
                }
                else
                {
                    if (rbComptaAvant.Checked == true && rbComptaApres.Checked == false)
                    {   // avant
                        ClausewhereDate = "where " + txtDate + " <= '" + string.Format("{0:u}", dtComptaAvant.Value).Substring(0, 10) + "'";
                        RafraichirCompta();
                        ClausewhereDate = "where " + txtDate + " <= '" + string.Format("{0:u}", dtComptaAvant.Value).Substring(0, 10) + "'";
                    }
                    else
                        ClausewhereDate = "";
                }
            }            
            RafraichirCompta();
            RafraichirGraphCompta();
        }

        private void dtComptaApres_ValueChanged(object sender, EventArgs e)
        {
            string txtDate = "date_cmd";
            if (rbComptaAvant.Checked == true && rbComptaApres.Checked == true)
            { // entre
                if (dtComptaAvant.Value > dtComptaApres.Value)
                    ClausewhereDate = "where " + txtDate + " between '" + string.Format("{0:u}", dtComptaApres.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dtComptaAvant.Value).Substring(0, 10) + "'";
                else
                    ClausewhereDate = "where " + txtDate + " between '" + string.Format("{0:u}", dtComptaAvant.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dtComptaApres.Value).Substring(0, 10) + "'";
                RafraichirCompta();

                if (dtComptaAvant.Value > dtComptaApres.Value)
                    ClausewhereDate = "where " + txtDate + " between '" + string.Format("{0:u}", dtComptaApres.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dtComptaAvant.Value).Substring(0, 10) + "'";
                else
                    ClausewhereDate = "where " + txtDate + " between '" + string.Format("{0:u}", dtComptaAvant.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dtComptaApres.Value).Substring(0, 10) + "'";
            }
            else
            {
                if (rbComptaAvant.Checked == false && rbComptaApres.Checked == true)
                { // aprés
                    ClausewhereDate = "where " + txtDate + " >= '" + string.Format("{0:u}", dtComptaApres.Value).Substring(0, 10) + "'";
                    RafraichirCompta();
                    ClausewhereDate = "where " + txtDate + " >= '" + string.Format("{0:u}", dtComptaApres.Value).Substring(0, 10) + "'";
                }
                else
                {
                    if (rbComptaAvant.Checked == true && rbComptaApres.Checked == false)
                    {   // avant
                        ClausewhereDate = "where " + txtDate + " <= '" + string.Format("{0:u}", dtComptaAvant.Value).Substring(0, 10) + "'";
                        RafraichirCompta();
                        ClausewhereDate = "where " + txtDate + " <= '" + string.Format("{0:u}", dtComptaAvant.Value).Substring(0, 10) + "'";
                    }
                    else
                        ClausewhereDate = "";
                }
            }
            RafraichirCompta();
            RafraichirGraphCompta();
        }
        #endregion
    

        // Magasin
        #region Magasin        
        // Commandes 
        void RafraichirCmdFournisseur()
        {
            Requete_Sql = @"select * from cmd_fournisseur inner join fournisseur on cmd_fournisseur.id_fournisseur = fournisseur.id " + ClausewhereDate;

            dgvMagCmdFournisseur.DataSource = sc.LireCmdFournisseurSql(Requete_Sql);

            dgvMagCmdFournisseur.Columns["Id"].DisplayIndex = 0;
            dgvMagCmdFournisseur.Columns["id_fournisseur"].DisplayIndex = 1;
            dgvMagCmdFournisseur.Columns["nom_produit"].DisplayIndex = 2;
            dgvMagCmdFournisseur.Columns["description"].DisplayIndex = 3;
            dgvMagCmdFournisseur.Columns["date_cmd"].DisplayIndex = 4;
            dgvMagCmdFournisseur.Columns["date_reception"].DisplayIndex = 5;
            dgvMagCmdFournisseur.Columns["prix_unitaire"].DisplayIndex = 6;
            dgvMagCmdFournisseur.Columns["quantite"].DisplayIndex = 7;

            dgvMagCmdFournisseur.Columns["Id"].Visible = false;
            dgvMagCmdFournisseur.Columns["Id_fournisseur"].Visible = false;
            dgvMagCmdFournisseur.Columns["Somme"].Visible = false;

            if (chbDateCmd.Checked == true)
            {
                dgvMagCmdFournisseur.Columns["date_cmd"].Visible = false;
                dgvMagCmdFournisseur.Columns["date_reception"].Visible = true;
            }                
            else
            {
                dgvMagCmdFournisseur.Columns["date_cmd"].Visible = true;
                dgvMagCmdFournisseur.Columns["date_reception"].Visible = false;
            }
        }

                
        private void chbDateCmd_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDateCmd.Checked == false)
                chbDateCmd.Text = "Date de commande";
            else
                chbDateCmd.Text = "Date de reception";
            RafraichirCmdFournisseur();
        }
       
        // Stock
        void RafraichirStock()
        {
            Requete_Sql = @"select * from produit where quantite_stock <= " + numMagNbArticle.Value;            
            dgvMagStock.DataSource = sc.LireStockProduitSql(Requete_Sql);

            dgvMagStock.Columns["id"].DisplayIndex = 0;
            dgvMagStock.Columns["nom_produit"].DisplayIndex = 1;
            dgvMagStock.Columns["description"].DisplayIndex = 2;
            dgvMagStock.Columns["prix_vente"].DisplayIndex = 3;
            dgvMagStock.Columns["quantite_stock"].DisplayIndex = 4;
            dgvMagStock.Columns["somme"].DisplayIndex = 5;
            dgvMagStock.Columns["id_categorie"].DisplayIndex = 6;
            dgvMagStock.Columns["id_fournisseur"].DisplayIndex = 7;

            dgvMagStock.Columns["Id"].Visible = false;            
            dgvMagStock.Columns["Id_fournisseur"].Visible = false;
            dgvMagStock.Columns["Nom_Categorie"].Visible = false;            
            dgvMagStock.Columns["Somme"].Visible = false;

            //Initialisation ComboBox Categorie article Magasin
            cbMagCateg.Items.Clear();
            Requete_Sql = @"select * from categorie";
            List<ServiceWCF.ClsStockProduit> TableCateg = new List<ServiceWCF.ClsStockProduit>();
            TableCateg.AddRange(sc.LireCategorieSql(Requete_Sql));
            ServiceWCF.ClsStockProduit[] tabCateg = TableCateg.ToArray();
            for (int i = 0; i < tabCateg.Length; i++)
                cbMagCateg.Items.Add(tabCateg[i].Nom_Categorie);
            cbMagCateg.Visible = false;
        }

        private void numMagNbArticle_ValueChanged(object sender, EventArgs e)
        {
            RafraichirStock();
        }

        private void btSupprimerProduit_Click(object sender, EventArgs e) // Supprimer
        {            
            int numligStock = dgvMagStock.CurrentCell.OwningRow.Index;
            string id_produit = dgvMagStock.Rows[numligStock].Cells["Id"].Value.ToString();

            Requete_Sql = @"delete from produit where id = " + id_produit;
            sc.AjoutSupModifProduitSql(Requete_Sql);
            RafraichirStock();
        }

        private void btAjouterProduit_Click(object sender, EventArgs e) // Ajouter
        {
            Requete_Sql = "insert into produit values (null,null,null,'0.00',0,1,10)";
            sc.AjoutSupModifProduitSql(Requete_Sql);
            RafraichirStock();
            int nbLig = dgvMagStock.RowCount;
            dgvMagStock.CurrentCell = dgvMagStock.Rows[nbLig - 1].Cells["Nom_produit"];
            dgvMagStock.Rows[nbLig-1].Selected = true;

        }

        
        private void dgvMagStock_CellValueChanged(object sender, DataGridViewCellEventArgs e) // Modifier
        {
            int numligStock = dgvMagStock.CurrentCell.OwningRow.Index;
            string id_produit = dgvMagStock.Rows[numligStock].Cells["Id"].Value.ToString();
            string nomcol = dgvMagStock.CurrentCell.OwningColumn.Name;

            if (nomcol == "Prix_Vente")
            {
                MessageBox.Show("Seul le service comptabilité est habilité à modifier les prix de vente des articles !");
                RafraichirStock();
            }
            else
            {
                string donnee_Table = dgvMagStock.CurrentCell.Value.ToString();
                donnee_Table = donnee_Table.Replace("'", "''");
                Requete_Sql = "update produit set " + nomcol + " = '" + donnee_Table + "' where id = '" + id_produit + "'";
                sc.AjoutSupModifProduitSql(Requete_Sql);
            }

            
            
        }

        private void dgvMagStock_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string nomcol = dgvMagStock.CurrentCell.OwningColumn.Name;
            if (nomcol == "Id_Categorie")
            {
                cbMagCateg.Visible = true;
            }
        }
        private void cbMagCateg_SelectedValueChanged(object sender, EventArgs e)
        {
            int numligStock = dgvMagStock.CurrentCell.OwningRow.Index;
            string id_produit = dgvMagStock.Rows[numligStock].Cells["Id"].Value.ToString();

            Requete_Sql = @"select * from categorie";
            List<ServiceWCF.ClsStockProduit> TableCateg = new List<ServiceWCF.ClsStockProduit>();
            TableCateg.AddRange(sc.LireCategorieSql(Requete_Sql));
            ServiceWCF.ClsStockProduit[] tabCateg = TableCateg.ToArray();
            for (int i = 0; i < tabCateg.Length; i++)
            {
                if (cbMagCateg.SelectedItem.ToString() == tabCateg[i].Nom_Categorie)
                {
                    string donnee_Table = tabCateg[i].Id.ToString();
                    Requete_Sql = "update produit set id_categorie = '" + donnee_Table + "' where id = '" + id_produit + "'";
                    sc.AjoutSupModifProduitSql(Requete_Sql);
                    RafraichirStock();
                    break;
                }
            }
        }
        #endregion

        #region Commande fournisseur
        private void btCommander_Click(object sender, EventArgs e) // Ajouter
        {
            int numlig = 0;
            int numligStock = 0;
            string id_fournisseur = "1";
            string nom_produit = "";
            string description = "";            
            string prix_unitaire = "0";
            string quantite = "0";

            try
            {
                numlig = dgvMagCmdFournisseur.CurrentCell.OwningRow.Index;
                numligStock = dgvMagStock.CurrentCell.OwningRow.Index;                
                id_fournisseur = dgvMagStock.Rows[numligStock].Cells["Id_fournisseur"].Value.ToString();
                nom_produit = dgvMagStock.Rows[numligStock].Cells["Nom_produit"].Value.ToString();
                description = dgvMagStock.Rows[numligStock].Cells["Description"].Value.ToString();                
            }
            catch (Exception)
            {
                numlig = 0;
            }  

            Requete_Sql = @"insert into cmd_fournisseur set id_fournisseur = " + id_fournisseur + ", nom_produit = '" + nom_produit + "', description = '" + description + "', date_cmd = current_date, date_reception = null, prix_unitaire = " + prix_unitaire + ", quantite = " + quantite;
            try
            {
                sc.AjoutSupModifCmdFournisseurSql(Requete_Sql);
                RafraichirCmdFournisseur();
                int nbLig = dgvMagCmdFournisseur.RowCount;
                dgvMagCmdFournisseur.CurrentCell = dgvMagCmdFournisseur.Rows[nbLig - 1].Cells["Nom_produit"];
                dgvMagCmdFournisseur.Rows[nbLig - 1].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvStockMag_CellValueChanged(object sender, DataGridViewCellEventArgs e) // Modifier
        {
            string annee ="";
            string mois = "";
            string jour = "";
            string datetxt = "";
            string nomcol = dgvMagCmdFournisseur.CurrentCell.OwningColumn.Name;
            int numlig = dgvMagCmdFournisseur.CurrentCell.OwningRow.Index;            
            string clauseWhere = " where id = " + dgvMagCmdFournisseur.Rows[numlig].Cells["id"].Value.ToString();
            switch (nomcol)
            {
                case "Id_fournisseur":
                    Requete_Sql = @"update cmd_fournisseur set id_fournisseur = '" + dgvMagCmdFournisseur.Rows[numlig].Cells["Id_fournisseur"].Value.ToString() + "'";
                    break;
                case "Nom_produit":
                    Requete_Sql = @"update cmd_fournisseur set nom_produit = '" + dgvMagCmdFournisseur.Rows[numlig].Cells["Nom_produit"].Value.ToString() + "'";
                    break;
                case "Description":
                    Requete_Sql = @"update cmd_fournisseur set description = '" + dgvMagCmdFournisseur.Rows[numlig].Cells["Description"].Value.ToString() + "'";
                    break;
                case "Date_cmd":
                    jour = dgvMagCmdFournisseur.Rows[numlig].Cells["Date_cmd"].Value.ToString().Substring(0, 2);
                    mois = dgvMagCmdFournisseur.Rows[numlig].Cells["Date_cmd"].Value.ToString().Substring(3, 2);
                    annee = dgvMagCmdFournisseur.Rows[numlig].Cells["Date_cmd"].Value.ToString().Substring(6, 4);
                    datetxt = annee + "-" + mois + "-" + jour;
                    Requete_Sql = @"update cmd_fournisseur set date_cmd = '" + datetxt + "'";
                    break;
                case "Date_reception":
                    jour = dgvMagCmdFournisseur.Rows[numlig].Cells["Date_reception"].Value.ToString().Substring(0, 2);
                    mois = dgvMagCmdFournisseur.Rows[numlig].Cells["Date_reception"].Value.ToString().Substring(3, 2);
                    annee = dgvMagCmdFournisseur.Rows[numlig].Cells["Date_reception"].Value.ToString().Substring(6, 4);
                    datetxt = annee + "-" + mois + "-" + jour;
                    Requete_Sql = @"update cmd_fournisseur set date_reception = '" + datetxt + "'";
                    break;
                case "Prix_unitaire":
                    Requete_Sql = @"update cmd_fournisseur set prix_unitaire = '" + dgvMagCmdFournisseur.Rows[numlig].Cells["Prix_unitaire"].Value.ToString() + "'";
                    break;
                case "Quantite":
                    Requete_Sql = @"update cmd_fournisseur set quantite = '" + dgvMagCmdFournisseur.Rows[numlig].Cells["Quantite"].Value.ToString() + "'";
                    break;

                default:
                    Requete_Sql = "";
                    break;
            }
            Requete_Sql = Requete_Sql + clauseWhere;
            sc.AjoutSupModifCmdFournisseurSql(Requete_Sql);
            RafraichirCmdFournisseur();
            int nbLig = dgvMagCmdFournisseur.RowCount;
            dgvMagCmdFournisseur.CurrentCell = dgvMagCmdFournisseur.Rows[nbLig - 1].Cells["Nom_produit"];
            dgvMagCmdFournisseur.Rows[nbLig - 1].Selected = true;
        }

        private void btSupprimerCmd_Click(object sender, EventArgs e) // Supprimer
        {
            int numlig = 0;
            numlig = dgvMagCmdFournisseur.CurrentCell.OwningRow.Index;
            string id = dgvMagCmdFournisseur.Rows[numlig].Cells["Id"].Value.ToString();
            Requete_Sql = @"delete from cmd_fournisseur where id = '" + id + "'";
            sc.AjoutSupModifCmdFournisseurSql(Requete_Sql);
            RafraichirCmdFournisseur();
        }
        #endregion

        #region historique des commandes
        private void radioButton1_CheckedChanged_1(object sender, EventArgs e) // Toutes les commandes
        {
            dtAvant.Visible = false;
            dtApres.Visible = false;
            ClausewhereDate = "";
            RafraichirCmdFournisseur();
        }
        private void rdMagCmdRecep_CheckedChanged(object sender, EventArgs e)  // Commandes en cours
        {
            dtAvant.Visible = false;
            dtApres.Visible = false;
            ClausewhereDate = "where date_reception <=> null";
            RafraichirCmdFournisseur();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) // avant
        {
            string txtDate = "";
            if (chbDateCmd.Checked == true)
                txtDate = "date_reception";
            else
                txtDate = "date_cmd";
            dtAvant.Visible = true;
            dtApres.Visible = false;
            ClausewhereDate = " where " + txtDate + " <= '" + string.Format("{0:u}", dtAvant.Value).Substring(0, 10) + "' order by " + txtDate;
            RafraichirCmdFournisseur();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)  // entre
        {
            string txtDate = "";
            if (chbDateCmd.Checked == true)
                txtDate = "date_reception";
            else
                txtDate = "date_cmd";
            dtAvant.Visible = true;
            dtApres.Visible = true;
            if (dtAvant.Value > dtApres.Value)
                ClausewhereDate = " where" + txtDate + " between '" + string.Format("{0:u}", dtApres.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dtAvant.Value).Substring(0, 10) + "' order by " + txtDate;
            else
                ClausewhereDate = " where " + txtDate + " between '" + string.Format("{0:u}", dtAvant.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dtApres.Value).Substring(0, 10) + "' order by " + txtDate;
            RafraichirCmdFournisseur();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) // aprés
        {
            string txtDate = "";
            if (chbDateCmd.Checked == true)
                txtDate = "date_reception";
            else
                txtDate = "date_cmd";
            dtAvant.Visible = false;
            dtApres.Visible = true;
            ClausewhereDate = " where " + txtDate + " >= '" + string.Format("{0:u}", dtApres.Value).Substring(0, 10) + "' order by " + txtDate;
            RafraichirCmdFournisseur();
        }

        private void dtAvant_ValueChanged(object sender, EventArgs e) // date avant
        {
            string txtDate = "";
            if (chbDateCmd.Checked == true)
                txtDate = "date_reception";
            else
                txtDate = "date_cmd";

            if (rbMagAvant.Checked == true)
                ClausewhereDate = " where " + txtDate + " <= '" + string.Format("{0:u}", dtAvant.Value).Substring(0, 10) + "' order by " + txtDate;
            else
            {
                if (rbMagEntre.Checked == true)
                {
                    if (dtAvant.Value > dtApres.Value)
                        ClausewhereDate = " where " + txtDate + " between '" + string.Format("{0:u}", dtApres.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dtAvant.Value).Substring(0, 10) + "' order by " + txtDate;
                    else
                        ClausewhereDate = " where " + txtDate + " between '" + string.Format("{0:u}", dtAvant.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dtApres.Value).Substring(0, 10) + "' order by " + txtDate;
                }
                else
                {
                    if (rbMagApres.Checked == true)
                        ClausewhereDate = " where " + txtDate + " >= '" + string.Format("{0:u}", dtApres.Value).Substring(0, 10) + "' order by " + txtDate;
                    else
                        ClausewhereDate = "";
                }
            }
            RafraichirCmdFournisseur();
        }

        private void dtApres_ValueChanged(object sender, EventArgs e) // date aprés
        {
            string txtDate = "";
            if (chbDateCmd.Checked == true)
                txtDate = "date_reception";
            else
                txtDate = "date_cmd";

            if (rbMagAvant.Checked == true)
                ClausewhereDate = " where " + txtDate + " <= '" + string.Format("{0:u}", dtAvant.Value).Substring(0, 10) + "' order by " + txtDate;
            else
            {
                if (rbMagEntre.Checked == true)
                {
                    if (dtAvant.Value > dtApres.Value)
                        ClausewhereDate = " where " + txtDate + " between '" + string.Format("{0:u}", dtApres.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dtAvant.Value).Substring(0, 10) + "' order by " + txtDate;
                    else
                        ClausewhereDate = " where " + txtDate + " between '" + string.Format("{0:u}", dtAvant.Value).Substring(0, 10) + "' and '" + string.Format("{0:u}", dtApres.Value).Substring(0, 10) + "' order by " + txtDate;
                }
                else
                {
                    if (rbMagApres.Checked == true)
                        ClausewhereDate = " where " + txtDate + " >= '" + string.Format("{0:u}", dtApres.Value).Substring(0, 10) + "' order by " + txtDate;
                    else
                        ClausewhereDate = "";
                }
            }
            RafraichirCmdFournisseur();
        }
        #endregion


        // Informatique
        #region Table BDD
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictUtilisateur.Visible = false;
            pictStatut.Visible = false;
            pictFournisseur.Visible = false;
            pictProduit.Visible = false;
            pictCategorie.Visible = false;
            pictPanier.Visible = false;
            pictCmdClient.Visible = false;
            pictCmdFournisseur.Visible = false;

            switch (comboBox1.SelectedIndex)
            {
                case 1:
                    pictUtilisateur.Visible = true;
                    break;
                case 2:
                    pictStatut.Visible = true;
                    break;
                case 3:
                    pictFournisseur.Visible = true;
                    break;
                case 4:
                    pictProduit.Visible = true;
                    break;
                case 5:
                    pictCategorie.Visible = true;
                    break;
                case 6:
                    pictPanier.Visible = true;
                    break;
                case 7:
                    pictCmdClient.Visible = true;
                    break;
                case 8:
                    pictCmdFournisseur.Visible = true;
                    break;

                default:
                    pictUtilisateur.Visible = false;
                    pictStatut.Visible = false;
                    pictFournisseur.Visible = false;
                    pictProduit.Visible = false;
                    pictCategorie.Visible = false;
                    pictPanier.Visible = false;
                    pictCmdClient.Visible = false;
                    pictCmdFournisseur.Visible = false;
                    break;
            }

        }
        #endregion


        // Compte utilisateur
        #region Modification mot de passe
        private void chBoxModifMotDePass_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxModifMotDePass.Checked == true)
            {
                dgvInfoEmploye.Columns["MotDePasse"].Visible = true;                
                chBoxModifMotDePass.Text = "Masquer votre mot de passe";

            }
            else
            {
                dgvInfoEmploye.Columns["MotDePasse"].Visible = false;
                chBoxModifMotDePass.Text = "Modifier votre mot de passe";
            }

            if (chBoxModifMotDePass.Checked == true)
            {
                //  Décryptage mot de passe                
                //int lig = dgvInfoEmploye.CurrentCell.OwningRow.Index;
                /*string motdepasse = dgvInfoEmploye.Rows[0].Cells[4].Value.ToString();
                byte[] protectedBytes = Convert.FromBase64String(motdepasse);
                byte[] bytes = ProtectedData.Unprotect(protectedBytes, null, DataProtectionScope.CurrentUser);
                string decmotdepasse = Encoding.UTF8.GetString(bytes);
                dgvInfoEmploye.Rows[0].Cells[4].Value = decmotdepasse;*/

                dgvInfoEmploye.CurrentCell = dgvInfoEmploye[4, 0];
                dgvInfoEmploye.Rows[0].Cells[4].Value = "";
                    
            }                

            tabCtrlService.SelectTab("tabPage" + PageAcceuil.Service);
        }
        #endregion

        #region Modification Info Utilisateur
        private void dgvInfoEmploye_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int col = dgvInfoEmploye.CurrentCell.OwningColumn.Index;
            string nomcol = dgvInfoEmploye.CurrentCell.OwningColumn.Name;
            string id_Table = dgvInfoEmploye.Rows[e.RowIndex].Cells[0].Value.ToString();
            string donnee_Table = dgvInfoEmploye.CurrentCell.Value.ToString();
            donnee_Table = donnee_Table.Replace("'", "''");

            // Cryptage mot de passe
            if (dgvInfoEmploye.Rows[0].Cells[4].Value.ToString() != "")
            {
                if(nomcol == "MotDePasse")
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


        // Généralité
        #region Retour à l'accueil
        private void btRetourAccueil_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Accés au stock
        private void btCatalogue_Click(object sender, EventArgs e)
        {
            FormCatalogue f = new FormCatalogue();
            f.ShowDialog();
        }

        #endregion

        
    }
}
