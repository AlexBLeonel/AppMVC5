using Alex.Business.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Business.Core.Services {
    public abstract class BaseService {

        public bool RunValidation<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity {
            return validacao.Validate(entidade).IsValid;
        }
    }
}
