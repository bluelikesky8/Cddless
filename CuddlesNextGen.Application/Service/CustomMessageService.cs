using CuddlesNextGen.Application.Utility;
using Microsoft.Extensions.Options;
using PARSNextGen.Application.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuddlesNextGen.Application.Service
{
    public class CustomMessageService : ICustomMessageService
    {
        private readonly List<CustomMessage> _customMessages;

        public CustomMessageService(IOptions<List<CustomMessage>> options)
        {
            _customMessages = (List<CustomMessage>)options.Value;
        }

        public CustomMessage GetCustomMessageByShortCode(string shortCode)
        {
            if (!string.IsNullOrEmpty(shortCode))

              return  _customMessages.Where(x => x.message_shortcode == shortCode.ToUpper()).FirstOrDefault();
            else
              return _customMessages.Where(x => x.message_shortcode == "CUDDLES_UNHANDLED_ERROR").FirstOrDefault();



        }
    }
}
