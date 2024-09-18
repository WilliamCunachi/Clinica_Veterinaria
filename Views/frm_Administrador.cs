using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clinica_Veterinaria.Reportes;

namespace Clinica_Veterinaria.Views
{
    public partial class frm_Administrador : Form
    {
        public frm_Administrador()
        {
            InitializeComponent();
        }

        private void agregarPropietarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
             frm_Propietario _frm_Propietario= new frm_Propietario();
            _frm_Propietario.ShowDialog();
            this.Show();
        }

        private void agregarMascotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Mascota _frm_Mascota = new frm_Mascota();
            _frm_Mascota.ShowDialog();
            this.Show();
        }

        private void agregarVeterinarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Veterinario _Veterinario = new frm_Veterinario();
            _Veterinario.ShowDialog();
            this.Show();
        }

        private void listaCitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Citas _frm_Citas = new frm_Citas();
            _frm_Citas.ShowDialog();
            this.Show();
        }

        private void informeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_Informe _frm_Informe = new frm_Informe();
            _frm_Informe.ShowDialog();
            this.Show();
        }
    }
}
