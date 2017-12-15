using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace nomina
{
    public partial class btnactualizar : Form
    {
        public btnactualizar()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //boton consultar
        private void button3_Click(object sender, EventArgs e)
        {
            //muestra la consulta de la tabla detalle nomina en datagridview
            operacion oper = new operacion();
            DataTable dt = new DataTable();
            dt = oper.ExtraeData(" SELECT * FROM detalle_nomina");
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            //Esto hace una busqueda en el datagridview por el nombre
            operacion oper = new operacion();
            DataTable dt = new DataTable();
            dt = oper.ExtraeData(" SELECT * FROM detalle_nomina WHERE nombre LIKE '" + txtbuscar.Text + "%'");
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        //boton agregar
        private void btnagregar_Click(object sender, EventArgs e)
        {
            //un try catch para prevenir errores
            try
            {
                if (txtnombre.Text != null && txtcargo.Text != null && txtsbruto.Text != null && txtisr.Text != null && txtss.Text != null && txtotro.Text != null && txtdeducciones.Text != null && txtsneto.Text != null)
                {
                    //abre la conexion a la db
                    operacion oper = new operacion();

                    //hace insert a tabla detalle nomina
                    oper.ExecuteNonQuery("INSERT INTO detalle_nomina(nombre,cargo,sueldo_bruto,isr,ss,otro,total_deduccion,sueldo_neto) VALUES ('" + txtnombre.Text + "','" + txtcargo.Text + "','" + txtsbruto.Text + "','" + txtisr.Text + "','" + txtss.Text + "','" + txtotro.Text + "','" + txtdeducciones.Text + "','" + txtsneto.Text + "'); ");

                    //mensaje para cuando se guardan los datos
                    MessageBox.Show("Se almacenaron los datos", "Bien");
                }
                else
                {
                    //mensaje de error cuando no se almacenan los datos
                    MessageBox.Show("Registro Fallido no guardado", "Error");
                }

            }
            catch (SQLiteException ex)
            {

                ex.ToString();
            }
        }
        //boton eliminar
        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {

                operacion oper = new operacion();
                
                oper.ExecuteNonQuery("DELETE FROM detalle_nomina WHERE nombre LIKE  '" + txtnombre.Text + "%' ");
                MessageBox.Show("Usuario eliminado exitosamente");
               
            }
            catch (SQLiteException sqlEx)
            {

                MessageBox.Show(sqlEx.Message);

            }

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {

        }


        private void btncancelar_Click(object sender, EventArgs e)
        {
            DialogResult confirmar = MessageBox.Show("Desea salir sin guardar los cambios", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar == DialogResult.Yes)
            {
                Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow rowupdate in dataGridView1.SelectedRows)
            {
                txtnombre.Text = rowupdate.Cells[0].Value.ToString();
                txtcargo.Text = rowupdate.Cells[1].Value.ToString();
                txtsbruto.Text = rowupdate.Cells[2].Value.ToString();
                txtisr.Text = rowupdate.Cells[3].Value.ToString();
                txtss.Text = rowupdate.Cells[4].Value.ToString();
                txtotro.Text = rowupdate.Cells[5].Value.ToString();
                txtdeducciones.Text = rowupdate.Cells[6].Value.ToString();
                txtsneto.Text = rowupdate.Cells[7].Value.ToString();
                
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            operacion oper = new operacion();
            oper.ExecuteNonQuery("Update detalle_nomina set cargo='" + txtcargo.Text + "', sueldo_bruto='" + txtsbruto.Text + "', isr='" + txtisr.Text + "', ss='" + txtss.Text + "', otro='" + txtotro.Text + "', total_deduccion='" + txtdeducciones.Text + "', sueldo_neto='" + txtsneto.Text + "' where nombre='" + txtnombre.Text + "'");
            MessageBox.Show("Se actualizo correctamente");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtisr_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
