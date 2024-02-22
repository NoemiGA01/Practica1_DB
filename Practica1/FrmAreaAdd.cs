using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Practica1
{
    public partial class FrmAreaAdd : Form
    {
        Boolean a;
        Areas p;
        InventarioDAO iDAO;
        public FrmAreaAdd(Boolean a, Areas p)
        {
            InitializeComponent();
            this.a = a;
            this.p = p;
            
            if (a == false)
            {
                iDAO = new InventarioDAO();
                List<Inventario> invent = iDAO.GetInventario();
                txtId.Text = p.ID_Area.ToString();
                txtNameA.Text = p.Nombre.ToString();
                txtUbicacion.Text = p.Ubicacion.ToString();
                btnAdd.Text = "MODIFICAR";

                txtId.Enabled = false;
            }
        }
        private bool ValidarCampos()
        {
            // Verificar que no haya campos vacíos
            if (string.IsNullOrWhiteSpace(txtId.Text) ||
                string.IsNullOrWhiteSpace(txtNameA.Text) ||
                string.IsNullOrWhiteSpace(txtUbicacion.Text))
            {
                MessageBox.Show("No se puede dejar ningún campo vacío.");
                return false;
            }

            // Verificar que txtId contiene solo números
            if (!Regex.IsMatch(txtId.Text, @"^\d+$"))
            {
                MessageBox.Show("Por favor, ingrese solo números en el campo de ID.");
                return false;
            }

            // Puedes agregar más validaciones según sea necesario

            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                int id = Convert.ToInt32(txtId.Text);
                string nombre = txtNameA.Text;
                string ubicacion = txtUbicacion.Text;
                if (a)
                {
                    AreasDAO p = new AreasDAO();
                    if (p.Insertar(id, nombre, ubicacion) != -1)
                    {
                        MessageBox.Show("Asigancion agregada con exito");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No fue posible insertar la area");
                    }
                }
                else
                {
                    AreasDAO p = new AreasDAO();
                    if (p.Editar(id, nombre, ubicacion) != -1)
                    {
                        MessageBox.Show("Asiganción editada con éxito");
                        // Cerrar el formulario actual
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No fue posible editar la asignación");
                    }
                }
            }
        }
    }
}
