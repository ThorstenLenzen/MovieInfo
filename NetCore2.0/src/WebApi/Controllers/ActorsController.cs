using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using Toto.MovieInfo.DataAccess;
using Toto.MovieInfo.PersistenceModel;
using Toto.MovieInfo.ServiceModel;

namespace Toto.MovieInfo.WebApi.Controllers
{
    [Route("api/v1/actors")]
    public class ActorsController : Controller
    {
        private readonly IActorRepository _actorsRepository;
        private readonly IModelIdGenerator<Actor> _idGenerator;

        public ActorsController(
            IModelIdGenerator<Actor> idGenerator,
            IActorRepository actorsRepository)
        {
            _idGenerator = idGenerator;
            _actorsRepository = actorsRepository;
        }

        // GET api/actors
        [HttpGet]
        public IActionResult GetAllActors()
        {
            var actors = _actorsRepository.GetAllActors();

            var dtos = Mapper.Map<IEnumerable<ActorForMultiDisplay>>(actors);

            return Ok(dtos);
        }

        // GET api/actors/HarrisonFord1942
        /// <summary>
        /// Retrieves an actor, identified by his actor id.
        /// </summary>
        /// <remarks>This method retrieves an actor, identified by his actor id. The actor id consists normaly of a formalized combination of first and last name.</remarks>
        /// <param name="actorKey">The actor id consists normaly of a formalized combination of first and last name.</param>
        /// <response code="200">The actor, identified by the given actor id.</response>
        /// <response code="404">An actor with the specified actor id could not be found.</response>
        /// <response code="500">An error occured. The cause is not specified.</response>
        [SwaggerOperation("GetActorById")]
        [SwaggerResponse(200, typeof(ActorForMultiDisplay), "The actor, identified by the given actor id.")]
        [SwaggerResponse(404, typeof(ActorForMultiDisplay), "An actor with the specified actor id could not be found.")]
        [SwaggerResponse(500, typeof(ActorForMultiDisplay), "An error occured. The cause is not specified.")]
        [HttpGet("{actorKey}", Name = "GetActorByKey")]
        public IActionResult GetActorByKey(string actorKey)
        {
            var actor = _actorsRepository.GetActor(actorKey);
            var dto = Mapper.Map<ActorForMultiDisplay>(actor);

            return Ok(dto);
        }

        // POST api/actors
        /// <summary>
        /// Creates a new actor.
        /// </summary>
        /// <remarks>This method creates a new actor in the movie info data store. The newly created ctor id will consist normaly of a formalized combination of  first and last name.</remarks>
        /// <param name="actor">The actor id consists normaly of a formalized combination of first and last name.</param>
        /// <response code="204">The actor was succesfully inserted into the movie info data store.</response>
        /// <response code="404">An actor with the specified actor id could not be found.</response>
        /// <response code="500">An error occured. The cause is not specified.</response>
        [HttpPost]
        [SwaggerOperation("CreateActor")]
        public IActionResult CreateActor([FromBody]ActorForCreate actor)
        {
            var actorEntity = Mapper.Map<Actor>(actor);
            actorEntity.Key = _idGenerator.Create(actorEntity);

            _actorsRepository.CreateActor(actorEntity);
            _actorsRepository.Persist();

            var actorToReturn = Mapper.Map<ActorForMultiDisplay>(actorEntity);

            return CreatedAtRoute(
                "GetActorById", 
                new { id = actorEntity.Key },
                actorToReturn);
        }

        // POST api/actors/HarrisonFord1942
        [HttpPatch("{actorKey}")]
        public IActionResult UpdatePartialActor(string actorKey, [FromBody]string value)
        {
            // Todo: impl.

            return NoContent();
        }

        // PUT api/actors/HarrisonFord1942
        [HttpPut("{actorKey}")]
        public IActionResult UpdateCompleteActor(string actorKey, [FromBody]ActorForUpdate actor)
        {
            if (actor == null)
                return BadRequest();

            if (!_actorsRepository.ActorExist(actorKey))
                return NotFound();

            var actorEntity = Mapper.Map<Actor>(actor);
            actorEntity.Key = actorKey;

            _actorsRepository.UpdateActor(actorEntity);
            _actorsRepository.Persist();

            return NoContent();
        }

        // DELETE api/actors/HarrisonFord1942
        /// <summary>
        /// Deletes an actor.
        /// </summary>
        /// <remarks>This method deletes an existing actor from the movie info data store. The id consists normaly of a formalized combination of first and last name.</remarks>
        /// <param name="actorKey">The actor id consists normaly of a formalized combination of first and last name.</param>
        /// <response code="204">The actor was deleted from the movie info data store.</response>
        /// <response code="404">An actor with the specified actor id could not be found.</response>
        /// <response code="500">An error occured. The cause is not specified.</response>
        [SwaggerOperation("DeleteActor")]
        [HttpDelete("{actorKey}")]
        public IActionResult DeleteActor([FromRoute]string actorKey)
        {
            if (!_actorsRepository.ActorExist(actorKey))
                return NotFound();

            _actorsRepository.DeleteActor(actorKey);
            _actorsRepository.Persist();

            return NoContent();
        }
    }
}
