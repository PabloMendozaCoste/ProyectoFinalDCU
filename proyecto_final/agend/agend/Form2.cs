using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace agend
{
    public partial class Form2 : Form
    {

        private List<Contacto> Contactos = new List<Contacto>();
        private int indice = -1;
        public Form2()
        {
            InitializeComponent();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            Contacto persona = new Contacto();

            persona.Nombre = txtname.Text;
            persona.Apellido = txtlastname.Text;
            persona.Cedula = txtcedul.Text;
            persona.Numero_de_telefono = txtphone.Text;
			persona.Fecha_examen = txtdate.Text;
			persona.Por_que_quieres_entrar_a_esta_universidad = txtmodevisit.Text;
            
            if (indice > -1)
            {
                Contactos[indice] = persona;
                indice = -1;
            }
            else
            {
                Contactos.Add(persona);
                Universidades Ventana = new Universidades();
                Ventana.Show();
                this.Visible = true;
            }
            actualizavista();
            limpiacampos();
        }

        private void actualizavista()
        {
            dgvdatos.DataSource = null;
            dgvdatos.DataSource = Contactos;
            dgvdatos.ClearSelection();
        }

        private void dgvdatos_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow renglon = dgvdatos.SelectedRows[0];
            indice = dgvdatos.Rows.IndexOf(renglon);
            Contacto persona = Contactos[indice];
            txtname.Text = persona.Nombre;
            txtlastname.Text = persona.Apellido;
            txtcedul.Text = persona.Cedula;
            txtphone.Text = persona.Numero_de_telefono;
			txtdate.Text = persona.Fecha_examen;
			txtmodevisit.Text = persona.Por_que_quieres_entrar_a_esta_universidad;
            
        }

        private  void limpiacampos()
        {
            txtname.Text = null;
            txtlastname.Text = null;
            txtcedul.Text = null;
            txtphone.Text = null;
            txtmodevisit.Text = null;
            txtdate.Text = null;
            
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            if (indice > -1)
            {
                Contactos.RemoveAt(indice);
                actualizavista();
                limpiacampos();
                indice = -1;
            }

            else
            {
                MessageBox.Show("seleccione el registro al borrar");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
