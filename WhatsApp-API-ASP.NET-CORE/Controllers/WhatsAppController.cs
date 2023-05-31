using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace WhatsApp_API_ASP.NET_CORE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WhatsAppController : ControllerBase
    {

        private readonly ILogger<WhatsAppController> _logger;

        public WhatsAppController(ILogger<WhatsAppController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post()
        {
            const string accountSid = "AC560a06f30b769f7273622fd45217f7ed";
            const string authToken = "45ac020fb0a29234b8eeb041820a7c8b";


            TwilioClient.Init(accountSid, authToken);


            var response = MessageResource.Create(
                from: new Twilio.Types.PhoneNumber("whatsapp:+989102925901"),
                body: "Blimey! WhatsApp from C#",
                //to: new Twilio.Types.PhoneNumber("whatsapp:+447309091478")
                to: new Twilio.Types.PhoneNumber("whatsapp:+989194324853")
            );


            var result = $"Message response: {response.Sid}";

            return Ok(result);
        }
    }
}