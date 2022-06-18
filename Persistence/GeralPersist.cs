using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VnsProjectTrips.Data;
using VnsProjectTrips.Domain.Models;
using VnsProjectTrips.Persistence.Interfaces;

namespace VnsProjectTrips.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        private readonly DataContext _dataContext;

        public GeralPersist(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _dataContext.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _dataContext.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _dataContext.Remove(entity);
        }
        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _dataContext.RemoveRange(entityArray);
        }
        public async Task<bool> SavaChangesAsync()
        {
            return (await _dataContext.SaveChangesAsync()) > 0;
        }
    }
}
