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

    public void Delete(string nome)
    {
        try
        {
            var query = "DELETE FROM Equipamento WHERE Nome = @Nome";
            _connection.Open();
            var parameter = new { Nome = nome };
            var row = _connection.Execute(query, parameter);
            if (row == 1)
            {
                MessageBox.Show("Equipamento deletado com sucesso!", "SUCESSO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Erro ao deletar equipamento!", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro: {ex.Message}", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        finally
        {
            _connection.Close();
        }
    }

    public IEnumerable<Equipamento> GetAll()
    {
        try
        {
            var query = "SELECT Nome FROM Equipamento;";
            _connection.Open();
            return _connection.Query<Equipamento>(query).ToList();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro: {ex.Message}", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
            return null;
        }
        finally
        {
            _connection.Close();
        }
    }

    public Equipamento GetByName(string nome)
    {
        try
        {
            string query = "SELECT Nome FROM Equipamento WHERE Nome = @Nome";
            _connection.Open();
            var parameter = new { Nome = nome };
            return _connection.QueryFirst<Equipamento>(query, parameter);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro: {ex.Message}", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
            return null;
        }
        finally
        {
            _connection.Close();
        }
    }

    public void Update(Equipamento equipamento, string nome)
    {
        try
        {
            var query = "UPDATE Equipamento SET Nome = @NomeAtualizado  WHERE Nome = @Nome";
            _connection.Open();
            var parameters = new
            {
                equipamento.Nome,
                NomeAtualizado = nome
            };
            var row = _connection.Execute(query, parameters);
            if (row == 1)
            {
                MessageBox.Show("Equipamento atualizado com sucesso!", "SUCESSO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Erro ao atualizar equipamento!", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro: {ex.Message}", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        finally
        {
            _connection.Close();
        }
    }
}
