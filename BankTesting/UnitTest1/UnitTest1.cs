
using NUnit.Framework;
using NUnitEg;

namespace BankTesting
{
    [TestFixture]
    public class UnitTest1
    {
        Banking obj = new Banking();
        double bal;
        [Test]
        public void TestDepositAmtPass()
        {
            obj.DepositAmt(60);
            bal = obj.balance;
            Assert.AreEqual(60, bal);
        }
        [Test]
        public void TestDepositAmtNegativeValue()
        {
            Banking obj = new Banking();
            obj.DepositAmt(-90);
            double balance = 0;
            bal = obj.balance;
            Assert.AreEqual(balance, bal);
        }
        [Test]
        public void TestwithdrawAmtNotEnoughBalance()
        {
            obj.WithdrawAmt(60006);
            Assert.AreEqual("Sorry!Not Enough Balance", obj.msg);
        }
        public void TestwithdrawAmtEnoughBalance()
        {
            obj.WithdrawAmt(60);
            Assert.AreEqual("success", obj.msg);
        }
    }
}
