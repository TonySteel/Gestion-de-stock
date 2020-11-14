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
using System.Security.Cryptography;


namespace GestionDeStock
{ 
    public partial class PageAcceuil : Form
    {
        //ClsRequete Requete = new ClsRequete();
        string Requete_Sql = "";
        //DataTable TableStatut = new DataTable();        
        public static int Id_Statut = 1; // 1: client 2:Employé 
        string LoginUtilisateur;
        string MotDePasse;
        public static int NumUtilisateur = 0;
        public static string Service = "";
        public static bool ConfirmationConnection = false;
        bool[] ValidationCompte = new bool[] { false, false, false, false, false, true, true }; // 7 conditions de validation de compte
        public ServiceWCF.Service1Client sc;

        public PageAcceuil()
        {
            InitializeComponent();
        }

        private void PageAcceuil_Load(object sender, EventArgs e)
        {            
            sc = new ServiceWCF.Service1Client();            
        }

        #region Quitter l'application
        private void btQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Connection
        private void textBoxLogin_Validated(object sender, EventArgs e) // Login
        {
            if (textBoxLogin.Text != "")
            {   
                LoginUtilisateur = textBoxLogin.Text;
                Requete_Sql = "select * from utilisateur where login = '" + LoginUtilisateur + "'";
                List<ServiceWCF.ClsUtilisateur> TableUtilisateur = new List<ServiceWCF.ClsUtilisateur>();
                TableUtilisateur.AddRange(sc.LireTableUtilisateurSql(Requete_Sql));
                ServiceWCF.ClsUtilisateur[] tabUtil = TableUtilisateur.ToArray();
                try
                {
                    NumUtilisateur = tabUtil[0].Id;
                    Id_Statut = tabUtil[0].Id_Statut;
                    Service = tabUtil[0].Service;

                    switch (Id_Statut)
                    {
                        case 1:
                            rbClient.Checked = true;
                            break;
                        case 2:
                            rbEmploye.Checked = true;
                            break;                        
                    }

                    lbNumUtilisateur.Text = NumUtilisateur.ToString();
                    lbBienvenu.Text = "Bonjour " + tabUtil[0].Prenom;
                }                    
               catch (Exception)
                {
                    MessageBox.Show("Login non reconnu !");
                }                    
            }            
        }

        
        private void chBoxAffMotDePass_CheckedChanged_1(object sender, EventArgs e) // Affichage du mot de passe
        {
            if (chBoxAffMotDePass.Checked == false)
            {
                textBoxMotDePasse.UseSystemPasswordChar = true;
                textBoxMotDePasse.Select();
            }
            else
            {
                textBoxMotDePasse.UseSystemPasswordChar = false;
                textBoxMotDePasse.Select();
            }
        }

        private void textBoxMotDePasse_TextChanged(object sender, EventArgs e) // Mot de passe
        {
        }
        private void textBoxMotDePasse_Validated(object sender, EventArgs e)
        {            
            MotDePasse = textBoxMotDePasse.Text;
        }
       
        private void btValidationConnection_Click(object sender, EventArgs e)  // Connection
        {
            // Cryptage du mot de passe saisie
            /*byte[] bytes = Encoding.UTF8.GetBytes(MotDePasse);
            byte[] protectedBytes = ProtectedData.Protect(bytes, null, DataProtectionScope.CurrentUser);
            MotDePasse = Convert.ToBase64String(protectedBytes);*/

            ConfirmationConnection = sc.Loguer(LoginUtilisateur,MotDePasse);


            if (ConfirmationConnection == true)
            {                
                if (rbClient.Checked == true)
                {
                     FormEspaceClient f = new FormEspaceClient();
                     f.ShowDialog();
                }
                else if (rbEmploye.Checked == true)
                {
                    FormEspaceEmploye f = new FormEspaceEmploye();
                    f.ShowDialog();
                }
                
                btDeconnection.Visible = true;
                btMonEspace.Visible = true;
                textBoxLogin.Select();
            }
            else
            {
                MessageBox.Show("La connection a échouée ! \n     Veuillez entrer votre Login et votre Mot de passe.");
                textBoxLogin.Select();
            }  
        }

        private void btDeconnection_Click(object sender, EventArgs e)
        {
            ConfirmationConnection = false;
            btDeconnection.Visible = false;
            btMonEspace.Visible = false;            
            textBoxMotDePasse.Text = "";
            textBoxLogin.Text = "";
        }
        #endregion

