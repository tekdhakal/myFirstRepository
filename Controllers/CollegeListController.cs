/* Name: Pushpa Dhakal, Course: C# .NET
Code Louisville @ Bellarmine University, Mondays 6:00PM to 8:00PM 
Spring 2020
Instructor: Steve England
 */


using CollegeListOfAmerica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.SqlServer;

namespace CollegeListOfAmerica.Controllers
{
    //This inherits Controller class.
    public class CollegeListController : Controller
    {
        // I have created index.cshtml page for this action in order to display the list of 
        // datas on the index page.
        public ActionResult Index()
        {
            //Made an object variable as universities to model UnversitiesEntities
            using(UniversitiesEntities universities= new UniversitiesEntities())
            {
                //This will allow to view all the list of available colleges from table
                //Converting the data to list
               var listOfUniversities= universities.InstituteCampuses_.ToList();
               var universitiesInAscendingOrder = listOfUniversities.OrderBy(a => a.Name);

                return View(universitiesInAscendingOrder);

            }       
        }

        //This is to display detail of data based onid.        
        //This is to GET: CollegeList/Details/5
        public ActionResult Details(int id)
        {
            //Made an object variable as collegeDetails to model UnversitiesEntities
            using (UniversitiesEntities collegeDetails = new UniversitiesEntities())
            {
               //Details method takes id as an input.
               //So, we are assigning collegeID == id
                return View(collegeDetails.InstituteCampuses_.Where(a=>a.CollegeID ==id).FirstOrDefault());
            }
            
        }

        //This will allow to create new list to the table
        //This is to GET: CollegeList/Create
        public ActionResult Create()
        {
            return View();
        }

        //This will be for creating new list 
        // POST: CollegeList/Create
        [HttpPost]
        public ActionResult Create(InstituteCampuses_ newDatas) // This will create new data to data set in model
        {
            try
            {
                ////Made an object variable as collegeInput to model UnversitiesEntities
                using (UniversitiesEntities collegeInput = new UniversitiesEntities())
                {
                    //We will add new datas by using .Add()
                    collegeInput.InstituteCampuses_.Add(newDatas);
                    collegeInput.SaveChanges(); //This will allow to save data that was entered on previous parameter.

                }
                //When we hit the submit botton, it will redirect us to the Index page.
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // Creating an option to edit the data set 
        //This will run as GET: CollegeList/Edit/1 in mainpage
        public ActionResult Edit(int id)
        {
            using (UniversitiesEntities collegeEdit = new UniversitiesEntities())
            {
                return View(collegeEdit.InstituteCampuses_.Where(a => a.CollegeID == id).FirstOrDefault());
            }
        }
        //Once it is edited, it will allow to save new data in the list
        // POST: CollegeList/Edit/1
        [HttpPost]
        public ActionResult Edit(InstituteCampuses_ newDatas)
        {
            try
            {
                using (UniversitiesEntities collegeEdit = new UniversitiesEntities())
                {
                    //Modifying the data
                    collegeEdit.Entry(newDatas).State = EntityState.Modified;
                    // This will allow to save edited data.
                    collegeEdit.SaveChanges(); 

                }
                //When we hit the submit botton, it will redirect us to the Index page.
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // This is for an option to delete data and it is also added in view
        // GET: CollegeList/Delete/1
        public ActionResult Delete(int id)
        {

            using (UniversitiesEntities collegeDelete = new UniversitiesEntities())
            {
                return View(collegeDelete.InstituteCampuses_.Where(a => a.CollegeID == id).FirstOrDefault());
            }
          
        }

        // This is a POST example: CollegeList/Delete/1
        [HttpPost]
        public ActionResult Delete(int id, InstituteCampuses_ newDatas)
        {
            try
            {
                using (UniversitiesEntities collegeDelete = new UniversitiesEntities())
                {
                    InstituteCampuses_ everyEntry = collegeDelete.InstituteCampuses_.Where(a => a.CollegeID == id).FirstOrDefault();
                    //This will remove the entry
                    collegeDelete.InstituteCampuses_.Remove(everyEntry);
                    // This will save the changes
                    collegeDelete.SaveChanges();

                }
                //When we hit the submit botton, it will redirect us to the Index page.
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Practice(string x)
        {
            return View();
        }
    }
}
