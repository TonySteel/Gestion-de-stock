namespace GestionDeStock
{
    partial class FormCatalogue
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCatalogue));
            this.lbStockCompagny = new System.Windows.Forms.Label();
            this.btCatalogue = new System.Windows.Forms.Button();
            this.dgvCategorie = new System.Windows.Forms.DataGridView();
            this.grpBoxCatagorie = new System.Windows.Forms.GroupBox();
            this.btTouteCategorie = new System.Windows.Forms.Button();
            this.grpBoxArticle = new System.Windows.Forms.GroupBox();
            this.dgvArticle = new System.Windows.Forms.DataGridView();
            this.btPanier = new System.Windows.Forms.Button();
            this.btAjouterCategorie = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorie)).BeginInit();
            this.grpBoxCatagorie.SuspendLayout();
            this.grpBoxArticle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticle)).BeginInit();
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
            this.lbStockCompagny.Font = new System.Drawing.Font("Segoe UI", 27.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStockCompagny.ForeColor = System.Drawing.Color.Black;
            this.lbStockCompagny.Location = new System.Drawing.Point(32, 20);
            this.lbStockCompagny.Name = "lbStockCompagny";
            this.lbStockCompagny.Size = new System.Drawing.Size(455, 50);
            this.lbStockCompagny.TabIndex = 4;
            this.lbStockCompagny.Text = "Vladivo Stock Compagny";
            // 
            // btCatalogue
            // 
            this.btCatalogue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCatalogue.Location = new System.Drawing.Point(1031, 519);
            this.btCatalogue.Name = "btCatalogue";
            this.btCatalogue.Size = new System.Drawing.Size(127, 31);
            this.btCatalogue.TabIndex = 8;
            this.btCatalogue.Text = "Retour";
            this.btCatalogue.UseVisualStyleBackColor = true;
            this.btCatalogue.Click += new System.EventHandler(this.btCatalogue_Click);
            // 
            // dgvCategorie
            // 
            this.dgvCategorie.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCategorie.BackgroundColor = System.Drawing.Color.White;
            this.dgvCategorie.CausesValidation = false;
            this.dgvCategorie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorie.Location = new System.Drawing.Point(15, 25);
            this.dgvCategorie.Name = "dgvCategorie";
            this.dgvCategorie.ReadOnly = true;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvCategorie.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCategorie.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategorie.Size = new System.Drawing.Size(269, 318);
            this.dgvCategorie.TabIndex = 9;
            this.dgvCategorie.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategorie_CellValueChanged);
            this.dgvCategorie.CurrentCellChanged += new System.EventHandler(this.dgvCategorie_CurrentCellChanged);
            // 
            // grpBoxCatagorie
            // 
            this.grpBoxCatagorie.BackColor = System.Drawing.Color.Transparent;
            this.grpBoxCatagorie.Controls.Add(this.btTouteCategorie);
            this.grpBoxCatagorie.Controls.Add(this.dgvCategorie);
            this.grpBoxCatagorie.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxCatagorie.ForeColor = System.Drawing.Color.White;
            this.grpBoxCatagorie.Location = new System.Drawing.Point(40, 89);
            this.grpBoxCatagorie.Name = "grpBoxCatagorie";
            this.grpBoxCatagorie.Size = new System.Drawing.Size(300, 410);
            this.grpBoxCatagorie.TabIndex = 10;
            this.grpBoxCatagorie.TabStop = false;
            this.grpBoxCatagorie.Text = "Catagories";
            // 
            // btTouteCategorie
            // 
            this.btTouteCategorie.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTouteCategorie.ForeColor = System.Drawing.Color.Black;
            this.btTouteCategorie.Location = new System.Drawing.Point(56, 363);
            this.btTouteCategorie.Name = "btTouteCategorie";
            this.btTouteCategorie.Size = new System.Drawing.Size(180, 31);
            this.btTouteCategorie.TabIndex = 18;
            this.btTouteCategorie.Text = "Toutes les catégorie";
            this.btTouteCategorie.UseVisualStyleBackColor = true;
            this.btTouteCategorie.Click += new System.EventHandler(this.btTouteCategorie_Click);
            // 
            // grpBoxArticle
            // 
            this.grpBoxArticle.BackColor = System.Drawing.Color.Transparent;
            this.grpBoxArticle.Controls.Add(this.dgvArticle);
            this.grpBoxArticle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxArticle.ForeColor = System.Drawing.Color.White;
            this.grpBoxArticle.Location = new System.Drawing.Point(360, 89);
            this.grpBoxArticle.Name = "grpBoxArticle";
            this.grpBoxArticle.Size = new System.Drawing.Size(798, 410);
            this.grpBoxArticle.TabIndex = 11;
            this.grpBoxArticle.TabStop = false;
            this.grpBoxArticle.Text = "Articles";
            // 
            // dgvArticle
            // 
            this.dgvArticle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvArticle.BackgroundColor = System.Drawing.Color.White;
            this.dgvArticle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticle.Location = new System.Drawing.Point(15, 25);
            this.dgvArticle.MultiSelect = false;
            this.dgvArticle.Name = "dgvArticle";
            this.dgvArticle.ReadOnly = true;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.dgvArticle.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvArticle.Size = new System.Drawing.Size(765, 369);
            this.dgvArticle.TabIndex = 9;
            // 
            // btPanier
            // 
            this.btPanier.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPanier.Location = new System.Drawing.Point(733, 34);
            this.btPanier.Name = "btPanier";
            this.btPanier.Size = new System.Drawing.Size(213, 31);
            this.btPanier.TabIndex = 10;
            this.btPanier.Text = "Ajouter au panier";
            this.btPanier.UseVisualStyleBackColor = true;
            this.btPanier.Click += new System.EventHandler(this.btPanier_Click);
            // 
            // btAjouterCategorie
            // 
            this.btAjouterCategorie.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAjouterCategorie.Location = new System.Drawing.Point(96, 517);
            this.btAjouterCategorie.Name = "btAjouterCategorie";
            this.btAjouterCategorie.Size = new System.Drawing.Size(180, 31);
            this.btAjouterCategorie.TabIndex = 17;
            this.btAjouterCategorie.Text = "Ajouter une catégorie";
            this.btAjouterCategorie.UseVisualStyleBackColor = true;
            this.btAjouterCategorie.Visible = false;
            this.btAjouterCategorie.Click += new System.EventHandler(this.btAjouterCategorie_Click);
            // 
            // FormCatalogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1184, 562);
            this.Controls.Add(this.btAjouterCategorie);
            this.Controls.Add(this.btPanier);
            this.Controls.Add(this.grpBoxArticle);
            this.Controls.Add(this.grpBoxCatagorie);
            this.Controls.Add(this.btCatalogue);
            this.Controls.Add(this.lbStockCompagny);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCatalogue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catalogue";
            this.Load += new System.EventHandler(this.FormCatalogue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorie)).EndInit();
            this.grpBoxCatagorie.ResumeLayout(false);
            this.grpBoxArticle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbStockCompagny;
        private System.Windows.Forms.Button btCatalogue;
        private System.Windows.Forms.DataGridView dgvCategorie;
        private System.Windows.Forms.GroupBox grpBoxCatagorie;
        private System.Windows.Forms.GroupBox grpBoxArticle;
        private System.Windows.Forms.Button btPanier;
        private System.Windows.Forms.DataGridView dgvArticle;
        private System.Windows.Forms.Button btAjouterCategorie;
        private System.Windows.Forms.Button btTouteCategorie;
    }
}