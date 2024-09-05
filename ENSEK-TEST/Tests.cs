using ENSEK.DataAdapters;
using ENSEK.Validation;
using System.Security.Cryptography.X509Certificates;

namespace ENSEK_TEST
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestCheckIfFieldExists()
        {
            BaseAdapter adapter = new BaseAdapter();
            Assert.IsTrue(adapter.CheckIfFieldExists("Account", "AccountId", "1"));
        }

        [TestMethod]
        public void TestCheckIfEntryExists()
        {
            BaseAdapter adapter = new BaseAdapter();
            Dictionary<string, string> testDict = new Dictionary<string, string>();
            testDict.Add("AccountId", "1");
            testDict.Add("FirstName", "Samir");
            testDict.Add("SurName", "Sabbagh");
            Assert.IsTrue(adapter.CheckIfEntryExists("Account", testDict));
        }

        [TestMethod]
        public void TestUniqueAccountId()
        {
            AccountDataAdapter adapter = new AccountDataAdapter();
            AccountValidator validator = new AccountValidator();
            Assert.IsFalse(validator.IsAccountIdUnique(new ENSEK.Models.Account(1 ,"Samir","Sabbagh")));
        }

        //TODO seed meter reads
    }
}