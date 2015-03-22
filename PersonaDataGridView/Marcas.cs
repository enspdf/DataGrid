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
    public partial class Marcas : Form
    {
        ClMarcas marcas = new ClMarcas();
        List<ClMarcas> listaMarcas = new List<ClMarcas>();
        public Marcas()
        {
            InitializeComponent();
            ClMarcas objetoMarcas;
            

            objetoMarcas = new ClMarcas();
            objetoMarcas.Codigo = "01";
            objetoMarcas.Marca = "HP";
            listaMarcas.Add(objetoMarcas);

            objetoMarcas = new ClMarcas();
            objetoMarcas.Codigo = "02";
            objetoMarcas.Marca = "Intel";
            listaMarcas.Add(objetoMarcas);

            objetoMarcas = new ClMarcas();
            objetoMarcas.Codigo = "03";
            objetoMarcas.Marca = "SONY";
            listaMarcas.Add(objetoMarcas);

            cbMarca.DataSource = listaMarcas;
            //cbMarca.DisplayMember = "Marca";
            //cbMarca.ValueMember = "Codigo";
        }

        private void Marcas_Load(object sender, EventArgs e)
        {
                 
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClMarcas marca = new ClMarcas();
            clpc2 pc = new clpc2();
            pc.Referencia = txtReferencia.Text;
            marca.Marca = cbMarca.SelectedItem;
            pc.Modelo = txtModelo.Text;
            pc.Tipo = cbTipo.Text;

            listaMarcas.Add(marca);
            dgDatos.DataSource = null;
            dgDatos.DataSource = listaMarcas;
            txtReferencia.Text = "";
            txtModelo.Text = "";
        }
    }
}
