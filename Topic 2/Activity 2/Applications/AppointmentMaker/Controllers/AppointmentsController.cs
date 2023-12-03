using AppointmentMaker.Models;
using AppointmentMaker.Views.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentMaker.Controllers
{
    public class AppointmentsController : Controller
    {
        BusinessService businessService = new BusinessService();

        // GET: Appointment
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowAppointmentDetails(AppointmentModel appointment)
        {
            if (businessService.PatientHasHighEnoughNetWorth(appointment.PatientNetWorth))
            {
                if (businessService.PatientPainLevelMeetsRequirement(appointment.Painlevel))
                {
                    return View(appointment);
                }
                else
                {
                    ViewBag.Message = "patients must have a pain level exceeding 5.";
                    return View("AppointmentRejection", appointment);
                }
            }
            else
            {
                ViewBag.Message = "patients must have a net worth exceeding $90,000.";
                return View("AppointmentRejection", appointment);
            }
        }
    }
}
