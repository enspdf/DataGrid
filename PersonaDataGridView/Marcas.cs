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
            this.CenterToScreen();
            ClMarcas objetoMarcas;            

            objetoMarcas = new ClMarcas();
            objetoMarcas.Marca = "HP";
            objetoMarcas.Codigo = "01";            
            listaMarcas.Add(objetoMarcas);

            objetoMarcas = new ClMarcas();
            objetoMarcas.Marca = "Intel";
            objetoMarcas.Codigo = "02";            
            listaMarcas.Add(objetoMarcas);

            objetoMarcas = new ClMarcas();
            objetoMarcas.Marca = "SONY";
            objetoMarcas.Codigo = "03";            
            listaMarcas.Add(objetoMarcas);

            cbMarca.DataSource = listaMarcas;
            cbMarca.DisplayMember = "Marca";
            //cbMarca.ValueMember = "Codigo";
        }

        private void Marcas_Load(object sender, EventArgs e)
        {
                 
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            List<ClMarcas> marcas = new List<ClMarcas>();
            ClMarcas marca = new ClMarcas();
            marca.Referencia = txtReferencia.Text;
            marca.Marca = cbMarca.Text;
            marca.Modelo = txtModelo.Text;
            marca.Tipo = cbTipo.Text;

            marcas.Add(marca);
            dgDatos.DataSource = null;
            dgDatos.DataSource = marcas;
            txtReferencia.Text = "";
            txtModelo.Text = "";
        }
    }
}
