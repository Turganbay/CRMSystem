using CRMSystem.BLL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CRMSystem.DAL.Domain;

namespace CRMSystem.BLL.Repositories
{
    public class Repository
    {
        CRMSystemDomain db;
        public Repository()
        {
            db = new CRMSystemDomain();
        }

        //////////////////////////////////////////////////////////////////
        // GET USER
        public Users getUser(LoginData l)
        {
            Users user = new Users();

            if (db.isOpen())
            {       
                var reader = db.GetUser(l.username, l.password);

                while (reader.Read())
                {
                    user.id = Convert.ToInt32(reader["id"]);
                    user.username = reader["username"].ToString();
                    user.email = reader["email"].ToString();
                    user.role = Convert.ToInt32(reader["role"]);
                }

            }
            db.Close();

            return user;
        }
        /////////////////////////////////////////////////////////////////////
        // GET ALL USERS
        public List<Users> getAllUsers()
        {
            List<Users> list = new List<Users>();
            
            if (db.isOpen())
            {
                var reader = db.GetAllUsers();
                while (reader.Read())
                {
                    Users user = new Users();
                    user.id = Convert.ToInt32(reader["id"]);
                    user.username = reader["username"].ToString();
                    user.password = reader["password"].ToString();
                    user.email = reader["email"].ToString();
                    user.role = Convert.ToInt32(reader["role"]);
                    list.Add(user);
                }
            }

            db.Close();

            return list;
        }

        // add user
        public string addUser(Users user)
        {
            if (db.isOpen())
            {
                db.AddUser(user.username, user.password, user.email, user.role);
            }
            db.Close();

            return "Successfull";
        }

        // GET User By ID
        public Users getUserById(string id) 
        {
            Users user = new Users();

            if (db.isOpen())
            {
                var reader = db.GetUserById(id);
                while (reader.Read())
                {
                    user.id = Convert.ToInt32(reader["id"]); 
                    user.username = reader["username"].ToString();
                    user.password = reader["password"].ToString();
                    user.email = reader["email"].ToString();
                    user.role = Convert.ToInt32(reader["role"]);
                }
            }
            db.Close();

            return user;
        }

        // Update User
        public string updateUser(Users user)
        {
            if (db.isOpen())
            {
                db.UpdateUser(user.id, user.username, user.password, user.email, user.role);
            }

            db.Close();

            return "Successfull";

        }

        // Delete User
        public string deleteUser(int userId)
        {
            if (db.isOpen())
            {
                db.DeleteUser(userId);
            }
            db.Close();

            return "Successfull";
        }

        //////////////////////////////////////////////////////////////////////
        // GET ALL Courses
        public List<Courses> getAllCourses()
        {
            List<Courses> list = new List<Courses>();

            if (db.isOpen())
            {
                var reader = db.GetAllCourses();
               
                while (reader.Read())
                {
                    Courses course = new Courses();
                    course.id = Convert.ToInt32(reader["id"]);
                    course.name = reader["name"].ToString();
                    course.description = reader["description"].ToString();
                    list.Add(course);
                }
            }
            db.Close();

            return list;
        }

        // add Course
        public string addCourse(Courses course)
        {
            if (db.isOpen())
            {
                db.AddCourse(course.name, course.description);
            }
            db.Close();

            return "Successfull";
        }

        // GET Course By ID
        public Courses getCourseById(int id)
        {
            Courses course = new Courses();

            if (db.isOpen())
            {
                var reader = db.GetCourseById(id);
                while (reader.Read())
                {
                    course.id = Convert.ToInt32(reader["id"]);
                    course.name = reader["name"].ToString();
                    course.description = reader["description"].ToString();
                }
            }
            db.Close();

            return course;
        }

        // Update Course
        public string updateCourse(Courses course)
        {
            if (db.isOpen())
            {
                db.UpdateCourse(course.id, course.name, course.description);
            }
            db.Close();

            return "Successfull";
        }

        // Delete Course
        public string deleteCourse(int courseId)
        {
            if (db.isOpen())
            {
                db.DeleteCourse(courseId);

            }
            db.Close();

            return "Successfull";
        }

        //////////////////////////////////////////////////////////////////////
        // GET ALL Events
        public List<Events> getAllEvents()
        {
            List<Events> list = new List<Events>();

            if (db.isOpen())
            {
                var reader = db.GetAllEvents();
                while (reader.Read())
                {
                    Events e = new Events();
                    e.id = Convert.ToInt32(reader["id"]);
                    e.name = reader["name"].ToString();
                    e.description = reader["description"].ToString();
                    e.event_date =  Convert.ToDateTime(reader["event_date"]).ToString("dd.MM.yyyy");
                    list.Add(e);
                }
            }
            db.Close();

            return list;
        }

        // add event
        public string addEvent(Events e)
        {
            if (db.isOpen())
            {
                db.AddEvent(e.name, e.description, e.event_date);
            }
            db.Close();

            return "Successfull";
        }

