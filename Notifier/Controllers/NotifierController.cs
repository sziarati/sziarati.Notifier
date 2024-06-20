using Microsoft.AspNetCore.Mvc;
using Notifier.Features.Sms;

namespace Notifier.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotifierController(ISMSProvider smsProvider, CancellationToken cancellationToken) : ControllerBase
    {
        [HttpGet]
        public async void Get()
        {
            await smsProvider.SendAsync("", "",cancellationToken);
        }
    }
}
