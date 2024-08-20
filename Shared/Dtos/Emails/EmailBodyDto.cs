using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Security.Principal;

namespace Shared.Dtos.Emails;

public class EmailBodyDto
{ 
    public string To { get; set; } = null!; 
    public string From { get; set; } = null!; 
    public string? Bcc { get; set; } 
    public string? Cc { get; set; } 
    public string Subject { get; set; } = null!;

    public string? Body { get; set; }
    public bool SendNow { get; set; } = true;

    public DateTime? SchuleDate  { get; set; }

    public ICollection<AttachmentDto>? Attachments { get; set; } = new List<AttachmentDto>();
}
