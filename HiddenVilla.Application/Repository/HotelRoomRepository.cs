using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HiddenVilla.Application.Repository.IRepository;
using HiddenVilla.Domain;
using HiddenVilla.Persistence;
using HiddenVilla.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace HiddenVilla.Application.Repository
{
    public class HotelRoomRepository : IRepository<HotelRoomDto>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public HotelRoomRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<HotelRoomDto> Create(HotelRoomDto hotelRoomDto)
        {
            var hotelRoom = _mapper.Map<HotelRoomDto, HotelRoom>(hotelRoomDto);
            hotelRoom.CreatedDate = DateTime.Now;
            hotelRoom.CreatedBy = "";
            var addedHotelRoom = await _context.HotelRooms.AddAsync(hotelRoom);
            await _context.SaveChangesAsync();
            return _mapper.Map<HotelRoom, HotelRoomDto>(addedHotelRoom.Entity);
        }

        public async Task<HotelRoomDto> Get(int id)
        {
            try
            {
                 return _mapper.Map<HotelRoom, 
                    HotelRoomDto>(await _context.HotelRooms
                    .FirstOrDefaultAsync(x => x.Id == id));
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<HotelRoomDto>> GetAll()
        {
            try
            {
                 return _mapper.Map<IEnumerable<HotelRoom>, 
                    IEnumerable<HotelRoomDto>>(_context.HotelRooms);
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public async Task<HotelRoomDto> IsUnique(string name, int id = 0)
        {
            try
            {
                if (id == 0)
                    return _mapper.Map<HotelRoom, 
                        HotelRoomDto>(await _context.HotelRooms
                        .FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()));
                
                return _mapper.Map<HotelRoom, 
                    HotelRoomDto>(await _context.HotelRooms
                    .FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower() && x.Id != id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<HotelRoomDto> Update(int id, HotelRoomDto hotelRoomDto)
        {
            try
            {
                if(id == hotelRoomDto.Id)
                {
                    var roomDetails = await _context.HotelRooms.FindAsync(id);
                    var room = _mapper.Map<HotelRoomDto, HotelRoom>(hotelRoomDto, roomDetails);
                    room.UpdatedBy = "";
                    room.UpdatedDate = DateTime.Now;
                    var updatedRoom = _context.HotelRooms.Update(room);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<HotelRoom, HotelRoomDto>(updatedRoom.Entity);
                }
                else
                {
                    return null;
                }  
            }
            catch (System.Exception)
            {
                return null;
            }
        }        
        
        public async Task<int> Delete(int id)
        {
            var roomDetails = await _context.HotelRooms.FindAsync(id);
            if(roomDetails != null)
            {
                _context.HotelRooms.Remove(roomDetails);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }
    }
}
