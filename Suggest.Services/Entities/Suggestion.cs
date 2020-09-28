using System;

namespace Suggest.Services.Entities
{
    public class Suggestion
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
    }
}
