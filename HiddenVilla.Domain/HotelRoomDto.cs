using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HiddenVilla.Domain
{
    public class HotelRoomDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter room name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Occupancy")]
        public int Occupancy { get; set; }
        [Range(1, 3000, ErrorMessage = "Regular Rate must be between 1 and 3000")]
        public double RegularRate { get; set; }
        public string Details { get; set; }
        public string SqFt { get; set; }
        public virtual ICollection<HotelRoomImageDto> HotelRoomImages { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}