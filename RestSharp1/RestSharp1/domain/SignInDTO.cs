using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharp1.domain
{
    class SignInDTO
    {
        private string email;
        private string token;

        public string Email { get => email; set => email = value; }
        public string Token { get => token; set => token = value; }
    }
}
