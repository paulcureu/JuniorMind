namespace Ranking.Facts
{
    public class SoccerTeamFacts
    {
        [Fact]
        public void HasFewerPoint_WhenPointsAreLess_ShouldReturnTrue()
        {
            SoccerTeam teamA = new SoccerTeam("TeamA", 10);
            SoccerTeam teamB = new SoccerTeam("TeamB", 15);
            bool result = teamA.HasFewerPointsThan(teamB);

            Assert.True(result, "TeamA should have fewer points than TeamB.");
        }

        [Fact]
        public void HasFewerPoint_WhenPointsAreMore_ShouldReturnFalse()
        {
            SoccerTeam teamA = new SoccerTeam("TeamA", 10);
            SoccerTeam teamB = new SoccerTeam("TeamB", 15);
            bool result = teamB.HasFewerPointsThan(teamA);

            Assert.False(result, "TeamB should not have fewer points than TeamA.");
        }

        [Fact]
        public void AddPoints_ShouldIncreasePointsByGivenAmount()
        {
            SoccerTeam teamA = new SoccerTeam("TeamA", 10);
            int updatedPoints = teamA.AddPoints(5);

            Assert.Equal(15, updatedPoints);
        }

        [Fact]
        public void AddPoints_WithNegativeAmount_ShouldDecreasePoints()
        {
            SoccerTeam teamA = new SoccerTeam("TeamA", 10);
            int updatedPoints = teamA.AddPoints(-5);

            Assert.Equal(5, updatedPoints);
        }

        [Fact]
        public void AddPoints_WithZero_ShouldNotChangePoints()
        {
            SoccerTeam teamA = new SoccerTeam("TeamA", 10);
            int updatedPoints = teamA.AddPoints(0);

            Assert.Equal(10, updatedPoints);
        }

        [Fact]
        public void HasFewerPoint_WhenPointsAreEqual_ShouldReturnFalse()
        {
            SoccerTeam teamA = new SoccerTeam("TeamA", 10);
            var teamC = new SoccerTeam("TeamC", 10);
            bool result = teamA.HasFewerPointsThan(teamC);

            Assert.False(result, "The teams should not have fewer points when points are equal.");
        }

        [Fact]
        public void MultipleAddPoints_ShouldAccumulateCorrectly()
        {
            SoccerTeam teamA = new SoccerTeam("TeamA", 10);
            teamA.AddPoints(3);
            teamA.AddPoints(4);
            teamA.AddPoints(2);

            Assert.Equal(19, teamA.AddPoints(0));
        }
    }
}
