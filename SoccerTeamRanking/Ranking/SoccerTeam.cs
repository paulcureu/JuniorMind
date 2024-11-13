namespace Ranking
{
    public class SoccerTeam
    {
        private readonly string name;
        private int points;

        public SoccerTeam(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public bool HasFewerPointsThan(SoccerTeam otherTeam)
        {
            return points < otherTeam.points;
        }

        public bool IsNameEqual(SoccerTeam team)
        {
            return name == team.name;
        }

        public int AddPoints(int newPoints)
        {
            return points += newPoints;
        }
    }
}
