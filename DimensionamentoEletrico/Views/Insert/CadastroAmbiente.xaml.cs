using DimensionamentoEletrico.Models;
using DimensionamentoEletrico.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DimensionamentoEletrico.Views.Insert
{
    /// <summary>
    /// Lógica interna para CadastroAmbiente.xaml
    /// </summary>
    public partial class CadastroAmbiente : Window
    {
        public CadastroAmbiente()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
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
            if(comboBoxSelecionaAcao.SelectedIndex == 0)
            {
                labelSelecionaAcao.Visibility = Visibility.Hidden;
                comboBoxSelecionaAcao.Visibility = Visibility.Hidden;
                labelNome.Visibility = Visibility.Visible;
                textBoxNomeAmbiente.Visibility = Visibility.Visible;
                buttonCadastrarAmbiente.Visibility = Visibility.Visible;

            }
            else if (comboBoxSelecionaAcao.SelectedIndex == 1)
            {
                MessageBox.Show("Essa opção ainda não foi implementada", "ATENÇÃO", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (comboBoxSelecionaAcao.SelectedIndex == 2)
            {
                MessageBox.Show("Essa opção ainda não foi implementada", "ATENÇÃO", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (comboBoxSelecionaAcao.SelectedIndex == 3)
            {
                MessageBox.Show("Essa opção ainda não foi implementada", "ATENÇÃO", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (comboBoxSelecionaAcao.SelectedIndex == 4)
            {
                MessageBox.Show("Essa opção ainda não foi implementada", "ATENÇÃO", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
