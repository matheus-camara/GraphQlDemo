using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Domain;
using Demo.Repositories;
using GraphQL;
using GraphQL.Types;

namespace Demo.Graph
{
    public interface IStarWarsQuery : IObjectGraphType
    { }

    public class StarWarsQuery : ObjectGraphType<object>, IStarWarsQuery
    {
        private IStarWarsDB Context { get; }

        public StarWarsQuery(IStarWarsDB context)
        {
            Context = context;
            Name = "StarWarsQuery";

            Field<DroidType>("droid",
                arguments : new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the droid" }
                ),
                resolve : ctx => Context.GetDroid(ctx.GetArgument<long>("id")));

            Field<DroidType>("droids", resolve : _ => Context.GetDroids());

            Field<JediType>("jedi",
                arguments : new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the jedi" }
                ),
                resolve : ctx => Context.GetJedi(ctx.GetArgument<long>("id")));

            Field<JediType>("jedis", resolve : _ => Context.GetJedis());
        }
    }
}