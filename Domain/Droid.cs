using GraphQL.Types;

namespace Demo.Domain
{
    public sealed class Droid
    {
        private Droid() { }
        public Droid(long id, string model, string type)
        {
            Id = id;
            Model = model;
            Type = type;
        }

        public long Id { get; private set; }

        public string Model { get; private set; }

        public string Type { get; private set; }
    }

    public sealed class DroidType : ObjectGraphType<Droid>
    {
        public DroidType()
        {
            Name = "Droid";
            Description = "A mechanical creature in the Star Wars universe.";
            Field(x => x.Id).Description("The Primary Key.");
            Field(x => x.Model).Description("The Model of the droid");
            Field(x => x.Type).Description("The Type of the droid");
        }
    }
}