using System;

namespace ProjetoPetshop.Models
{
    public class PetViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