        // GET Event By ID
        public Events getEventById(int id)
        {
            Events e = new Events();

            if (db.isOpen())
            {
                var reader = db.GetEventById(id);

                while (reader.Read())
                {
                    e.id = Convert.ToInt32(reader["id"]);
                    e.name = reader["name"].ToString();
                    e.description = reader["description"].ToString();
                    e.event_date = Convert.ToDateTime(reader["event_date"]).ToString("dd.MM.yyyy");
                }

            }
            db.Close();

            return e;
        }

        // Update Event
        public string updateEvent(Events e)
        {
            if (db.isOpen())
            {
                db.UpdateEvent(e.id, e.name, e.description, e.event_date);

            }
            db.Close();

            return "Successfull";
        }

        // Delete Event
        public string deleteEvent(int eventId)
        {
            if (db.isOpen())
            {
                db.DeleteEvent(eventId);

            }
            db.Close();

            return "Successfull";
        }
        /////////////////////////////////////////////////////////////////
        // GET ALL EventsContents
        public List<EventsContent> getAllEventsContents()
        {
            List<EventsContent> list = new List<EventsContent>();

            if (db.isOpen())
            {
                var reader = db.GetAllEventsContents();

                while (reader.Read())
                {
                    EventsContent e = new EventsContent();

                    e.id = Convert.ToInt32(reader["id"]);
                    e.event_id = Convert.ToInt32(reader["event_id"]);
                    e.course_id = Convert.ToInt32(reader["course_id"]);
                    list.Add(e);
                }

            }
            db.Close();

            return list;
        }

        // add Content
        public string addContent(EventsContent e)
        {
            if (db.isOpen())
            {
                db.AddContent(e.event_id, e.course_id);
            }
            db.Close();

            return "Successfull";
        }

        // GET Content By ID
        public EventsContent getContentById(int id)
        {
            EventsContent e = new EventsContent();

            if (db.isOpen())
            {
                var reader = db.GetContentById(id);

                while (reader.Read())
                {
                    e.id = Convert.ToInt32(reader["id"]);
                    e.event_id = Convert.ToInt32(reader["event_id"]);
                    e.course_id = Convert.ToInt32(reader["course_id"]);
                }

            }
            db.Close();

            return e;
        }


        // Update Content
        public string updateContent(EventsContent e)
        {
            if (db.isOpen())
            {
                db.UpdateContent(e.id, e.event_id, e.course_id);
            }
            db.Close();

            return "Successfull";
        }


        // Delete Content
        public string deleteContent(int contentId)
        {
            if (db.isOpen())
            {
                db.DeleteContent(contentId);
            }
            db.Close();

            return "Successfull";
        }

        // GET ALL Events with course
        public List<EventsWithCourse> getEventsWithCourse()
        {
            List<EventsWithCourse> list = new List<EventsWithCourse>();

            if (db.isOpen())
            {
                var reader = db.GetEventsWithCourse();

                while (reader.Read())
                {
                    EventsWithCourse e = new EventsWithCourse();
                    e.event_id = Convert.ToInt32(reader["event_id"]);
                    e.event_name = reader["event_name"].ToString();
                    e.course_name = reader["course_name"].ToString();
                    list.Add(e);
                }

            }
            db.Close();

            return list;
        }


        ///////////////////////////////////////////////////////////////////////////
        // GET User By ID
        public List<int> getUserEventsIds(int id)
        {
            List<int> ids = new List<int>();

            if (db.isOpen())
            {
                var reader = db.GetUserEventsIds(id);

                while (reader.Read())
                {
                    int event_id = Convert.ToInt32(reader["event_id"]);
                    ids.Add(event_id);
                }

            }
            db.Close();

            return ids;

        }

        // add Subscription
        public string addSubscription(Subscription s)
        {
            if (db.isOpen())
            {
                db.AddSubscription(s.event_id, s.user_id);
            }
            db.Close();

            return "Successfull";
        }

        // Delete Subscription
        public string deleteSubscription(int userId, int eventId)
        {
            if (db.isOpen())
            {
                db.DeleteSubscription(userId, eventId);

            }
            db.Close();

            return "Successfull";
        }

        // get All Subscriptions
        public List<Subscription> getAllSubscriptions()
        {
            List<Subscription> list = new List<Subscription>();

            if (db.isOpen())
            {
                var reader = db.GetAllSubscriptions();

                while (reader.Read())
                {
                    Subscription s = new Subscription();
                    s.id = Convert.ToInt32(reader["id"]);
                    s.event_id = Convert.ToInt32(reader["event_id"]);
                    s.user_id = Convert.ToInt32(reader["user_id"]);
                    s.event_name = reader["event_name"].ToString();
                    s.user_name = reader["user_name"].ToString();
                    list.Add(s);
                }

            }
            db.Close();

            return list;
        }

    }
}