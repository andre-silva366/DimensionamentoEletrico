namespace DimensionamentoEletrico.Models;

class Ambiente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public List<Comodos> comodos { get; set; }

} 

    
