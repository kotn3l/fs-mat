namespace fs_mat
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cB_allmat = new System.Windows.Forms.ComboBox();
            this.cB_matCategory = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dGV_Params = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dGV_Samplers = new System.Windows.Forms.DataGridView();
            this.l_shaderPath = new System.Windows.Forms.Label();
            this.tb_ShaderPath = new System.Windows.Forms.TextBox();
            this.b_Save = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.loadmatbinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreFromBackupFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromDefaultLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.createBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.withDefaultFilenamelocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.b_ResetMat = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Params)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Samplers)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cB_allmat
            // 
            this.cB_allmat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_allmat.FormattingEnabled = true;
            this.cB_allmat.Location = new System.Drawing.Point(12, 59);
            this.cB_allmat.Name = "cB_allmat";
            this.cB_allmat.Size = new System.Drawing.Size(698, 23);
            this.cB_allmat.TabIndex = 0;
            this.cB_allmat.SelectedIndexChanged += new System.EventHandler(this.cB_allmat_SelectedIndexChanged);
            // 
            // cB_matCategory
            // 
            this.cB_matCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_matCategory.FormattingEnabled = true;
            this.cB_matCategory.Location = new System.Drawing.Point(12, 30);
            this.cB_matCategory.Name = "cB_matCategory";
            this.cB_matCategory.Size = new System.Drawing.Size(121, 23);
            this.cB_matCategory.TabIndex = 2;
            this.cB_matCategory.SelectedIndexChanged += new System.EventHandler(this.cB_matCategory_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 114);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(816, 464);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dGV_Params);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(808, 436);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Params";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dGV_Params
            // 
            this.dGV_Params.AllowUserToAddRows = false;
            this.dGV_Params.AllowUserToDeleteRows = false;
            this.dGV_Params.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_Params.Location = new System.Drawing.Point(6, 6);
            this.dGV_Params.MultiSelect = false;
            this.dGV_Params.Name = "dGV_Params";
            this.dGV_Params.RowTemplate.Height = 25;
            this.dGV_Params.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGV_Params.Size = new System.Drawing.Size(796, 424);
            this.dGV_Params.TabIndex = 0;
            this.dGV_Params.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_Params_CellClick);
            this.dGV_Params.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_Params_CellValueChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dGV_Samplers);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(808, 436);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Samplers";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dGV_Samplers
            // 
            this.dGV_Samplers.AllowUserToAddRows = false;
            this.dGV_Samplers.AllowUserToDeleteRows = false;
            this.dGV_Samplers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_Samplers.Location = new System.Drawing.Point(6, 6);
            this.dGV_Samplers.MultiSelect = false;
            this.dGV_Samplers.Name = "dGV_Samplers";
            this.dGV_Samplers.RowTemplate.Height = 25;
            this.dGV_Samplers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGV_Samplers.Size = new System.Drawing.Size(796, 436);
            this.dGV_Samplers.TabIndex = 0;
            this.dGV_Samplers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_Samplers_CellClick);
            this.dGV_Samplers.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_Samplers_CellValueChanged);
            // 
            // l_shaderPath
            // 
            this.l_shaderPath.AutoSize = true;
            this.l_shaderPath.Location = new System.Drawing.Point(12, 91);
            this.l_shaderPath.Name = "l_shaderPath";
            this.l_shaderPath.Size = new System.Drawing.Size(73, 15);
            this.l_shaderPath.TabIndex = 5;
            this.l_shaderPath.Text = "Shader path:";
            // 
            // tb_ShaderPath
            // 
            this.tb_ShaderPath.Enabled = false;
            this.tb_ShaderPath.Location = new System.Drawing.Point(91, 88);
            this.tb_ShaderPath.Name = "tb_ShaderPath";
            this.tb_ShaderPath.Size = new System.Drawing.Size(619, 23);
            this.tb_ShaderPath.TabIndex = 6;
            // 
            // b_Save
            // 
            this.b_Save.Location = new System.Drawing.Point(716, 59);
            this.b_Save.Name = "b_Save";
            this.b_Save.Size = new System.Drawing.Size(112, 23);
            this.b_Save.TabIndex = 7;
            this.b_Save.Text = "Save Material";
            this.b_Save.UseVisualStyleBackColor = true;
            this.b_Save.Click += new System.EventHandler(this.b_Save_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(838, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "text";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadmatbinToolStripMenuItem,
            this.restoreFromBackupFileToolStripMenuItem,
            this.createBackupToolStripMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // loadmatbinToolStripMenuItem
            // 
            this.loadmatbinToolStripMenuItem.Name = "loadmatbinToolStripMenuItem";
            this.loadmatbinToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.loadmatbinToolStripMenuItem.Text = "Load allmaterial.matbinbnd.dcx...";
            this.loadmatbinToolStripMenuItem.Click += new System.EventHandler(this.loadmatbinToolStripMenuItem_Click);
            // 
            // restoreFromBackupFileToolStripMenuItem
            // 
            this.restoreFromBackupFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromDefaultLocationToolStripMenuItem,
            this.browseToolStripMenuItem1});
            this.restoreFromBackupFileToolStripMenuItem.Name = "restoreFromBackupFileToolStripMenuItem";
            this.restoreFromBackupFileToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.restoreFromBackupFileToolStripMenuItem.Text = "Restore backup file";
            // 
            // fromDefaultLocationToolStripMenuItem
            // 
            this.fromDefaultLocationToolStripMenuItem.Name = "fromDefaultLocationToolStripMenuItem";
            this.fromDefaultLocationToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.fromDefaultLocationToolStripMenuItem.Text = "from default location";
            this.fromDefaultLocationToolStripMenuItem.Click += new System.EventHandler(this.fromDefaultLocationToolStripMenuItem_Click);
            // 
            // browseToolStripMenuItem1
            // 
            this.browseToolStripMenuItem1.Enabled = false;
            this.browseToolStripMenuItem1.Name = "browseToolStripMenuItem1";
            this.browseToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.browseToolStripMenuItem1.Text = "browse...";
            // 
            // createBackupToolStripMenuItem
            // 
            this.createBackupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.withDefaultFilenamelocationToolStripMenuItem,
            this.browseToolStripMenuItem});
            this.createBackupToolStripMenuItem.Name = "createBackupToolStripMenuItem";
            this.createBackupToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.createBackupToolStripMenuItem.Text = "Create backup";
            // 
            // withDefaultFilenamelocationToolStripMenuItem
            // 
            this.withDefaultFilenamelocationToolStripMenuItem.Name = "withDefaultFilenamelocationToolStripMenuItem";
            this.withDefaultFilenamelocationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.withDefaultFilenamelocationToolStripMenuItem.Text = "at default location";
            this.withDefaultFilenamelocationToolStripMenuItem.Click += new System.EventHandler(this.withDefaultFilenamelocationToolStripMenuItem_Click);
            // 
            // browseToolStripMenuItem
            // 
            this.browseToolStripMenuItem.Enabled = false;
            this.browseToolStripMenuItem.Name = "browseToolStripMenuItem";
            this.browseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.browseToolStripMenuItem.Text = "browse...";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(716, 30);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(112, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(139, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(571, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // b_ResetMat
            // 
            this.b_ResetMat.Location = new System.Drawing.Point(716, 88);
            this.b_ResetMat.Name = "b_ResetMat";
            this.b_ResetMat.Size = new System.Drawing.Size(112, 23);
            this.b_ResetMat.TabIndex = 11;
            this.b_ResetMat.Text = "Reset Material";
            this.b_ResetMat.UseVisualStyleBackColor = true;
            this.b_ResetMat.Click += new System.EventHandler(this.b_ResetMat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 590);
            this.Controls.Add(this.b_ResetMat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.b_Save);
            this.Controls.Add(this.tb_ShaderPath);
            this.Controls.Add(this.l_shaderPath);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cB_matCategory);
            this.Controls.Add(this.cB_allmat);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(854, 629);
            this.MinimumSize = new System.Drawing.Size(854, 629);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Params)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Samplers)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cB_allmat;
        private ComboBox cB_matCategory;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView dGV_Params;
        private TabPage tabPage2;
        private DataGridView dGV_Samplers;
        private Label l_shaderPath;
        private TextBox tb_ShaderPath;
        private Button b_Save;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem loadmatbinToolStripMenuItem;
        private ProgressBar progressBar1;
        private Label label1;
        private Button b_ResetMat;
        private ToolStripMenuItem restoreFromBackupFileToolStripMenuItem;
        private ToolStripMenuItem createBackupToolStripMenuItem;
        private ToolStripMenuItem withDefaultFilenamelocationToolStripMenuItem;
        private ToolStripMenuItem browseToolStripMenuItem;
        private ToolStripMenuItem fromDefaultLocationToolStripMenuItem;
        private ToolStripMenuItem browseToolStripMenuItem1;
    }
}