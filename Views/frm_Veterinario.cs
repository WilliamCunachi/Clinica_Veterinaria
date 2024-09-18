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
    public partial class frm_Veterinario : Form
    {
        public frm_Veterinario()
        {
            InitializeComponent();
            CargarVeterinarios();
        }
        private void CargarVeterinarios()
        {
            var veterinarios = VeterinarioController.ObtenerVeterinarios();
            dgv_Veterinarios.DataSource = veterinarios;
        }

        private void LimpiarFormulario()
        {
            txt_IdVeterinario.Clear();
            txt_NombreVeterinario.Clear();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            var veterinario = new Veterinario
            {
                Nombre = txt_NombreVeterinario.Text
            };

            VeterinarioController.AgregarVeterinario(veterinario);
            CargarVeterinarios();
            LimpiarFormulario();
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            var veterinario = new Veterinario
            {
                ID_Veterinario = int.Parse(txt_IdVeterinario.Text),
                Nombre = txt_NombreVeterinario.Text
            };

            VeterinarioController.ModificarVeterinario(veterinario);
            CargarVeterinarios();
            LimpiarFormulario();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_Veterinarios.SelectedRows.Count> 0)
            {
                var veterinario = (Veterinario)dgv_Veterinarios.SelectedRows[0].DataBoundItem;
                VeterinarioController.EliminarVeterinario(veterinario.ID_Veterinario);
                CargarVeterinarios();
                LimpiarFormulario();
            }
        }

        private void lst_Veterinarios_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void dgv_Veterinarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_Veterinarios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgv_Veterinarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var veterinario = (Veterinario)dgv_Veterinarios.Rows[e.RowIndex].DataBoundItem;
                txt_IdVeterinario.Text = veterinario.ID_Veterinario.ToString();
                txt_NombreVeterinario.Text = veterinario.Nombre;

            }
        }
    }
}
