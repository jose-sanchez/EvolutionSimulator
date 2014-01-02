namespace EvolutionSimulator.UI
{
    partial class GroundProperties
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbCoor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbGroundType = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbNumberOfPlants = new System.Windows.Forms.Label();
            this.dgPlantList = new System.Windows.Forms.DataGridView();
            this.cbGeneration = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlantList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Coordenates:";
            // 
            // lbCoor
            // 
            this.lbCoor.AutoSize = true;
            this.lbCoor.Location = new System.Drawing.Point(126, 29);
            this.lbCoor.Name = "lbCoor";
            this.lbCoor.Size = new System.Drawing.Size(0, 13);
            this.lbCoor.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ground Type:";
            // 
            // lbGroundType
            // 
            this.lbGroundType.AutoSize = true;
            this.lbGroundType.Location = new System.Drawing.Point(126, 63);
            this.lbGroundType.Name = "lbGroundType";
            this.lbGroundType.Size = new System.Drawing.Size(0, 13);
            this.lbGroundType.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Number of plants:";
            // 
            // lbNumberOfPlants
            // 
            this.lbNumberOfPlants.AutoSize = true;
            this.lbNumberOfPlants.Location = new System.Drawing.Point(129, 94);
            this.lbNumberOfPlants.Name = "lbNumberOfPlants";
            this.lbNumberOfPlants.Size = new System.Drawing.Size(0, 13);
            this.lbNumberOfPlants.TabIndex = 6;
            // 
            // dgPlantList
            // 
            this.dgPlantList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPlantList.Location = new System.Drawing.Point(12, 127);
            this.dgPlantList.Name = "dgPlantList";
            this.dgPlantList.Size = new System.Drawing.Size(693, 150);
            this.dgPlantList.TabIndex = 7;
            this.dgPlantList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgPlantList_MouseDoubleClick);
            // 
            // cbGeneration
            // 
            this.cbGeneration.FormattingEnabled = true;
            this.cbGeneration.Location = new System.Drawing.Point(519, 94);
            this.cbGeneration.Name = "cbGeneration";
            this.cbGeneration.Size = new System.Drawing.Size(121, 21);
            this.cbGeneration.TabIndex = 8;
            this.cbGeneration.SelectedIndexChanged += new System.EventHandler(this.cbGeneration_SelectedIndexChanged);
            // 
            // GroundProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 305);
            this.Controls.Add(this.cbGeneration);
            this.Controls.Add(this.dgPlantList);
            this.Controls.Add(this.lbNumberOfPlants);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbGroundType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbCoor);
            this.Controls.Add(this.label1);
            this.Name = "GroundProperties";
            this.Text = "GroundProperties";
            ((System.ComponentModel.ISupportInitialize)(this.dgPlantList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCoor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbGroundType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbNumberOfPlants;
        private System.Windows.Forms.DataGridView dgPlantList;
        private System.Windows.Forms.ComboBox cbGeneration;
    }
}