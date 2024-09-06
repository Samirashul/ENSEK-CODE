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
            AccountValidator validator = new AccountValidator();
            Assert.IsFalse(validator.IsAccountIdUnique(new ENSEK.Models.Account(1 ,"Samir","Sabbagh")));
        }

        [TestMethod]
        public void TestMostRecentMeterRead1()
        {
            MeterReadValidator validator = new MeterReadValidator();
            Assert.IsTrue(validator.IsMostRecentMeterRead(new ENSEK.Models.MeterRead(2345, "45522", new DateTime(2019, 4, 22, 12, 26, 1))));
        }

        [TestMethod]
        public void TestMostRecentMeterRead2()
        {
            MeterReadValidator validator = new MeterReadValidator();
            Assert.IsFalse(validator.IsMostRecentMeterRead(new ENSEK.Models.MeterRead(2345, "45522", new DateTime(2019, 4, 22, 12, 25, 0))));
        }

        [TestMethod]
        public void TestMostRecentMeterRead3()
        {
            MeterReadValidator validator = new MeterReadValidator();
            Assert.IsFalse(validator.IsMostRecentMeterRead(new ENSEK.Models.MeterRead(2345, "45522", new DateTime(2019, 4, 22, 12, 24, 0))));
        }

        [TestMethod]
        public void TestMeterReadFormat1()
        {
            MeterReadValidator validator = new MeterReadValidator();
            Assert.IsFalse(validator.IsReadValueCorrectFormat(new ENSEK.Models.MeterRead(1, "this should fail", DateTime.MinValue)));
        }

        [TestMethod]
        public void TestMeterReadFormat2()
        {
            MeterReadValidator validator = new MeterReadValidator();
            Assert.IsFalse(validator.IsReadValueCorrectFormat(new ENSEK.Models.MeterRead(1, "123456", DateTime.MinValue)));
        }

        [TestMethod]
        public void TestMeterReadFormat3()
        {
            MeterReadValidator validator = new MeterReadValidator();
            Assert.IsFalse(validator.IsReadValueCorrectFormat(new ENSEK.Models.MeterRead(1, "", DateTime.MinValue)));
        }

        [TestMethod]
        public void TestMeterReadFormat4()
        {
            MeterReadValidator validator = new MeterReadValidator();
            Assert.IsTrue(validator.IsReadValueCorrectFormat(new ENSEK.Models.MeterRead(1, "12345", DateTime.MinValue)));
        }
    }
}