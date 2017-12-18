using System;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;
using NUnit.Framework;
using StatePrinting;

namespace Emails
{
    [UseReporter(typeof(DiffReporter))]
    [TestFixture]
    public class EmailMessager_Should
    {
        [Test]
        public void ApproveMessager()
        {
            var st = new Stateprinter();
            st.Configuration.Add(new SbValueConverter());
            var messager = new NewRateEmailMessager();
            CombinationApprovals.VerifyAllCombinations(
                (name, aType, rate) => messager.CreateMessage(name, aType, rate), x => st.PrintObject(x),
                new[] {"Vladimir Putin"},
                new[] {AccountType.Cheque, AccountType.Credit, AccountType.Savings},
                new[] {0.05m, 2, 10, 100, 150, -100});
        }

        [Test]
        public void ApproveMessagerConfig1()
        {
            var st = new Stateprinter();
            st.Configuration.Add(new SbValueConverter());
            var messager = new NewRateEmailMessager();

            Config.Local.IncreaseRate = true;
            Config.Local.IncreaseRateFactor = 1.5m;

            CombinationApprovals.VerifyAllCombinations(
                (name, aType, rate) => messager.CreateMessage(name, aType, rate), x => st.PrintObject(x),
                new[] { "Vladimir Putin" },
                new[] { AccountType.Cheque, AccountType.Credit, AccountType.Savings },
                new[] { 1, 2, 10, 100, 150, -100 });
        }

        [Test]
        public void ApproveMessagerConfig2()
        {
            var st = new Stateprinter();
            st.Configuration.Add(new SbValueConverter());
            var messager = new NewRateEmailMessager();

            Config.Local.IncreaseRate = true;
            Config.Local.IncreaseRateFactor = 0.75m;

            CombinationApprovals.VerifyAllCombinations(
                (name, aType, rate) => messager.CreateMessage(name, aType, rate), x => st.PrintObject(x),
                new[] { "Vladimir Putin" },
                new[] { AccountType.Cheque, AccountType.Credit, AccountType.Savings },
                new[] { 1, 2, 10, 100, 150, -100 });
        }

        [Test]
        public void ApproveMessagerConfig3()
        {
            var st = new Stateprinter();
            st.Configuration.Add(new SbValueConverter());
            var messager = new NewRateEmailMessager();

            Config.Local.IncreaseRate = false;
            Config.Local.IncreaseRateFactor = 1.50m;

            CombinationApprovals.VerifyAllCombinations(
                (name, aType, rate) => messager.CreateMessage(name, aType, rate), x => st.PrintObject(x),
                new[] { "Vladimir Putin" },
                new[] { AccountType.Cheque, AccountType.Credit, AccountType.Savings },
                new[] { 1, 2, 10, 100, 150, -100 });
        }
    }
}