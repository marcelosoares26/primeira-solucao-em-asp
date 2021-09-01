using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace primeira_solucao_em_asp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyDiv.Visible = false;
                disp_data();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            {
                using (SqlConnection objConexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True"))
                {

                    {
                        using (SqlCommand cCommand = new SqlCommand())
                        { 
                            try {
                                objConexao.Open();
                                cCommand.Connection = objConexao;
                                cCommand.CommandType = CommandType.Text;
                                cCommand.CommandText = "insert into profissional values ('teste', '123224', '23123', 'sdadasdsad', '10000' )";
                                cCommand.ExecuteReader();


                                disp_data();
                        }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message);
                            }
                                objConexao.Close();
                        }
                    }
                }
            }
   


    

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(DropDownList1.SelectedValue) && DropDownList1.SelectedIndex != 0)

            {
                MyDiv.Visible = true;
                CarregarDropDownFuncionario(int.Parse(DropDownList1.SelectedValue));
            } else
            {
                MyDiv.Visible = false;

            }
        }

        private void disp_data()
        {

            {
                using (SqlConnection objConexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True"))
                {

                    {
                        using (SqlCommand cCommand = new SqlCommand())
                        {
                            try { 

                                cCommand.Connection = objConexao;
                                cCommand.CommandType = CommandType.Text;

                                cCommand.CommandText = "select * from profissional";

                                DataTable dtRetorno = new DataTable();

                                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cCommand))
                                {
                                    sqlAdapter.Fill(dtRetorno);
                                    GridView1.DataSource = dtRetorno;
                                    GridView1.DataBind();

                                    DropDownList1.DataTextField = "nomeCompleto";
                                    DropDownList1.DataValueField = "id";
                                    DropDownList1.DataSource = dtRetorno;
                                    DropDownList1.DataBind();

                                    DropDownList1.Items.Insert(0, "Selecione um funcionario");
                                    DropDownList1.SelectedIndex = 0;

                                 

                                }

                        }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message);
                            }
                                objConexao.Close();

                        }
                    }
                }
            }
         

        }

        private void CarregarDropDownFuncionario(int idProfissional)
        {
            string strInstrucao = "select * from profissional where id = @idProfissional";

            using (SqlConnection objConexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True"))
            {
                using (SqlCommand objCommand = new SqlCommand(strInstrucao, objConexao))
                {
                    if (idProfissional > 0)
                    {
                        objCommand.Parameters.AddWithValue("@idProfissional", idProfissional);
                        objConexao.Open();

                        try
                        {
                            using (SqlDataReader reader = objCommand.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
                                        SalarioText.Text = Convert.ToDecimal(reader[5].ToString()).ToString("#,##0.00");

                                    }
                                }
                                reader.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }

                        objConexao.Close();
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Double salario  = Double.Parse(SalarioText.Text.ToString());
            Double horasExtras = Double.Parse(HorasExtras.Value.ToString());


            double valorFinal = salario + (horasExtras * (salario / 100));

            Calculo.Text = "R$" + Convert.ToDecimal(valorFinal.ToString()).ToString("#,##0.00");
        }
    }
}