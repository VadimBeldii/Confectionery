using Confectionery.BLL.DTOs;
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
            var item = order.OrderItems.SingleOrDefault(o => o.Product == currentCategory.Products[ProductsLV.SelectedIndices[0]]);

            uint count;
            if (item == default(OrderItemDTO))
            {
                if (uint.TryParse(CountTB.Text, out count))
                {
                    order.OrderItems.Add(new OrderItemDTO
                    {
                        count = (int)count,
                        Product = currentCategory.Products[ProductsLV.SelectedIndices[0]]
                    });
                }
            }
            else
            {
                if (uint.TryParse(CountTB.Text, out count))
                {
                    item.count += (int)count;
                }
            }
            CountTB.Text = "1";
        }

        private void RemoveProduct_Click(object sender, EventArgs e)
        {
            order.OrderItems.Remove(
                order.OrderItems.FirstOrDefault(o => o.Product == currentCategory.Products[ProductsLV.SelectedIndices[0]]));
        }

        private void SendOrderButton_Click(object sender, EventArgs e)
        {
            order.Time = DateTime.Now;
            ApiWrapper.SendOrder(order);
        }

        private void ShowOrderButton_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            foreach (var i in order.OrderItems)
                sb.Append($"{i.Product.Name} ({i.count} шт.) \n");

            Form prompt = new Form()
            {
                Width = 500,
                Height = 500,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Текущий заказ: ",
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = sb.ToString() };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 400, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            prompt.ShowDialog();
        }

        private void CategoryChanged()
        {
            ProductsLV.Items.Clear();
            ProductsLV.Columns.Add("Name", "Название");
            ProductsLV.Columns.Add("Price", "Цена");
            foreach(var p in currentCategory.Products)
            {
                var item = new ListViewItem(new[] { p.Name, p.Price.ToString() })
                {
                    ToolTipText = p.Description
                };
                ProductsLV.Items.Add(item);
            }
        }

        //причина существования этого костыля в том, что я не знаю как уговорить вижуалку подождать, пока сервер запускается
        private void Form1_Click(object sender, EventArgs e)
        {
            categories = ApiWrapper.GetCategories();
            foreach (var c in categories)
            {
                var btn = new Button { Text = c.Name };
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
