using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormAppEFCore.Services;
using WinFormAppEFCore.Data;
using WinFormAppEFCore.Models;

namespace WinFormAppEFCore.Forms
{
    public partial class ProductsOperations : Form
    {
        StoreDBContext context = new StoreDBContext();
        ProductServices productsServices = new ProductServices();
        CategoryServices categoryServices = new CategoryServices();
        Products selectedProduct = null;
       
        public ProductsOperations()
        {
            InitializeComponent();
        }

        private void ProductsOperations_Load(object sender, EventArgs e)
        {
            FillProductsDataGridView();

            cmbProductCategory.DataSource = categoryServices.GetCategories();
            cmbProductCategory.DisplayMember = "Name";
            cmbProductCategory.ValueMember = "Id";

            FillProductsComboBox();
        }

        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            Products product = new Products();

            product.Name = txtProductName.Text;
            product.Price = (float)Convert.ToDecimal(txtProductPrice.Text); //?
            product.Description = txtProductDescription.Text;
            product.CategoryId = cmbProductCategory.SelectedIndex + 1; //zerobase (index + 1)=categoryId
           
            productsServices.AddProduct(product);
            FillProductsDataGridView();
            FillProductsComboBox();
        }

        private void cmbProductDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int selectedProductId = (int)cmbProductDetails.SelectedValue;

            var product = productsServices.GetProductsById(selectedProductId);

            selectedProduct = product;

            txtProductName.Text = product.Name;
            txtProductPrice.Text = (product.Price).ToString();
            txtProductDescription.Text = product.Description;
            cmbProductCategory.Text = product.CategoryName;
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            selectedProduct.Name = txtProductName.Text;
            selectedProduct.Price = (float)Convert.ToDecimal(txtProductPrice.Text);
            selectedProduct.Description = txtProductDescription.Text;
            selectedProduct.CategoryId = cmbProductCategory.SelectedIndex + 1;

            productsServices.UpdateProduct(selectedProduct);
            FillProductsDataGridView();
            FillProductsComboBox();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            productsServices.DeleteProduct(selectedProduct);
            FillProductsDataGridView();
            FillProductsComboBox();
        }

        public void FillProductsDataGridView()
        {
            dgvProductsOperations.DataSource = productsServices.GetProducts();
            this.dgvProductsOperations.Columns["Category"].Visible = false;
            this.dgvProductsOperations.Columns["CategoryId"].Visible = false;
        }


        /// <summary>
        /// CRUD operasyonlarından sonra bu liste güncellenmelidir. Bu nedenle bu methoda ihtiyaç duyulmuştur.
        /// </summary>
        public void FillProductsComboBox()
        {
            cmbProductDetails.DataSource = context.Products.ToList();
            cmbProductDetails.DisplayMember = "Name";
            cmbProductDetails.ValueMember = "Id";
        }
       
    }
}