        #region choix statut Utilisateur
        private void rbClient_CheckedChanged(object sender, EventArgs e)
        {
            lbService.Visible = false;
            comboBoxService.Visible = false;
            Id_Statut = 1;
            ValidationCompte[5] = true;
            ValidationCompte[6] = true;
        }

        private void rbFournisseur_CheckedChanged(object sender, EventArgs e)
        {
            lbService.Visible = false;
            comboBoxService.Visible = false;
            Id_Statut = 3;
            ValidationCompte[5] = false;            
            ValidationCompte[6] = true;

        }

        private void rbEmploye_CheckedChanged(object sender, EventArgs e)
        {
            lbService.Visible = true;
            comboBoxService.Visible = true;
            Id_Statut = 2;
            ValidationCompte[5] = true;
            ValidationCompte[6] = false;
            comboBoxService.SelectedIndex = -1;

            // initialisation 
            comboBoxService.Items.Clear();
            Requete_Sql = "select distinct service from utilisateur where id_statut = 2";
            List<ServiceWCF.ClsUtilisateur> TableUtilisateur = new List<ServiceWCF.ClsUtilisateur>();
            TableUtilisateur.AddRange(sc.LireTableUtilisateurSql(Requete_Sql));
            ServiceWCF.ClsUtilisateur[] tabstat = TableUtilisateur.ToArray();
            for (int i = 0; i < tabstat.Length; i++)
                comboBoxService.Items.Add(tabstat[i].Service);
        }
        #endregion

        #region Création d'un Compte utilisateur
        private void btValidationCompte_Click(object sender, EventArgs e)
        {
            Int16 ValCompte = 0;
            //int numUtilisateur = 0;
            string LoginUtilisateur = textBoxChoixLogin.Text;
            string MotDePasse = textBoxChoixMotDePasse.Text;
            string nomUtilisateur = textBoxNom.Text;
            string prenomUtilisateur = textBoxPrenom.Text;
            string mailUtilisateur = textBoxMail.Text;
            string service = comboBoxService.Text;

            switch (Id_Statut)
            {                
                case 2:                    
                    if (service == "") ;                        
                    break;
                case 3:
                    service = "";
                    break;
                default:
                    service = "";
                    break;
            }

            Requete_Sql = "";

            for(Int16 i = 0; i < 7; i++)
            {
                if (ValidationCompte[i] == true)
                    ValCompte++;                    
            }

            if (ValCompte == 7)
            {
                // Cryptage mot de passe
                string cryptmotDePasse;
                /*byte[] bytes = Encoding.UTF8.GetBytes(MotDePasse);
                byte[] protectedBytes = ProtectedData.Protect(bytes, null, DataProtectionScope.CurrentUser);
                cryptmotDePasse = Convert.ToBase64String(protectedBytes);*/
                cryptmotDePasse = MotDePasse;

                Requete_Sql = @"insert into utilisateur values (null,'" + LoginUtilisateur + "', '"
                                                                        + cryptmotDePasse + "', '"
                                                                        + nomUtilisateur + "', '"
                                                                        + prenomUtilisateur + "', '"
                                                                        + mailUtilisateur + "', "
                                                                        + Id_Statut + ", '', '"
                                                                        + service + "')";

                sc.AjoutSupModifUtilisateurSql(Requete_Sql);
                // préparation à la connection du nouvel utilisateur   
                //LoginUtilisateur = loginUtilisateur;
                textBoxLogin.Text = LoginUtilisateur;
                //MotDePasse = cryptmotDePasse;
                textBoxMotDePasse.Text = MotDePasse;
                //lbBienvenu.Text = "Bonjour " + LoginUtilisateur + " ! Votre compte est validé.";
                //lbNumUtilisateur.Text = numUtilisateur.ToString();

                // récupération du n°utilisateur (id)
                Requete_Sql = "select * from utilisateur where login = '" + LoginUtilisateur + "'";
                List<ServiceWCF.ClsUtilisateur> TableUtilisateur = new List<ServiceWCF.ClsUtilisateur>();
                TableUtilisateur.AddRange(sc.LireTableUtilisateurSql(Requete_Sql));
                ServiceWCF.ClsUtilisateur[] tabUtil = TableUtilisateur.ToArray();
                NumUtilisateur = tabUtil[0].Id;
                lbNumUtilisateur.Text = NumUtilisateur.ToString();
                lbBienvenu.Text = "Bonjour " + tabUtil[0].Prenom + ". Votre compte est validé.";
            }            
        }

