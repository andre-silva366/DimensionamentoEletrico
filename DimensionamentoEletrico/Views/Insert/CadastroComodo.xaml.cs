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
    /// Lógica interna para CadastroComodo.xaml
    /// </summary>
    public partial class CadastroComodo : Window
    {
        public CadastroComodo()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
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
                MessageBox.Show("Essa opção ainda não foi implementada", "ATENÇÃO", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (comboBoxSelecionaAcaoComodo.SelectedIndex == 2)
            {
                MessageBox.Show("Essa opção ainda não foi implementada", "ATENÇÃO", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (comboBoxSelecionaAcaoComodo.SelectedIndex == 3)
            {
                MessageBox.Show("Essa opção ainda não foi implementada", "ATENÇÃO", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (comboBoxSelecionaAcaoComodo.SelectedIndex == 4)
            {
                MessageBox.Show("Essa opção ainda não foi implementada", "ATENÇÃO", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
