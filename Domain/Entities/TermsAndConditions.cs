using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TermsAndConditions : Entity
    {
        public TermsAndConditions() { }
     

        public string EnglishContent { get; private set; }
        public string SpanishContent { get; private set; }
    }
}
