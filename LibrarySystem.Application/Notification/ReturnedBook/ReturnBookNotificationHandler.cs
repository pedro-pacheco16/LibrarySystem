using LibrarySystem.Core.Common.Interfaces;
using MediatR;

namespace LibrarySystem.Application.Notification.ReturnedBook
{
    public class ReturnBookNotificationHandler : INotificationHandler<ReturnedBookNotification>
    {
        private readonly IEmailService _emailService;

        public ReturnBookNotificationHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public async Task Handle(ReturnedBookNotification notification, CancellationToken cancellationToken)
        {
            var message = notification.DelayInDays > 0
            ? $"Olá {notification.UserName},\n\n" +
              $"O livro foi devolvido com {notification.DelayInDays} dias de atraso.\n" +
              $"ID do empréstimo: {notification.IdLoan}\n\n" +
              $"Por favor, regularize sua situação na biblioteca."
            : $"Olá {notification.UserName},\n\n" +
              $"O livro foi devolvido dentro do prazo.\n" +
              $"ID do empréstimo: {notification.IdLoan}\n\n" +
              $"Obrigado por utilizar a biblioteca!";

            await _emailService.SendEmailAsync(notification.Email, "Confirmação de devolução", message);
        }
    }
}

