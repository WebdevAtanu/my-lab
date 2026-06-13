using System;
using System.Data;
using System.Windows.Forms;

namespace winform_app
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
        }

        private void App_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                DataTable dt = ProductService.GetAllProducts();

                if (dt != null)
                {
                    dgvProducts.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                Product product = new Product
                {
                    ProductName = txtProductName.Text,
                    Description = txtDescription.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    Quantity = int.Parse(txtQuantity.Text)
                };

                if (ProductService.AddProduct(product))
                {
                    MessageBox.Show("Product added successfully!");
                    ClearInputs();
                    LoadProducts();
                }
                else
                {
                    MessageBox.Show("Error adding product!");
                }
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to update!");
                return;
            }

            if (ValidateInputs())
            {
                int productId = Convert.ToInt32(
                    dgvProducts.SelectedRows[0].Cells["ProductID"].Value
                );

                Product product = new Product
                {
                    ProductID = productId,
                    ProductName = txtProductName.Text,
                    Description = txtDescription.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    Quantity = int.Parse(txtQuantity.Text)
                };

                if (ProductService.UpdateProduct(product))
                {
                    MessageBox.Show("Product updated successfully!");
                    ClearInputs();
                    LoadProducts();
                }
                else
                {
                    MessageBox.Show("Error updating product!");
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to delete!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this product?",
                "Confirm Delete",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                int productId = Convert.ToInt32(
                    dgvProducts.SelectedRows[0].Cells["ProductID"].Value
                );

                if (ProductService.DeleteProduct(productId))
                {
                    MessageBox.Show("Product deleted successfully!");
                    ClearInputs();
                    LoadProducts();
                }
                else
                {
                    MessageBox.Show("Error deleting product!");
                }
            }
        }

        private void DgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

                txtProductName.Text = row.Cells["ProductName"].Value?.ToString() ?? "";
                txtDescription.Text = row.Cells["Description"].Value?.ToString() ?? "";
                txtPrice.Text = row.Cells["Price"].Value?.ToString() ?? "";
                txtQuantity.Text = row.Cells["Quantity"].Value?.ToString() ?? "";
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Product Name is required!");
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Invalid Price format!");
                return false;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Invalid Quantity format!");
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            txtProductName.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();

            dgvProducts.ClearSelection();
        }
    }
}