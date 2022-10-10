using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelListing.Domain.Models;
using System.Collections.Generic;
using HotelListing.Infrastructure.Data;
using HotelListing.Infrastructure.IRepository;

namespace HotelListing.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private IGenericRepository<Country> _countryRepository;
        private IGenericRepository<Hotel> _hotelRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public IGenericRepository<Hotel> HotelRepository => _hotelRepository ??= new GenericRepository<Hotel>(_context);

        public IGenericRepository<Country> CountryRepository => _countryRepository ??= new GenericRepository<Country>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
