using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AgendaMedica
{
    public partial class AgendaConsulta : Form
    {
        public AgendaConsulta()
        {
            InitializeComponent();
        }

        private void cadastrarFuncionario(string nmNome, string dtNascimento, string dsEmail, string nrTelefone, string dsEndereco)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = "Password=info211;Persist Security Info=True;User ID=sa;Initial Catalog=AgendaMedica;Data Source=LAB-08-02";
            conexao.Open();
            string insertFuncionario = string.Concat("insert into tb_funcionario (nmFuncioario,dsEmail,nrTelefone,dtNascimento,dsEndereco) values ('",nmNome,"','",dsEmail,"','",nrTelefone,"','",dtNascimento,"','",dsEndereco,"')");
            SqlCommand comandoSql = new SqlCommand(insertFuncionario, conexao);
            comandoSql.ExecuteNonQuery();

            conexao.Close();

       }

        private void cadastrarCliente(string nmCliente, string dtNascimento, string dsEmail, string nrTelefone, string dsEndereco, string nrCPF, int idFuncionario) 
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = "Password=info211;Persist Security Info=True;User ID=sa;Initial Catalog=AgendaMedica;Data Source=LAB-08-02";
            conexao.Open();
            string insertCliente = string.Concat("insert into tb_clientes (nmCliente,nrCPF,dsEmail,dtNascimento, dsEndereco,nrTelefone,id_funcionario) values ('",nmCliente,"', '",nrCPF,"', '",dsEmail,"', '",nrTelefone,"', '",dtNascimento,"', '",dsEndereco,"', '",idFuncionario,"')");
            SqlCommand comandoSql = new SqlCommand(insertCliente, conexao);
            comandoSql.ExecuteNonQuery();
            conexao.Close();
        }

        private void cadastrarConsulta(int id_cliente, int id_funcionario, string dtConsulta, string hrConsulta, string nmMedico) 
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = "Password=info211;Persist Security Info=True;User ID=sa;Initial Catalog=AgendaMedica;Data Source=LAB-08-02";
            conexao.Open();
            string inserirConsulta = string.Concat("insert into tb_consulta(id_cliente,id_funcionario,dtConsulta,hrConsulta,nmMedico) values ('",id_cliente,"', '",id_funcionario,"', '",dtConsulta,"', '",hrConsulta,"', '",nmMedico,"')");
            SqlCommand comandoSql = new SqlCommand(inserirConsulta, conexao);
            comandoSql.ExecuteNonQuery();
            conexao.Close();
        }


        private void limparCampos() 
        {
            txtCpfCliente.Text = "";
            txtDataConsulta.Text = "";
            txtdsEmail.Text = "";
            txtdsEndereco.Text = "";
            txtdtFuncionario.Text = "";
            txtDtNascCliente.Text = "";
            txtEmailCliente.Text = "";
            txtEnderecoCliente.Text = "";
            txtHoraConsulta.Text = "";
            txtIdClienteConsulta.Text = "";
            txtIdFuncionario.Text = "";
            txtidFuncionarioConsulta.Text = "";
            txtnmCliente.Text = "";
            txtnmFuncionario.Text = "";
            txtnmMedico.Text = "";
            txtnrTelefone.Text = "";
            txtTelefoneCliente.Text = "";
        }


        private void btnSalvarFunc_Click(object sender, EventArgs e)
        {
            cadastrarFuncionario(txtnmFuncionario.Text, txtdtFuncionario.Text, txtdsEmail.Text, txtnrTelefone.Text,txtdsEndereco.Text);
            limparCampos();
            MessageBox.Show("Registro Cadastrado","Funcionario");
        }

        private void btnSalvarCli_Click(object sender, EventArgs e)
        {
            cadastrarCliente(txtnmCliente.Text, txtDtNascCliente.Text, txtEmailCliente.Text, txtTelefoneCliente.Text, txtEnderecoCliente.Text, txtCpfCliente.Text, Convert.ToInt32(txtIdFuncionario.Text));
            limparCampos();
            MessageBox.Show("Registro Cadastrado", "Cliente");
        }

        private void btnSalvarConsu_Click(object sender, EventArgs e)
        {
            cadastrarConsulta(Convert.ToInt32(txtIdClienteConsulta.Text), Convert.ToInt32(txtidFuncionarioConsulta.Text), txtDataConsulta.Text, txtHoraConsulta.Text, txtnmMedico.Text);
            limparCampos();
            MessageBox.Show("Registro Cadastrado", "Consulta");
        }
    }
}
