using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonaDataGridView
{
    public partial class Universidad : Form
    {
        List<ClMunicipio> Municipios = new List<ClMunicipio>();
        List<ClUniversidad> DatosUniversidad = new List<ClUniversidad>();
        public Universidad()
        {
            InitializeComponent();
            this.CenterToScreen();
            ClMunicipio ObjetosMunicipios;

            ObjetosMunicipios = new ClMunicipio();
            ObjetosMunicipios.Municipio = "Antioquia";
            Municipios.Add(ObjetosMunicipios);

            ObjetosMunicipios = new ClMunicipio();
            ObjetosMunicipios.Municipio = "Amazonas";
            Municipios.Add(ObjetosMunicipios);

            ObjetosMunicipios = new ClMunicipio();
            ObjetosMunicipios.Municipio = "Arauca";
            Municipios.Add(ObjetosMunicipios);

            ObjetosMunicipios = new ClMunicipio();
            ObjetosMunicipios.Municipio = "Atlantico";
            Municipios.Add(ObjetosMunicipios);

            ObjetosMunicipios = new ClMunicipio();
            ObjetosMunicipios.Municipio = "Cesar";
            Municipios.Add(ObjetosMunicipios);

            ObjetosMunicipios = new ClMunicipio();
            ObjetosMunicipios.Municipio = "Caldas";
            Municipios.Add(ObjetosMunicipios);

            ObjetosMunicipios = new ClMunicipio();
            ObjetosMunicipios.Municipio = "Bolivar";
            Municipios.Add(ObjetosMunicipios);

            cbMunicipio.DataSource = Municipios;
            cbMunicipio.DisplayMember = "Municipio";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClUniversidad OUniversidad = new ClUniversidad();
            OUniversidad.Nit = txtNit.Text;
            OUniversidad.Nombre = txtNombre.Text;
            OUniversidad.Municipio = cbMunicipio.Text;
            OUniversidad.Direccion = txtDireccion.Text;

            DatosUniversidad.Add(OUniversidad);
            dgDatos.DataSource = null;
            dgDatos.DataSource = DatosUniversidad;
            txtNit.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int identificador = DatosUniversidad.FindIndex(U => U.Nit == txtNit.Text);
            ClUniversidad EditarUniversidades = DatosUniversidad[identificador];
            EditarUniversidades.Nombre = txtNombre.Text;
            EditarUniversidades.Municipio = cbMunicipio.Text;
            EditarUniversidades.Direccion = txtDireccion.Text;

            DatosUniversidad[identificador] = EditarUniversidades;
            dgDatos.DataSource = null;
            dgDatos.DataSource = DatosUniversidad;
        }

        private void dgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int identificador = e.RowIndex;
            ClUniversidad UniversidadSeleccionada = ((ClUniversidad)(dgDatos.Rows[identificador].DataBoundItem));
            txtNit.Text = UniversidadSeleccionada.Nit;
            txtNombre.Text = UniversidadSeleccionada.Nombre;
            cbMunicipio.Text = UniversidadSeleccionada.Municipio;
            txtDireccion.Text = UniversidadSeleccionada.Direccion;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int identificador = DatosUniversidad.FindIndex(U => U.Nit == txtNit.Text);
            ClUniversidad EliminarUniversidades = DatosUniversidad[identificador];

            DatosUniversidad.Remove(EliminarUniversidades);
            dgDatos.DataSource = null;
            dgDatos.DataSource = DatosUniversidad;
            txtNit.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                List<ClUniversidad> Busquedas = DatosUniversidad.Where(x => x.Nombre.Contains(txtNombre.Text)).ToList();
                dgDatos.DataSource = null;
                dgDatos.DataSource = Busquedas;
            }
            /*else if (txtNit.Text == "")
            {
                List<ClUniversidad> Busquedas = DatosUniversidad.Where(a => a.Nit.Contains(txtNit.Text)).ToList();
                dgDatos.DataSource = null;
                dgDatos.DataSource = Busquedas;
            }*/
            else
            {
                //MessageBox.Show("No se encontraron resultados");
                dgDatos.DataSource = null;
                dgDatos.DataSource = DatosUniversidad;
            }
        }
    }
}
