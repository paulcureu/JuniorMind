namespace Ranking
{
    public class GeneralRanking
    {
        private SoccerTeam[] teams;

        public GeneralRanking(SoccerTeam[] teams)
        {
            this.teams = teams;
            Sort();
        }

        public void AddTeam(SoccerTeam team)
        {
            Array.Resize(ref teams, teams.Length + 1);
            teams[^1] = team;
            Sort();
        }

        public int GetTeamPosition(SoccerTeam team)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].IsNameEqual(team))
                {
                    return i + 1;
                }
            }

            return -1;
        }

        private static void Swap(SoccerTeam[] teams, int firstIndex, int secondIndex)
        {
            SoccerTeam temp = teams[firstIndex];
            teams[firstIndex] = teams[secondIndex];
            teams[secondIndex] = temp;
        }

        private void Sort()
        {
            int n = teams.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (teams[j].HasFewerPoint(teams[j + 1]))
                    {
                        Swap(teams, j, j + 1);
                    }
                }
            }
        }
    }
}
