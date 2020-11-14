namespace GestionDeStock
{
    partial class PageAcceuil
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageAcceuil));
            this.pictureBoxIllustration = new System.Windows.Forms.PictureBox();
            this.lbStockCompagny = new System.Windows.Forms.Label();
            this.grpBoxIdentification = new System.Windows.Forms.GroupBox();
            this.grpBoxCreationCompte = new System.Windows.Forms.GroupBox();
            this.chBoxAffChoixMotDePass = new System.Windows.Forms.CheckBox();
            this.comboBoxService = new System.Windows.Forms.ComboBox();
            this.lbService = new System.Windows.Forms.Label();
            this.rbEmploye = new System.Windows.Forms.RadioButton();
            this.btValidationCompte = new System.Windows.Forms.Button();
            this.lbMail = new System.Windows.Forms.Label();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.lbCreationCompte = new System.Windows.Forms.Label();
            this.rbClient = new System.Windows.Forms.RadioButton();
            this.lbPrenom = new System.Windows.Forms.Label();
            this.textBoxPrenom = new System.Windows.Forms.TextBox();
            this.lbNom = new System.Windows.Forms.Label();
            this.textBoxNom = new System.Windows.Forms.TextBox();
            this.lbChoixMotDePasse = new System.Windows.Forms.Label();
            this.lbChoixLogin = new System.Windows.Forms.Label();
            this.textBoxChoixMotDePasse = new System.Windows.Forms.TextBox();
            this.textBoxChoixLogin = new System.Windows.Forms.TextBox();
            this.grpBoxConnection = new System.Windows.Forms.GroupBox();
            this.chBoxAffMotDePass = new System.Windows.Forms.CheckBox();
            this.btDeconnection = new System.Windows.Forms.Button();
            this.lbBienvenu = new System.Windows.Forms.Label();
            this.lbNumUtilisateur = new System.Windows.Forms.Label();
            this.lbNumUtilisateurLegende = new System.Windows.Forms.Label();
            this.btValidationConnection = new System.Windows.Forms.Button();
            this.lbMotDePasse = new System.Windows.Forms.Label();
            this.lbLogin = new System.Windows.Forms.Label();
            this.textBoxMotDePasse = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.btQuitter = new System.Windows.Forms.Button();
            this.lbWelcome = new System.Windows.Forms.Label();
            this.btCatalogueAccueil = new System.Windows.Forms.Button();
            this.btMonEspace = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIllustration)).BeginInit();
            this.grpBoxIdentification.SuspendLayout();
            this.grpBoxCreationCompte.SuspendLayout();
            this.grpBoxConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxIllustration
            // 
            this.pictureBoxIllustration.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxIllustration.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxIllustration.Enabled = false;
            this.pictureBoxIllustration.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxIllustration.Image")));
            this.pictureBoxIllustration.Location = new System.Drawing.Point(756, 86);
            this.pictureBoxIllustration.Name = "pictureBoxIllustration";
            this.pictureBoxIllustration.Size = new System.Drawing.Size(461, 421);
            this.pictureBoxIllustration.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxIllustration.TabIndex = 1;
            this.pictureBoxIllustration.TabStop = false;
            // 
            // lbStockCompagny
            // 
            this.lbStockCompagny.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStockCompagny.AutoSize = true;
            this.lbStockCompagny.BackColor = System.Drawing.Color.Transparent;
            this.lbStockCompagny.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbStockCompagny.Font = new System.Drawing.Font("Segoe UI", 36F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStockCompagny.ForeColor = System.Drawing.Color.Black;
            this.lbStockCompagny.Location = new System.Drawing.Point(91, 9);
            this.lbStockCompagny.Name = "lbStockCompagny";
            this.lbStockCompagny.Size = new System.Drawing.Size(588, 65);
            this.lbStockCompagny.TabIndex = 2;
            this.lbStockCompagny.Text = "Vladivo Stock Compagny";
            // 
            // grpBoxIdentification
            // 
            this.grpBoxIdentification.BackColor = System.Drawing.Color.Transparent;
            this.grpBoxIdentification.Controls.Add(this.grpBoxCreationCompte);
            this.grpBoxIdentification.Controls.Add(this.grpBoxConnection);
            this.grpBoxIdentification.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxIdentification.ForeColor = System.Drawing.Color.White;
            this.grpBoxIdentification.Location = new System.Drawing.Point(12, 77);
            this.grpBoxIdentification.Name = "grpBoxIdentification";
            this.grpBoxIdentification.Size = new System.Drawing.Size(738, 562);
            this.grpBoxIdentification.TabIndex = 3;
            this.grpBoxIdentification.TabStop = false;
            this.grpBoxIdentification.Text = "Identification";
            // 
            // grpBoxCreationCompte
            // 
            this.grpBoxCreationCompte.Controls.Add(this.chBoxAffChoixMotDePass);
            this.grpBoxCreationCompte.Controls.Add(this.comboBoxService);
            this.grpBoxCreationCompte.Controls.Add(this.lbService);
            this.grpBoxCreationCompte.Controls.Add(this.rbEmploye);
            this.grpBoxCreationCompte.Controls.Add(this.btValidationCompte);
            this.grpBoxCreationCompte.Controls.Add(this.lbMail);
            this.grpBoxCreationCompte.Controls.Add(this.textBoxMail);
            this.grpBoxCreationCompte.Controls.Add(this.lbCreationCompte);
            this.grpBoxCreationCompte.Controls.Add(this.rbClient);
            this.grpBoxCreationCompte.Controls.Add(this.lbPrenom);
            this.grpBoxCreationCompte.Controls.Add(this.textBoxPrenom);
            this.grpBoxCreationCompte.Controls.Add(this.lbNom);
            this.grpBoxCreationCompte.Controls.Add(this.textBoxNom);
            this.grpBoxCreationCompte.Controls.Add(this.lbChoixMotDePasse);
            this.grpBoxCreationCompte.Controls.Add(this.lbChoixLogin);
            this.grpBoxCreationCompte.Controls.Add(this.textBoxChoixMotDePasse);
            this.grpBoxCreationCompte.Controls.Add(this.textBoxChoixLogin);
            this.grpBoxCreationCompte.ForeColor = System.Drawing.Color.White;
            this.grpBoxCreationCompte.Location = new System.Drawing.Point(26, 216);
            this.grpBoxCreationCompte.Name = "grpBoxCreationCompte";
            this.grpBoxCreationCompte.Size = new System.Drawing.Size(688, 319);
            this.grpBoxCreationCompte.TabIndex = 5;
            this.grpBoxCreationCompte.TabStop = false;
            this.grpBoxCreationCompte.Text = "Création d\' un compte";
            // 
            // chBoxAffChoixMotDePass
            // 
            this.chBoxAffChoixMotDePass.AutoSize = true;
            this.chBoxAffChoixMotDePass.Location = new System.Drawing.Point(450, 243);
            this.chBoxAffChoixMotDePass.Name = "chBoxAffChoixMotDePass";
            this.chBoxAffChoixMotDePass.Size = new System.Drawing.Size(83, 25);
            this.chBoxAffChoixMotDePass.TabIndex = 15;
            this.chBoxAffChoixMotDePass.Text = "Afficher";
            this.chBoxAffChoixMotDePass.UseVisualStyleBackColor = true;
            this.chBoxAffChoixMotDePass.CheckedChanged += new System.EventHandler(this.chBoxAffChoixMotDePass_CheckedChanged);
            // 
            // comboBoxService
            // 
            this.comboBoxService.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxService.FormattingEnabled = true;
            this.comboBoxService.Location = new System.Drawing.Point(483, 150);
            this.comboBoxService.Name = "comboBoxService";
            this.comboBoxService.Size = new System.Drawing.Size(187, 29);
            this.comboBoxService.TabIndex = 5;
            this.comboBoxService.Visible = false;
            this.comboBoxService.SelectedIndexChanged += new System.EventHandler(this.comboBoxService_SelectedIndexChanged);
            // 
            // lbService
            // 
            this.lbService.AutoSize = true;
            this.lbService.ForeColor = System.Drawing.Color.Black;
            this.lbService.Location = new System.Drawing.Point(485, 127);
            this.lbService.Name = "lbService";
            this.lbService.Size = new System.Drawing.Size(59, 21);
            this.lbService.TabIndex = 14;
            this.lbService.Text = "Service";
            this.lbService.Visible = false;
            // 
            // rbEmploye
            // 
            this.rbEmploye.AutoSize = true;
            this.rbEmploye.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEmploye.ForeColor = System.Drawing.Color.Black;
            this.rbEmploye.Location = new System.Drawing.Point(339, 67);
            this.rbEmploye.Name = "rbEmploye";
            this.rbEmploye.Size = new System.Drawing.Size(106, 29);
            this.rbEmploye.TabIndex = 2;
            this.rbEmploye.Text = "Employé";
            this.rbEmploye.UseVisualStyleBackColor = true;
            this.rbEmploye.CheckedChanged += new System.EventHandler(this.rbEmploye_CheckedChanged);
            // 
            // btValidationCompte
            // 
            this.btValidationCompte.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btValidationCompte.BackColor = System.Drawing.Color.Transparent;
            this.btValidationCompte.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btValidationCompte.ForeColor = System.Drawing.Color.Black;
            this.btValidationCompte.Location = new System.Drawing.Point(567, 250);
            this.btValidationCompte.Name = "btValidationCompte";
            this.btValidationCompte.Size = new System.Drawing.Size(103, 44);
            this.btValidationCompte.TabIndex = 7;
            this.btValidationCompte.Text = "Valider";
            this.btValidationCompte.UseVisualStyleBackColor = false;
            this.btValidationCompte.Click += new System.EventHandler(this.btValidationCompte_Click);
            // 
            // lbMail
            // 
            this.lbMail.AutoSize = true;
            this.lbMail.ForeColor = System.Drawing.Color.Black;
            this.lbMail.Location = new System.Drawing.Point(22, 184);
            this.lbMail.Name = "lbMail";
            this.lbMail.Size = new System.Drawing.Size(98, 21);
            this.lbMail.TabIndex = 9;
            this.lbMail.Text = "Adresse mail";
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(25, 207);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(293, 29);
            this.textBoxMail.TabIndex = 2;
            this.textBoxMail.Validated += new System.EventHandler(this.textBoxMail_Validated);
            // 
            // lbCreationCompte
            // 
            this.lbCreationCompte.AutoSize = true;
            this.lbCreationCompte.BackColor = System.Drawing.Color.Transparent;
            this.lbCreationCompte.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCreationCompte.ForeColor = System.Drawing.Color.Black;
            this.lbCreationCompte.Location = new System.Drawing.Point(21, 51);
            this.lbCreationCompte.Name = "lbCreationCompte";
            this.lbCreationCompte.Size = new System.Drawing.Size(278, 25);
            this.lbCreationCompte.TabIndex = 6;
            this.lbCreationCompte.Text = "Créer un compte en tant que :";
            // 
            // rbClient
            // 
            this.rbClient.AutoSize = true;
            this.rbClient.Checked = true;
            this.rbClient.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbClient.ForeColor = System.Drawing.Color.Black;
            this.rbClient.Location = new System.Drawing.Point(321, 40);
            this.rbClient.Name = "rbClient";
            this.rbClient.Size = new System.Drawing.Size(81, 29);
            this.rbClient.TabIndex = 0;
            this.rbClient.TabStop = true;
            this.rbClient.Text = "Client";
            this.rbClient.UseVisualStyleBackColor = true;
            this.rbClient.CheckedChanged += new System.EventHandler(this.rbClient_CheckedChanged);
            // 
            // lbPrenom
            // 
            this.lbPrenom.AutoSize = true;
            this.lbPrenom.ForeColor = System.Drawing.Color.Black;
            this.lbPrenom.Location = new System.Drawing.Point(253, 127);
            this.lbPrenom.Name = "lbPrenom";
            this.lbPrenom.Size = new System.Drawing.Size(65, 21);
            this.lbPrenom.TabIndex = 7;
            this.lbPrenom.Text = "Prénom";
            // 
            // textBoxPrenom
            // 
            this.textBoxPrenom.Location = new System.Drawing.Point(256, 150);
            this.textBoxPrenom.Name = "textBoxPrenom";
            this.textBoxPrenom.Size = new System.Drawing.Size(187, 29);
            this.textBoxPrenom.TabIndex = 1;
            this.textBoxPrenom.Validated += new System.EventHandler(this.textBoxPrenom_Validated);
            // 
            // lbNom
            // 
            this.lbNom.AutoSize = true;
            this.lbNom.ForeColor = System.Drawing.Color.Black;
            this.lbNom.Location = new System.Drawing.Point(22, 127);
            this.lbNom.Name = "lbNom";
            this.lbNom.Size = new System.Drawing.Size(45, 21);
            this.lbNom.TabIndex = 5;
            this.lbNom.Text = "Nom";
            // 
            // textBoxNom
            // 
            this.textBoxNom.Location = new System.Drawing.Point(25, 150);
            this.textBoxNom.Name = "textBoxNom";
            this.textBoxNom.Size = new System.Drawing.Size(187, 29);
            this.textBoxNom.TabIndex = 0;
            this.textBoxNom.Validated += new System.EventHandler(this.textBoxNom_Validated);
            // 
            // lbChoixMotDePasse
            // 
            this.lbChoixMotDePasse.AutoSize = true;
            this.lbChoixMotDePasse.ForeColor = System.Drawing.Color.Black;
            this.lbChoixMotDePasse.Location = new System.Drawing.Point(245, 245);
            this.lbChoixMotDePasse.Name = "lbChoixMotDePasse";
            this.lbChoixMotDePasse.Size = new System.Drawing.Size(196, 21);
            this.lbChoixMotDePasse.TabIndex = 3;
            this.lbChoixMotDePasse.Text = "Choisissez un mot de passe";
            // 
            // lbChoixLogin
            // 
            this.lbChoixLogin.AutoSize = true;
            this.lbChoixLogin.ForeColor = System.Drawing.Color.Black;
            this.lbChoixLogin.Location = new System.Drawing.Point(22, 245);
            this.lbChoixLogin.Name = "lbChoixLogin";
            this.lbChoixLogin.Size = new System.Drawing.Size(140, 21);
            this.lbChoixLogin.TabIndex = 2;
            this.lbChoixLogin.Text = "Choisissez un login";
            // 
            // textBoxChoixMotDePasse
            // 
            this.textBoxChoixMotDePasse.Location = new System.Drawing.Point(248, 268);
            this.textBoxChoixMotDePasse.Name = "textBoxChoixMotDePasse";
            this.textBoxChoixMotDePasse.Size = new System.Drawing.Size(285, 29);
            this.textBoxChoixMotDePasse.TabIndex = 4;
            this.textBoxChoixMotDePasse.UseSystemPasswordChar = true;
            this.textBoxChoixMotDePasse.Validated += new System.EventHandler(this.textBoxChoixMotDePasse_Validated_1);
            // 
            // textBoxChoixLogin
            // 
            this.textBoxChoixLogin.Location = new System.Drawing.Point(25, 268);
            this.textBoxChoixLogin.Name = "textBoxChoixLogin";
            this.textBoxChoixLogin.Size = new System.Drawing.Size(187, 29);
            this.textBoxChoixLogin.TabIndex = 3;
            this.textBoxChoixLogin.Validated += new System.EventHandler(this.textBoxChoixLogin_Validated);
            // 
            // grpBoxConnection
            // 
            this.grpBoxConnection.Controls.Add(this.chBoxAffMotDePass);
            this.grpBoxConnection.Controls.Add(this.btDeconnection);
            this.grpBoxConnection.Controls.Add(this.lbBienvenu);
            this.grpBoxConnection.Controls.Add(this.lbNumUtilisateur);
            this.grpBoxConnection.Controls.Add(this.lbNumUtilisateurLegende);
            this.grpBoxConnection.Controls.Add(this.btValidationConnection);
            this.grpBoxConnection.Controls.Add(this.lbMotDePasse);
            this.grpBoxConnection.Controls.Add(this.lbLogin);
            this.grpBoxConnection.Controls.Add(this.textBoxMotDePasse);
            this.grpBoxConnection.Controls.Add(this.textBoxLogin);
            this.grpBoxConnection.ForeColor = System.Drawing.Color.White;
            this.grpBoxConnection.Location = new System.Drawing.Point(137, 41);
            this.grpBoxConnection.Name = "grpBoxConnection";
            this.grpBoxConnection.Size = new System.Drawing.Size(513, 169);
            this.grpBoxConnection.TabIndex = 4;
            this.grpBoxConnection.TabStop = false;
            this.grpBoxConnection.Text = "Connection";
            // 
            // chBoxAffMotDePass
            // 
            this.chBoxAffMotDePass.AutoSize = true;
            this.chBoxAffMotDePass.Location = new System.Drawing.Point(115, 93);
            this.chBoxAffMotDePass.Name = "chBoxAffMotDePass";
            this.chBoxAffMotDePass.Size = new System.Drawing.Size(83, 25);
            this.chBoxAffMotDePass.TabIndex = 22;
            this.chBoxAffMotDePass.Text = "Afficher";
            this.chBoxAffMotDePass.UseVisualStyleBackColor = true;
            this.chBoxAffMotDePass.CheckedChanged += new System.EventHandler(this.chBoxAffMotDePass_CheckedChanged_1);
            // 
            // btDeconnection
            // 
            this.btDeconnection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btDeconnection.BackColor = System.Drawing.Color.Transparent;
            this.btDeconnection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDeconnection.ForeColor = System.Drawing.Color.Black;
            this.btDeconnection.Location = new System.Drawing.Point(351, 111);
            this.btDeconnection.Name = "btDeconnection";
            this.btDeconnection.Size = new System.Drawing.Size(134, 44);
            this.btDeconnection.TabIndex = 21;
            this.btDeconnection.Text = "Se déconnecter";
            this.btDeconnection.UseVisualStyleBackColor = false;
            this.btDeconnection.Visible = false;
            this.btDeconnection.Click += new System.EventHandler(this.btDeconnection_Click);
            // 
            // lbBienvenu
            // 
            this.lbBienvenu.AutoSize = true;
            this.lbBienvenu.ForeColor = System.Drawing.Color.Black;
            this.lbBienvenu.Location = new System.Drawing.Point(86, 22);
            this.lbBienvenu.Name = "lbBienvenu";
            this.lbBienvenu.Size = new System.Drawing.Size(91, 21);
            this.lbBienvenu.TabIndex = 20;
            this.lbBienvenu.Text = "Bienvenue !";
            // 
            // lbNumUtilisateur
            // 
            this.lbNumUtilisateur.AutoSize = true;
            this.lbNumUtilisateur.ForeColor = System.Drawing.Color.Black;
            this.lbNumUtilisateur.Location = new System.Drawing.Point(381, 64);
            this.lbNumUtilisateur.Name = "lbNumUtilisateur";
            this.lbNumUtilisateur.Size = new System.Drawing.Size(37, 21);
            this.lbNumUtilisateur.TabIndex = 19;
            this.lbNumUtilisateur.Text = "000";
            // 
            // lbNumUtilisateurLegende
            // 
            this.lbNumUtilisateurLegende.AutoSize = true;
            this.lbNumUtilisateurLegende.ForeColor = System.Drawing.Color.Black;
            this.lbNumUtilisateurLegende.Location = new System.Drawing.Point(283, 64);
            this.lbNumUtilisateurLegende.Name = "lbNumUtilisateurLegende";
            this.lbNumUtilisateurLegende.Size = new System.Drawing.Size(114, 21);
            this.lbNumUtilisateurLegende.TabIndex = 18;
            this.lbNumUtilisateurLegende.Text = "N° Utilisateur : ";
            // 
            // btValidationConnection
            // 
            this.btValidationConnection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btValidationConnection.BackColor = System.Drawing.Color.Transparent;
            this.btValidationConnection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btValidationConnection.ForeColor = System.Drawing.Color.Black;
            this.btValidationConnection.Location = new System.Drawing.Point(351, 111);
            this.btValidationConnection.Name = "btValidationConnection";
            this.btValidationConnection.Size = new System.Drawing.Size(134, 44);
            this.btValidationConnection.TabIndex = 2;
            this.btValidationConnection.Text = "Se connecter";
            this.btValidationConnection.UseVisualStyleBackColor = false;
            this.btValidationConnection.Click += new System.EventHandler(this.btValidationConnection_Click);
            // 
            // lbMotDePasse
            // 
            this.lbMotDePasse.AutoSize = true;
            this.lbMotDePasse.ForeColor = System.Drawing.Color.Black;
            this.lbMotDePasse.Location = new System.Drawing.Point(18, 94);
            this.lbMotDePasse.Name = "lbMotDePasse";
            this.lbMotDePasse.Size = new System.Drawing.Size(100, 21);
            this.lbMotDePasse.TabIndex = 3;
            this.lbMotDePasse.Text = "Mot de passe";
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.ForeColor = System.Drawing.Color.Black;
            this.lbLogin.Location = new System.Drawing.Point(18, 38);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(48, 21);
            this.lbLogin.TabIndex = 2;
            this.lbLogin.Text = "Login";
            // 
            // textBoxMotDePasse
            // 
            this.textBoxMotDePasse.Location = new System.Drawing.Point(21, 120);
            this.textBoxMotDePasse.Name = "textBoxMotDePasse";
            this.textBoxMotDePasse.Size = new System.Drawing.Size(285, 29);
            this.textBoxMotDePasse.TabIndex = 1;
            this.textBoxMotDePasse.UseSystemPasswordChar = true;
            this.textBoxMotDePasse.TextChanged += new System.EventHandler(this.textBoxMotDePasse_TextChanged);
            this.textBoxMotDePasse.Validated += new System.EventHandler(this.textBoxMotDePasse_Validated);
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(21, 61);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(187, 29);
            this.textBoxLogin.TabIndex = 0;
            this.textBoxLogin.Validated += new System.EventHandler(this.textBoxLogin_Validated);
            // 
            // btQuitter
            // 
            this.btQuitter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btQuitter.BackColor = System.Drawing.Color.Transparent;
            this.btQuitter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btQuitter.Location = new System.Drawing.Point(1115, 599);
            this.btQuitter.Name = "btQuitter";
            this.btQuitter.Size = new System.Drawing.Size(123, 40);
            this.btQuitter.TabIndex = 4;
            this.btQuitter.Text = "Quitter";
            this.btQuitter.UseVisualStyleBackColor = false;
            this.btQuitter.Click += new System.EventHandler(this.btQuitter_Click);
            // 
            // lbWelcome
            // 
            this.lbWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.BackColor = System.Drawing.Color.White;
            this.lbWelcome.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbWelcome.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWelcome.ForeColor = System.Drawing.Color.Black;
            this.lbWelcome.Location = new System.Drawing.Point(909, 498);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(169, 47);
            this.lbWelcome.TabIndex = 5;
            this.lbWelcome.Text = "Welcome !";
            // 
            // btCatalogueAccueil
            // 
            this.btCatalogueAccueil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btCatalogueAccueil.AutoSize = true;
            this.btCatalogueAccueil.BackColor = System.Drawing.Color.Transparent;
            this.btCatalogueAccueil.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCatalogueAccueil.Location = new System.Drawing.Point(785, 554);
            this.btCatalogueAccueil.Name = "btCatalogueAccueil";
            this.btCatalogueAccueil.Size = new System.Drawing.Size(175, 40);
            this.btCatalogueAccueil.TabIndex = 6;
            this.btCatalogueAccueil.Text = "Catalogue";
            this.btCatalogueAccueil.UseVisualStyleBackColor = false;
            this.btCatalogueAccueil.Click += new System.EventHandler(this.btCatalogueAccueil_Click);
            // 
            // btMonEspace
            // 
            this.btMonEspace.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btMonEspace.BackColor = System.Drawing.Color.Transparent;
            this.btMonEspace.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMonEspace.Location = new System.Drawing.Point(857, 602);
            this.btMonEspace.Name = "btMonEspace";
            this.btMonEspace.Size = new System.Drawing.Size(195, 35);
            this.btMonEspace.TabIndex = 8;
            this.btMonEspace.Text = "Accéder à mon espace";
            this.btMonEspace.UseVisualStyleBackColor = false;
            this.btMonEspace.Visible = false;
            this.btMonEspace.Click += new System.EventHandler(this.btMonEspace_Click);
            // 
            // PageAcceuil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1250, 657);
            this.Controls.Add(this.btMonEspace);
            this.Controls.Add(this.btCatalogueAccueil);
            this.Controls.Add(this.lbWelcome);
            this.Controls.Add(this.btQuitter);
            this.Controls.Add(this.grpBoxIdentification);
            this.Controls.Add(this.lbStockCompagny);
            this.Controls.Add(this.pictureBoxIllustration);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PageAcceuil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Page d\'accueil";
            this.Load += new System.EventHandler(this.PageAcceuil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIllustration)).EndInit();
            this.grpBoxIdentification.ResumeLayout(false);
            this.grpBoxCreationCompte.ResumeLayout(false);
            this.grpBoxCreationCompte.PerformLayout();
            this.grpBoxConnection.ResumeLayout(false);
            this.grpBoxConnection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxIllustration;
        private System.Windows.Forms.Label lbStockCompagny;
        private System.Windows.Forms.GroupBox grpBoxIdentification;
        private System.Windows.Forms.RadioButton rbEmploye;
        private System.Windows.Forms.RadioButton rbClient;
        private System.Windows.Forms.Button btQuitter;
        private System.Windows.Forms.Label lbWelcome;
        private System.Windows.Forms.GroupBox grpBoxConnection;
        private System.Windows.Forms.Label lbMotDePasse;
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.TextBox textBoxMotDePasse;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.GroupBox grpBoxCreationCompte;
        private System.Windows.Forms.Label lbMail;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.Label lbCreationCompte;
        private System.Windows.Forms.Label lbPrenom;
        private System.Windows.Forms.TextBox textBoxPrenom;
        private System.Windows.Forms.Label lbNom;
        private System.Windows.Forms.TextBox textBoxNom;
        private System.Windows.Forms.Label lbChoixMotDePasse;
        private System.Windows.Forms.Label lbChoixLogin;
        private System.Windows.Forms.TextBox textBoxChoixMotDePasse;
        private System.Windows.Forms.TextBox textBoxChoixLogin;
        private System.Windows.Forms.ComboBox comboBoxService;
        private System.Windows.Forms.Label lbService;
        private System.Windows.Forms.Button btValidationCompte;
        private System.Windows.Forms.Button btValidationConnection;
        private System.Windows.Forms.Label lbNumUtilisateur;
        private System.Windows.Forms.Label lbNumUtilisateurLegende;
        private System.Windows.Forms.Button btCatalogueAccueil;
        private System.Windows.Forms.Label lbBienvenu;
        private System.Windows.Forms.Button btDeconnection;
        private System.Windows.Forms.Button btMonEspace;
        private System.Windows.Forms.CheckBox chBoxAffChoixMotDePass;
        private System.Windows.Forms.CheckBox chBoxAffMotDePass;
    }
}

