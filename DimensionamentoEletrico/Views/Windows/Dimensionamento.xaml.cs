using DimensionamentoEletrico.Models;
using DimensionamentoEletrico.Repositories.Implements;
using System.Windows;

namespace DimensionamentoEletrico.Views.Windows
{
    /// <summary>
    /// Lógica interna para Dimensionamento.xaml
    /// </summary>
    public partial class Dimensionamento : Window
    {
        public List<string> ambientes = [];
        private readonly AmbienteRepository _ambienteRepository = new();
        public Dimensionamento()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ambientes = _ambienteRepository.GetAll().Select(a => a.Nome).ToList();
            comboBoxDimensionamentoAmbiente.ItemsSource = ambientes;
        }

        private void buttonSalvaAmbienteComodoDimensionamento_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(textBoxNomeProjeto.Text) || textBoxNomeProjeto.Text.Length < 5)
                {
                    MessageBox.Show("Informe o nome do projeto, com no mínimo 5 caracteres!", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (string.IsNullOrEmpty(comboBoxDimensionamentoAmbiente.Text))
                {
                    MessageBox.Show("Selecione um ambiente!", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    var nomeAmbiente = comboBoxDimensionamentoAmbiente.Text;
                    var nomeProjeto = textBoxNomeProjeto.Text;
                    var ambiente = _ambienteRepository.GetByName(nomeAmbiente);
                    ProjetoRepository projetoRepository = new();
                    projetoRepository.Add(new Projeto { Nome = nomeProjeto, IdAmbiente = ambiente.Id });
                    textBoxNomeProjeto.Text = "";
                    comboBoxDimensionamentoAmbiente.Text = "";
                    Dimensionamento2 dimensionamento2 = new();
                    dimensionamento2.ShowDialog();
                    this.Close();
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
