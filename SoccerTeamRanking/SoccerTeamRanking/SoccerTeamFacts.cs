namespace Ranking.Facts
{
    public class SoccerTeamFacts
    {
        [Fact]
        public void CheckHasFewerPointWithSmallerValue()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 36);
            SoccerTeam t2 = new SoccerTeam("FCSB", 31);
        }
    }
}
