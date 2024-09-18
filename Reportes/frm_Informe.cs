using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinica_Veterinaria.Reportes
{
    public partial class frm_Informe : Form
    {
        public frm_Informe()
        {
            InitializeComponent();
        }

        private void frm_Informe_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'clinica_VeterinariaDataSet.Mascotas' Puede moverla o quitarla según sea necesario.
            this.mascotasTableAdapter.Fill(this.clinica_VeterinariaDataSet.Mascotas);
            // TODO: esta línea de código carga datos en la tabla 'clinica_VeterinariaDataSet.Citas' Puede moverla o quitarla según sea necesario.
            this.citasTableAdapter.Fill(this.clinica_VeterinariaDataSet.Citas);

            this.reportViewer1.RefreshReport();
        }
    }
}
