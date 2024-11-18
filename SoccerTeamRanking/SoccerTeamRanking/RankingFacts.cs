namespace Ranking.Facts
{
    public class RankingFacts
    {
        [Fact]
        public void AddTeam_WhenTeamDoesNotExist_ShouldAddTeam()
        {
            SoccerTeam t1 = new SoccerTeam("Real Madrid", 36);
            SoccerTeam t2 = new SoccerTeam("Barcelona", 32);
            SoccerTeam t3 = new SoccerTeam("Bayern Munich", 28);
            GeneralRanking ranking = new GeneralRanking();

            SoccerTeam newTeam = new SoccerTeam("Juventus", 20);
            ranking.AddTeam(t1);
            ranking.AddTeam(t2);
            ranking.AddTeam(t3);
            ranking.AddTeam(newTeam);

            int teamPosition = ranking.GetTeamPosition(newTeam);
            Assert.Equal(4, teamPosition);
        }

        [Fact]
        public void AddTeam_WhenTeamExists_ShouldNotAddTeam()
        {
            SoccerTeam t1 = new SoccerTeam("Real Madrid", 36);
            SoccerTeam t2 = new SoccerTeam("Barcelona", 32);
            SoccerTeam t3 = new SoccerTeam("Bayern Munich", 28);
            GeneralRanking ranking = new GeneralRanking();

            ranking.AddTeam(t1);
            ranking.AddTeam(t2);
            ranking.AddTeam(t3);

            int teamPosition = ranking.GetTeamPosition(t1);
            Assert.Equal(1, teamPosition);
        }

        [Fact]
        public void GetTeamByPosition_ShouldReturnCorrectTeam()
        {
            SoccerTeam t1 = new SoccerTeam("Real Madrid", 36);
            SoccerTeam t2 = new SoccerTeam("Barcelona", 32);
            SoccerTeam t3 = new SoccerTeam("Bayern Munich", 28);
            GeneralRanking ranking = new GeneralRanking();
            ranking.AddTeam(t1);
            ranking.AddTeam(t2);
            ranking.AddTeam(t3);

            SoccerTeam team = ranking.GetTeamByPosition(2);

            Assert.Equal(t2, team);
        }

        [Fact]
        public void GetTeamPositionByName_ShouldReturnCorrectPosition()
        {
            SoccerTeam t1 = new SoccerTeam("Real Madrid", 36);
            SoccerTeam t2 = new SoccerTeam("Barcelona", 32);
            SoccerTeam t3 = new SoccerTeam("Bayern Munich", 28);
            GeneralRanking ranking = new GeneralRanking();
            ranking.AddTeam(t1);
            ranking.AddTeam(t2);
            ranking.AddTeam(t3);

            int position = ranking.GetTeamPosition(t3);

            Assert.Equal(3, position);
        }

        [Fact]
        public void GetTeamPositionByName_WhenTeamDoesNotExist_ShouldReturnMinusOne()
        {
            SoccerTeam t1 = new SoccerTeam("Real Madrid", 36);
            SoccerTeam t2 = new SoccerTeam("Barcelona", 32);
            SoccerTeam t3 = new SoccerTeam("Bayern Munich", 28);
            GeneralRanking ranking = new GeneralRanking();
            ranking.AddTeam(t1);
            ranking.AddTeam(t2);
            ranking.AddTeam(t3);

            int position = ranking.GetTeamPosition(new SoccerTeam("Chelsea", 25));

            Assert.Equal(-1, position);
        }

        [Fact]
        public void UpdateTeamPoints_WhenTeamsDraw_ShouldUpdatePointsCorrectly()
        {
            SoccerTeam t1 = new SoccerTeam("Real Madrid", 36);
            SoccerTeam t2 = new SoccerTeam("Barcelona", 32);
            SoccerTeam t3 = new SoccerTeam("Bayern Munich", 28);
            GeneralRanking ranking = new GeneralRanking();
            ranking.AddTeam(t1);
            ranking.AddTeam(t2);
            ranking.AddTeam(t3);

            ranking.Update(t1, t2, 1, 1);

            Assert.Equal(37, t1.AddPoints(0));
            Assert.Equal(33, t2.AddPoints(0));
        }

        [Fact]
        public void UpdateTeamPoints_WhenTeam1Wins_ShouldUpdatePointsCorrectly()
        {
            SoccerTeam t1 = new SoccerTeam("Real Madrid", 36);
            SoccerTeam t2 = new SoccerTeam("Barcelona", 32);
            SoccerTeam t3 = new SoccerTeam("Bayern Munich", 28);
            GeneralRanking ranking = new GeneralRanking();
            ranking.AddTeam(t1);
            ranking.AddTeam(t2);
            ranking.AddTeam(t3);

            ranking.Update(t1, t2, 2, 1);

            Assert.Equal(39, t1.AddPoints(0));
            Assert.Equal(32, t2.AddPoints(0));
        }

        [Fact]
        public void UpdateTeamPoints_WhenTeam2Wins_ShouldUpdatePointsCorrectly()
        {
            SoccerTeam t1 = new SoccerTeam("Real Madrid", 36);
            SoccerTeam t2 = new SoccerTeam("Barcelona", 32);
            SoccerTeam t3 = new SoccerTeam("Bayern Munich", 28);
            GeneralRanking ranking = new GeneralRanking();

            ranking.AddTeam(t1);
            ranking.AddTeam(t2);
            ranking.AddTeam(t3);

            ranking.Update(t1, t2, 0, 1);

            Assert.Equal(36, t1.AddPoints(0));
            Assert.Equal(35, t2.AddPoints(0));
        }

        [Fact]
        public void Sort_ShouldOrderTeamsCorrectly()
        {
            SoccerTeam t1 = new SoccerTeam("Real Madrid", 36);
            SoccerTeam t2 = new SoccerTeam("Barcelona", 32);
            SoccerTeam t3 = new SoccerTeam("Bayern Munich", 28);
            GeneralRanking ranking = new GeneralRanking();
            ranking.AddTeam(t1);
            ranking.AddTeam(t2);
            ranking.AddTeam(t3);

            SoccerTeam team4 = new SoccerTeam("Juventus", 40);
            ranking.AddTeam(team4);

            int team1Position = ranking.GetTeamPosition(t1);
            int team4Position = ranking.GetTeamPosition(team4);

            Assert.Equal(2, team1Position);
            Assert.Equal(1, team4Position);
        }
    }
}