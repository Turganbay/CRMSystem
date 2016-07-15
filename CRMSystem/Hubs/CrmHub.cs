using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace CRMSystem.Hubs
{
    public class CrmHub : Hub
    {
        public void RefreshUsersList()
        {
            Clients.All.refresh();
        }

        // Refresh Courses List
        public void RefreshCoursesList()
        {
            Clients.All.refreshCourses();
        }
        // refresh Events List
        public void RefreshEventsList()
        {
            Clients.All.refreshEvents();
        }

        // refresh contents list
        public void RefreshContentsList()
        {
            Clients.All.refreshContents();
        }
        
        // refresh subscriptions List
        public void RefreshSubscriptionsList()
        {
            Clients.All.refreshSubscriptions();
        }
        

    }
}