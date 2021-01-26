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
using WinFormAppEFCore.Services;

namespace WinFormAppEFCore
{
    public partial class store : Form
    {
        StoreDBContext context = new StoreDBContext();
        ProductServices productsServices = new ProductServices();
        CategoryServices categoryServices = new CategoryServices();
        Form T;
        public store()
        {
            InitializeComponent();
        }
        private void store_Load(object sender, EventArgs e)
        {
            //Filling datagridview with products
            dgvProducts.DataSource = productsServices.GetProducts();
            this.dgvProducts.Columns["Category"].Visible = false;
            this.dgvProducts.Columns["CategoryId"].Visible = false;

            //Filling Combobox with categories
            cmbCategories.DataSource = categoryServices.GetCategories();
            cmbCategories.DisplayMember = "Name";
            cmbCategories.ValueMember = "Id";
        }

      

        private void cmbCategories_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //When a category selected, Display the selected Category's products.
            int selectedCategoryId = (int)cmbCategories.SelectedValue;
            dgvProducts.DataSource = productsServices.GetProductsByCategory(selectedCategoryId);
            this.dgvProducts.Columns["Category"].Visible = false;
            this.dgvProducts.Columns["CategoryId"].Visible = false;
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if(Application.OpenForms["AdminLogin"]!=null)
            {
                T = Application.OpenForms["AdminLogin"];
                T.Focus();
            }
            else
            {
                T = new AdminLogin();
                T.StartPosition = FormStartPosition.CenterScreen;
                T.Show();
            }
        }

    }
}
