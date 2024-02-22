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
    public partial class FrmArea : Form
    {
        public FrmArea()
        {
            InitializeComponent();
            ActualizarData();
        }
        private void ActualizarData()
        {
            AreasDAO p = new AreasDAO();
            dgvMostrar.DataSource = p.GetAreas();
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

        private void btnAgregarA_Click(object sender, EventArgs e)
        {
            FrmAreaAdd frm = new FrmAreaAdd(true, null);
            frm.FormClosed += Frm1_FormClosed;
            frm.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvMostrar.CurrentRow;
            if (selectedRow != null)
            {
                AreasDAO p = new AreasDAO();
                string id = dgvMostrar.SelectedRows[0].Cells[0].Value.ToString();
                int ids = Convert.ToInt32(id);
                p.Eliminar(ids);
                MessageBox.Show("Asignación eliminada");
                dgvMostrar.DataSource = null;
                dgvMostrar.DataSource = p.GetAreas();
            }
            else
            {
                MessageBox.Show("Por favor seleccione una fila para eliminar.");
            }
        }

        private void btnModificarA_Click(object sender, EventArgs e)
        {
            if (dgvMostrar.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvMostrar.SelectedRows[0];

                Areas p = new Areas();
                {
                    p.ID_Area = Convert.ToInt32(dgvMostrar.SelectedRows[0].Cells[0].Value.ToString());
                    p.Nombre = dgvMostrar.SelectedRows[0].Cells[1].Value.ToString();
                    p.Ubicacion = dgvMostrar.SelectedRows[0].Cells[2].Value.ToString();
                }

                FrmAreaAdd frm = new FrmAreaAdd(false, p);
                frm.FormClosed += Frm1_FormClosed;
                frm.Show();
            }
            else
            {
                MessageBox.Show("Por favor seleccione una fila para modificar.");
            }
        }
    }
}
