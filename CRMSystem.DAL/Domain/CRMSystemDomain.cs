using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CRMSystem.DAL.Domain
{
    public class CRMSystemDomain
    {
        protected SqlConnection con;

        public CRMSystemDomain() 
        {
            con = GetConnection();
        }

        // _CONNECTION_OPEN
        public bool isOpen(string Connection = "DefaultConnection")
        {
            con = new SqlConnection(@WebConfigurationManager.ConnectionStrings[Connection].ToString());

            try
            {
                bool b = true;
                if (con.State.ToString() != "Open")
                {
                    con.Open();
                }
                return b;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        // _CONNECTION_STRING
        public SqlConnection GetConnection()
        {
            return con;
        }

        // _CONNECTION_CLOSE
        public bool Close()
        {
            try
            {
                con.Close();
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // get user data
        public SqlDataReader GetUser(string username, string password)
        {

            SqlCommand cmd = new SqlCommand("dbo.getUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            var reader = cmd.ExecuteReader();

            return reader;
                
        }

        // get all users
        public SqlDataReader GetAllUsers()
        {
            SqlCommand cmd = new SqlCommand("dbo.getAllUsers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            var reader = cmd.ExecuteReader();

            return reader;
                
        }

        // add user
        public void AddUser(string username, string password, string email, int role)
        {
            SqlCommand cmd = new SqlCommand("dbo.addUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@role", role);
            cmd.ExecuteNonQuery();
        }

        // get user by id
        public SqlDataReader GetUserById(string id)
        {
            SqlCommand cmd = new SqlCommand("dbo.getUserById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            var reader = cmd.ExecuteReader();

            return reader;
        }

        // update user
        public void UpdateUser(int id, string username, string password, string email, int role)
        {
            SqlCommand cmd = new SqlCommand("dbo.updateUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@role", role);
            cmd.ExecuteNonQuery();
        }

        // delete user
        public void DeleteUser(int userId)
        {
            SqlCommand cmd = new SqlCommand("dbo.deleteUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.ExecuteNonQuery();
        }

        // get all courses
        public SqlDataReader GetAllCourses()
        {
            SqlCommand cmd = new SqlCommand("dbo.getAllCourses", con);
            cmd.CommandType = CommandType.StoredProcedure;
            var reader = cmd.ExecuteReader();

            return reader;
        }

        public void AddCourse(string name, string description)
        {
            SqlCommand cmd = new SqlCommand("dbo.addCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.ExecuteNonQuery();
        }

        // get course by id
        public SqlDataReader GetCourseById(int id)
        {
            SqlCommand cmd = new SqlCommand("dbo.getCourseById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            var reader = cmd.ExecuteReader();

            return reader;
        }

        public void UpdateCourse(int id, string name, string description)
        {
            SqlCommand cmd = new SqlCommand("dbo.updateCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.ExecuteNonQuery();
        }

        // delete course
        public void DeleteCourse(int courseId)
        {
            SqlCommand cmd = new SqlCommand("dbo.deleteCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", courseId);
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader GetAllEvents()
        {
            SqlCommand cmd = new SqlCommand("dbo.getAllEvents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            var reader = cmd.ExecuteReader();

            return reader;
        }

        // add event
        public void AddEvent(string name, string description, string event_date)
        {
            SqlCommand cmd = new SqlCommand("dbo.addEvent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@event_date", event_date);
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader GetEventById(int id)
        {
            SqlCommand cmd = new SqlCommand("dbo.getEventById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            var reader = cmd.ExecuteReader();

            return reader;
        }

        // update event
        public void UpdateEvent(int id, string name, string description, string event_date)
        {
            SqlCommand cmd = new SqlCommand("dbo.updateEvent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@event_date", event_date);
            cmd.ExecuteNonQuery();
        }

        // delete event
        public void DeleteEvent(int eventId)
        {
            SqlCommand cmd = new SqlCommand("dbo.deleteEvent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", eventId);
            cmd.ExecuteNonQuery();
        }

        // get all events content
        public SqlDataReader GetAllEventsContents()
        {
            SqlCommand cmd = new SqlCommand("dbo.getAllEventsContent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            var reader = cmd.ExecuteReader();

            return reader;
        }

        public void AddContent(int event_id, int course_id)
        {
            SqlCommand cmd = new SqlCommand("dbo.addEventsContent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@event_id", event_id);
            cmd.Parameters.AddWithValue("@course_id", course_id);
            cmd.ExecuteNonQuery();
        }

        // get content by id
        public SqlDataReader GetContentById(int id)
        {
            SqlCommand cmd = new SqlCommand("dbo.getContentById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            var reader = cmd.ExecuteReader();

            return reader;
        }

        // update content
        public void UpdateContent(int id, int event_id, int course_id)
        {
            SqlCommand cmd = new SqlCommand("dbo.updateEventsContent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@event_id", event_id);
            cmd.Parameters.AddWithValue("@course_id", course_id);
            cmd.ExecuteNonQuery();
        }

        // delete content
        public void DeleteContent(int contentId)
        {
            SqlCommand cmd = new SqlCommand("dbo.deleteEventsContent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", contentId);
            cmd.ExecuteNonQuery();
        }

        // get all events with course
        public SqlDataReader GetEventsWithCourse()
        {
            SqlCommand cmd = new SqlCommand("dbo.getEventsWithCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;
            var reader = cmd.ExecuteReader();

            return reader;
        }

        // get user events ids
        public SqlDataReader GetUserEventsIds(int id)
        {
            SqlCommand cmd = new SqlCommand("dbo.getUserEventsIds", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            var reader = cmd.ExecuteReader();

            return reader;
        }

        // add subscription
        public void AddSubscription(int event_id, int user_id)
        {
            SqlCommand cmd = new SqlCommand("dbo.addSubscription", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@event_id", event_id);
            cmd.Parameters.AddWithValue("@user_id", user_id);
            cmd.ExecuteNonQuery();
        }

        // delete subscription
        public void DeleteSubscription(int userId, int eventId)
        {
            SqlCommand cmd = new SqlCommand("dbo.deleteSubscription", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@event_id", eventId);
            cmd.Parameters.AddWithValue("@user_id", userId);
            cmd.ExecuteNonQuery();
        }

        // get all subscriptions
        public SqlDataReader GetAllSubscriptions()
        {
            SqlCommand cmd = new SqlCommand("dbo.getAllSubscriptions", con);
            cmd.CommandType = CommandType.StoredProcedure;
            var reader = cmd.ExecuteReader();

            return reader;
        }
    }
}