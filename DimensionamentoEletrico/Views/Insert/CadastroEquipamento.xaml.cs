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
        public List<string> equipamentos = new();
        public CadastroEquipamento()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            var equipamentoRepository = new EquipamentoRepository();
            equipamentos = equipamentoRepository.GetAll().Select(a => a.Nome).ToList();
        }

        private void buttonCadastrarEquipamento_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nomeEquipamento = textBoxNomeEquipamento.Text;

                if(string.IsNullOrEmpty(nomeEquipamento) || nomeEquipamento.Length < 2)
                {
                    MessageBox.Show("Preencha o campo nome!", "ATENÇÃO", MessageBoxButton.OK, MessageBoxImage.Warning);
                    
                }
                else
                {
                    Equipamento equipamento = new Equipamento
                    {
                        Nome = nomeEquipamento
                    };

                    EquipamentoRepository equipamentoRepository = new();
                    equipamentoRepository.Add(equipamento);
                }               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void comboBoxSelecionaAcao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxSelecionaAcaoEquipamento.SelectedIndex == 0)
            {
                labelSelecionaAcaoEquipamento.Visibility = Visibility.Hidden;
                comboBoxSelecionaAcaoEquipamento.Visibility = Visibility.Hidden;
                labelNomeEquipamento.Visibility = Visibility.Visible;
                textBoxNomeEquipamento.Visibility = Visibility.Visible;
                buttonCadastrarEquipamento.Visibility = Visibility.Visible;
                Title = "Cadastro de Equipamento";

            }
            else if (comboBoxSelecionaAcaoEquipamento.SelectedIndex == 1)
            {
                comboBoxSelecionaEquipamentoAtualizar.ItemsSource = equipamentos;
                labelSelecionaAcaoEquipamento.Visibility = Visibility.Hidden;
                comboBoxSelecionaAcaoEquipamento.Visibility = Visibility.Hidden;
                labelNomeEquipamentoAtualizar.Visibility = Visibility.Visible;
                textBoxEquipamentoAtualizar.Visibility = Visibility.Visible;
                buttonAtualizarEquipamento.Visibility = Visibility.Visible;
                comboBoxSelecionaEquipamentoAtualizar.Visibility = Visibility.Visible;
                labelSelecionaEquipamentoAtualizar.Visibility = Visibility.Visible;
                Title = "Atualizar Equipamento";
            }
            else if (comboBoxSelecionaAcaoEquipamento.SelectedIndex == 2)
            {
                comboBoxSelecionaEquipamentoExcluir.ItemsSource = equipamentos;
                labelSelecionaAcaoEquipamento.Visibility = Visibility.Hidden;
                comboBoxSelecionaAcaoEquipamento.Visibility = Visibility.Hidden;
                labelSelecionaEquipamentoExcluir.Visibility = Visibility.Visible;
                comboBoxSelecionaEquipamentoExcluir.Visibility = Visibility.Visible;
                buttonExcluirEquipamento.Visibility = Visibility.Visible;
                Title = "Excluir Equipamento";
            }
            else if (comboBoxSelecionaAcaoEquipamento.SelectedIndex == 3)
            {
                listBoxEquipamento.ItemsSource = equipamentos;
                labelSelecionaAcaoEquipamento.Visibility = Visibility.Hidden;
                comboBoxSelecionaAcaoEquipamento.Visibility = Visibility.Hidden;
                listBoxEquipamento.Visibility = Visibility.Visible;
                Title = "Listar Todos os Equipamentos";
            }
            
        }

        private void buttonExcluirEquipamento_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nomeEquipamento = comboBoxSelecionaEquipamentoExcluir.Text;
                if (string.IsNullOrEmpty(nomeEquipamento))
                {
                    MessageBox.Show("Selecione o equipamento corretamente!", "ATENÇÃO", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                EquipamentoRepository EquipamentoRepository = new();
                EquipamentoRepository.Delete(nomeEquipamento);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonAtualizarEquipamento_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nomeAntigoEquipamento = comboBoxSelecionaEquipamentoAtualizar.Text;
                var nomeAtualizadoEquipamento = textBoxEquipamentoAtualizar.Text;
                if (string.IsNullOrEmpty(nomeAntigoEquipamento) || string.IsNullOrEmpty(nomeAtualizadoEquipamento) || nomeAtualizadoEquipamento.Length < 3)
                {
                    MessageBox.Show("Preencha os campos corretamente!", "ATENÇÃO", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                EquipamentoRepository equipamentoRepository = new();
                var equipamento = equipamentoRepository.GetByName(nomeAntigoEquipamento);
                equipamentoRepository.Update(equipamento, nomeAtualizadoEquipamento);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