        private void textBoxChoixLogin_Validated(object sender, EventArgs e)
        {
            string loginUtilisateur = textBoxChoixLogin.Text;
            int nbcar = loginUtilisateur.Length;
            string car = " ";
            if (nbcar > 0)
            {
                ValidationCompte[0] = true;
                if (loginUtilisateur.Contains(car) || nbcar < 4)
                {
                    MessageBox.Show("Votre Login doit contenir au moins 4 caractères et ne doit pas contenir d'espace !");
                    textBoxChoixLogin.Clear();
                    ValidationCompte[0] = false;
                }
            }
        }

        private void chBoxAffChoixMotDePass_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxAffChoixMotDePass.Checked == false)
            {
                textBoxChoixMotDePasse.UseSystemPasswordChar = true;
                textBoxChoixMotDePasse.Select();
            }
            else
            {
                textBoxChoixMotDePasse.UseSystemPasswordChar = false;
                textBoxChoixMotDePasse.Select();
            }
        }
        private void textBoxChoixMotDePasse_Validated_1(object sender, EventArgs e)
        {
            string motDePasse = textBoxChoixMotDePasse.Text;
            int nbcar = motDePasse.Length;
            string car = " ";
            if (nbcar > 0)
            {
                ValidationCompte[1] = true;
                if (motDePasse.Contains(car) || nbcar < 4)
                {
                    MessageBox.Show("Votre mot de passe doit contenir au moins 4 caractères et ne doit pas contenir d'espace !");
                    textBoxChoixMotDePasse.Clear();
                    ValidationCompte[1] = false;
                }
            }
        }

        private void textBoxNom_Validated(object sender, EventArgs e)
        {
            string nomUtilisateur = textBoxNom.Text;
            int nbcar = nomUtilisateur.Length;
            if (nbcar > 0)
                ValidationCompte[2] = true;
            else
            {
                MessageBox.Show("Veuillez entrer votre nom !");
                ValidationCompte[2] = false;
            }
        }

        private void textBoxPrenom_Validated(object sender, EventArgs e)
        {
            string prenomUtilisateur = textBoxPrenom.Text;
            int nbcar = prenomUtilisateur.Length;
            if (nbcar > 0)
                ValidationCompte[3] = true;
            else
            {
                MessageBox.Show("Veuillez entrer votre prénom !");
                ValidationCompte[3] = false;
            }
        }

        private void textBoxMail_Validated(object sender, EventArgs e)
        {
            string mailUtilisateur = textBoxMail.Text;
            int nbcar = mailUtilisateur.Length;
            string car1 = "@";
            string car2 = ".";
            if (nbcar > 0)
            {
                ValidationCompte[4] = true;
                if (!mailUtilisateur.Contains(car1) || !mailUtilisateur.Contains(car2))
                {
                    MessageBox.Show("adresse email non valide !");
                    textBoxChoixLogin.Clear();
                    ValidationCompte[4] = false;
                }
            }
        }

        
        private void comboBoxService_SelectedIndexChanged(object sender, EventArgs e)
        {            
            string service = comboBoxService.Text;
            int nbcar = service.Length;
            if (nbcar > 0 && Id_Statut == 2)
                ValidationCompte[6] = true;
            else           
                ValidationCompte[6] = false;
        

        }
        #endregion

        #region Catalogue
        private void btCatalogueAccueil_Click(object sender, EventArgs e)
        {
            textBoxLogin.Select();
            FormCatalogue f = new FormCatalogue();
            f.ShowDialog();
        }
        #endregion

        #region accés à mon espace
        private void btMonEspace_Click(object sender, EventArgs e)
        {
            if (LoginUtilisateur != "" && MotDePasse != "")
                ConfirmationConnection = true;

            if (ConfirmationConnection == true)
            {
                if (rbClient.Checked == true)
                {
                    FormEspaceClient f = new FormEspaceClient();
                    f.ShowDialog();
                }
                else if (rbEmploye.Checked == true)
                {
                    FormEspaceEmploye f = new FormEspaceEmploye();
                    f.ShowDialog();
                }                
            }
            else
            {
                MessageBox.Show("Veuillez vous connecter !");
                btMonEspace.Visible = false;                
            }
            textBoxLogin.Select();
        }
        #endregion
    }
}
