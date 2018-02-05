using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using MoMAGraphQL.GraphQL;
using System;
using System.Threading.Tasks;

namespace MoMAGraphQL.Controllers
{
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        private IDocumentExecuter documentExecuter;
        private ISchema schema;

        public GraphQLController(IDocumentExecuter documentExecuter, ISchema schema)
        {
            this.documentExecuter = documentExecuter;
            this.schema = schema;
        }

        public IActionResult Index()
        {
            throw new NotImplementedException();
        }

        // POST api/graphql
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            var executionOptions = new ExecutionOptions
            {
                Schema = schema,
                Query = root.Query
            };

            try
            {
                var result = await documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

                if (result.Errors?.Count > 0)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}