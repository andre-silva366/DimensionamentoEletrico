using DimensionamentoEletrico.Models;
using DimensionamentoEletrico.Repositories.Implements;
using System.Windows;
using System.Windows.Controls;

namespace DimensionamentoEletrico.Views.Windows
{
    /// <summary>
    /// Lógica interna para CadastroAmbiente.xaml
    /// </summary>
    public partial class CadastroAmbiente : Window
    {
        private List<string> ambientes = new();
        public CadastroAmbiente()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            var ambienteRepository = new AmbienteRepository();
            ambientes = ambienteRepository.GetAll().Select(a => a.Nome).ToList() ;
        }

        private void buttonCadastrarAmbiente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nomeAmbiente = textBoxNomeAmbiente.Text;

                if (string.IsNullOrEmpty(nomeAmbiente) || nomeAmbiente.Length < 2)
                {
                    MessageBox.Show("Preencha o campo nome!", "ATENÇÃO", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
                else
                {
                    Ambiente ambiente= new Ambiente
                    {
                        Nome = nomeAmbiente
                    };

                    AmbienteRepository ambienteRepository = new();
                    ambienteRepository.Add(ambiente);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void comboBoxSelecionaAcao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Cadastrar ------------------------------------------------------
            if (comboBoxSelecionaAcaoAmbiente.SelectedIndex == 0)
            {
                labelSelecionaAcao.Visibility = Visibility.Hidden;
                comboBoxSelecionaAcaoAmbiente.Visibility = Visibility.Hidden;
                labelNome.Visibility = Visibility.Visible;
                textBoxNomeAmbiente.Visibility = Visibility.Visible;
                buttonCadastrarAmbiente.Visibility = Visibility.Visible;                
                Title = "Cadastrar Ambiente";
            }
            // Atualizar ------------------------------------------------------
            else if (comboBoxSelecionaAcaoAmbiente.SelectedIndex == 1)
            {
                comboBoxSelecionaAmbienteAtualizar.ItemsSource = ambientes;
                labelSelecionaAcao.Visibility = Visibility.Hidden;
                comboBoxSelecionaAcaoAmbiente.Visibility = Visibility.Hidden;
                labelNomeAmbienteAtualizar.Visibility = Visibility.Visible;
                textBoxAmbienteAtualizar.Visibility = Visibility.Visible;
                buttonAtualizarAmbiente.Visibility = Visibility.Visible;
                comboBoxSelecionaAmbienteAtualizar.Visibility = Visibility.Visible;
                labelSelecionaAmbienteAtualizar.Visibility = Visibility.Visible;
                Title = "Atualizar Ambiente";
            }
            // Excluir ------------------------------------------------------
            else if (comboBoxSelecionaAcaoAmbiente.SelectedIndex == 2)
            {
                comboBoxSelecionaAmbienteExcluir.ItemsSource = ambientes;
                labelSelecionaAcao.Visibility = Visibility.Hidden;
                comboBoxSelecionaAcaoAmbiente.Visibility = Visibility.Hidden;
                labelSelecionaAmbienteExcluir.Visibility = Visibility.Visible;
                comboBoxSelecionaAmbienteExcluir.Visibility = Visibility.Visible;
                buttonExcluirAmbiente.Visibility = Visibility.Visible;
                Title = "Excluir Ambiente";
            }
            // Listar todos ------------------------------------------------------
            else if (comboBoxSelecionaAcaoAmbiente.SelectedIndex == 3)
            {
                listBoxAmbiente.ItemsSource = ambientes;
                labelSelecionaAcao.Visibility = Visibility.Hidden;
                comboBoxSelecionaAcaoAmbiente.Visibility = Visibility.Hidden;
                listBoxAmbiente.Visibility = Visibility.Visible;
                Title = "Listar Todos os Ambientes";
            }
            
        }

        private void buttonAtualizarAmbiente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nomeAntigoAmbiente = comboBoxSelecionaAmbienteAtualizar.Text;
                var nomeAtualizadoAmbiente = textBoxAmbienteAtualizar.Text;
                if(string.IsNullOrEmpty(nomeAntigoAmbiente) || string.IsNullOrEmpty(nomeAtualizadoAmbiente) || nomeAtualizadoAmbiente.Length < 3)
                {
                    MessageBox.Show("Preencha os campos corretamente!", "ATENÇÃO", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;                    
                }
                AmbienteRepository ambienteRepository = new();
                var ambiente = ambienteRepository.GetByName(nomeAntigoAmbiente);
                ambienteRepository.Update(ambiente,nomeAtualizadoAmbiente);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonExcluirAmbiente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nomeAmbiente = comboBoxSelecionaAmbienteExcluir.Text;
                if (string.IsNullOrEmpty(nomeAmbiente) )
                {
                    MessageBox.Show("Selecione o ambiente corretamente!", "ATENÇÃO", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                AmbienteRepository ambienteRepository = new();
                ambienteRepository.Delete(nomeAmbiente);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
