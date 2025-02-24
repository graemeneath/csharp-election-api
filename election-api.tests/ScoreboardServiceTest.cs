using election_api.Model;
using election_api.Service;

namespace election_api.tests
{
    [TestFixture]
    class ScoreboardServiceTest
    {
        [Test]
        public void AddResult_IncrementsSum()
        {
            // Arrange
            var service = new ScoreboardService();
            var cr = GetConstituencyResult();
            // Act
            service.AddResult(cr);
            // Assert
            Assert.That(service.GetScoreboard().sum, Is.EqualTo(1));
        }

        [Test]
        public void Add5Results_TestResults()
        {
            // Arrange
            var service = new ScoreboardService();
            var cr = GetConstituencyResult();
            // Act
            for (int i = 0; i < 5; i++)
            {
                service.AddResult(cr);
            }
            // Assert
            var scoreboard = service.GetScoreboard();
            Assert.That(scoreboard.results.Count, Is.EqualTo(1));
            Assert.That(scoreboard.results["A"].seats, Is.EqualTo(5));
            Assert.That(service.GetScoreboard().sum, Is.EqualTo(5));
            Assert.That(service.GetScoreboard().winner, Is.EqualTo("noone"));
        }

        [Test]
        public void Add325Results_TestResults()
        {
            // Arrange
            var service = new ScoreboardService();
            var cr = GetConstituencyResult();
            // Act
            for (int i = 0; i < 325; i++)
            {
                service.AddResult(cr);
            }
            // Assert
            var scoreboard = service.GetScoreboard();
            Assert.That(scoreboard.results.Count, Is.EqualTo(1));
            Assert.That(scoreboard.results["A"].seats, Is.EqualTo(325));
            Assert.That(service.GetScoreboard().sum, Is.EqualTo(325));
            Assert.That(service.GetScoreboard().winner, Is.EqualTo("A"));
        }

        private ConstituencyResult GetConstituencyResult()
        {
            return new ConstituencyResult
            {
                name = "Test",
                partyResults = new List<PartyResult>
                {
                    new PartyResult { party = "A", votes = 100 },
                    new PartyResult { party = "B", votes = 50 }
                }
            };
        }
    }
}
