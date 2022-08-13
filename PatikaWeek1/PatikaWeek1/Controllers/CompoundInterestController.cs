using Microsoft.AspNetCore.Mvc;


namespace PatikaWeek1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CompoundInterestController : ControllerBase
    {

        // GET: api/<InterestController>
        [HttpGet]
        public IActionResult GetCompoundInterest( double duration, double interest_rate, double principal )
        {
            // checking inputs are valid.
            CompoundInterest interest = new CompoundInterest();
            if (duration <= 0 || principal <= 0)
            {
                // because of the purpose of the interest, duration and principal must be higher than zero.
                // BadRequest is 400.
                return BadRequest(); 

            }

            // principal = a
            // n         = duration
            // int rate  = t

            // Formula of compound interest. taken directly from documentation.
            var compound_interest = principal * Math.Pow((1 + interest_rate), duration);

            interest.interest_amount = compound_interest - principal;
            interest.total_income = compound_interest;
            interest.interest_rate = interest_rate;

            // Ok is 200.
            return Ok(interest);

        }

    }
}
