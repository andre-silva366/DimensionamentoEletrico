using DimensionamentoEletrico.Views.Windows;
using System.Windows;

namespace DimensionamentoEletrico;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
    }

    private void buttonCadastrarEquipamento_Click(object sender, RoutedEventArgs e)
    {
        CadastroEquipamento telaCadastroEquipamento = new CadastroEquipamento();
        telaCadastroEquipamento.ShowDialog();
    }

    private void buttonAmbiente_Click(object sender, RoutedEventArgs e)
    {
        CadastroAmbiente cadastroAmbiente = new();
        cadastroAmbiente.ShowDialog();
    }

    private void buttonCadastrarComodo_Click(object sender, RoutedEventArgs e)
    {
        CadastroComodo cadastroComodo = new();
        cadastroComodo.ShowDialog();
    }

    private void buttonDimensionar_Click(object sender, RoutedEventArgs e)
    {
        Dimensionamento dimensionamento = new();
        dimensionamento.ShowDialog();
    }
}