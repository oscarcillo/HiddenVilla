using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HiddenVilla.Application.Repository.IRepository;
using HiddenVilla.Domain;
using HiddenVilla.Persistence;
using HiddenVilla.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace HiddenVilla.Application.Repository
{
    public class HotelRoomImageRepository : IHotelRoomImageRepository<HotelRoomImageDto>
    {
        
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public HotelRoomImageRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<int> Create(HotelRoomImageDto itemDto)
        {
            var image = _mapper.Map<HotelRoomImageDto, HotelRoomImage>(itemDto);
            await _context.AddAsync(image);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteByImageId(int id)
        {
            var image = await _context.HotelRoomImages.FindAsync(id);
            _context.HotelRoomImages.Remove(image);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteByRoomId(int id)
        {
            var images = await _context.HotelRoomImages.Where(x => x.RoomId == id).ToListAsync();
            _context.HotelRoomImages.RemoveRange(images);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HotelRoomImageDto>> GetByRoomId(int id) 
            => _mapper.Map<IEnumerable<HotelRoomImage>, IEnumerable<HotelRoomImageDto>>(
                await _context.HotelRoomImages.Where(x => x.RoomId == id).ToListAsync());
    }
}