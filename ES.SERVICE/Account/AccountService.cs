using ES.DAL.repositories;
using ES.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.SERVICE
{
    public interface IAccountService
    {
        string Login(AspNetUser loginModel);
    }
    public class AccountService : IAccountService
    {
        public IAccountRepository _repository;
        public IUnitOfWork unitOfWork;
        public AccountService(
        IUnitOfWork unitOfWork,
        IAccountRepository accountRepository)
        {
            this.unitOfWork = unitOfWork;
            this._repository = accountRepository;
        }


        public string Login(AspNetUser loginModel)
        {



           // var result = _repository.Login(loginModel);
            return "Success";


        }

    }
}
