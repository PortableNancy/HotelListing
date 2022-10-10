using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelListing.Domain.Models;
using System.Collections.Generic;

namespace HotelListing.Infrastructure.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Hotel> HotelRepository { get; }
        IGenericRepository<Country> CountryRepository { get; }
        Task Save();
    }
}
