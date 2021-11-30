using System.Collections.Generic;
using System.Threading.Tasks;
using HiddenVilla.Domain;

namespace HiddenVilla.Application.Repository.IRepository
{
    public interface IHotelRoomImageRepository<TDto> where TDto: class
    {
         public Task<int> Create(TDto itemDto);
         public Task<int> DeleteByImageId(int id);
         public Task<int> DeleteByRoomId(int id);
         public Task<IEnumerable<TDto>> GetByRoomId(int id);
    }
}