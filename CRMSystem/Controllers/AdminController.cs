using CRMSystem.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRMSystem.BLL.Repositories;

namespace CRMSystem.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        Repository repo;

        public AdminController() 
        {
            repo = new Repository();
        }

        public ActionResult Index()
        {
            return PartialView();
        }

        ////////////////////////////////////////////////////////
        // View Users
        public ActionResult Users()
        {
            return PartialView();
        }
        // GET ALL USERS
        public JsonResult getAllUsers()
        {
            List<Users> list = repo.getAllUsers();
          
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // Add user
        public string AddUser(Users user)
        {
            if (user != null)
            {

                return repo.addUser(user);

            }
            else
            {
                return "Invalid book record";
            }
        }

        // GET: User by ID
        public JsonResult GetUserById(string id) 
        {
            Users user = repo.getUserById(id);

            return Json(user, JsonRequestBehavior.AllowGet);
        }

        // Update User
        public string UpdateUser(Users user) 
        {
            if (user != null){

                return repo.updateUser(user);
            }
            else {
                return "Invalid user record";
            }
        }

        // Delete User
        public string DeleteUser(string userId) 
        {
            if (!String.IsNullOrEmpty(userId))
            {
                try
                {
                    int _userId = Int32.Parse(userId);

                    return repo.deleteUser(_userId);

                }
                catch (Exception)
                {
                    return "User not found";
                }
            }
            else {
                return "Invalid operation";
            }
        }

        /////////////////////////////////////////////////////////////////////////

        // View Courses
        public ActionResult Courses()
        {
            return PartialView();
        }

        // GET ALL Courses
        public JsonResult getAllCourses()
        {
            List<Courses> list = repo.getAllCourses();

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // Add Course
        public string AddCourse(Courses course)
        {
            if (course != null)
            {
                return repo.addCourse(course);
            }
            else
            {
                return "Invalid book record";
            }
        }

        // GET: Course by ID
        public JsonResult GetCourseById(int id)
        {
            Courses course = repo.getCourseById(id);

            return Json(course, JsonRequestBehavior.AllowGet);
        }

        // Update Course
        public string UpdateCourse(Courses course)
        {
            if (course != null)
            {

                return repo.updateCourse(course);
            }
            else
            {
                return "Invalid user record";
            }
        }

        // Delete Course
        public string DeleteCourse(string courseId)
        {
            if (!String.IsNullOrEmpty(courseId))
            {
                try
                {
                    int _courseId = Int32.Parse(courseId);

                    return repo.deleteCourse(_courseId);
                }
                catch (Exception)
                {
                    return "User not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }

        /////////////////////////////////////////////////////////////////
        // View Events
        public ActionResult Events()
        {
            return PartialView();
        }

        // GET ALL Events
        public JsonResult getAllEvents()
        {
            List<Events> list = repo.getAllEvents();

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // Add Event
        public string AddEvent(Events e)
        {
            if (e != null)
            {

                return repo.addEvent(e);

            }
            else
            {
                return "Invalid event record";
            }
        }

        // GET: Event by ID
        public JsonResult GetEventById(int id)
        {
            Events e = repo.getEventById(id);

            return Json(e, JsonRequestBehavior.AllowGet);
        }

        // Update Event
        public string UpdateEvent(Events e)
        {
            if (e != null)
            {
                return repo.updateEvent(e);
            }
            else
            {
                return "Invalid user record";
            }
        }
        // Delete Event
        public string DeleteEvent(string eventId)
        {
            if (!String.IsNullOrEmpty(eventId))
            {
                try
                {
                    int _eventId = Int32.Parse(eventId);

                    return repo.deleteEvent(_eventId);
                }
                catch (Exception)
                {
                    return "Event not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }

        //////////////////////////////////////////////////////////////////////
        // View Events
        public ActionResult EventsContents()
        {
            return PartialView();
        }

        // GET ALL EventsContent
        public JsonResult getAllEventsContents()
        {
            List<EventsContent> list = repo.getAllEventsContents();

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        // Add Content
        public string AddContent(EventsContent e)
        {
            if (e != null)
            {

                return repo.addContent(e);

            }
            else
            {
                return "Invalid event record";
            }
        }
        // GET: Content by ID
        public JsonResult GetContentById(int id)
        {
            EventsContent e = repo.getContentById(id);

            return Json(e, JsonRequestBehavior.AllowGet);
        }

        // Update Content
        public string UpdateContent(EventsContent e)
        {
            if (e != null)
            {
                return repo.updateContent(e);
            }
            else
            {
                return "Invalid content record";
            }
        }
        // Delete Content
        public string DeleteContent(string contentId)
        {
            if (!String.IsNullOrEmpty(contentId))
            {
                try
                {
                    int _contentId = Int32.Parse(contentId);

                    return repo.deleteContent(_contentId);
                }
                catch (Exception)
                {
                    return "Content not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }

        // GET Events With Course for users
        public JsonResult getEventsWithCourse()
        {
            List<EventsWithCourse> list = repo.getEventsWithCourse();

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // GET: Content by ID
        public JsonResult GetUserEventsIds(int id)
        {
            List<int> ids = repo.getUserEventsIds(id);

            return Json(ids, JsonRequestBehavior.AllowGet);
        }

        public string AddSubscription(int userId, int eventId) 
        {
            Subscription sub = new Subscription() { user_id = userId, event_id = eventId };

            return repo.addSubscription(sub);
            
        }

        // Delete Subscription
        public string DeleteSubscription(string userId, string eventId)
        {
            if (!String.IsNullOrEmpty(userId) && !String.IsNullOrEmpty(eventId))
            {
                try
                {
                    int _userId = Int32.Parse(userId);
                    int _eventId = Int32.Parse(eventId);

                    return repo.deleteSubscription(_userId, _eventId);
                }
                catch (Exception)
                {
                    return "Subscription not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }

        // GET ALL Subscriptions
        public JsonResult getAllSubscriptions()
        {
            List<Subscription> list = repo.getAllSubscriptions();

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // View Subscriptions
        public ActionResult Subscriptions()
        {

            return PartialView();
        }

    }
}
