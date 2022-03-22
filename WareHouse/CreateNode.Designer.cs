
namespace WareHouse
{
    partial class CreateNode
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
            this.mainLabel = new System.Windows.Forms.Label();
            this.newNodeName = new System.Windows.Forms.TextBox();
            this.saveNewNode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.Font = new System.Drawing.Font("mr_NewhouseExtraBlackG", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabel.Location = new System.Drawing.Point(12, 22);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(253, 16);
            this.mainLabel.TabIndex = 0;
            this.mainLabel.Text = "Введите название классификатора:";
            // 
            // newNodeName
            // 
            this.newNodeName.Location = new System.Drawing.Point(12, 52);
            this.newNodeName.Name = "newNodeName";
            this.newNodeName.Size = new System.Drawing.Size(253, 20);
            this.newNodeName.TabIndex = 1;
            // 
            // saveNewNode
            // 
            this.saveNewNode.Location = new System.Drawing.Point(12, 89);
            this.saveNewNode.Name = "saveNewNode";
            this.saveNewNode.Size = new System.Drawing.Size(75, 23);
            this.saveNewNode.TabIndex = 2;
            this.saveNewNode.Text = "Добавить";
            this.saveNewNode.UseVisualStyleBackColor = true;
            this.saveNewNode.Click += new System.EventHandler(this.saveNewNode_Click);
            // 
            // CreateNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 133);
            this.Controls.Add(this.saveNewNode);
            this.Controls.Add(this.newNodeName);
            this.Controls.Add(this.mainLabel);
            this.Name = "CreateNode";
            this.Text = "Добавить классификатор";
            this.Load += new System.EventHandler(this.CreateNode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainLabel;
        private System.Windows.Forms.TextBox newNodeName;
        private System.Windows.Forms.Button saveNewNode;
    }
}