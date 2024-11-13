namespace Ranking.Facts
{
    public class RankingFacts
    {
        [Fact]
        public void CheckAddNewTeam()
        {
            SoccerTeam t1 = new SoccerTeam("Bayern", 30);
            SoccerTeam t2 = new SoccerTeam("Manchester Utd", 34);
            SoccerTeam t3 = new SoccerTeam("PSV", 32);
            SoccerTeam t4 = new SoccerTeam("Arsenal", 24);
            SoccerTeam t5 = new SoccerTeam("Sevilla", 15);

            SoccerTeam[] teams = new SoccerTeam[] { t1, t2, t3, t4 };

            GeneralRanking ranking = new GeneralRanking(teams);
            ranking.AddTeam(t5);

            Assert.Equal(5, ranking.GetTeamPosition(t5));
        }
    }
}