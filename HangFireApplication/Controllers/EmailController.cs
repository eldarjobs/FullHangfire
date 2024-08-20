using Hangfire;
using HangFireApplication.Service;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace HangFireApplication.Controllers;

//public class EmailController : Controller
//{
//    private readonly IBackgroundJobClient _client;

//    public EmailController(IBackgroundJobClient client)
//    {
//        _client = client;
//    }

//    public IActionResult Send() => View();


//    [HttpPost]
//    public IActionResult Send(EmailBodyDto model)
//    {
//        try
//        {
//            if (model.SendNow)
//            {
//                _client.Enqueue(() => SendEmailJobAsync(model));

//            }
//            else
//            {
//                var timeUntilSendDate = model.SchuleDate.Value - DateTime.Now;
//                _client.Schedule(() => SendEmailJobAsync(model), timeUntilSendDate);
//            }
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(ex.Message);
//        }


//        return View(model);
//    }

//    [NonAction]
//    public async Task SendEmailJobAsync(EmailBodyDto request)
//    {
//        var mailServiceapi = RestService.For<IMailServiceApi>("http://localhost:5020");

//        await mailServiceapi.SendEmailAsync(request);



//    }
//}

public class EmailController : Controller
{
    private readonly IBackgroundJobClient _client;
    public EmailController(IBackgroundJobClient backgroundJobClient)
    {
        this._client = backgroundJobClient;
    }

    public IActionResult Send() => View();

    [HttpPost]
    public IActionResult Send(EmailBodyDto model, IFormFile[] attachments)
    {

        if (model.SendNow) // mail anlık olarak gönderilecekse,
        {
            _client.Enqueue(() => SendEmailJobAsync(model));
        }
        else
        {
            var timeUntilSendDate = model.SchuleDate.Value - DateTime.Now;
            _client.Schedule(() => SendEmailJobAsync(model), timeUntilSendDate);
        }

        return View();
    }


    [NonAction]
    public async Task SendEmailJobAsync(EmailBodyDto request)
    {
        var mailServiceApi = RestService.For<IMailServiceApi>("http://localhost:5020");
        await mailServiceApi.SendEmailAsync(request);
    }
}