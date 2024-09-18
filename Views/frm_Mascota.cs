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
    public partial class frm_Mascota : Form
    {
        public frm_Mascota()
        {
            InitializeComponent();
            CargarMascotas();
            CargaPropietario();
        }
        private void CargarMascotas()
        {
            var mascotas = MascotaController.ObtenerMascotas();
            dgv_Mascotas.DataSource = mascotas;
        }
        private void CargaPropietario()
        {
            var IdPropietarios = PropietarioController.ObtenerPropietarios();
            cmb_IdPropietario.DataSource = IdPropietarios;
            cmb_IdPropietario.DisplayMember = "ID_Propietario";
        }

        private void LimpiarFormulario()
        {
            txt_IdMascota.Clear();
            txt_NombreMascota.Clear();
            cmb_IdPropietario.SelectedIndex = -1;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            var mascota = new Mascota
            {
                Nombre = txt_NombreMascota.Text,
                ID_Propietario = ((Propietario)cmb_IdPropietario.SelectedItem).ID_Propietario,// Asegúrate de que el ID del propietario esté correcto
            };

            MascotaController.AgregarMascota(mascota);
            CargarMascotas();
            LimpiarFormulario();

        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            var mascota = new Mascota
            {
                ID_Mascota = int.Parse(txt_IdMascota.Text),
                Nombre = txt_NombreMascota.Text,
                ID_Propietario = ((Propietario)cmb_IdPropietario.SelectedItem).ID_Propietario,
            };

            MascotaController.ModificarMascota(mascota);
            CargarMascotas();
            LimpiarFormulario();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_Mascotas.SelectedRows.Count >0)
            {
                var mascota = (Mascota)dgv_Mascotas.SelectedRows[0].DataBoundItem;
                MascotaController.EliminarMascota(mascota.ID_Mascota);
                CargarMascotas();
                LimpiarFormulario();
            }
        }

        private void lst_Mascotas_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void dgv_Mascotas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var mascota = (Mascota)dgv_Mascotas.Rows[e.RowIndex].DataBoundItem;
                txt_IdMascota.Text = mascota.ID_Mascota.ToString();
                txt_NombreMascota.Text = mascota.Nombre.ToString();
                foreach (Propietario propietario in cmb_IdPropietario.Items)
                {
                    if (propietario.ID_Propietario== mascota.ID_Propietario)
                    {
                        cmb_IdPropietario.SelectedItem = propietario;
                        break;
                    }
                }
            }
        }

        private void dgv_Mascotas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
