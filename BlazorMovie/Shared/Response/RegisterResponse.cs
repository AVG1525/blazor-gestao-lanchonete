using System.Collections.Generic;

namespace BlazorMovie.Shared.Response
{
    public class RegisterResponse
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
