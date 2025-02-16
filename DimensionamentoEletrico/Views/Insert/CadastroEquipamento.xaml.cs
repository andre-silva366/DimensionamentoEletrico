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
    /// Lógica interna para CadastroEquipamento.xaml
    /// </summary>
    public partial class CadastroEquipamento : Window
    {
        
        public CadastroEquipamento()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            comboBoxTensaoEquipamento.ItemsSource = new List<int> { 127, 220 };;
        }

        private void buttonCadastrarEquipamento_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nomeEquipamento = textBoxNomeEquipamento.Text;
                var tensaoEquipamento = Convert.ToInt32(comboBoxTensaoEquipamento.Text);
                var potenciaEquipamento = Convert.ToInt32(textBoxPotenciaEquipamento.Text);

                if(string.IsNullOrEmpty(nomeEquipamento) || tensaoEquipamento == 0 || potenciaEquipamento == 0)
                {
                    MessageBox.Show("Preencha todos os campos!", "ATENÇÃO", MessageBoxButton.OK, MessageBoxImage.Warning);
                    
                }

                Equipamento equipamento = new Equipamento
                {
                    Nome = nomeEquipamento,
                    Tensao = tensaoEquipamento,
                    Potencia = potenciaEquipamento
                };

                EquipamentoRepository equipamentoRepository = new ();
                equipamentoRepository.Add(equipamento);
                var messageBoxResult = MessageBox.Show("Equipamento cadastrado com sucesso!\nDeseja cadastrar outro equipamento?", "SUCESSO", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    textBoxNomeEquipamento.Clear();
                    comboBoxTensaoEquipamento.SelectedIndex = -1;
                    textBoxPotenciaEquipamento.Clear();
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
    }
}
