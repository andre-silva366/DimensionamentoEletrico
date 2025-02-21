using Dapper;
using DimensionamentoEletrico.Models;
using DimensionamentoEletrico.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows;

namespace DimensionamentoEletrico.Repositories.Implements;

class ComodoRepository : IRepository<Comodo>
{
    private readonly IDbConnection _connection;

    public ComodoRepository()
    {
        _connection = new SqlConnection("Server=ANDRE-SILVA366\\SQLEXPRESS;Database=DimensionamentoEletrico;Trusted_Connection=True;TrustServerCertificate=True");
    }
    public void Add(Comodo comodo)
    {
        try
        {
            var query = "INSERT INTO Comodo (Nome) VALUES (@Nome)";
            _connection.Open();
            var parameter = new { comodo.Nome };
            var row = _connection.Execute(query, parameter);
            if (row == 1)
            {
                MessageBox.Show("Comodo cadastrado com sucesso!", "SUCESSO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar comodo!", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
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

    public void Delete(string nome)
    {
        try
        {
            var query = "DELETE FROM Comodo WHERE Nome = @Nome";
            _connection.Open();
            var parameter = new { Nome = nome };
            var row = _connection.Execute(query, parameter);
            if (row == 1)
            {
                MessageBox.Show("Comodo deletado com sucesso!", "SUCESSO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Erro ao deletar Comodo!", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
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

    public IEnumerable<Comodo> GetAll()
    {
        try
        {
            var query = "SELECT Nome FROM Comodo;";
            _connection.Open();
            return _connection.Query<Comodo>(query).ToList();
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

    public Comodo GetByName(string nome)
    {
        try
        {
            string query = "SELECT Nome FROM Comodo WHERE Nome = @Nome";
            _connection.Open();
            var parameter = new { Nome = nome };
            return _connection.QueryFirst<Comodo>(query, parameter);
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

    public void Update(Comodo comodo, string nome)
    {
        try
        {
            var query = "UPDATE Comodo SET Nome = @NomeAtualizado  WHERE Nome = @Nome";
            _connection.Open();
            var parameters = new
            {
                comodo.Nome,
                NomeAtualizado = nome
            };
            var row = _connection.Execute(query, parameters);
            if (row == 1)
            {
                MessageBox.Show("Comodo atualizado com sucesso!", "SUCESSO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Erro ao atualizar Comodo!", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
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
