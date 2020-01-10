using System;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Graph
{
    public interface IStarWarsSchema : ISchema
    {
    }

    public sealed class StarWarsSchema : Schema, IStarWarsSchema
    {
        public StarWarsSchema(IStarWarsQuery provider)
        {
            Query = provider;
        }
    }
}