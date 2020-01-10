using System.Collections.Generic;
using Demo.Domain;
using Demo.Repositories;
using GraphQL.Types;

namespace Demo.Graph
{
    public interface IStarWarsQuery : IObjectGraphType { }

    public sealed class StarWarsQuery : ObjectGraphType<object>, IStarWarsQuery
    {
        private IStarWarsDB Context { get; }

        public StarWarsQuery(IStarWarsDB context)
        {
            Context = context;
            Name = "StarWarsQuery";

            Field<DroidType>("droid",
                arguments : new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "id of the droid" }
                ),
                resolve : ctx => Context.GetDroid(ctx.GetArgument<long>("id")));

            Field<ListGraphType<DroidType>>("droids",
                resolve : _ => Context.GetDroids());

            Field<JediType>("jedi",
                arguments : new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "id of the jedi" }
                ),
                resolve : ctx => Context.GetJedi(ctx.GetArgument<long>("id")));

            Field<ListGraphType<JediType>>("jedis",
                resolve : _ => Context.GetJedis());
        }
    }
}