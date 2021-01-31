using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormAppEFCore.Data;
using WinFormAppEFCore.Models;
using WinFormAppEFCore.Services;

namespace WinFormAppEFCore.Forms
{
    public partial class CategoriesOperations : Form
    {
        StoreDBContext context = new StoreDBContext();
        CategoryServices categoryServices = new CategoryServices();
        Categories selectedCategory;
        public CategoriesOperations()
        {
            InitializeComponent();
        }

        private void CategoriesOperations_Load(object sender, EventArgs e)
        {
            FillCategoriesDataGridView();
            FillCategoriesComboBox();
        }


        public void FillCategoriesDataGridView()
        {
            dgvCategories.DataSource = categoryServices.GetCategories();
        }

        public void FillCategoriesComboBox()
        {
            cmbCategoryOperations.DataSource = context.Categories.ToList();
            cmbCategoryOperations.DisplayMember = "Name";
            cmbCategoryOperations.ValueMember = "Id";
        }

        private void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            Categories category = new Categories();
            category.Name = txtCategoryName.Text;
            if (string.IsNullOrEmpty(category.Name))
            {
                MessageBox.Show("Please fill the required fields", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Categories existingCategory = context.Categories.SingleOrDefault(x => x.Name == category.Name);


                if (existingCategory!=null)
                {
                    MessageBox.Show("The category you want to add is in the list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                   
                    int returnvalue = categoryServices.AddCategory(category);

                    if (returnvalue > 0)
                    {
                        MessageBox.Show("Category added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult dialogResult = MessageBox.Show("Do you want to add new item?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialogResult == DialogResult.No)
                        {

                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Category could not be added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            FillCategoriesDataGridView();
            FillCategoriesComboBox();
        }

        private void btnCategoyDelete_Click(object sender, EventArgs e)
        {
            categoryServices.DeleteCategory(selectedCategory);
            FillCategoriesDataGridView();
            FillCategoriesComboBox();
        }

        private void btnCategoryUpdate_Click(object sender, EventArgs e)
        {
            selectedCategory.Name = txtCategoryName.Text;
            categoryServices.UpdateCategory(selectedCategory);
            FillCategoriesDataGridView();
            FillCategoriesComboBox();
        }

        private void cmbCategoryOperations_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int selectedCategoryId = (int)cmbCategoryOperations.SelectedValue;

            var category = categoryServices.GetCategoriesById(selectedCategoryId);

            selectedCategory = category;
            txtCategoryName.Text = category.Name;
        }
    }
}
