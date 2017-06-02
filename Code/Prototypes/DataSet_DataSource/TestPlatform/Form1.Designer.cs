namespace TestPlatform
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.OpenButton = new System.Windows.Forms.ToolStripButton();
            this.SaveButton = new System.Windows.Forms.ToolStripButton();
            this.CreateButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.AddSceneButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridScenes = new System.Windows.Forms.DataGridView();
            this.gridVersions = new System.Windows.Forms.DataGridView();
            this.DeleteSceneButton = new System.Windows.Forms.ToolStripButton();
            this.sceneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridScenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVersions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sceneBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.versionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenButton,
            this.SaveButton,
            this.CreateButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(752, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // OpenButton
            // 
            this.OpenButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenButton.Image")));
            this.OpenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(56, 22);
            this.OpenButton.Text = "Open";
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
            this.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(51, 22);
            this.SaveButton.Text = "Save";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CreateButton
            // 
            this.CreateButton.Image = ((System.Drawing.Image)(resources.GetObject("CreateButton.Image")));
            this.CreateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(61, 22);
            this.CreateButton.Text = "Create";
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddSceneButton,
            this.DeleteSceneButton});
            this.toolStrip2.Location = new System.Drawing.Point(0, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(752, 25);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // AddSceneButton
            // 
            this.AddSceneButton.Image = ((System.Drawing.Image)(resources.GetObject("AddSceneButton.Image")));
            this.AddSceneButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddSceneButton.Name = "AddSceneButton";
            this.AddSceneButton.Size = new System.Drawing.Size(83, 22);
            this.AddSceneButton.Text = "Add Scene";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridScenes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridVersions);
            this.splitContainer1.Size = new System.Drawing.Size(752, 346);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 6;
            // 
            // gridScenes
            // 
            this.gridScenes.AutoGenerateColumns = false;
            this.gridScenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridScenes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTitle});
            this.gridScenes.DataSource = this.sceneBindingSource;
            this.gridScenes.Location = new System.Drawing.Point(30, 45);
            this.gridScenes.Name = "gridScenes";
            this.gridScenes.Size = new System.Drawing.Size(197, 206);
            this.gridScenes.TabIndex = 1;
            // 
            // gridVersions
            // 
            this.gridVersions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVersions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCode});
            this.gridVersions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVersions.Location = new System.Drawing.Point(0, 0);
            this.gridVersions.Name = "gridVersions";
            this.gridVersions.Size = new System.Drawing.Size(498, 346);
            this.gridVersions.TabIndex = 1;
            // 
            // DeleteSceneButton
            // 
            this.DeleteSceneButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteSceneButton.Image")));
            this.DeleteSceneButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteSceneButton.Name = "DeleteSceneButton";
            this.DeleteSceneButton.Size = new System.Drawing.Size(94, 22);
            this.DeleteSceneButton.Text = "Delete Scene";
            // 
            // colTitle
            // 
            this.colTitle.DataPropertyName = "Title";
            this.colTitle.HeaderText = "Title";
            this.colTitle.Name = "colTitle";
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.HeaderText = "Code";
            this.colCode.Name = "colCode";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 396);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridScenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVersions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sceneBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.versionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton OpenButton;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton CreateButton;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton AddSceneButton;
        private System.Windows.Forms.ToolStripButton DeleteSceneButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gridScenes;
        private System.Windows.Forms.DataGridView gridVersions;
        private System.Windows.Forms.BindingSource sceneBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.BindingSource versionBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
    }
}

