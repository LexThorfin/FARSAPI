using Microsoft.AspNetCore.Mvc;
using Entities;
using Newtonsoft.Json;

namespace FARS_GetData.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MasterDataController : Controller
    {
        /// <summary>
        /// Just getting the master data for states and their code numbers
        /// </summary>
        /// <remarks>
        /// Please note, the ID codes are not what you would expect them to be, either alphabetically, or through date becoming state
        /// and that some of them aren't states
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(US_States))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public ActionResult<US_States> getStates()
        {
            var states = BuildStateList();
            if(states == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Master Data not Found");
            }
            return StatusCode(StatusCodes.Status200OK, states);
        }

        private List<US_States> BuildStateList()
        {
            try
            {
                using (StreamReader r = new StreamReader(@"JSONData/States.json"))
                {
                    string json = r.ReadToEnd();
                    List<US_States> states = JsonConvert.DeserializeObject<List<US_States>>(json);
                    return states;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
