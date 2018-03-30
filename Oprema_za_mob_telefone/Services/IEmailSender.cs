using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oprema_za_mob_telefone.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
