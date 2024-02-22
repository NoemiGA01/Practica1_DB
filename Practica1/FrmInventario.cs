using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1
{
    public partial class FrmInventario : Form
    {
        public FrmInventario()
        {
            InitializeComponent();
            ActualizarData();
        }

        private void ActualizarData()
        {
            InventarioDAO p = new InventarioDAO();
            dgvMostrar.DataSource = p.GetInventario();
            dgvMostrar.AllowUserToAddRows = false;
            dgvMostrar.AllowUserToDeleteRows = false;
            dgvMostrar.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvMostrar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Frm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Llamar a la función ActualizarData()
            ActualizarData();
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvMostrar.CurrentRow;
            if (selectedRow != null)
            {
                InventarioDAO p = new InventarioDAO();
                string id = selectedRow.Cells[0].Value.ToString();
                int ids = Convert.ToInt32(id);
                p.Eliminar(ids);
                MessageBox.Show("Dato eliminado");
                dgvMostrar.DataSource = null;
                dgvMostrar.DataSource = p.GetInventario();
            }
            else
            {
                MessageBox.Show("Por favor seleccione una fila para eliminar.");
            }
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMostrar.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvMostrar.SelectedRows[0];

                // Asegúrate de que estás accediendo a las celdas en el orden correcto
                Inventario p = new Inventario
                {
                    ID_Inventario = Convert.ToInt32(selectedRow.Cells[0].Value.ToString()),
                    NombreCorto = selectedRow.Cells[1].Value.ToString(),
                    Descripcion = selectedRow.Cells[2].Value.ToString(),
                    Serie = selectedRow.Cells[3].Value.ToString(),
                    Color = selectedRow.Cells[4].Value.ToString(),
                    FechaAdquisicion = selectedRow.Cells[5].Value.ToString(),
                    TipoAdquisicion = selectedRow.Cells[6].Value.ToString(),
                    Observaciones = selectedRow.Cells[7].Value.ToString(),
                    Area = Convert.ToInt32(selectedRow.Cells[8].Value.ToString())
                };



                FrmInventarioAdd frm1 = new FrmInventarioAdd(false, p);
                frm1.FormClosed += Frm1_FormClosed;
                frm1.Show();

            }
            else
            {
                MessageBox.Show("Por favor seleccione una fila para modificar.");
            }
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {

            FrmInventarioAdd frm1 = new FrmInventarioAdd(true, null);
            frm1.FormClosed += Frm1_FormClosed;
            frm1.Show();
        }
    }
}
