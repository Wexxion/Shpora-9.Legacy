using ApprovalTests.Reporters;
using FakeItEasy;
using NUnit.Framework;

namespace ProviderProcessing.Refactored
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
    public class Tests
    {
        private ProductValidator validator;
        [SetUp]
        public void SetUp()
        {
            var prodRef = A.Fake<IProductsReference>();
            var measureRef = A.Fake<IMeasureUnitsReference>();
            validator = new ProductValidator(prodRef, measureRef);
        }


        [Test]
        public void DoSomething_WhenSomething()
        {
            
        }
    }
}