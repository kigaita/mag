using System.Collections.Generic;
using System.Linq;
using Bogus;
using MediatR;
using Newtonsoft.Json;
using UwbItContest.Web.Features.Shared;

namespace UwbItContest.Web.Features.Ajax
{
    public class GetTeams
    {
        public class Query : IRequest<DataTableResponse<Models.Team>>
        {
            
        }

        public class QueryHandler : IRequestHandler<Query, DataTableResponse<Models.Team>>
        {
            public DataTableResponse<Models.Team> Handle(Query message)
            {
                var id = 0;

                var data =
                    new Faker<Models.Team>()
                        .RuleFor(t => t.Id, f => ++id)
                        .RuleFor(t => t.Name, f => f.Name.FirstName())
                        .Generate(15)
                        .ToList();

                return DataTableResponse<Models.Team>.Create(data);
            }
        }

        //public class Query : IRequest<string>
        //{

        //}

        //public class QueryHandler : IRequestHandler<Query, string>
        //{
        //    public string Handle(Query message)
        //    {
        //        var id = 0;

        //        var data =
        //            new Faker<Models.Team>()
        //                .RuleFor(t => t.Id, f => ++id)
        //                .RuleFor(t => t.Name, f => f.Name.FirstName())
        //                .Generate(15)
        //                .ToList();

        //        return JsonConvert.SerializeObject(data, Formatting.None, new DataTableReponseJsonConverter());
        //    }
        //}
    }
}