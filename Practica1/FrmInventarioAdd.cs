using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1
{
    public partial class FrmInventarioAdd : Form
    {
        Boolean a;
        Inventario p;
        AreasDAO aDAO;
        public FrmInventarioAdd(Boolean a, Inventario p)
        {
            InitializeComponent();
            this.a = a;
            this.p = p;
            if(a)
            {
                aDAO = new AreasDAO();
                List<Areas> areas = aDAO.GetAreas();
                cboArea.Items.Clear();

                foreach (Areas area in areas)
                {
                    cboArea.Items.Add(area.ID_Area);
                }
            }
            else if(a==false)
            {
                aDAO = new AreasDAO();
                List<Areas> areas = aDAO.GetAreas();
                cboArea.Items.Clear();

                foreach (Areas area in areas)
                {
                    cboArea.Items.Add(area.ID_Area);
                }


                txtId.Text = p.ID_Inventario.ToString();
                txtName.Text = p.NombreCorto.ToString();
                txtColor.Text = p.Color.ToString();
                txtDescription.Text = p.Descripcion.ToString();
                txtObservaciones.Text = p.Observaciones.ToString();
                txtSerie.Text = p.Serie.ToString();
                btnAgregar.Text = "MODIFICAR";

                txtId.Enabled = false;


                int indexArea = cboArea.FindStringExact(p.Area.ToString());
                if (indexArea != -1)
                {
                    cboArea.SelectedIndex = indexArea;
                }

                int indexTipo = cboTipo.FindStringExact(p.TipoAdquisicion.ToString());
                if (indexTipo != -1)
                {
                    cboTipo.SelectedIndex = indexTipo;
                }


                DateTime fecha;
                if (DateTime.TryParseExact(p.FechaAdquisicion, "dddd, d 'de' MMMM 'de' yyyy", new CultureInfo("es-ES"), DateTimeStyles.None, out fecha))
                {
                    dtpFecha.Value = fecha;
                }
                else
                {
                    MessageBox.Show("No se pudo analizar la fecha correctamente: " + p.FechaAdquisicion);
                }
                
            }
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private bool ValidarCampos()
        {
            // Verificar que no haya campos vacíos
            if (string.IsNullOrWhiteSpace(txtId.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text) ||
                string.IsNullOrWhiteSpace(txtSerie.Text) ||
                cboArea.SelectedItem == null ||  // Verificar si un ítem está seleccionado en lugar de comprobar la colección completa
                string.IsNullOrWhiteSpace(dtpFecha.Text) ||
                cboTipo.SelectedItem == null ||  // Verificar si un ítem está seleccionado en lugar de comprobar la colección completa
                string.IsNullOrWhiteSpace(txtColor.Text) ||
                string.IsNullOrWhiteSpace(txtObservaciones.Text))
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


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                int id = Convert.ToInt32(txtId.Text);
                string nombre = txtName.Text;
                string descripcion = txtDescription.Text;
                string serie = txtSerie.Text;
                string fechaAd = dtpFecha.Text;
                int area = Convert.ToInt32(cboArea.Text);
                string observaciones = txtObservaciones.Text;
                string color = txtColor.Text;
                string tipoAd = cboTipo.Text;
                if (a)
                {
                    InventarioDAO p = new InventarioDAO();
                    if (p.insertar(id, nombre, descripcion, serie, color, fechaAd, tipoAd, observaciones, area) != -1)
                    {
                        MessageBox.Show("Asiganción agregada con éxito");
                        // Cerrar el formulario actual
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No fue posible insertar la asignación");
                    }
                }
                else
                {
                    InventarioDAO p = new InventarioDAO();
                    if (p.editar(id, nombre, descripcion, serie, color, fechaAd, tipoAd, observaciones, area) != -1)
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


        private void FrmInventarioAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
