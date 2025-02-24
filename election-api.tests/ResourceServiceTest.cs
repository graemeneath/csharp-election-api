using election_api.Model;
using election_api.Service;

namespace election_api.tests
{
    [TestFixture]
    class ResourceServiceTest
    {
        [Test]
        public void LoadFirstResult()
        {
            ConstituencyResult? result = new ResourceService().GetConstituencyResult(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result?.name, Is.EqualTo("Aberconwy"));
        }
    }
}
