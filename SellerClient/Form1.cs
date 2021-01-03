﻿using Confectionery.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SellerClient
{
    //test
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ICollection<CategoryDTO> categories;
        private CategoryDTO currentCategory;
        private OrderDTO order = new OrderDTO { OrderItems = new List<OrderItemDTO>() };

        private void AddProductBtn_Click(object sender, EventArgs e)
        {
            var item = order.OrderItems.SingleOrDefault(o => o.ProductId == currentCategory.Products[ProductsLV.SelectedIndices[0]].Id);
            
            uint count;

            if (uint.TryParse(CountTB.Text, out count)
                && count <= currentCategory.Products[ProductsLV.SelectedIndices[0]].Count)
            {
                if (item == default(OrderItemDTO))
                { 
                    order.OrderItems.Add(new OrderItemDTO
                    {
                        Count = (int)count,
                        ProductId = currentCategory.Products[ProductsLV.SelectedIndices[0]].Id
                    });
                }
                else
                {
                    item.Count += (int)count;
                }
            }
            else
            {
                MessageBox.Show("Unable to order");
            }
            CountTB.Text = "1";
        }

        private void RemoveProduct_Click(object sender, EventArgs e)
        {
            order.OrderItems.Remove(
                order.OrderItems.FirstOrDefault(o => o.ProductId == currentCategory.Products[ProductsLV.SelectedIndices[0]].Id));
        }

        private void SendOrderButton_Click(object sender, EventArgs e)
        {
            if (order.OrderItems == null || order.OrderItems.Count == 0)
            {
                return;
            }
            order.Time = DateTime.Now;
            ApiWrapper.SendOrder(order);
            order = new OrderDTO();
            order.OrderItems = new List<OrderItemDTO>();
        }

        private void ShowOrderButton_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            
            if (order.OrderItems != null || order.OrderItems.Count != 0)
            {
                foreach (var i in order.OrderItems)
                    sb.Append($"{currentCategory.Products.First(p => p.Id == i.ProductId).Name} ({i.Count} шт.) \n");
            }

            var prompt = new Form()
            {
                Width = 500,
                Height = 500,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Текущий заказ: ",
                StartPosition = FormStartPosition.CenterScreen
            };
            var textLabel = new Label()
            {
                Left = 50,
                Top = 20,
                Width = 400,
                Height = 300,
                Text = sb.ToString()
            };
            var confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 400, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            prompt.ShowDialog();
        }

        private void CategoryChanged()
        {
            ProductsLV.Items.Clear();
            ProductsLV.Columns.Clear();
            ProductsLV.Columns.Add("Name", "Название");
            ProductsLV.Columns.Add("Price", "Цена");
            ProductsLV.Columns.Add("Description", "Описание");
            ProductsLV.Columns.Add("Count", "Остаток на складе");
            foreach(var p in currentCategory.Products)
            {
                var item = new ListViewItem(new[] { p.Name, p.Price.ToString(), p.Description, p.Count.ToString() });
                ProductsLV.Items.Add(item);
            }
        }

        //причина существования этого костыля в том, что я не знаю как уговорить вижуалку подождать, пока сервер запускается
        private void Form1_Click(object sender, EventArgs e)
        {
            CategoriesPanel.Controls.Clear();
            categories = ApiWrapper.GetCategories();
            foreach (var c in categories)
            {
                var btn = new Button { Text = c.Name };
                btn.Width = CategoriesPanel.Width;
                btn.Height = 50;
                btn.Top = CategoriesPanel.Controls.Count * 50;
                btn.Click += (sender, e) =>
                {
                    currentCategory = c;
                    CategoryChanged();
                };
                CategoriesPanel.Controls.Add(btn);
            }
        }
    }
}
