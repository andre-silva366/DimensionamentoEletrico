namespace DimensionamentoEletrico.Repositories.Interfaces;

interface IRepository<T> where T : class
{    
    void Add(T entity);
    void Update(T entity, string name);
    void Delete(string name);
    IEnumerable<T> GetAll();
    T GetByName(string name);
    T GetById(int id);
}
