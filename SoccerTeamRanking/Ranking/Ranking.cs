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
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].IsNameEqual(team))
                {
                    return;
                }
            }

            Array.Resize(ref teams, teams.Length + 1);
            teams[^1] = team;
            Sort();
        }

        public SoccerTeam GetTeamByPosition(int position)
        {
            return teams[position - 1];
        }

        public int GetTeamPositionByName(SoccerTeam team)
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

        public void UpdateTeamPoints(SoccerTeam team1, SoccerTeam team2, int team1GameResult, int team2GameResult)
        {
            if (team1 == null || team2 == null)
            {
                return;
            }

            const int DrawPoints = 1;
            const int WinPoints = 3;
            if (team1GameResult == team2GameResult)
            {
                team1.AddPoints(DrawPoints);
                team2.AddPoints(DrawPoints);
            }
            else if (team1GameResult > team2GameResult)
            {
                team1.AddPoints(WinPoints);
            }
            else
            {
                team2.AddPoints(WinPoints);
            }

            Sort();
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
                    if (teams[j].HasFewerPointsThan(teams[j + 1]))
                    {
                        Swap(teams, j, j + 1);
                    }
                }
            }
        }
    }
}
