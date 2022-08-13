using System.Collections.Generic;
using System.Linq;

namespace DomainC.Results
{
    public class DomainValidation
    {
        public List<string> Errors { get; set; }
        public bool HasErrors => Errors.Any();

        public DomainValidation()
        {
            Errors = new List<string>();
        }

    }
}
