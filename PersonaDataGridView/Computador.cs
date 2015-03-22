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
    public partial class Computador : Form
    {
        ClComputador Computadores = new ClComputador();
        
        List<ClComputador> Marcas = new List<ClComputador>();
        List<ClComputador> DatosGrid = new List<ClComputador>();
        
        public Computador()
        {
            InitializeComponent();
            this.CenterToScreen();
            ClComputador objetoMarcas;            

            objetoMarcas = new ClComputador();
            objetoMarcas.Marca = "HP";
            objetoMarcas.Codigo = "01";
            Marcas.Add(objetoMarcas);

            objetoMarcas = new ClComputador();
            objetoMarcas.Marca = "Intel";
            objetoMarcas.Codigo = "02";
            Marcas.Add(objetoMarcas);

            objetoMarcas = new ClComputador();
            objetoMarcas.Marca = "SONY";
            objetoMarcas.Codigo = "03";
            Marcas.Add(objetoMarcas);

            cbMarca.DataSource = Marcas;
            cbMarca.DisplayMember = "Marca";
            //cbMarca.ValueMember = "Codigo";
        }

        private void Marcas_Load(object sender, EventArgs e)
        {
                 
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            ClComputador marca = new ClComputador();
            marca.Referencia = txtReferencia.Text;
            marca.Marca = cbMarca.Text;
            marca.Modelo = txtModelo.Text;
            marca.Tipo = cbTipo.Text;

            DatosGrid.Add(marca);
            dgDatos.DataSource = null;
            dgDatos.DataSource = DatosGrid;
            txtReferencia.Text = "";
            txtModelo.Text = "";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int identificador = DatosGrid.FindIndex(C => C.Referencia == txtReferencia.Text);
            ClComputador EditarComputadores = DatosGrid[identificador];
            EditarComputadores.Modelo = txtModelo.Text;
            EditarComputadores.Marca = cbMarca.Text;
            EditarComputadores.Tipo = cbTipo.Text;

            DatosGrid[identificador] = EditarComputadores;
            dgDatos.DataSource = null;
            dgDatos.DataSource = DatosGrid;
        }

        private void dgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int identificador = e.RowIndex;
            ClComputador ComputadorSeleccionado = ((ClComputador)(dgDatos.Rows[identificador].DataBoundItem));
            txtReferencia.Text = ComputadorSeleccionado.Referencia;
            txtModelo.Text = ComputadorSeleccionado.Modelo;
            cbMarca.Text = ComputadorSeleccionado.Marca;
            cbTipo.Text = ComputadorSeleccionado.Tipo;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int identificador = DatosGrid.FindIndex(C => C.Referencia == txtReferencia.Text);
            ClComputador EliminarComputadores = DatosGrid[identificador];

            DatosGrid.Remove(EliminarComputadores);
            dgDatos.DataSource = null;
            dgDatos.DataSource = DatosGrid;
            txtModelo.Text = "";
            txtReferencia.Text = "";
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (txtReferencia.Text != "")
            {
                List<ClComputador> Busquedas = DatosGrid.Where(w => w.Referencia.Contains(txtReferencia.Text)).ToList();
                dgDatos.DataSource = null;
                dgDatos.DataSource = DatosGrid;
            }
            else if (txtModelo.Text != "")
            {
                
            }
            else
            {

            }
        }
    }
}
