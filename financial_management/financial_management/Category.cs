using financial_management.DTO;
using financial_management.Models;
using financial_management.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace financial_management
{
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();
        }

        private void SaveCategory(object sender, EventArgs e)
        {

            String categoryName = txtCategoryName.Text;
            if (categoryName == null || categoryName == String.Empty)
            {

                MessageBox.Show("Name Can't be Empty!", "Category", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Save new category
            CategoryDTO categoryDTO = new CategoryDTO();
            categoryDTO.Name = categoryName;

            // Server request
            CategoryModel categoryModel = new CategoryModel();
            categoryModel.CreateCategory(categoryDTO);

            MessageBox.Show("Category successfully added!", "Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshListView();
            txtCategoryName.Text = null;
        }

        private void Load_Categories(object sender, EventArgs e)
        {
            RefreshListView();
        }

        public void RefreshListView()
        {
            CategoryModel categoryModel = new CategoryModel();
            lsCategories.Items.Clear();
            foreach (CategoryDTO categoryDTO in categoryModel.GetCategories())
            {
                string[] items = new string[2];
                items[0] = categoryDTO.Id.ToString();
                items[1] = categoryDTO.Name.ToString();

                ListViewItem listViewItem = new ListViewItem(items);
                lsCategories.Items.Add(listViewItem);
            };
            btnDelete.Enabled = false;

        }

        private void Enabled_Selected(object sender, EventArgs e)
        {
            if (lsCategories.SelectedItems.Count == 1)
            {
                btnDelete.Enabled = true;
            }
        }

        private void Remove_Category(object sender, EventArgs e)
        {
            int id = int.Parse(lsCategories.SelectedItems[0].SubItems[0].Text);

            // Server request
            CategoryModel categoryModel = new CategoryModel();
            AllCategoryResponse response = categoryModel.DeleteCategory(id);


            if (response.Sucess)
            {
                MessageBox.Show(response.Discription, "Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(response.Discription, "Category", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            RefreshListView();
        }
    }
}
