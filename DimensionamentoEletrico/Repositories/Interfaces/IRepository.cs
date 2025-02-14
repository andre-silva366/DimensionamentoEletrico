namespace DimensionamentoEletrico.Repositories.Interfaces;

interface IRepository<T> where T : class
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    void Save();
    IEnumerable<T> GetAll();
    T GetById(int id);
}
