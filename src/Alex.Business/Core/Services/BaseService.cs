using Alex.Business.Core.Models;
using Alex.Business.Core.Notifications;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Business.Core.Services {
    public abstract class BaseService {

        private readonly INotifier _notifier;

        public BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        #region Sobrecarga
        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }
        #endregion

        public bool RunValidation<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity {
            //return validacao.Validate(entidade).IsValid;
            var result = validacao.Validate(entidade);

            if (result.IsValid)
            {
                return true;
            } else
            {
                Notify(result);
                return false;
            }
        }
    }
}
