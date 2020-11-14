namespace GestionDeStock
{
    partial class FormEspaceClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEspaceClient));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbStockCompagny = new System.Windows.Forms.Label();
            this.btRetourAccueil = new System.Windows.Forms.Button();
            this.grpBoxInfoClient = new System.Windows.Forms.GroupBox();
            this.chBoxModifMotDePass = new System.Windows.Forms.CheckBox();
            this.dgvInfoClient = new System.Windows.Forms.DataGridView();
            this.grpBoxCmdClient = new System.Windows.Forms.GroupBox();
            this.tabCtrlClient = new System.Windows.Forms.TabControl();
            this.tabPagePanier = new System.Windows.Forms.TabPage();
            this.btSupprimerArticle = new System.Windows.Forms.Button();
            this.grpBoxCalculPrixPanier = new System.Windows.Forms.GroupBox();
            this.lbSommePanier = new System.Windows.Forms.Label();
            this.lbDevisePanier = new System.Windows.Forms.Label();
            this.lbPrixTotalPanier = new System.Windows.Forms.Label();
            this.btValiderPanier = new System.Windows.Forms.Button();
            this.dgvPanier = new System.Windows.Forms.DataGridView();
            this.tabPageCommande = new System.Windows.Forms.TabPage();
            this.dgvCmdClient = new System.Windows.Forms.DataGridView();
            this.grpBoxHistoriqueCmd = new System.Windows.Forms.GroupBox();
            this.btCmdAttente = new System.Windows.Forms.Button();
            this.grpBoxCalculPrixCmd = new System.Windows.Forms.GroupBox();
            this.lbSommeCmd = new System.Windows.Forms.Label();
            this.lbDeviseCmd = new System.Windows.Forms.Label();
            this.lbPrixTotalCmd = new System.Windows.Forms.Label();
            this.rdEntreDate = new System.Windows.Forms.RadioButton();
            this.rbApresDate = new System.Windows.Forms.RadioButton();
            this.rbAvantDate = new System.Windows.Forms.RadioButton();
            this.dateCmdApres = new System.Windows.Forms.DateTimePicker();
            this.dateCmdAvant = new System.Windows.Forms.DateTimePicker();
            this.btCatalogue = new System.Windows.Forms.Button();
            this.grpBoxInfoClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfoClient)).BeginInit();
            this.grpBoxCmdClient.SuspendLayout();
            this.tabCtrlClient.SuspendLayout();
            this.tabPagePanier.SuspendLayout();
            this.grpBoxCalculPrixPanier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPanier)).BeginInit();
            this.tabPageCommande.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCmdClient)).BeginInit();
            this.grpBoxHistoriqueCmd.SuspendLayout();
            this.grpBoxCalculPrixCmd.SuspendLayout();
            this.SuspendLayout();
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
            this.lbStockCompagny.Location = new System.Drawing.Point(64, 40);
            this.lbStockCompagny.Name = "lbStockCompagny";
            this.lbStockCompagny.Size = new System.Drawing.Size(588, 65);
            this.lbStockCompagny.TabIndex = 3;
            this.lbStockCompagny.Text = "Vladivo Stock Compagny";
            // 
            // btRetourAccueil
            // 
            this.btRetourAccueil.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRetourAccueil.Location = new System.Drawing.Point(1179, 588);
            this.btRetourAccueil.Name = "btRetourAccueil";
            this.btRetourAccueil.Size = new System.Drawing.Size(136, 37);
            this.btRetourAccueil.TabIndex = 4;
            this.btRetourAccueil.Text = "Retour à l\'accueil";
            this.btRetourAccueil.UseVisualStyleBackColor = true;
            this.btRetourAccueil.Click += new System.EventHandler(this.btRetourAccueil_Click);
            // 
            // grpBoxInfoClient
            // 
            this.grpBoxInfoClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxInfoClient.BackColor = System.Drawing.Color.Transparent;
            this.grpBoxInfoClient.Controls.Add(this.chBoxModifMotDePass);
            this.grpBoxInfoClient.Controls.Add(this.dgvInfoClient);
            this.grpBoxInfoClient.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxInfoClient.ForeColor = System.Drawing.Color.White;
            this.grpBoxInfoClient.Location = new System.Drawing.Point(658, 12);
            this.grpBoxInfoClient.Name = "grpBoxInfoClient";
            this.grpBoxInfoClient.Size = new System.Drawing.Size(639, 144);
            this.grpBoxInfoClient.TabIndex = 5;
            this.grpBoxInfoClient.TabStop = false;
            this.grpBoxInfoClient.Text = "Info compte client";
            // 
            // chBoxModifMotDePass
            // 
            this.chBoxModifMotDePass.AutoSize = true;
            this.chBoxModifMotDePass.Location = new System.Drawing.Point(397, 113);
            this.chBoxModifMotDePass.Name = "chBoxModifMotDePass";
            this.chBoxModifMotDePass.Size = new System.Drawing.Size(222, 25);
            this.chBoxModifMotDePass.TabIndex = 2;
            this.chBoxModifMotDePass.Text = "Modifier votre mot de passe";
            this.chBoxModifMotDePass.UseVisualStyleBackColor = true;
            this.chBoxModifMotDePass.CheckedChanged += new System.EventHandler(this.chBoxModifMotDePass_CheckedChanged);
            // 
            // dgvInfoClient
            // 
            this.dgvInfoClient.AllowUserToAddRows = false;
            this.dgvInfoClient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvInfoClient.BackgroundColor = System.Drawing.Color.White;
            this.dgvInfoClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfoClient.Location = new System.Drawing.Point(22, 25);
            this.dgvInfoClient.Name = "dgvInfoClient";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvInfoClient.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInfoClient.Size = new System.Drawing.Size(599, 82);
            this.dgvInfoClient.TabIndex = 0;
            this.dgvInfoClient.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInfoClient_CellValueChanged);
            // 
            // grpBoxCmdClient
            // 
            this.grpBoxCmdClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxCmdClient.BackColor = System.Drawing.Color.Transparent;
            this.grpBoxCmdClient.Controls.Add(this.tabCtrlClient);
            this.grpBoxCmdClient.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxCmdClient.ForeColor = System.Drawing.Color.White;
            this.grpBoxCmdClient.Location = new System.Drawing.Point(48, 162);
            this.grpBoxCmdClient.Name = "grpBoxCmdClient";
            this.grpBoxCmdClient.Size = new System.Drawing.Size(1249, 410);
            this.grpBoxCmdClient.TabIndex = 6;
            this.grpBoxCmdClient.TabStop = false;
            this.grpBoxCmdClient.Text = "Commande";
            // 
            // tabCtrlClient
            // 
            this.tabCtrlClient.Controls.Add(this.tabPagePanier);
            this.tabCtrlClient.Controls.Add(this.tabPageCommande);
            this.tabCtrlClient.Location = new System.Drawing.Point(20, 26);
            this.tabCtrlClient.Name = "tabCtrlClient";
            this.tabCtrlClient.SelectedIndex = 0;
            this.tabCtrlClient.Size = new System.Drawing.Size(1209, 366);
            this.tabCtrlClient.TabIndex = 1;
            // 
            // tabPagePanier
            // 
            this.tabPagePanier.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPagePanier.BackgroundImage")));
            this.tabPagePanier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPagePanier.Controls.Add(this.btSupprimerArticle);
            this.tabPagePanier.Controls.Add(this.grpBoxCalculPrixPanier);
            this.tabPagePanier.Controls.Add(this.btValiderPanier);
            this.tabPagePanier.Controls.Add(this.dgvPanier);
            this.tabPagePanier.ImageKey = "(aucun)";
            this.tabPagePanier.Location = new System.Drawing.Point(4, 30);
            this.tabPagePanier.Name = "tabPagePanier";
            this.tabPagePanier.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePanier.Size = new System.Drawing.Size(1201, 332);
            this.tabPagePanier.TabIndex = 0;
            this.tabPagePanier.Text = "Panier";
            this.tabPagePanier.UseVisualStyleBackColor = true;
            // 
            // btSupprimerArticle
            // 
            this.btSupprimerArticle.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.btSupprimerArticle.ForeColor = System.Drawing.Color.Black;
            this.btSupprimerArticle.Location = new System.Drawing.Point(743, 142);
            this.btSupprimerArticle.Name = "btSupprimerArticle";
            this.btSupprimerArticle.Size = new System.Drawing.Size(175, 40);
            this.btSupprimerArticle.TabIndex = 7;
            this.btSupprimerArticle.Text = "Supprimer un article";
            this.btSupprimerArticle.UseVisualStyleBackColor = true;
            this.btSupprimerArticle.Click += new System.EventHandler(this.btSupprimerArticle_Click);
            // 
            // grpBoxCalculPrixPanier
            // 
            this.grpBoxCalculPrixPanier.Controls.Add(this.lbSommePanier);
            this.grpBoxCalculPrixPanier.Controls.Add(this.lbDevisePanier);
            this.grpBoxCalculPrixPanier.Controls.Add(this.lbPrixTotalPanier);
            this.grpBoxCalculPrixPanier.ForeColor = System.Drawing.Color.White;
            this.grpBoxCalculPrixPanier.Location = new System.Drawing.Point(967, 76);
            this.grpBoxCalculPrixPanier.Name = "grpBoxCalculPrixPanier";
            this.grpBoxCalculPrixPanier.Size = new System.Drawing.Size(208, 64);
            this.grpBoxCalculPrixPanier.TabIndex = 6;
            this.grpBoxCalculPrixPanier.TabStop = false;
            this.grpBoxCalculPrixPanier.Text = "Total";
            // 
            // lbSommePanier
            // 
            this.lbSommePanier.AutoSize = true;
            this.lbSommePanier.Location = new System.Drawing.Point(102, 26);
            this.lbSommePanier.Name = "lbSommePanier";
            this.lbSommePanier.Size = new System.Drawing.Size(40, 21);
            this.lbSommePanier.TabIndex = 2;
            this.lbSommePanier.Text = "0,00";
            this.lbSommePanier.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbDevisePanier
            // 
            this.lbDevisePanier.AutoSize = true;
            this.lbDevisePanier.Location = new System.Drawing.Point(169, 26);
            this.lbDevisePanier.Name = "lbDevisePanier";
            this.lbDevisePanier.Size = new System.Drawing.Size(19, 21);
            this.lbDevisePanier.TabIndex = 1;
            this.lbDevisePanier.Text = "€";
            // 
            // lbPrixTotalPanier
            // 
            this.lbPrixTotalPanier.AutoSize = true;
            this.lbPrixTotalPanier.Location = new System.Drawing.Point(18, 26);
            this.lbPrixTotalPanier.Name = "lbPrixTotalPanier";
            this.lbPrixTotalPanier.Size = new System.Drawing.Size(79, 21);
            this.lbPrixTotalPanier.TabIndex = 0;
            this.lbPrixTotalPanier.Text = "Prix total :";
            // 
            // btValiderPanier
            // 
            this.btValiderPanier.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btValiderPanier.ForeColor = System.Drawing.Color.Black;
            this.btValiderPanier.Location = new System.Drawing.Point(967, 189);
            this.btValiderPanier.Name = "btValiderPanier";
            this.btValiderPanier.Size = new System.Drawing.Size(208, 37);
            this.btValiderPanier.TabIndex = 5;
            this.btValiderPanier.Text = "Valider la commande";
            this.btValiderPanier.UseVisualStyleBackColor = true;
            this.btValiderPanier.Click += new System.EventHandler(this.btValiderPanier_Click);
            // 
            // dgvPanier
            // 
            this.dgvPanier.AllowUserToAddRows = false;
            this.dgvPanier.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPanier.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPanier.BackgroundColor = System.Drawing.Color.White;
            this.dgvPanier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPanier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPanier.Location = new System.Drawing.Point(36, 28);
            this.dgvPanier.Name = "dgvPanier";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.dgvPanier.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPanier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPanier.Size = new System.Drawing.Size(665, 242);
            this.dgvPanier.TabIndex = 0;
            this.dgvPanier.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPanier_CellValueChanged);
            // 
            // tabPageCommande
            // 
            this.tabPageCommande.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPageCommande.BackgroundImage")));
            this.tabPageCommande.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPageCommande.Controls.Add(this.dgvCmdClient);
            this.tabPageCommande.Controls.Add(this.grpBoxHistoriqueCmd);
            this.tabPageCommande.Location = new System.Drawing.Point(4, 30);
            this.tabPageCommande.Name = "tabPageCommande";
            this.tabPageCommande.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCommande.Size = new System.Drawing.Size(1201, 332);
            this.tabPageCommande.TabIndex = 1;
            this.tabPageCommande.Text = "Commande";
            this.tabPageCommande.UseVisualStyleBackColor = true;
            this.tabPageCommande.Click += new System.EventHandler(this.tabPageCommande_Click);
            // 
            // dgvCmdClient
            // 
            this.dgvCmdClient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCmdClient.BackgroundColor = System.Drawing.Color.White;
            this.dgvCmdClient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCmdClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCmdClient.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCmdClient.Location = new System.Drawing.Point(377, 30);
            this.dgvCmdClient.Name = "dgvCmdClient";
            this.dgvCmdClient.Size = new System.Drawing.Size(804, 227);
            this.dgvCmdClient.TabIndex = 13;
            // 
            // grpBoxHistoriqueCmd
            // 
            this.grpBoxHistoriqueCmd.BackColor = System.Drawing.Color.Transparent;
            this.grpBoxHistoriqueCmd.Controls.Add(this.btCmdAttente);
            this.grpBoxHistoriqueCmd.Controls.Add(this.grpBoxCalculPrixCmd);
            this.grpBoxHistoriqueCmd.Controls.Add(this.rdEntreDate);
            this.grpBoxHistoriqueCmd.Controls.Add(this.rbApresDate);
            this.grpBoxHistoriqueCmd.Controls.Add(this.rbAvantDate);
            this.grpBoxHistoriqueCmd.Controls.Add(this.dateCmdApres);
            this.grpBoxHistoriqueCmd.Controls.Add(this.dateCmdAvant);
            this.grpBoxHistoriqueCmd.ForeColor = System.Drawing.Color.White;
            this.grpBoxHistoriqueCmd.Location = new System.Drawing.Point(26, 18);
            this.grpBoxHistoriqueCmd.Name = "grpBoxHistoriqueCmd";
            this.grpBoxHistoriqueCmd.Size = new System.Drawing.Size(326, 239);
            this.grpBoxHistoriqueCmd.TabIndex = 12;
            this.grpBoxHistoriqueCmd.TabStop = false;
            this.grpBoxHistoriqueCmd.Text = "Historique";
            // 
            // btCmdAttente
            // 
            this.btCmdAttente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCmdAttente.ForeColor = System.Drawing.Color.Black;
            this.btCmdAttente.Location = new System.Drawing.Point(41, 122);
            this.btCmdAttente.Name = "btCmdAttente";
            this.btCmdAttente.Size = new System.Drawing.Size(248, 34);
            this.btCmdAttente.TabIndex = 16;
            this.btCmdAttente.Text = "Commande en attente de livraison";
            this.btCmdAttente.UseVisualStyleBackColor = true;
            this.btCmdAttente.Click += new System.EventHandler(this.btCmdAttente_Click);
            // 
            // grpBoxCalculPrixCmd
            // 
            this.grpBoxCalculPrixCmd.Controls.Add(this.lbSommeCmd);
            this.grpBoxCalculPrixCmd.Controls.Add(this.lbDeviseCmd);
            this.grpBoxCalculPrixCmd.Controls.Add(this.lbPrixTotalCmd);
            this.grpBoxCalculPrixCmd.ForeColor = System.Drawing.Color.White;
            this.grpBoxCalculPrixCmd.Location = new System.Drawing.Point(67, 160);
            this.grpBoxCalculPrixCmd.Name = "grpBoxCalculPrixCmd";
            this.grpBoxCalculPrixCmd.Size = new System.Drawing.Size(193, 64);
            this.grpBoxCalculPrixCmd.TabIndex = 15;
            this.grpBoxCalculPrixCmd.TabStop = false;
            this.grpBoxCalculPrixCmd.Text = "Total";
            // 
            // lbSommeCmd
            // 
            this.lbSommeCmd.AutoSize = true;
            this.lbSommeCmd.Location = new System.Drawing.Point(101, 26);
            this.lbSommeCmd.Name = "lbSommeCmd";
            this.lbSommeCmd.Size = new System.Drawing.Size(40, 21);
            this.lbSommeCmd.TabIndex = 2;
            this.lbSommeCmd.Text = "0,00";
            this.lbSommeCmd.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbDeviseCmd
            // 
            this.lbDeviseCmd.AutoSize = true;
            this.lbDeviseCmd.Location = new System.Drawing.Point(168, 26);
            this.lbDeviseCmd.Name = "lbDeviseCmd";
            this.lbDeviseCmd.Size = new System.Drawing.Size(19, 21);
            this.lbDeviseCmd.TabIndex = 1;
            this.lbDeviseCmd.Text = "€";
            // 
            // lbPrixTotalCmd
            // 
            this.lbPrixTotalCmd.AutoSize = true;
            this.lbPrixTotalCmd.Location = new System.Drawing.Point(18, 26);
            this.lbPrixTotalCmd.Name = "lbPrixTotalCmd";
            this.lbPrixTotalCmd.Size = new System.Drawing.Size(79, 21);
            this.lbPrixTotalCmd.TabIndex = 0;
            this.lbPrixTotalCmd.Text = "Prix total :";
            // 
            // rdEntreDate
            // 
            this.rdEntreDate.AutoSize = true;
            this.rdEntreDate.ForeColor = System.Drawing.Color.White;
            this.rdEntreDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdEntreDate.Location = new System.Drawing.Point(42, 57);
            this.rdEntreDate.Name = "rdEntreDate";
            this.rdEntreDate.Size = new System.Drawing.Size(139, 25);
            this.rdEntreDate.TabIndex = 14;
            this.rdEntreDate.Text = "entre le ... et le ...";
            this.rdEntreDate.UseVisualStyleBackColor = true;
            this.rdEntreDate.CheckedChanged += new System.EventHandler(this.rdEntreDate_CheckedChanged);
            // 
            // rbApresDate
            // 
            this.rbApresDate.AutoSize = true;
            this.rbApresDate.Checked = true;
            this.rbApresDate.ForeColor = System.Drawing.Color.White;
            this.rbApresDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbApresDate.Location = new System.Drawing.Point(41, 89);
            this.rbApresDate.Name = "rbApresDate";
            this.rbApresDate.Size = new System.Drawing.Size(89, 25);
            this.rbApresDate.TabIndex = 13;
            this.rbApresDate.TabStop = true;
            this.rbApresDate.Text = "aprés le .";
            this.rbApresDate.UseVisualStyleBackColor = true;
            this.rbApresDate.CheckedChanged += new System.EventHandler(this.rbApresDate_CheckedChanged);
            // 
            // rbAvantDate
            // 
            this.rbAvantDate.AutoSize = true;
            this.rbAvantDate.ForeColor = System.Drawing.Color.White;
            this.rbAvantDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbAvantDate.Location = new System.Drawing.Point(42, 25);
            this.rbAvantDate.Name = "rbAvantDate";
            this.rbAvantDate.Size = new System.Drawing.Size(91, 25);
            this.rbAvantDate.TabIndex = 12;
            this.rbAvantDate.Text = "avant le .";
            this.rbAvantDate.UseVisualStyleBackColor = true;
            this.rbAvantDate.CheckedChanged += new System.EventHandler(this.rbAvantDate_CheckedChanged);
            // 
            // dateCmdApres
            // 
            this.dateCmdApres.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateCmdApres.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateCmdApres.Location = new System.Drawing.Point(175, 85);
            this.dateCmdApres.Name = "dateCmdApres";
            this.dateCmdApres.Size = new System.Drawing.Size(114, 29);
            this.dateCmdApres.TabIndex = 11;
            this.dateCmdApres.ValueChanged += new System.EventHandler(this.dateCmdApres_ValueChanged);
            // 
            // dateCmdAvant
            // 
            this.dateCmdAvant.CalendarFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateCmdAvant.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateCmdAvant.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateCmdAvant.Location = new System.Drawing.Point(175, 25);
            this.dateCmdAvant.Name = "dateCmdAvant";
            this.dateCmdAvant.Size = new System.Drawing.Size(114, 29);
            this.dateCmdAvant.TabIndex = 10;
            this.dateCmdAvant.Value = new System.DateTime(2018, 11, 9, 20, 35, 33, 0);
            this.dateCmdAvant.Visible = false;
            this.dateCmdAvant.ValueChanged += new System.EventHandler(this.dateCmdAvant_ValueChanged);
            // 
            // btCatalogue
            // 
            this.btCatalogue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCatalogue.Location = new System.Drawing.Point(590, 583);
            this.btCatalogue.Name = "btCatalogue";
            this.btCatalogue.Size = new System.Drawing.Size(183, 47);
            this.btCatalogue.TabIndex = 7;
            this.btCatalogue.Text = "Catalogue";
            this.btCatalogue.UseVisualStyleBackColor = true;
            this.btCatalogue.Click += new System.EventHandler(this.btCatalogue_Click);
            // 
            // FormEspaceClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1327, 637);
            this.Controls.Add(this.btCatalogue);
            this.Controls.Add(this.grpBoxCmdClient);
            this.Controls.Add(this.grpBoxInfoClient);
            this.Controls.Add(this.btRetourAccueil);
            this.Controls.Add(this.lbStockCompagny);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEspaceClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Espace client";
            this.Load += new System.EventHandler(this.FormEspaceClient_Load);
            this.grpBoxInfoClient.ResumeLayout(false);
            this.grpBoxInfoClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfoClient)).EndInit();
            this.grpBoxCmdClient.ResumeLayout(false);
            this.tabCtrlClient.ResumeLayout(false);
            this.tabPagePanier.ResumeLayout(false);
            this.grpBoxCalculPrixPanier.ResumeLayout(false);
            this.grpBoxCalculPrixPanier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPanier)).EndInit();
            this.tabPageCommande.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCmdClient)).EndInit();
            this.grpBoxHistoriqueCmd.ResumeLayout(false);
            this.grpBoxHistoriqueCmd.PerformLayout();
            this.grpBoxCalculPrixCmd.ResumeLayout(false);
            this.grpBoxCalculPrixCmd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbStockCompagny;
        private System.Windows.Forms.Button btRetourAccueil;
        private System.Windows.Forms.GroupBox grpBoxInfoClient;
        private System.Windows.Forms.DataGridView dgvInfoClient;
        private System.Windows.Forms.GroupBox grpBoxCmdClient;
        private System.Windows.Forms.DataGridView dgvPanier;
        private System.Windows.Forms.Button btCatalogue;
        private System.Windows.Forms.TabControl tabCtrlClient;
        private System.Windows.Forms.TabPage tabPagePanier;
        private System.Windows.Forms.TabPage tabPageCommande;
        private System.Windows.Forms.Button btValiderPanier;
        private System.Windows.Forms.GroupBox grpBoxCalculPrixPanier;
        private System.Windows.Forms.Label lbSommePanier;
        private System.Windows.Forms.Label lbDevisePanier;
        private System.Windows.Forms.Label lbPrixTotalPanier;
        private System.Windows.Forms.GroupBox grpBoxHistoriqueCmd;
        private System.Windows.Forms.RadioButton rdEntreDate;
        private System.Windows.Forms.RadioButton rbApresDate;
        private System.Windows.Forms.RadioButton rbAvantDate;
        private System.Windows.Forms.DateTimePicker dateCmdApres;
        private System.Windows.Forms.DateTimePicker dateCmdAvant;
        private System.Windows.Forms.CheckBox chBoxModifMotDePass;
        private System.Windows.Forms.Button btSupprimerArticle;
        private System.Windows.Forms.DataGridView dgvCmdClient;
        private System.Windows.Forms.GroupBox grpBoxCalculPrixCmd;
        private System.Windows.Forms.Label lbSommeCmd;
        private System.Windows.Forms.Label lbDeviseCmd;
        private System.Windows.Forms.Label lbPrixTotalCmd;
        private System.Windows.Forms.Button btCmdAttente;
    }
}