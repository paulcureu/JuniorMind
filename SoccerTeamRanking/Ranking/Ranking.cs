namespace Ranking
{
    public class GeneralRanking
    {
        private SoccerTeam[] teams;

        public GeneralRanking()
        {
            teams = new SoccerTeam[0];
        }

        public void AddTeam(SoccerTeam team)
        {
            if (GetTeamPosition(team) != -1)
            {
                return;
            }

            Array.Resize(ref teams, teams.Length + 1);
            teams[^1] = team;
            InsertionSort(teams);
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

            InsertionSort(teams);
        }

        static void InsertionSort(SoccerTeam[] teams)
        {
            for (int i = 1; i < teams.Length; i++)
            {
                SoccerTeam current = teams[i];
                int j = i - 1;
                while (j >= 0 && teams[j].GetPoints() < current.GetPoints())
                {
                    teams[j + 1] = teams[j];
                    j--;
                }

                teams[j + 1] = current;
            }
        }
    }
}
