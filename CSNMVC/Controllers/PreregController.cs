using Microsoft.AspNetCore.Mvc;
using CSNMVC.Models; // Ensure this namespace includes your ApplicationDbContext
using CSNMVC.Models.ViewModels; // Ensure this namespace includes your ChildPreregistrationViewModel
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic; // Include this for List<T>

namespace CSNMVC.Controllers
{
    public class PreRegController : Controller
    {
        private readonly ApplicationDbContext _context; // Use your ApplicationDbContext

        // Constructor for dependency injection
        public PreRegController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Prereg()
        {
            var model = new ChildPreregistrationViewModel(); // Initialize the model
            return View(model); // Pass the model to the view
        }

        public IActionResult Prereg2()
        {
                // Retrieve the Step 1 data from the session
                var step1Data = HttpContext.Session.GetString("Step1Data");

                if (step1Data != null)
                {
                    // Deserialize the JSON string back into the object
                    var model = JsonConvert.DeserializeObject<ChildPreregistration>(step1Data);
                    // Use the model in Step 2 as needed
                    // e.g., prefill some fields or use the data
                }

                return View();
        }

        public IActionResult Prereg3()
        {
            // Retrieve the Step 2 data from the session (if necessary)
            var step2Data = HttpContext.Session.GetString("Step2Data");

            ChildPreregistrationViewModel model;
            if (step2Data != null)
            {
                model = JsonConvert.DeserializeObject<ChildPreregistrationViewModel>(step2Data);
            }
            else
            {
                model = new ChildPreregistrationViewModel();
            }

            return View(model); // Pass the model to the view
        }


        public IActionResult Prereg4()
        {
            return View();
        }

        // Action method to save step 1 data
        [HttpPost]
        public async Task<IActionResult> SaveStep1Data([FromBody] ChildPreregistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create a new ChildPreregistration object and map data from the ViewModel
                var childPreregistration = new ChildPreregistration
                {
                    ChildSname = model.ChildSname,
                    ChildFname = model.ChildFname,
                    ChildMname = model.ChildMname,
                    ChildAge = model.ChildAge,
                    ChildSex = model.ChildSex,
                    Birthday = model.Birthday,
                    Address = model.Address,
                    Barangay = model.Barangay,
                    Diagnosis = model.Diagnosis,
                    ContactNumber = model.ContactNumber,
                    Email = model.Email,
                    // Convert Base64 string to byte array
                    Picture = !string.IsNullOrEmpty(model.Picture)
                        ? Convert.FromBase64String(model.Picture)
                        : null, // Set to null if there's no picture
                    // Add additional mappings for other fields as needed
                };

                // Serialize the object to JSON and store it in session
                HttpContext.Session.SetString("Step1Data", JsonConvert.SerializeObject(childPreregistration));

                // Add the entity to the context
                await _context.ChildPreregistrations.AddAsync(childPreregistration);
                await _context.SaveChangesAsync(); // Save changes to the database

                return Ok(); // Return success response
            }

            return BadRequest(ModelState); // Return error response if model state is invalid
        }

        // Action method to save step 2 data 
        [HttpPost]
        public async Task<IActionResult> SaveStep2Data([FromBody] ChildPreregistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create a new ChildPreregistration object
                var childPreregistration = new ChildPreregistration
                {           MotherMaidenName = model.MotherMaidenName,
                    MotherAge = model.MotherAge,
                    MotherBirthday = model.MotherBirthday,
                    MotherContact = model.MotherContact,
                    MotherWork = model.MotherWork,
                    FatherName = model.FatherName,
                    FatherAge = model.FatherAge,
                    FatherBirthday = model.FatherBirthday,
                    FatherContact = model.FatherContact,
                    FatherWork = model.FatherWork,
                    BothParentsJob = model.BothParentsJob,
                    SoloParent = model.SoloParent,
                    MemberOfPrograms = model.MemberOfPrograms,
                    FamilyIncome = model.FamilyIncome,
                    SiblingsInfo = model.SiblingsInfo, // Assuming this property exists in your ViewModel
                    ChildInfos = new List<ChildInfo>() // Initialize the ChildInfos collection
                };

                // Assuming you want to save multiple children
                foreach (var child in model.Children) // Ensure your ViewModel has a Children property
                {
                    var childEntry = new ChildInfo // Create an instance of ChildInfo
                    {
                        ChildName = child.ChildName, // Correct property reference
                        Child_Age = child.Child_Age,   // Correct property reference
                        Child_Sex = child.Child_Sex,    // Correct property reference
                        EducationalAttainment = child.EducationalAttainment // Correct property reference
                    };

                    childPreregistration.ChildInfos.Add(childEntry); // Add the child entry to the ChildInfos collection
                }

                // Add the ChildPreregistration entity to the context
                await _context.ChildPreregistrations.AddAsync(childPreregistration);
                await _context.SaveChangesAsync(); // Save changes to the database

                return Ok(); // Return success response
            }

            return BadRequest(ModelState); // Return error response if model state is invalid
        }

        [HttpPost]
        public async Task<IActionResult> SaveStep3Data([FromBody] ChildPreregistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Retrieve Step 1 and Step 2 data from session if needed
                var step1Data = HttpContext.Session.GetString("Step1Data");
                var step2Data = HttpContext.Session.GetString("Step2Data");

                var childPreregistration = new ChildPreregistration
                {
                    // Map existing data from session (if available)
                    ChildSname = model.ChildSname,
                    ChildFname = model.ChildFname,
                    ChildMname = model.ChildMname,
                    // Step 3-specific mappings
                    RegularCheckup = model.RegularCheckup,
                    Medicines = model.Medicines,
                    Illness = model.Illness,
                    DisabilityDifficulties = model.DisabilityDifficulties

                };
       
                // Serialize Step 3 data to session if needed
                HttpContext.Session.SetString("Step3Data", JsonConvert.SerializeObject(model));

                // Save the entity to the database
                await _context.ChildPreregistrations.AddAsync(childPreregistration);
                await _context.SaveChangesAsync();

                return Ok(); // Return success response
            }

            return BadRequest(ModelState); // Return error response if model state is invalid
        }
    }
}


