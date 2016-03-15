using AppFixAPI.Services;
using System.Web.Http;

namespace AppFixAPI.Controllers
{
    public class KontehChallengeController : ApiController
    {
        private IGuidProvider _guidProvider;
        private IResultGenerator _resultGenerator;

        public KontehChallengeController(IGuidProvider guidProvider, IResultGenerator resultGenerator)
        {
            _guidProvider = guidProvider;
            _resultGenerator = resultGenerator;
        }

        public IHttpActionResult GetResult()
        {
            var guid = _guidProvider.GetGuid();
            var result = _resultGenerator.GenerateResult(guid);
            return Ok(result);
        }
    }
}