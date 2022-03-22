
namespace WareHouse
{
    partial class AutoSaveForm
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
            this.saveTimeTextBox = new System.Windows.Forms.TextBox();
            this.maxQuantityTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Промежуток автосохранения (в секундах, не меньше 60 секунд):";
            // 
            // saveTimeTextBox
            // 
            this.saveTimeTextBox.Location = new System.Drawing.Point(15, 53);
            this.saveTimeTextBox.Name = "saveTimeTextBox";
            this.saveTimeTextBox.Size = new System.Drawing.Size(139, 20);
            this.saveTimeTextBox.TabIndex = 1;
            // 
            // maxQuantityTextBox
            // 
            this.maxQuantityTextBox.Location = new System.Drawing.Point(15, 120);
            this.maxQuantityTextBox.Name = "maxQuantityTextBox";
            this.maxQuantityTextBox.Size = new System.Drawing.Size(139, 20);
            this.maxQuantityTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(321, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Максимальное количество товара для сохранения в таблицу:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(15, 164);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // AutoSaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 199);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.maxQuantityTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.saveTimeTextBox);
            this.Controls.Add(this.label1);
            this.Name = "AutoSaveForm";
            this.Text = "Автоматическое сохранение:";
            this.Load += new System.EventHandler(this.AutoSaveForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox saveTimeTextBox;
        private System.Windows.Forms.TextBox maxQuantityTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveButton;
    }
}