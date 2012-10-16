using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace PirateChatSite.Models
{
    public class ContactsListViewModel
    {
        public class ContactsListUserViewModel
        {
            public string name { get; set; }
            public List<string> subscribedToNames { get; set; }
        }
        public ContactsListViewModel(UserProfile generateFrom)
        {
            if (generateFrom.Following != null)
            {
                string userName = generateFrom.UserName;
                List<string> contacts = new List<string>();
                foreach (Contact c in generateFrom.Following)
                {
                    contacts.Add(c.Follows.UserName);
                }
                user = new ContactsListUserViewModel { name = userName, subscribedToNames = contacts };
            }
        }

        public ContactsListUserViewModel user { get; set; }

    }
}