using HotelListing.DataAccess.Data;
using HotelListing.DataAccess.Repository.IRepository;
using HotelListing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private IRepository<Country> _countries;
        private IRepository<Hotel> _hotels;

        public IRepository<Country> Countries => _countries ??= new Repository<Country>(_db);
        public IRepository<Hotel> Hotels => _hotels ??= new Repository<Hotel>(_db);

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
