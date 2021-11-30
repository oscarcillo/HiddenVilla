using System.Collections.Generic;
using System.Threading.Tasks;
using HiddenVilla.Domain;

namespace HiddenVilla.Application.Repository.IRepository
{
    public interface IHotelRoomRepository<TDto> where TDto: class
    {
         public Task<TDto> Create(TDto itemDto);
         public Task<TDto> Update(int id, TDto itemDto);
         public Task<TDto> Get(int id);
         public Task<IEnumerable<TDto>> GetAll();
         public Task<TDto> IsUnique(string name, int id = 0);
         public Task<int> Delete(int id);
    }
}