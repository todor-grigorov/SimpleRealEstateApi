using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SimpleRealEstateApi.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}
