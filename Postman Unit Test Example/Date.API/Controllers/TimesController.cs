using Date.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Date.API.Controllers
{
    [Route("v1/times")]
    [ApiController]
    public class TimesController : ControllerBase
    {

        [HttpGet("days-in-month")]
        public Task<IActionResult> GetDaysInMonth([FromQuery] DayInMonthDto query)
        {
            try
            {
                var daysInMonth = DateTime.DaysInMonth(query.Year, query.Month);

                var data = new
                { 
                    query.Year,
                    query.Month,
                    daysInMonth 
                };

                var res = new
                {
                    code = "success",
                    data
                };

                return Task.FromResult<IActionResult>(Ok(res));
            }
            catch (Exception ex)
            {
                var err = new
                {
                    code = "error",
                    message = $"An error occurred: {ex.Message}"
                };
                // Log the exception here
                return Task.FromResult<IActionResult>(BadRequest(err));
            }
        }

        [HttpGet("today")]
        public Task<IActionResult> GetToday()
        {
            try
            {
                var today = DateTime.Today;
                var dayOfWeek = today.DayOfWeek.ToString();
                var ddMMyyyy = today.ToString("dd/MM/yyyy");

                var data = new
                {
                    today,
                    dayOfWeek,
                    ddMMyyyy
                };

                var res = new
                {
                    code = "success",
                    data
                };

                return Task.FromResult<IActionResult>(Ok(res));
            }
            catch (Exception ex)
            {
                var err = new
                {
                    code = "error",
                    message = $"An error occurred: {ex.Message}"
                };
                // Log the exception here
                return Task.FromResult<IActionResult>(BadRequest(err));
            }
        }

        [HttpGet("current-week")]
        public Task<IActionResult> GetCurrentWeek()
        {
            try
            {
                var today = DateTime.Today;
                int currentDayOfWeek = (int)DateTime.Today.DayOfWeek;

                var startOfWeek = today.AddDays(-currentDayOfWeek);
                var weekDates = Enumerable.Range(1, 7).Select(days => startOfWeek.AddDays(days));

                var data = new
                {
                    dates = weekDates.Select(date => new
                    {
                        date,
                        ddMMyyyy = date.ToString("dd/MM/yyyy"),
                        dayOfWeek = date.DayOfWeek.ToString()
                    }),
                };

                var res = new
                {
                    code = "success",
                    data
                };

                return Task.FromResult<IActionResult>(Ok(res));
            }
            catch (Exception ex)
            {
                // Log the exception here
                var err = new
                {
                    code = "error",
                    message = $"An error occurred: {ex.Message}"
                };
                // Log the exception here
                return Task.FromResult<IActionResult>(BadRequest(err));
            }
        }

        [HttpGet("current-month")]
        public Task<IActionResult> GetCurrentMonth()
        {
            try
            {
                var today = DateTime.Today;
                var startOfMonth = new DateTime(today.Year, today.Month, 1);
                var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

                var daysInMonth = Enumerable.Range(0, (endOfMonth - startOfMonth).Days + 1)
                                            .Select(days => startOfMonth.AddDays(days));

                var data = new
                {
                    dates = daysInMonth.Select(date => new
                    {
                        date,
                        ddMMyyyy = date.ToString("dd/MM/yyyy"),
                        dayOfWeek = date.DayOfWeek.ToString()
                    }),
                };

                var res = new
                {
                    code = "success",
                    data
                };

                return Task.FromResult<IActionResult>(Ok(res));
            }
            catch (Exception ex)
            {
                // Log the exception here
                var err = new
                {
                    code = "error",
                    message = $"An error occurred: {ex.Message}"
                };
                return Task.FromResult<IActionResult>(BadRequest(err));
            }
        }

        [HttpGet("specific-month")]
        public Task<IActionResult> GetSpecificMonth([FromQuery] DayInMonthDto query)
        {
            try
            {
                var startOfMonth = new DateTime(query.Year, query.Month, 1);
                var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

                var daysInMonth = Enumerable.Range(0, (endOfMonth - startOfMonth).Days + 1)
                                            .Select(days => startOfMonth.AddDays(days));

                var data = new
                {
                    dates = daysInMonth.Select(date => new
                    {
                        date,
                        ddMMyyyy = date.ToString("dd/MM/yyyy"),
                        dayOfWeek = date.DayOfWeek.ToString()
                    }),
                };

                var res = new
                {
                    code = "success",
                    data
                };

                return Task.FromResult<IActionResult>(Ok(res));
            }
            catch (Exception ex)
            {
                // Log the exception here
                var err = new
                {
                    code = "error",
                    message = $"An error occurred: {ex.Message}"
                };
                return Task.FromResult<IActionResult>(BadRequest(err));
            }
        }


    }
}
