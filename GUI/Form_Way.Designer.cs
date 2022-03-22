
namespace SoftwareConstructing_Forms
{
    partial class Form_Way
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.B_Swich = new System.Windows.Forms.Button();
            this.PB_GraphGraphics = new System.Windows.Forms.PictureBox();
            this.B_GetSize = new System.Windows.Forms.Button();
            this.DGV_Matrix = new System.Windows.Forms.DataGridView();
            this.B_boot1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PB_GraphGraphics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Matrix)).BeginInit();
            this.SuspendLayout();
            // 
            // B_Swich
            // 
            this.B_Swich.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Swich.Location = new System.Drawing.Point(12, 600);
            this.B_Swich.Name = "B_Swich";
            this.B_Swich.Size = new System.Drawing.Size(414, 47);
            this.B_Swich.TabIndex = 33;
            this.B_Swich.Text = "переключатель";
            this.B_Swich.UseVisualStyleBackColor = true;
            // 
            // PB_GraphGraphics
            // 
            this.PB_GraphGraphics.Location = new System.Drawing.Point(666, 73);
            this.PB_GraphGraphics.Name = "PB_GraphGraphics";
            this.PB_GraphGraphics.Size = new System.Drawing.Size(748, 603);
            this.PB_GraphGraphics.TabIndex = 28;
            this.PB_GraphGraphics.TabStop = false;
            // 
            // B_GetSize
            // 
            this.B_GetSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_GetSize.Location = new System.Drawing.Point(436, 599);
            this.B_GetSize.Name = "B_GetSize";
            this.B_GetSize.Size = new System.Drawing.Size(217, 47);
            this.B_GetSize.TabIndex = 27;
            this.B_GetSize.Text = "Задать размер";
            this.B_GetSize.UseVisualStyleBackColor = true;
            this.B_GetSize.Click += new System.EventHandler(this.B_GetSize_Click);
            // 
            // DGV_Matrix
            // 
            this.DGV_Matrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Matrix.Location = new System.Drawing.Point(12, 12);
            this.DGV_Matrix.Name = "DGV_Matrix";
            this.DGV_Matrix.RowHeadersWidth = 51;
            this.DGV_Matrix.RowTemplate.Height = 24;
            this.DGV_Matrix.Size = new System.Drawing.Size(641, 581);
            this.DGV_Matrix.TabIndex = 26;
            // 
            // B_boot1
            // 
            this.B_boot1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_boot1.Location = new System.Drawing.Point(659, 12);
            this.B_boot1.Name = "B_boot1";
            this.B_boot1.Size = new System.Drawing.Size(414, 47);
            this.B_boot1.TabIndex = 34;
            this.B_boot1.Text = "Поиск пути";
            this.B_boot1.UseVisualStyleBackColor = true;
            this.B_boot1.Click += new System.EventHandler(this.B_boot1_Click);
            // 
            // Form_Prototype
            // 
            this.ClientSize = new System.Drawing.Size(1433, 714);
            this.Controls.Add(this.B_boot1);
            this.Controls.Add(this.B_Swich);
            this.Controls.Add(this.PB_GraphGraphics);
            this.Controls.Add(this.B_GetSize);
            this.Controls.Add(this.DGV_Matrix);
            this.Name = "Form_Prototype";
            ((System.ComponentModel.ISupportInitialize)(this.PB_GraphGraphics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Matrix)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_Swich;
        private System.Windows.Forms.PictureBox PB_GraphGraphics;
        private System.Windows.Forms.Button B_GetSize;
        private System.Windows.Forms.DataGridView DGV_Matrix;
        private System.Windows.Forms.Button B_boot1;
    }
}
