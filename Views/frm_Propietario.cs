using Clinica_Veterinaria.Controllers;
using Clinica_Veterinaria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinica_Veterinaria.Views
{
    public partial class frm_Propietario : Form
    {
        public frm_Propietario()
        {
            InitializeComponent();
            CargarPropietarios();
            
        }
        private void CargarPropietarios()
        {
            var propietarios = PropietarioController.ObtenerPropietarios();
            dgv_Propietarios.DataSource = propietarios;
        }
        private void LimpiarFormulario()
        {
            txt_IdPropietario .Clear();
            txt_Nombre.Clear();
        }
       

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            var propietario = new Propietario
            {
                Nombre = txt_Nombre.Text
            };

            PropietarioController.AgregarPropietario(propietario);
            CargarPropietarios();
            LimpiarFormulario();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila
            if (dgv_Propietarios.SelectedRows.Count > 0)
            {
                // Obtener el objeto seleccionado y verificar su tipo
                var propietario = dgv_Propietarios.SelectedRows[0].DataBoundItem as Propietario;

                if (propietario != null)
                {
                    // Eliminar el propietario solo si se obtuvo correctamente
                    PropietarioController.EliminarPropietario(propietario.ID_Propietario);
                    CargarPropietarios();
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo obtener el propietario seleccionado. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un propietario para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            var propietario = new Propietario
            {
                ID_Propietario = int.Parse(txt_IdPropietario.Text),
                Nombre = txt_Nombre.Text
            };

            PropietarioController.ModificarPropietario(propietario);
            CargarPropietarios();
            LimpiarFormulario();
        }

        private void lst_Propietario_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void dgv_Propietarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var propietario = (Propietario)dgv_Propietarios.Rows[e.RowIndex].DataBoundItem;
                txt_IdPropietario.Text = propietario.ID_Propietario.ToString();
                txt_Nombre.Text = propietario.Nombre;
            }
        }
    }
}
