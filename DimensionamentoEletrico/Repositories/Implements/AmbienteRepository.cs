using Dapper;
using DimensionamentoEletrico.Models;
using DimensionamentoEletrico.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows;

namespace DimensionamentoEletrico.Repositories.Implements;

class AmbienteRepository : IRepository<Ambiente>
{
    private readonly IDbConnection _connection;
    public AmbienteRepository()
    {
        _connection = new SqlConnection("Server=ANDRE-SILVA366\\SQLEXPRESS;Database=DimensionamentoEletrico;Trusted_Connection=True;TrustServerCertificate=True");
    }
    public void Add(Ambiente ambiente)
    {
        try
        {
            var query = "INSERT INTO Ambiente (Nome) VALUES (@Nome)";
            _connection.Open();
            var parameter = new { ambiente.Nome };
            var row = _connection.Execute(query, parameter);
            if (row == 1)
            {
                MessageBox.Show("Ambiente cadastrado com sucesso!", "SUCESSO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar ambiente!", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro: {ex.Message}","ERRO",MessageBoxButton.OK,MessageBoxImage.Error);
        }
        finally
        {
            _connection.Close();
        }
    }

    public void Update(Ambiente ambiente, string nome)
    {
        try
        {
            var query = "UPDATE Ambiente SET Nome = @NomeAtualizado  WHERE Nome = @Nome";
            _connection.Open();            
            var parameters = new 
            {
                ambiente.Nome,
                NomeAtualizado = nome
            };
            var row = _connection.Execute(query, parameters);
            if (row == 1)
            {
                MessageBox.Show("Ambiente atualizado com sucesso!", "SUCESSO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Erro ao atualizar ambiente!", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
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

    public IEnumerable<Ambiente> GetAll()
    {
        try
        {
            var query = "SELECT Nome FROM Ambiente;";
            _connection.Open();
            return _connection.Query<Ambiente>(query).ToList();
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

    public void Delete(string nome)
    {
        try
        {
            var query = "DELETE FROM Ambiente WHERE Nome = @Nome";
            _connection.Open();
            var parameter = new { Nome = nome };
            var row = _connection.Execute(query, parameter);
            if (row == 1)
            {
                MessageBox.Show("Ambiente deletado com sucesso!", "SUCESSO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Erro ao deletar ambiente!", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show($"Erro: {ex.Message}", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        finally
        {
            _connection.Close();
        }
    }    

    public Ambiente GetByName(string nome)
    {
        try
        {
            string query = "SELECT * FROM Ambiente WHERE Nome = @Nome";
            _connection.Open();
            var parameter = new { Nome = nome };
            return _connection.QueryFirst<Ambiente>(query, parameter);
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

    public Ambiente GetById(int id)
    {
        throw new NotImplementedException();
    }
}
