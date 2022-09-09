using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Dtos
{
    public class GetListSocialDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string GithubLink { get; set; }
    }
}
