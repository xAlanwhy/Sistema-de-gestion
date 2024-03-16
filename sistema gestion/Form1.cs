using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace sistema_gestion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server = GABIMISA-GAMING; database = restaurante; integrated security = true ");
            conn.Open();
            {

                string nombre = textBox1.Text;
                string stock = textBox2.Text;
                string descripcion = textBox3.Text;

                // Utiliza parámetros para evitar problemas de seguridad y errores tipográficos.
                string cadena = "INSERT INTO inventario (nombre, stock, descripcion) VALUES (@nombre, @stock, @descripcion)";


                SqlCommand comando = new SqlCommand(cadena, conn);

                // Agrega los valores de los parámetros.
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@stock", stock);
                comando.Parameters.AddWithValue("@descripcion", descripcion);


                int rowsAffected = comando.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Registro exitoso");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
                else
                {
                    MessageBox.Show("No se pudo insertar el registro.");
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_VisibleChanged(object sender, EventArgs e)
        {



            SqlConnection conn = new SqlConnection("server = GABIMISA-GAMING; database = restaurante; integrated security = true ");
            conn.Open();


            string cadena = "SELECT codigo,nombre, stock, descripcion FROM inventario";
            SqlCommand comando = new SqlCommand(cadena, conn);
            SqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {
                string codigo = registro["codigo"].ToString();
                listBox1.Items.Add("Código: " + codigo);

                string nombre = registro["nombre"].ToString();
                listBox1.Items.Add("nombre: " + nombre);

                string descripcion = registro["descripcion"].ToString();
                listBox1.Items.Add("Descripción: " + descripcion);

                string stock = registro["stock"].ToString();
                listBox1.Items.Add("stock: " + stock);

                listBox1.Items.Add(""); // Espacio en blanco para separar registros
            }

            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("No existen registros");
            }
            conn.Close();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server = GABIMISA-GAMING; database = restaurante; integrated security = true ");
            conn.Open();


            string nombre = textBox1.Text;
            string stock = textBox2.Text;
            string descripcion = textBox3.Text;


            string cadena = "update inventario set nombre = '" + nombre + "', descripcion = '" + descripcion + "', stock = '" + stock + "' ";

            SqlCommand comando = new SqlCommand(cadena, conn);
            int cant;
            cant = comando.ExecuteNonQuery();

            if (cant == 1)
            {
                MessageBox.Show("Registro modificado");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

            }
            else
            {
                MessageBox.Show("No existe registro");
            }

            conn.Close();


        }



        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server = GABIMISA-GAMING; database = restaurante; integrated security = true ");
            conn.Open();

            string cadena = "SELECT  nombre, stock, descripcion FROM inventario";
            SqlCommand comando = new SqlCommand(cadena, conn);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {


                textBox1.AppendText(registro["nombre"].ToString());

                textBox3.AppendText(registro["descripcion"].ToString());

                textBox2.AppendText(registro["stock"].ToString());









            }
            else
            {
                MessageBox.Show("No existe este registro");
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server = GABIMISA-GAMING; database = restaurante; integrated security = true ");
            conn.Open();

            int flag = 0;
            string cadena = "delete from inventario where nombre = '" + textBox1.Text + "' ";
            SqlCommand comando = new SqlCommand(cadena, conn);
            flag = comando.ExecuteNonQuery();

            if (flag == 1)
            {
                MessageBox.Show("Se eliminó correctamente");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

            }
            else
            {
                MessageBox.Show("No se encontró");
            }


            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            menu ventana = new menu();
            ventana.Show();


            this.Hide();


        }
    }

    
}
    

