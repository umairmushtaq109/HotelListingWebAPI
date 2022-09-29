using HotelListing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Country> Countries { get; }
        IRepository<Hotel> Hotels { get; }

        Task Save();
    }
}
