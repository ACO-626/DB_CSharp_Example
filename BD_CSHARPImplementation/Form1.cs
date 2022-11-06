using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD_CSHARPImplementation
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void productoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.databaseEjemploDataSet);

        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'databaseEjemploDataSet.Producto' Puede moverla o quitarla según sea necesario.
            this.productoTableAdapter.Fill(this.databaseEjemploDataSet.Producto);

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                this.productoTableAdapter.Insertar(int.Parse(textBoxCodigo.Text), textBoxProducto.Text, textBoxMarca.Text, decimal.Parse(textBoxPrecio.Text));
                MessageBox.Show("Se insertó un  nuevo registro", "Insertado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.productoTableAdapter.Fill(this.databaseEjemploDataSet.Producto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                this.productoTableAdapter.Actualizar(int.Parse(codigoTextBox.Text), productoTextBox.Text, marcaTextBox.Text, decimal.Parse(precioTextBox.Text), int.Parse(codigoLabel3.Text));
                MessageBox.Show("Se actualizó un registro", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.productoTableAdapter.Fill(this.databaseEjemploDataSet.Producto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                this.productoTableAdapter.Eliminar(int.Parse(codigoLabel3.Text));
                MessageBox.Show("Se eliminó un registro", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.productoTableAdapter.Fill(this.databaseEjemploDataSet.Producto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
