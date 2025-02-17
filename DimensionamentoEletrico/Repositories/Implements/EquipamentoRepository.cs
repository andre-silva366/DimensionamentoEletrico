using DimensionamentoEletrico.Models;
using DimensionamentoEletrico.Repositories.Interfaces;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Windows;
using DimensionamentoEletrico.Views.Insert;

namespace DimensionamentoEletrico.Repositories.Implements;

class EquipamentoRepository : IRepository<Equipamento>
{
    private readonly IDbConnection _connection;
    public EquipamentoRepository()
    {

        _connection = new SqlConnection("Server=ANDRE-SILVA366\\SQLEXPRESS;Database=DimensionamentoEletrico;Trusted_Connection=True;TrustServerCertificate=True");

    }
    public void Add(Equipamento equipamento)
    {
        try
        {
            string query = "INSERT INTO Equipamento (Nome) VALUES (@Nome)";
            _connection.Open();

            var parameter = new
            {
                equipamento.Nome
            };

            var row = _connection.Execute(query, parameter);
            if (row == 1)
            {
                MessageBox.Show("Equipamento cadastrado com sucesso!", "SUCESSO", MessageBoxButton.OK, MessageBoxImage.Information);
                CadastroEquipamento cadastroEquipamento = new();
                cadastroEquipamento.textBoxNomeEquipamento.Text = "";
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar equipamento!", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ocorreu um erro: {ex.Message}", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        finally
        {

            _connection.Close();
        }
    }

    public void Delete(Equipamento entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Equipamento> GetAll()
    {
        throw new NotImplementedException();
    }

    public Equipamento GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Equipamento entity)
    {
        throw new NotImplementedException();
    }
}
