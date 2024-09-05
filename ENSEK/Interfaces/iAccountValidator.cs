using ENSEK.Models;

namespace ENSEK.Interfaces
{
    public interface iAccountValidator
    {
        public bool IsAccountIdUnique(Account account);
        public bool IsValid(Account account);
    }
}
