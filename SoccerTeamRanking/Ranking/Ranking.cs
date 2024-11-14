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
            if (Array.Exists(teams, existingTeam => existingTeam == team))
            {
                return;
            }

            Array.Resize(ref teams, teams.Length + 1);
            teams[^1] = team;
            Sort();
        }

        public SoccerTeam GetTeamByPosition(int position)
        {
            return teams[position - 1];
        }

        public int GetTeamPosition(SoccerTeam team)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i] == team)
                {
                    return i + 1;
                }
            }

            return -1;
        }

        public void Update(SoccerTeam homeTeam, SoccerTeam awayTeam, int homeResult, int awayResult)
        {
            if (homeTeam == null || awayTeam == null)
            {
                return;
            }

            const int DrawPoints = 1;
            const int WinPoints = 3;

            if (homeResult == awayResult)
            {
                homeTeam.AddPoints(DrawPoints);
                awayTeam.AddPoints(DrawPoints);
            }
            else if (homeResult > awayResult)
            {
                homeTeam.AddPoints(WinPoints);
            }
            else
            {
                awayTeam.AddPoints(WinPoints);
            }

            Sort();
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            (teams[firstIndex], teams[secondIndex]) = (teams[secondIndex], teams[firstIndex]);
        }

        private void Sort()
        {
            bool swapped;
            int n = teams.Length;
            for (int i = 0; i < n; i++)
            {
                swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (teams[j].HasFewerPointsThan(teams[j + 1]))
                    {
                        Swap(j, j + 1);
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }
    }
}
