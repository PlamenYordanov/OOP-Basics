using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TeamCollection : IEnumerable<Team>
{
    private List<Team> teams = new List<Team>();

    public IEnumerator<Team> GetEnumerator()
    {
        return teams.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public void AddTeam(Team team)
    {
        teams.Add(team);
    }
}

