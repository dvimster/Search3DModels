namespace InvAddIn.UI
{
    partial class AddFromFolderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFromFolderForm));
            this.locationLabel = new System.Windows.Forms.Label();
            this.locationComboBox = new System.Windows.Forms.ComboBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.modelDataGridView = new System.Windows.Forms.DataGridView();
            this.modelLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addToDatabaseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // locationLabel
            // 
            this.locationLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.locationLabel.AutoSize = true;
            this.locationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.locationLabel.Location = new System.Drawing.Point(12, 44);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(92, 25);
            this.locationLabel.TabIndex = 0;
            this.locationLabel.Text = "Location:";
            // 
            // locationComboBox
            // 
            this.locationComboBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.locationComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.locationComboBox.FormattingEnabled = true;
            this.locationComboBox.Location = new System.Drawing.Point(110, 41);
            this.locationComboBox.Name = "locationComboBox";
            this.locationComboBox.Size = new System.Drawing.Size(747, 33);
            this.locationComboBox.TabIndex = 1;
            // 
            // browseButton
            // 
            this.browseButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.browseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.browseButton.Location = new System.Drawing.Point(863, 41);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(97, 32);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // modelDataGridView
            // 
            this.modelDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modelDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.modelDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.modelDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.modelLocation});
            this.modelDataGridView.Location = new System.Drawing.Point(12, 113);
            this.modelDataGridView.Name = "modelDataGridView";
            this.modelDataGridView.ReadOnly = true;
            this.modelDataGridView.Size = new System.Drawing.Size(948, 270);
            this.modelDataGridView.TabIndex = 3;
            // 
            // modelLocation
            // 
            this.modelLocation.HeaderText = "Model location";
            this.modelLocation.Name = "modelLocation";
            this.modelLocation.ReadOnly = true;
            // 
            // addToDatabaseButton
            // 
            this.addToDatabaseButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.addToDatabaseButton.Enabled = false;
            this.addToDatabaseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addToDatabaseButton.Location = new System.Drawing.Point(375, 389);
            this.addToDatabaseButton.Name = "addToDatabaseButton";
            this.addToDatabaseButton.Size = new System.Drawing.Size(245, 33);
            this.addToDatabaseButton.TabIndex = 4;
            this.addToDatabaseButton.Text = "Add model(s) to database";
            this.addToDatabaseButton.UseVisualStyleBackColor = true;
            this.addToDatabaseButton.Click += new System.EventHandler(this.addToDatabaseButton_Click);
            // 
            // AddFromFolderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 434);
            this.Controls.Add(this.addToDatabaseButton);
            this.Controls.Add(this.modelDataGridView);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.locationComboBox);
            this.Controls.Add(this.locationLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddFromFolderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add model(s) from folder";
            this.Load += new System.EventHandler(this.AddFromFolderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.modelDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.ComboBox locationComboBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.DataGridView modelDataGridView;
        private System.Windows.Forms.Button addToDatabaseButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelLocation;
    }
}