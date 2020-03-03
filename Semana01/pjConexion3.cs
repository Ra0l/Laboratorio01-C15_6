using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Semana01
{
    public partial class lblCantidad : Form
    {
        public lblCantidad()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Leon"].ConnectionString);

        public void ListaProductos()
        {
            using(SqlDataAdapter df = new  SqlDataAdapter("Usp_ListaProductos_Neptuno", cn))
            {
                df.SelectCommand.CommandType = CommandType.StoredProcedure;
                using(DataSet Da= new DataSet())
                {
                    df.Fill(Da, "Productos");
                    dgProductos.DataSource = Da.Tables["Productos"];
                    label3.Text = Da.Tables["Productos"].Rows.Count.ToString();
                }
            }
        }

        private void pjConexion3_Load(object sender, EventArgs e)
        {
            ListaProductos();
        }
    }
}
