namespace SoftwareConstructing_Forms
{
    partial class Form_MinimalTree
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
            this.B_boot1 = new System.Windows.Forms.Button();
            this.B_Swich = new System.Windows.Forms.Button();
            this.PB_GraphGraphics = new System.Windows.Forms.PictureBox();
            this.B_GetSize = new System.Windows.Forms.Button();
            this.DGV_Matrix = new System.Windows.Forms.DataGridView();
            this.bRead = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PB_GraphGraphics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Matrix)).BeginInit();
            this.SuspendLayout();
            // 
            // B_boot1
            // 
            this.B_boot1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_boot1.Location = new System.Drawing.Point(664, 24);
            this.B_boot1.Name = "B_boot1";
            this.B_boot1.Size = new System.Drawing.Size(501, 47);
            this.B_boot1.TabIndex = 39;
            this.B_boot1.Text = "Поиск минимального дерева алгоритмом Прима";
            this.B_boot1.UseVisualStyleBackColor = true;
            this.B_boot1.Click += new System.EventHandler(this.B_boot1_Click);
            // 
            // B_Swich
            // 
            this.B_Swich.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Swich.Location = new System.Drawing.Point(17, 612);
            this.B_Swich.Name = "B_Swich";
            this.B_Swich.Size = new System.Drawing.Size(414, 47);
            this.B_Swich.TabIndex = 38;
            this.B_Swich.Text = "переключатель";
            this.B_Swich.UseVisualStyleBackColor = true;
            // 
            // PB_GraphGraphics
            // 
            this.PB_GraphGraphics.Location = new System.Drawing.Point(671, 85);
            this.PB_GraphGraphics.Name = "PB_GraphGraphics";
            this.PB_GraphGraphics.Size = new System.Drawing.Size(748, 603);
            this.PB_GraphGraphics.TabIndex = 37;
            this.PB_GraphGraphics.TabStop = false;
            // 
            // B_GetSize
            // 
            this.B_GetSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_GetSize.Location = new System.Drawing.Point(441, 611);
            this.B_GetSize.Name = "B_GetSize";
            this.B_GetSize.Size = new System.Drawing.Size(217, 47);
            this.B_GetSize.TabIndex = 36;
            this.B_GetSize.Text = "Задать размер";
            this.B_GetSize.UseVisualStyleBackColor = true;
            this.B_GetSize.Click += new System.EventHandler(this.B_GetSize_Click);
            // 
            // DGV_Matrix
            // 
            this.DGV_Matrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Matrix.Location = new System.Drawing.Point(17, 24);
            this.DGV_Matrix.Name = "DGV_Matrix";
            this.DGV_Matrix.RowHeadersWidth = 51;
            this.DGV_Matrix.RowTemplate.Height = 24;
            this.DGV_Matrix.Size = new System.Drawing.Size(641, 581);
            this.DGV_Matrix.TabIndex = 35;
            // 
            // bRead
            // 
            this.bRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bRead.Location = new System.Drawing.Point(1171, 24);
            this.bRead.Name = "bRead";
            this.bRead.Size = new System.Drawing.Size(248, 47);
            this.bRead.TabIndex = 40;
            this.bRead.Text = "Читать из файла";
            this.bRead.UseVisualStyleBackColor = true;
            this.bRead.Click += new System.EventHandler(this.bRead_Click);
            // 
            // Form_MinimalTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1437, 712);
            this.Controls.Add(this.bRead);
            this.Controls.Add(this.B_boot1);
            this.Controls.Add(this.B_Swich);
            this.Controls.Add(this.PB_GraphGraphics);
            this.Controls.Add(this.B_GetSize);
            this.Controls.Add(this.DGV_Matrix);
            this.Name = "Form_MinimalTree";
            this.Text = "Form_MinimalTree";
            ((System.ComponentModel.ISupportInitialize)(this.PB_GraphGraphics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Matrix)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_boot1;
        private System.Windows.Forms.Button B_Swich;
        private System.Windows.Forms.PictureBox PB_GraphGraphics;
        private System.Windows.Forms.Button B_GetSize;
        private System.Windows.Forms.DataGridView DGV_Matrix;
        private System.Windows.Forms.Button bRead;
    }
}