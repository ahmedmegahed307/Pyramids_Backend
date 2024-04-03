using Pyramids.Core.Models.Email;

namespace Pyramids.Core.IServices
{
    public interface IEmailService
    {
        bool SendEmail(IEnumerable<string> to, string subject, string body);

        bool SendEmailWithAttachments(IEnumerable<string> to, string subject, string body, FileAttachment attachment);
    }
}
