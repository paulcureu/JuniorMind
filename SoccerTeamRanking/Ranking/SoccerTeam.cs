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

        public int AddPoints(int newPoints)
        {
            return points += newPoints;
        }

        public int GetPoints()
        {
            return points;
        }
    }
}
