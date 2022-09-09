using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Features.Socials.Dtos
{
    public class DeletedSocialDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GithubProfile { get; set; }
    }
}
