using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using LakerScoutingService.DataObjects;
using LakerScoutingService.Models;

namespace LakerScoutingService.Controllers
{
    public class TeamController : TableController<Team>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            LakerScoutingContext context = new LakerScoutingContext();
            DomainManager = new EntityDomainManager<Team>(context, Request);
        }

        // GET tables/Team
        public IQueryable<Team> GetAllTeams()
        {
            return Query(); 
        }

        // GET tables/Team/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Team> GetTeam(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Team/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Team> PatchTeam(string id, Delta<Team> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Team
        public async Task<IHttpActionResult> PostTeam(Team item)
        {
            Team current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Team/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTeam(string id)
        {
             return DeleteAsync(id);
        }
    }
}
