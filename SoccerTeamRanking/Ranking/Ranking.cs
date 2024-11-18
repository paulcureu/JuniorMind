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
            QuickSort(teams, 0, teams.Length - 1);
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

            QuickSort(teams, 0, teams.Length - 1);
        }

        private void QuickSort(SoccerTeam[] teams, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int pivotIndex = Partition(teams, left, right);
            QuickSort(teams, left, pivotIndex - 1);
            QuickSort(teams, pivotIndex + 1, right);
        }

        private int Partition(SoccerTeam[] teams, int left, int right)
        {
            int pivot = teams[right].GetPoints();
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (teams[j].GetPoints() >= pivot)
                {
                    i++;
                    Swap(i, j);
                }
            }

            Swap(i + 1, right);
            return i + 1;
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            (teams[firstIndex], teams[secondIndex]) = (teams[secondIndex], teams[firstIndex]);
        }
    }
}
