using DimensionamentoEletrico.Models;
using DimensionamentoEletrico.Repositories.Implements;
using System.Windows;
using System.Windows.Controls;

namespace DimensionamentoEletrico.Views.Windows
{
    /// <summary>
    /// Lógica interna para CadastroComodo.xaml
    /// </summary>
    public partial class CadastroComodo : Window
    {
        private List<string> comodos = new();
        public CadastroComodo()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            var comodoRepository = new ComodoRepository();
            comodos = comodoRepository.GetAll().Select(a => a.Nome).ToList();
        }

        private void buttonCadastrarComodo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nomeComodo = textBoxNomeComodo.Text;

                if (string.IsNullOrEmpty(nomeComodo) || nomeComodo.Length < 2)
                {
                    MessageBox.Show("Preencha o campo nome!", "ATENÇÃO", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
                else
                {
                    Comodo comodo = new Comodo
                    {
                        Nome = nomeComodo
                    };

                    ComodoRepository comodoRepository = new();
                    comodoRepository.Add(comodo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void comboBoxSelecionaAcaoComodo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxSelecionaAcaoComodo.SelectedIndex == 0)
            {
                labelSelecionaAcao.Visibility = Visibility.Hidden;
                comboBoxSelecionaAcaoComodo.Visibility = Visibility.Hidden;
                labelNomeComodo.Visibility = Visibility.Visible;
                textBoxNomeComodo.Visibility = Visibility.Visible;
                buttonCadastrarComodo.Visibility = Visibility.Visible;
                Title = "Cadastro de Cômodo";

            }
            else if (comboBoxSelecionaAcaoComodo.SelectedIndex == 1)
            {
                comboBoxSelecionaComodoAtualizar.ItemsSource = comodos;
                labelSelecionaAcao.Visibility = Visibility.Hidden;
                comboBoxSelecionaAcaoComodo.Visibility = Visibility.Hidden;
                labelNomeComodoAtualizar.Visibility = Visibility.Visible;
                textBoxComodoAtualizar.Visibility = Visibility.Visible;
                buttonAtualizarComodo.Visibility = Visibility.Visible;
                comboBoxSelecionaComodoAtualizar.Visibility = Visibility.Visible;
                labelSelecionaComodoAtualizar.Visibility = Visibility.Visible;
                Title = "Atualizar Comodo";
            }
            else if (comboBoxSelecionaAcaoComodo.SelectedIndex == 2)
            {
                comboBoxSelecionaComodoExcluir.ItemsSource = comodos;
                labelSelecionaAcao.Visibility = Visibility.Hidden;
                comboBoxSelecionaAcaoComodo.Visibility = Visibility.Hidden;
                labelSelecionaComodoExcluir.Visibility = Visibility.Visible;
                comboBoxSelecionaComodoExcluir.Visibility = Visibility.Visible;
                buttonExcluirComodo.Visibility = Visibility.Visible;
                Title = "Excluir Comodo";
            }
            else if (comboBoxSelecionaAcaoComodo.SelectedIndex == 3)
            {
                listBoxComodo.ItemsSource = comodos;
                labelSelecionaAcao.Visibility = Visibility.Hidden;
                comboBoxSelecionaAcaoComodo.Visibility = Visibility.Hidden;
                listBoxComodo.Visibility = Visibility.Visible;
                Title = "Listar Todos os Comodos";
            }
            
        }

        private void buttonAtualizarComodo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nomeAntigoComodo = comboBoxSelecionaComodoAtualizar.Text;
                var nomeAtualizadoComodo = textBoxComodoAtualizar.Text;
                if (string.IsNullOrEmpty(nomeAntigoComodo) || string.IsNullOrEmpty(nomeAtualizadoComodo) || nomeAtualizadoComodo.Length < 3)
                {
                    MessageBox.Show("Preencha os campos corretamente!", "ATENÇÃO", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                ComodoRepository comodoRepository = new();
                var Comodo = comodoRepository.GetByName(nomeAntigoComodo);
                comodoRepository.Update(Comodo, nomeAtualizadoComodo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonExcluirComodo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nomeComodo = comboBoxSelecionaComodoExcluir.Text;
                if (string.IsNullOrEmpty(nomeComodo))
                {
                    MessageBox.Show("Selecione o Comodo corretamente!", "ATENÇÃO", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                ComodoRepository comodoRepository = new();
                comodoRepository.Delete(nomeComodo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
