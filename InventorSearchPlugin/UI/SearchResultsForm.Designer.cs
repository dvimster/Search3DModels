namespace InvAddIn.UI
{
    partial class SearchResultsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchResultsForm));
            this.resultsDataGridView = new System.Windows.Forms.DataGridView();
            this.addToAssembly = new System.Windows.Forms.Button();
            this.buildAssembly = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectAll = new System.Windows.Forms.Button();
            this.checkModel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.deviation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // resultsDataGridView
            // 
            this.resultsDataGridView.AllowUserToAddRows = false;
            this.resultsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resultsDataGridView.ColumnHeadersHeight = 40;
            this.resultsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkModel,
            this.deviation,
            this.height,
            this.length,
            this.width,
            this.location});
            this.resultsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.resultsDataGridView.Name = "resultsDataGridView";
            this.resultsDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultsDataGridView.Size = new System.Drawing.Size(1089, 435);
            this.resultsDataGridView.TabIndex = 0;
            // 
            // addToAssembly
            // 
            this.addToAssembly.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addToAssembly.Location = new System.Drawing.Point(6, 28);
            this.addToAssembly.Name = "addToAssembly";
            this.addToAssembly.Size = new System.Drawing.Size(326, 29);
            this.addToAssembly.TabIndex = 1;
            this.addToAssembly.Text = "Add selected model(s) to Assembly";
            this.addToAssembly.UseVisualStyleBackColor = true;
            this.addToAssembly.Click += new System.EventHandler(this.addToAssembly_Click);
            // 
            // buildAssembly
            // 
            this.buildAssembly.Enabled = false;
            this.buildAssembly.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buildAssembly.Location = new System.Drawing.Point(338, 28);
            this.buildAssembly.Name = "buildAssembly";
            this.buildAssembly.Size = new System.Drawing.Size(182, 29);
            this.buildAssembly.TabIndex = 2;
            this.buildAssembly.Text = "Build Assembly";
            this.buildAssembly.UseVisualStyleBackColor = true;
            this.buildAssembly.Click += new System.EventHandler(this.buildAssembly_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selectAll);
            this.groupBox1.Controls.Add(this.addToAssembly);
            this.groupBox1.Controls.Add(this.buildAssembly);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(13, 454);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1088, 76);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            // 
            // selectAll
            // 
            this.selectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.selectAll.Location = new System.Drawing.Point(526, 28);
            this.selectAll.Name = "selectAll";
            this.selectAll.Size = new System.Drawing.Size(182, 29);
            this.selectAll.TabIndex = 3;
            this.selectAll.Text = "Select All Models";
            this.selectAll.UseVisualStyleBackColor = true;
            this.selectAll.Click += new System.EventHandler(this.selectAll_Click);
            // 
            // checkModel
            // 
            this.checkModel.FillWeight = 20F;
            this.checkModel.HeaderText = "Select";
            this.checkModel.Name = "checkModel";
            // 
            // deviation
            // 
            this.deviation.FillWeight = 30F;
            this.deviation.HeaderText = "Deviation";
            this.deviation.Name = "deviation";
            // 
            // height
            // 
            this.height.FillWeight = 30F;
            this.height.HeaderText = "Height";
            this.height.Name = "height";
            // 
            // length
            // 
            this.length.FillWeight = 30F;
            this.length.HeaderText = "Length";
            this.length.Name = "length";
            // 
            // width
            // 
            this.width.FillWeight = 30F;
            this.width.HeaderText = "Width";
            this.width.Name = "width";
            // 
            // location
            // 
            this.location.FillWeight = 240.4596F;
            this.location.HeaderText = "Location";
            this.location.Name = "location";
            // 
            // SearchResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 562);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.resultsDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchResultsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView resultsDataGridView;
        private System.Windows.Forms.Button addToAssembly;
        private System.Windows.Forms.Button buildAssembly;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button selectAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviation;
        private System.Windows.Forms.DataGridViewTextBoxColumn height;
        private System.Windows.Forms.DataGridViewTextBoxColumn length;
        private System.Windows.Forms.DataGridViewTextBoxColumn width;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
    }
}