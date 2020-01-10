using GraphQL.Types;

namespace Demo.Domain
{
    public sealed class Jedi
    {
        private Jedi() { }
        public Jedi(long id, string name, string side)
        {
            Id = id;
            Name = name;
            Side = side;
        }

        public long Id { get; private set; }

        public string Name { get; private set; }

        public string Side { get; private set; }
    }

    public sealed class JediType : ObjectGraphType<Jedi>
    {
        public JediType()
        {
            Name = "Jedi";
            Description = "A member of a ancient order of protectors";
            Field(x => x.Id).Description("The Primary Key.");
            Field(x => x.Name).Description("The Name of the droid");
            Field(x => x.Side).Description("The Side of the droid");
        }
    }
}