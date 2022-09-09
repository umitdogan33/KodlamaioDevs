using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Features.AppUsers.Dtos
{
    public class RegisteredAppUserDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
