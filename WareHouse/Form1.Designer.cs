
namespace WareHouse
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Все товары");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.addClass = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nameOfProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toCart = new System.Windows.Forms.DataGridViewButtonColumn();
            this.deleteClass = new System.Windows.Forms.Button();
            this.changeClass = new System.Windows.Forms.Button();
            this.addProduct = new System.Windows.Forms.Button();
            this.changeProduct = new System.Windows.Forms.Button();
            this.deleteProduct = new System.Windows.Forms.Button();
            this.saveWarehouse = new System.Windows.Forms.Button();
            this.openWareHouse = new System.Windows.Forms.Button();
            this.saveExcel = new System.Windows.Forms.Button();
            this.autoSaveParamsButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(2, 76);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "all";
            treeNode1.Text = "Все товары";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(263, 508);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.Click += new System.EventHandler(this.treeView1_Click);
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // addClass
            // 
            this.addClass.Location = new System.Drawing.Point(13, 36);
            this.addClass.Name = "addClass";
            this.addClass.Size = new System.Drawing.Size(162, 23);
            this.addClass.TabIndex = 1;
            this.addClass.Text = "Добавить класификатор";
            this.addClass.UseVisualStyleBackColor = true;
            this.addClass.Click += new System.EventHandler(this.addClass_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameOfProduct,
            this.code,
            this.quantity,
            this.price,
            this.toCart});
            this.dataGridView1.Location = new System.Drawing.Point(271, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(853, 508);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseUp);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // nameOfProduct
            // 
            this.nameOfProduct.HeaderText = "Название товара/услуги";
            this.nameOfProduct.Name = "nameOfProduct";
            this.nameOfProduct.ReadOnly = true;
            this.nameOfProduct.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nameOfProduct.Width = 290;
            // 
            // code
            // 
            this.code.HeaderText = "Код";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Width = 200;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Количество";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // price
            // 
            this.price.HeaderText = "Цена";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // toCart
            // 
            this.toCart.HeaderText = "В корзину";
            this.toCart.Name = "toCart";
            this.toCart.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.toCart.Text = "Добавить в корзину";
            this.toCart.ToolTipText = "Добавить в корзину";
            this.toCart.UseColumnTextForButtonValue = true;
            this.toCart.Visible = false;
            this.toCart.Width = 120;
            // 
            // deleteClass
            // 
            this.deleteClass.Location = new System.Drawing.Point(349, 36);
            this.deleteClass.Name = "deleteClass";
            this.deleteClass.Size = new System.Drawing.Size(162, 23);
            this.deleteClass.TabIndex = 3;
            this.deleteClass.Text = "Удалить класификатор";
            this.deleteClass.UseVisualStyleBackColor = true;
            this.deleteClass.Click += new System.EventHandler(this.deleteClass_Click);
            // 
            // changeClass
            // 
            this.changeClass.Location = new System.Drawing.Point(181, 36);
            this.changeClass.Name = "changeClass";
            this.changeClass.Size = new System.Drawing.Size(162, 23);
            this.changeClass.TabIndex = 4;
            this.changeClass.Text = "Изменить класификатор";
            this.changeClass.UseVisualStyleBackColor = true;
            this.changeClass.Click += new System.EventHandler(this.changeClass_Click);
            // 
            // addProduct
            // 
            this.addProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addProduct.Location = new System.Drawing.Point(626, 36);
            this.addProduct.Name = "addProduct";
            this.addProduct.Size = new System.Drawing.Size(162, 23);
            this.addProduct.TabIndex = 5;
            this.addProduct.Text = "Добавить товар";
            this.addProduct.UseVisualStyleBackColor = true;
            this.addProduct.Click += new System.EventHandler(this.addProduct_Click);
            // 
            // changeProduct
            // 
            this.changeProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.changeProduct.Enabled = false;
            this.changeProduct.Location = new System.Drawing.Point(794, 36);
            this.changeProduct.Name = "changeProduct";
            this.changeProduct.Size = new System.Drawing.Size(162, 23);
            this.changeProduct.TabIndex = 6;
            this.changeProduct.Text = "Изменить товар";
            this.changeProduct.UseVisualStyleBackColor = true;
            this.changeProduct.Click += new System.EventHandler(this.changeProduct_Click);
            // 
            // deleteProduct
            // 
            this.deleteProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteProduct.Enabled = false;
            this.deleteProduct.Location = new System.Drawing.Point(962, 36);
            this.deleteProduct.Name = "deleteProduct";
            this.deleteProduct.Size = new System.Drawing.Size(162, 23);
            this.deleteProduct.TabIndex = 7;
            this.deleteProduct.Text = "Удалить товар";
            this.deleteProduct.UseVisualStyleBackColor = true;
            this.deleteProduct.Click += new System.EventHandler(this.deleteProduct_Click);
            // 
            // saveWarehouse
            // 
            this.saveWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveWarehouse.Location = new System.Drawing.Point(12, 594);
            this.saveWarehouse.Name = "saveWarehouse";
            this.saveWarehouse.Size = new System.Drawing.Size(108, 23);
            this.saveWarehouse.TabIndex = 8;
            this.saveWarehouse.Text = "Сохранить склад";
            this.saveWarehouse.UseVisualStyleBackColor = true;
            this.saveWarehouse.Click += new System.EventHandler(this.saveWarehouse_Click);
            // 
            // openWareHouse
            // 
            this.openWareHouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.openWareHouse.Location = new System.Drawing.Point(142, 594);
            this.openWareHouse.Name = "openWareHouse";
            this.openWareHouse.Size = new System.Drawing.Size(108, 23);
            this.openWareHouse.TabIndex = 9;
            this.openWareHouse.Text = "Открыть склад";
            this.openWareHouse.UseVisualStyleBackColor = true;
            this.openWareHouse.Click += new System.EventHandler(this.openWareHouse_Click);
            // 
            // saveExcel
            // 
            this.saveExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveExcel.Location = new System.Drawing.Point(729, 594);
            this.saveExcel.Name = "saveExcel";
            this.saveExcel.Size = new System.Drawing.Size(162, 23);
            this.saveExcel.TabIndex = 10;
            this.saveExcel.Text = "Сохранить в Excel";
            this.saveExcel.UseVisualStyleBackColor = true;
            this.saveExcel.Click += new System.EventHandler(this.saveExcel_Click);
            // 
            // autoSaveParamsButton
            // 
            this.autoSaveParamsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.autoSaveParamsButton.Location = new System.Drawing.Point(909, 594);
            this.autoSaveParamsButton.Name = "autoSaveParamsButton";
            this.autoSaveParamsButton.Size = new System.Drawing.Size(214, 23);
            this.autoSaveParamsButton.TabIndex = 11;
            this.autoSaveParamsButton.Text = "Задать параметры автосохранения";
            this.autoSaveParamsButton.UseVisualStyleBackColor = true;
            this.autoSaveParamsButton.Click += new System.EventHandler(this.autoSaveParamsButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 100000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cartToolStripMenuItem,
            this.signInToolStripMenuItem,
            this.singUpToolStripMenuItem,
            this.ordersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1135, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cartToolStripMenuItem
            // 
            this.cartToolStripMenuItem.Name = "cartToolStripMenuItem";
            this.cartToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.cartToolStripMenuItem.Text = "Корзина";
            this.cartToolStripMenuItem.Visible = false;
            this.cartToolStripMenuItem.Click += new System.EventHandler(this.cartToolStripMenuItem_Click);
            // 
            // signInToolStripMenuItem
            // 
            this.signInToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.signInToolStripMenuItem.Name = "signInToolStripMenuItem";
            this.signInToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.signInToolStripMenuItem.Text = "Войти";
            this.signInToolStripMenuItem.Click += new System.EventHandler(this.signInToolStripMenuItem_Click);
            // 
            // singUpToolStripMenuItem
            // 
            this.singUpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.singUpToolStripMenuItem.Name = "singUpToolStripMenuItem";
            this.singUpToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.singUpToolStripMenuItem.Text = "Зарегестрироваться";
            this.singUpToolStripMenuItem.Click += new System.EventHandler(this.singUpToolStripMenuItem_Click);
            // 
            // ordersToolStripMenuItem
            // 
            this.ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            this.ordersToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.ordersToolStripMenuItem.Text = "Мои заказы";
            this.ordersToolStripMenuItem.Visible = false;
            this.ordersToolStripMenuItem.Click += new System.EventHandler(this.ordersStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 629);
            this.Controls.Add(this.autoSaveParamsButton);
            this.Controls.Add(this.saveExcel);
            this.Controls.Add(this.openWareHouse);
            this.Controls.Add(this.saveWarehouse);
            this.Controls.Add(this.deleteProduct);
            this.Controls.Add(this.changeProduct);
            this.Controls.Add(this.addProduct);
            this.Controls.Add(this.changeClass);
            this.Controls.Add(this.deleteClass);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.addClass);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Склад товаров";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button addClass;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button deleteClass;
        private System.Windows.Forms.Button changeClass;
        private System.Windows.Forms.Button addProduct;
        private System.Windows.Forms.Button changeProduct;
        private System.Windows.Forms.Button deleteProduct;
        private System.Windows.Forms.Button saveWarehouse;
        private System.Windows.Forms.Button openWareHouse;
        private System.Windows.Forms.Button saveExcel;
        private System.Windows.Forms.Button autoSaveParamsButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem singUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cartToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameOfProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewButtonColumn toCart;
        private System.Windows.Forms.ToolStripMenuItem ordersToolStripMenuItem;
    }
}

