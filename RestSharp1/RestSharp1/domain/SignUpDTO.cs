using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharp1.domain
{
    class SignUpDTO
    {
        private string id;
        private string userEmail;

        public string Id { get => id; set => id = value; }
        public string UserEmail { get => userEmail; set => userEmail = value; }
    }
}
