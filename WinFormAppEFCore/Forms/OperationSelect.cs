using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormAppEFCore.Forms;

namespace WinFormAppEFCore
{
    public partial class OperationSelect : Form
    {
        Form T;
        public OperationSelect()
        {
            InitializeComponent();
        }

        private void btnProductOperations_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ProductsOperations"] != null)
            {
                T = Application.OpenForms["ProductsOperations"];
                T.Focus();
                Close();
            }
            else
            {
                T = new ProductsOperations();
                T.StartPosition = FormStartPosition.CenterScreen;
                T.Show();
                Close();
            }
        }

        private void btnCategoryOperations_Click(object sender, EventArgs e)
        {
            if(Application.OpenForms["CategoriesOperations"] != null)
            {
                T = Application.OpenForms["CategoriesOperations"];
                T.Focus();
                Close();
            }
            else
            {
                T = new CategoriesOperations();
                T.StartPosition = FormStartPosition.CenterScreen;
                T.Show();
                Close();
            }
        }
    }
}
