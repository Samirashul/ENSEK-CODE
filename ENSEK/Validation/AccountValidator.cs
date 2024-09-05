using ENSEK.DataAdapters;
using ENSEK.Interfaces;
using ENSEK.Models;

namespace ENSEK.Validation
{
    public class AccountValidator : iAccountValidator
    {
        public bool IsAccountIdUnique(Account account)
        {
            AccountDataAdapter adapter = new AccountDataAdapter();
            return !adapter.CheckIfFieldExists("Account", "AccountId", account.AccountId.ToString());
        }

        //This method exists to be extended later should additional validation be introduced by the client in the future
        public bool IsValid(Account account)
        {
            return IsAccountIdUnique(account);
        }
    }
}
