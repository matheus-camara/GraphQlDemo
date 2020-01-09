using System.Collections.Generic;
using System.Linq;
using Demo.Domain;

namespace Demo.Repositories
{
    public interface IStarWarsDB
    {
        Droid GetDroid(long id);
        IEnumerable<Droid> GetDroids();
        Jedi GetJedi(long id);
        IEnumerable<Jedi> GetJedis();
    }

    public class StarWarsDB : IStarWarsDB
    {
        public IEnumerable<Jedi> GetJedis() => new List<Jedi>
        {
            new Jedi(0, "Luke", "Light"),
            new Jedi(1, "Leia", "Light"),
            new Jedi(2, "Yoda", "Light"),
            new Jedi(3, "Darth Vader", "Dark"),
            new Jedi(4, "Darth Sidius", "Dark"),
        };

        public Jedi GetJedi(long id) => GetJedis().SingleOrDefault(j => j.Id == id);

        public IEnumerable<Droid> GetDroids() => new List<Droid>
        {
            new Droid(0, "R2-D2", "Astromech"),
            new Droid(1, "C2-PO", "Protocol"),
            new Droid(2, "BB-8", "Ball"),
            new Droid(3, "B1", "Combat"),
            new Droid(4, "GH-7", "Medical Analysis Unit"),
        };

        public Droid GetDroid(long id) => GetDroids().SingleOrDefault(d => d.Id == id);
    }
}