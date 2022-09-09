using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Social:Entity
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public string GithubLink { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
