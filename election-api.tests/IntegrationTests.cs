using election_api.Model;
using election_api.Service;

namespace election_api.tests
{
    [TestFixture]
    class IntegrationTests
    {
        ResultsControllerService _resultsController = new ResultsControllerService();

        [SetUp]
        public void Setup()
        {
            _resultsController.Reset();
        }

        [Test]
        public void First5Test()
        {
            Scoreboard scoreboard = runTest(5);

            Assert.That(scoreboard, Is.Not.Null);
            Assert.That(scoreboard.sum, Is.EqualTo(5));
            Assert.That(scoreboard.results["LD"].seats, Is.EqualTo(1));
            Assert.That(scoreboard.results["LAB"].seats, Is.EqualTo(4));
            Assert.That(scoreboard.winner, Is.EqualTo("noone"));
        }

        [Test]
        public void First100Test()
        {
            Scoreboard scoreboard = runTest(100);

            Assert.That(scoreboard, Is.Not.Null);
            Assert.That(scoreboard.sum, Is.EqualTo(100));
            Assert.That(scoreboard.results["LD"].seats, Is.EqualTo(12));
            Assert.That(scoreboard.results["LAB"].seats, Is.EqualTo(56));
            Assert.That(scoreboard.results["CON"].seats, Is.EqualTo(31));
            Assert.That(scoreboard.winner, Is.EqualTo("noone"));
        }

        [Test]
        public void First554Test()
        {
            Scoreboard scoreboard = runTest(554);

            Assert.That(scoreboard, Is.Not.Null);
            Assert.That(scoreboard.sum, Is.EqualTo(554));
            Assert.That(scoreboard.results["LD"].seats, Is.EqualTo(52));
            Assert.That(scoreboard.results["LAB"].seats, Is.EqualTo(325));
            Assert.That(scoreboard.results["CON"].seats, Is.EqualTo(167));
            Assert.That(scoreboard.winner, Is.EqualTo("LAB"));
        }

        [Test]
        public void AllTest()
        {
            Scoreboard scoreboard = runTest(650);

            Assert.That(scoreboard, Is.Not.Null);
            Assert.That(scoreboard.sum, Is.EqualTo(650));
            Assert.That(scoreboard.results["LD"].seats, Is.EqualTo(62));
            Assert.That(scoreboard.results["LAB"].seats, Is.EqualTo(349));
            Assert.That(scoreboard.results["CON"].seats, Is.EqualTo(210));
            Assert.That(scoreboard.winner, Is.EqualTo("LAB"));
        }


        private Scoreboard runTest(int numberOfResults)
        {
            ResourceService resourceService = new ResourceService();
            for (int i = 1; i <= numberOfResults; i++)
            {
                ConstituencyResult? result = resourceService.GetConstituencyResult(i);
                _resultsController.NewResult(result);
            }

            return _resultsController.GetScoreboard();

        }
    }
}
