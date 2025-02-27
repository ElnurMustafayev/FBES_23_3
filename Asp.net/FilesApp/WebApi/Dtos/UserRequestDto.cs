using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilesApp.Dtos
{
    public class UserRequestDto
    {
        public string? Mail { get; set; }
        public required string Name { get; set; }
    }
}