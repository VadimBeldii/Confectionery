
namespace SellerClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CategoriesPanel = new System.Windows.Forms.Panel();
            this.CountTB = new System.Windows.Forms.TextBox();
            this.ShowOrderButton = new System.Windows.Forms.Button();
            this.SendOrderButton = new System.Windows.Forms.Button();
            this.AddProductBtn = new System.Windows.Forms.Button();
            this.RemoveProduct = new System.Windows.Forms.Button();
            this.ProductsLV = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // CategoriesPanel
            // 
            this.CategoriesPanel.Location = new System.Drawing.Point(12, 12);
            this.CategoriesPanel.Name = "CategoriesPanel";
            this.CategoriesPanel.Size = new System.Drawing.Size(224, 426);
            this.CategoriesPanel.TabIndex = 0;
            // 
            // CountTB
            // 
            this.CountTB.Location = new System.Drawing.Point(697, 14);
            this.CountTB.Name = "CountTB";
            this.CountTB.Size = new System.Drawing.Size(50, 27);
            this.CountTB.TabIndex = 3;
            // 
            // ShowOrderButton
            // 
            this.ShowOrderButton.Location = new System.Drawing.Point(594, 374);
            this.ShowOrderButton.Name = "ShowOrderButton";
            this.ShowOrderButton.Size = new System.Drawing.Size(154, 29);
            this.ShowOrderButton.TabIndex = 4;
            this.ShowOrderButton.Text = "Просмотреть заказ";
            this.ShowOrderButton.UseVisualStyleBackColor = true;
            this.ShowOrderButton.Click += new System.EventHandler(this.ShowOrderButton_Click);
            // 
            // SendOrderButton
            // 
            this.SendOrderButton.Location = new System.Drawing.Point(594, 409);
            this.SendOrderButton.Name = "SendOrderButton";
            this.SendOrderButton.Size = new System.Drawing.Size(154, 29);
            this.SendOrderButton.TabIndex = 5;
            this.SendOrderButton.Text = "Отправить";
            this.SendOrderButton.UseVisualStyleBackColor = true;
            this.SendOrderButton.Click += new System.EventHandler(this.SendOrderButton_Click);
            // 
            // AddProductBtn
            // 
            this.AddProductBtn.Location = new System.Drawing.Point(593, 12);
            this.AddProductBtn.Name = "AddProductBtn";
            this.AddProductBtn.Size = new System.Drawing.Size(94, 29);
            this.AddProductBtn.TabIndex = 6;
            this.AddProductBtn.Text = "Добавить";
            this.AddProductBtn.UseVisualStyleBackColor = true;
            this.AddProductBtn.Click += new System.EventHandler(this.AddProductBtn_Click);
            // 
            // RemoveProduct
            // 
            this.RemoveProduct.Location = new System.Drawing.Point(593, 47);
            this.RemoveProduct.Name = "RemoveProduct";
            this.RemoveProduct.Size = new System.Drawing.Size(154, 29);
            this.RemoveProduct.TabIndex = 7;
            this.RemoveProduct.Text = "Удалить";
            this.RemoveProduct.UseVisualStyleBackColor = true;
            this.RemoveProduct.Click += new System.EventHandler(this.RemoveProduct_Click);
            // 
            // ProductsLV
            // 
            this.ProductsLV.HideSelection = false;
            this.ProductsLV.Location = new System.Drawing.Point(242, 12);
            this.ProductsLV.Name = "ProductsLV";
            this.ProductsLV.Size = new System.Drawing.Size(345, 426);
            this.ProductsLV.TabIndex = 8;
            this.ProductsLV.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 450);
            this.Controls.Add(this.ProductsLV);
            this.Controls.Add(this.RemoveProduct);
            this.Controls.Add(this.AddProductBtn);
            this.Controls.Add(this.SendOrderButton);
            this.Controls.Add(this.ShowOrderButton);
            this.Controls.Add(this.CountTB);
            this.Controls.Add(this.CategoriesPanel);
            this.Name = "Form1";
            this.Text = "Confectionery";
            this.Click += new System.EventHandler(this.Form1_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel CategoriesPanel;
        private System.Windows.Forms.TextBox CountTB;
        private System.Windows.Forms.Button ShowOrderButton;
        private System.Windows.Forms.Button SendOrderButton;
        private System.Windows.Forms.Button AddProductBtn;
        private System.Windows.Forms.Button RemoveProduct;
        private System.Windows.Forms.ListView ProductsLV;
    }
}

