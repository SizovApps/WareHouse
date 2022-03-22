
namespace WareHouse
{
    partial class ShowCartForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sumPriceLabel = new System.Windows.Forms.Label();
            this.sumPriceResult = new System.Windows.Forms.Label();
            this.orderButton = new System.Windows.Forms.Button();
            this.nameOfProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteFromCart = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameOfProduct,
            this.quantity,
            this.price,
            this.fullPrice,
            this.deleteFromCart});
            this.dataGridView1.Location = new System.Drawing.Point(2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(764, 216);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // sumPriceLabel
            // 
            this.sumPriceLabel.AutoSize = true;
            this.sumPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sumPriceLabel.Location = new System.Drawing.Point(12, 272);
            this.sumPriceLabel.Name = "sumPriceLabel";
            this.sumPriceLabel.Size = new System.Drawing.Size(144, 20);
            this.sumPriceLabel.TabIndex = 4;
            this.sumPriceLabel.Text = "Итого к оплате:";
            // 
            // sumPriceResult
            // 
            this.sumPriceResult.AutoSize = true;
            this.sumPriceResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sumPriceResult.Location = new System.Drawing.Point(178, 272);
            this.sumPriceResult.Name = "sumPriceResult";
            this.sumPriceResult.Size = new System.Drawing.Size(19, 20);
            this.sumPriceResult.TabIndex = 5;
            this.sumPriceResult.Text = "0";
            // 
            // orderButton
            // 
            this.orderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.orderButton.Location = new System.Drawing.Point(16, 385);
            this.orderButton.Name = "orderButton";
            this.orderButton.Size = new System.Drawing.Size(197, 39);
            this.orderButton.TabIndex = 6;
            this.orderButton.Text = "Сделать заказ";
            this.orderButton.UseVisualStyleBackColor = true;
            this.orderButton.Click += new System.EventHandler(this.orderButton_Click);
            // 
            // nameOfProduct
            // 
            this.nameOfProduct.HeaderText = "Название товара/услуги";
            this.nameOfProduct.Name = "nameOfProduct";
            this.nameOfProduct.ReadOnly = true;
            this.nameOfProduct.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nameOfProduct.Width = 290;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Количество";
            this.quantity.Name = "quantity";
            // 
            // price
            // 
            this.price.HeaderText = "Цена за ед.";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // fullPrice
            // 
            this.fullPrice.HeaderText = "Сумма";
            this.fullPrice.Name = "fullPrice";
            this.fullPrice.ReadOnly = true;
            // 
            // deleteFromCart
            // 
            this.deleteFromCart.HeaderText = "Из корзины";
            this.deleteFromCart.Name = "deleteFromCart";
            this.deleteFromCart.Text = "Убрать из корзины";
            this.deleteFromCart.UseColumnTextForButtonValue = true;
            this.deleteFromCart.Width = 130;
            // 
            // ShowCartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 447);
            this.Controls.Add(this.orderButton);
            this.Controls.Add(this.sumPriceResult);
            this.Controls.Add(this.sumPriceLabel);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ShowCartForm";
            this.Text = "Корзина";
            this.Load += new System.EventHandler(this.ShowCartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label sumPriceLabel;
        private System.Windows.Forms.Label sumPriceResult;
        private System.Windows.Forms.Button orderButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameOfProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullPrice;
        private System.Windows.Forms.DataGridViewButtonColumn deleteFromCart;
    }
}