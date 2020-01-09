using System;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Graph
{
    public interface IStarWarsSchema : ISchema
    {
    }

    public class StarWarsSchema : Schema, IStarWarsSchema
    {
        public StarWarsSchema(IServiceProvider provider)
        {
            Query = provider.GetRequiredService<IStarWarsQuery>();
        }
    }
}