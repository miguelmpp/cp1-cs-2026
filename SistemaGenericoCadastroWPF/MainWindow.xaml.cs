// Aluno: MIGUEL PARRADO
// RM: 554007
using System.Windows;

namespace SistemaGenericoCadastroWPF
{
    public partial class MainWindow : Window
    {
        private Cadastro<Pessoa> cadastroPessoas = new Cadastro<Pessoa>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private bool ValidarId(out int id)
        {
            if (!int.TryParse(txtId.Text, out id))
            {
                MessageBox.Show("Digite um ID válido.");
                return false;
            }

            return true;
        }

        private bool ValidarIdade(out int idade)
        {
            if (!int.TryParse(txtIdade.Text, out idade))
            {
                MessageBox.Show("Digite uma idade válida.");
                return false;
            }

            return true;
        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarId(out int id))
                return;

            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Digite o nome.");
                return;
            }

            if (!ValidarIdade(out int idade))
                return;

            Pessoa pessoa = new Pessoa(txtNome.Text, idade);
            txtResultado.Text = cadastroPessoas.Adicionar(id, pessoa);
        }

        private void BtnListar_Click(object sender, RoutedEventArgs e)
        {
            txtResultado.Text = cadastroPessoas.Listar();
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarId(out int id))
                return;

            txtResultado.Text = cadastroPessoas.Buscar(id);
        }

        private void BtnRemover_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarId(out int id))
                return;

            txtResultado.Text = cadastroPessoas.Remover(id);
        }

        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtIdade.Text = "";
            txtResultado.Text = "";
            txtId.Focus();
        }
    }
}