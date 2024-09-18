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
using Clinica_Veterinaria.Views;

namespace Clinica_Veterinaria.Views
{
    public partial class frm_Citas : Form
    {
        public frm_Citas()
        {
            InitializeComponent();
            CargarCitas();
            CargarMascotas();
            CargarVeterinarios();

        }
        private void CargarMascotas()
        {
            var mascotas = MascotaController.ObtenerMascotas();
            cmb_Mascota.DataSource = mascotas;
            cmb_Mascota.DisplayMember = "Nombre"; // Mostrar solo el nombre de la mascota
        }

        private void CargarVeterinarios()
        {
            var veterinarios = VeterinarioController.ObtenerVeterinarios();
            cmb_Veterinario.DataSource = veterinarios;
            cmb_Veterinario.DisplayMember = "Nombre"; // Mostrar solo el nombre del veterinario
        }
        private void CargarCitas()
        {
            var citas = CitasController.ObtenerCitas();
            dgv_Cita.DataSource = citas;


        }

        private void LimpiarFormulario()
        {
            txt_IdCita.Clear();
            dtp_FechaCita.Value = DateTime.Now;
            cmb_Mascota.SelectedIndex = -1;
            cmb_Veterinario.SelectedIndex = -1;
        }
        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            var cita = new Cita
            {
                ID_Mascota = ((Mascota)cmb_Mascota.SelectedItem).ID_Mascota,
                ID_Veterinario = ((Veterinario)cmb_Veterinario.SelectedItem).ID_Veterinario,
                Fecha_Cita = dtp_FechaCita.Value
            };

            CitasController.AgregarCita(cita);
            CargarCitas();
            LimpiarFormulario();
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            var cita = new Cita
            {
                ID_Cita = int.Parse(txt_IdCita.Text),
                ID_Mascota = ((Mascota)cmb_Mascota.SelectedItem).ID_Mascota,
                ID_Veterinario = ((Veterinario)cmb_Veterinario.SelectedItem).ID_Veterinario,
                Fecha_Cita = dtp_FechaCita.Value
            };

            CitasController.ModificarCita(cita);
            CargarCitas();
            LimpiarFormulario();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_Cita.SelectedRows.Count > 0)
            {
                var cita = (Cita)dgv_Cita.SelectedRows[0].DataBoundItem;
                CitasController.EliminarCita(cita.ID_Cita);
                CargarCitas();
                LimpiarFormulario();
            }
        }

        private void lst_Citas_DoubleClick(object sender, EventArgs e)
        {
        }

        private void dgv_Cita_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var cita = (Cita)dgv_Cita.Rows[e.RowIndex].DataBoundItem;
                txt_IdCita.Text = cita.ID_Cita.ToString();
                dtp_FechaCita.Value = cita.Fecha_Cita;
                foreach (Mascota mascota in cmb_Mascota.Items)
                {
                    if (mascota.ID_Mascota == cita.ID_Mascota)
                    {
                        cmb_Mascota.SelectedItem = mascota;
                        break;
                    }
                }

                foreach (Veterinario veterinario in cmb_Veterinario.Items)
                {
                    if (veterinario.ID_Veterinario == cita.ID_Veterinario)
                    {
                        cmb_Veterinario.SelectedItem = veterinario;
                        break;
                    }
                }
            }
        }

    }
}
