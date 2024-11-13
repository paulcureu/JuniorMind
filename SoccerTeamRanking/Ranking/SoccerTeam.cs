namespace Ranking
{
    public class SoccerTeam
    {
        private readonly string name;
        private readonly int points;

        public SoccerTeam(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public bool HasFewerPoint(SoccerTeam otherTeam)
        {
            return points < otherTeam.points;
        }

        public bool IsNameEqual(SoccerTeam team)
        {
            return name == team.name;
        }
    }
}
