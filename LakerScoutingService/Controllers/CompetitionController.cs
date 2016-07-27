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
    public class CompetitionController : TableController<Competition>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            LakerScoutingContext context = new LakerScoutingContext();
            DomainManager = new EntityDomainManager<Competition>(context, Request);
        }

        // GET tables/Competition
        public IQueryable<Competition> GetAllCompetitions()
        {
            return Query(); 
        }

        // GET tables/Competition/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Competition> GetCompetition(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Competition/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Competition> PatchCompetition(string id, Delta<Competition> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Competition
        public async Task<IHttpActionResult> PostCompetition(Competition item)
        {
            Competition current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Competition/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCompetition(string id)
        {
             return DeleteAsync(id);
        }
    }
}
