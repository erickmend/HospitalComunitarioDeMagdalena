using Domain.Enums;
using Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Responses
{
    public class MesssageResponse
    {
        public MesssageResponse() { }
        public MesssageResponse(InternalStatusCodes statusCode)
        {
            MessageSpanish = statusCode.GetDescription()[1];
            MessageEnglish = statusCode.GetDescription()[0];
        }

        public string MessageSpanish { get; set; }
        public string MessageEnglish { get; set; }
    }
}
