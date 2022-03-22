namespace SoftwareConstructing_Forms.SubForms
{
    partial class Input_form_1_stroke
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
            this.L_Stroke1 = new System.Windows.Forms.Label();
            this.TB_PointCount = new System.Windows.Forms.TextBox();
            this.B_Finish = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // L_Stroke1
            // 
            this.L_Stroke1.AutoSize = true;
            this.L_Stroke1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Stroke1.Location = new System.Drawing.Point(6, 9);
            this.L_Stroke1.Name = "L_Stroke1";
            this.L_Stroke1.Size = new System.Drawing.Size(230, 29);
            this.L_Stroke1.TabIndex = 1;
            this.L_Stroke1.Text = "Количество точек:";
            // 
            // TB_PointCount
            // 
            this.TB_PointCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_PointCount.Location = new System.Drawing.Point(11, 50);
            this.TB_PointCount.Name = "TB_PointCount";
            this.TB_PointCount.Size = new System.Drawing.Size(313, 34);
            this.TB_PointCount.TabIndex = 3;
            this.TB_PointCount.Text = "10";
            // 
            // B_Finish
            // 
            this.B_Finish.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Finish.Location = new System.Drawing.Point(11, 93);
            this.B_Finish.Name = "B_Finish";
            this.B_Finish.Size = new System.Drawing.Size(269, 50);
            this.B_Finish.TabIndex = 4;
            this.B_Finish.Text = "Готово";
            this.B_Finish.UseVisualStyleBackColor = true;
            this.B_Finish.Click += new System.EventHandler(this.B_Finish_Click);
            // 
            // Input_form_1_stroke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 155);
            this.Controls.Add(this.B_Finish);
            this.Controls.Add(this.TB_PointCount);
            this.Controls.Add(this.L_Stroke1);
            this.Name = "Input_form_1_stroke";
            this.Text = "7";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label L_Stroke1;
        private System.Windows.Forms.TextBox TB_PointCount;
        private System.Windows.Forms.Button B_Finish;
    }
}