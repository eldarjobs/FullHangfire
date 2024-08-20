using Microsoft.AspNetCore.Mvc;
using Refit;

namespace HangFireApplication.Service;

public interface IMailServiceApi
{
    //http://localhost:5020
    [Post("/api/emails")]
    Task SendEmailAsync([Body] EmailBodyDto emailRequest);


}
