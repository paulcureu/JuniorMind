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

            int position = BinarySerch(team);
            Array.Resize(ref teams, teams.Length + 1);

            for (int i = teams.Length - 1; i > position; i--)
            {
                teams[i] = teams[i - 1];
            }

            teams[position] = team;
        }

        public int BinarySerch(SoccerTeam team)
        {
            int left = 0;
            int right = teams.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (teams[mid].HasFewerPointsThan(team))
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return left;
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

            InsertionSort();
        }

        public void InsertionSort()
        {
            for (int i = 1; i < teams.Length; i++)
            {
                for (int j = i; j > 0 && teams[j - 1].HasFewerPointsThan(teams[j]); j--)
                {
                    (teams[j - 1], teams[j]) = (teams[j], teams[j - 1]);
                }
            }
        }
    }
}
