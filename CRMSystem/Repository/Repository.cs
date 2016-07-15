using CRMSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRMSystem.Repository
{
    public class Repository
    {
        ConnectDb db;
        public Repository()
        {
            db = new ConnectDb();
        }

        //////////////////////////////////////////////////////////////////
        // GET USER
        public Users getUser(LoginData l)
        {

            Users user = new Users();

            if (db.isOpen())
            {
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.getUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", l.username);
                cmd.Parameters.AddWithValue("@password", l.password);
                var reader = cmd.ExecuteReader();
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
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.getAllUsers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();
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
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.addUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@role", user.role);
                cmd.ExecuteNonQuery();
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
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.getUserById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
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
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.updateUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", user.id);
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@role", user.role);
                cmd.ExecuteNonQuery();
            }
            db.Close();

            return "Successfull";
        
        }

        // Delete User
        public string deleteUser(int userId)
        {
            if (db.isOpen())
            {
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.deleteUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", userId);
                cmd.ExecuteNonQuery();
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
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.getAllCourses", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();
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
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.addCourse", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", course.name);
                cmd.Parameters.AddWithValue("@description", course.description);
                cmd.ExecuteNonQuery();
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
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.getCourseById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
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
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.updateCourse", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", course.id);
                cmd.Parameters.AddWithValue("@name", course.name);
                cmd.Parameters.AddWithValue("@description", course.description);
                cmd.ExecuteNonQuery();
            }
            db.Close();

            return "Successfull";
        }

        // Delete Course
        public string deleteCourse(int courseId)
        {
            if (db.isOpen())
            {
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.deleteCourse", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", courseId);
                cmd.ExecuteNonQuery();
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
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.getAllEvents", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();
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
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.addEvent", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", e.name);
                cmd.Parameters.AddWithValue("@description", e.description);
                cmd.Parameters.AddWithValue("@event_date", e.event_date);
                cmd.ExecuteNonQuery();
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
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.getEventById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
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
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.updateEvent", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", e.id);
                cmd.Parameters.AddWithValue("@name", e.name);
                cmd.Parameters.AddWithValue("@description", e.description);
                cmd.Parameters.AddWithValue("@event_date", e.event_date);
                cmd.ExecuteNonQuery();
            }
            db.Close();

            return "Successfull";
        }

        // Delete Event
        public string deleteEvent(int eventId)
        {
            if (db.isOpen())
            {
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.deleteEvent", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", eventId);
                cmd.ExecuteNonQuery();
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
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.getAllEventsContent", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();
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
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.addEventsContent", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@event_id", e.event_id);
                cmd.Parameters.AddWithValue("@course_id", e.course_id);
                cmd.ExecuteNonQuery();
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
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.getContentById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
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
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.updateEventsContent", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", e.id);
                cmd.Parameters.AddWithValue("@event_id", e.event_id);
                cmd.Parameters.AddWithValue("@course_id", e.course_id);
                cmd.ExecuteNonQuery();
            }
            db.Close();

            return "Successfull";
        }


        // Delete Content
        public string deleteContent(int contentId)
        {
            if (db.isOpen())
            {
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.deleteEventsContent", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", contentId);
                cmd.ExecuteNonQuery();
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
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.getEventsWithCourse", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();
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
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.getUserEventsIds", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
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
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.addSubscription", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@event_id", s.event_id);
                cmd.Parameters.AddWithValue("@user_id", s.user_id);
                cmd.ExecuteNonQuery();
            }
            db.Close();

            return "Successfull";
        }

        // Delete Subscription
        public string deleteSubscription(int userId, int eventId)
        {
            if (db.isOpen())
            {
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.deleteSubscription", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@event_id", eventId);
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.ExecuteNonQuery();
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
                var conn = db.GetConnection();

                SqlCommand cmd = new SqlCommand("dbo.getAllSubscriptions", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();
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