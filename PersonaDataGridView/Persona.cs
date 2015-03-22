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
    public partial class Persona : Form
    {
        List<ClPersona> ListaPersonas = new List<ClPersona>();
        public Persona()
        {
            InitializeComponent();
            this.CenterToScreen();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClPersona oPersona = new ClPersona();

            oPersona.Nombre = txtNombre.Text;
            oPersona.Identificacion = int.Parse(txtidentificacion.Text);
            oPersona.FechaNacimiento = dtFechaNacimiento.Text;

            ListaPersonas.Add(oPersona);
            dgDatos.DataSource = null;
            dgDatos.DataSource = ListaPersonas;
            txtNombre.Text = "";
            txtidentificacion.Text = "";
        }

        private void dgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;
            ClPersona personaSeleccionada = ((ClPersona)(dgDatos.Rows[indice].DataBoundItem));
            txtNombre.Text = personaSeleccionada.Nombre;
            txtidentificacion.Text = personaSeleccionada.Identificacion.ToString();
            dtFechaNacimiento.Text = personaSeleccionada.FechaNacimiento;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int indicePersona = ListaPersonas.FindIndex(F => F.Identificacion == int.Parse(txtidentificacion.Text));
            ClPersona PersonaEditar = ListaPersonas[indicePersona];
            PersonaEditar.Nombre = txtNombre.Text;

            ListaPersonas[indicePersona] = PersonaEditar;
            dgDatos.DataSource = null;
            dgDatos.DataSource = ListaPersonas;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int indicePersona = ListaPersonas.FindIndex(F => F.Identificacion == int.Parse(txtidentificacion.Text));
            ClPersona PersonaEliminar = ListaPersonas[indicePersona];

            ListaPersonas.Remove(PersonaEliminar);
            dgDatos.DataSource = null;
            dgDatos.DataSource = ListaPersonas;
            txtNombre.Text = "";
            txtidentificacion.Text = "";
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                List<ClPersona> resultadoBusqueda = ListaPersonas.Where(w => w.Nombre.Contains(txtNombre.Text)).ToList();
                dgDatos.DataSource = null;
                dgDatos.DataSource = resultadoBusqueda;
            }
            else if (txtidentificacion.Text == "")
            {
                //List<ClPersona> resultadoBusqueda = ListaPersonas.Where(a => a.)
                dgDatos.DataSource = null;
                dgDatos.DataSource = ListaPersonas;
            }
            else
            {
                MessageBox.Show("No se encontraron resultados");
            }
        }
    }
}
