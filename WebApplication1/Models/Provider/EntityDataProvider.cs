using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.VieModels;

namespace WebApplication1.Models.Provider
{
    public class EntityDataProvider : IDataProvider
    {
        private GuestBookContext context = null;

        public ICollection<Message> Messages 
        {
            get {
                return new List<Message>();
            }
        }

        public ICollection<User> Users
        {
            get {
                using (context = new GuestBookContext())
                {
                    return context.Users.ToList();
                    
                }
            }
        }

        public bool AddMessage(string name, string message)
        {
            using (context = new GuestBookContext())
            {
                User user = context.Users.Where(u => u.Name == name).SingleOrDefault();
                context.Messages.Add(
                    new Message { Id_user = user.Id, MessageText = message, MessageDate = DateTime.Now }
               );
                context.SaveChanges();
                return true;
            }
        }

        public ICollection<ViewMessage> GetViewMessages(int count)
        {
            using (context = new GuestBookContext())
            {
                IEnumerable<Message> messages = null;
                if (context.Messages.Count() > 0)
                {
                    messages = context.Messages.Take(10).ToArray();

                }
                List<ViewMessage> mess = new List<ViewMessage>();
                string userName = null;
                if (messages != null)
                {
                    
                    foreach (var m in messages)
                    {
                        userName = context.Users.Where(u => u.Id == m.Id_user).Select(n => n.Name).Single().ToString();

                        mess.Add(
                            new ViewMessage()
                            {
                                UserName = userName,
                                MessageText = m.MessageText,
                                MessageDate = m.MessageDate
                            });
                    }
                }
                return mess;
            }
        }


        public ICollection<string> GetUsersNames(int count)
        {
            try
            {
                using (context = new GuestBookContext())
                {
                    ICollection<string> names = null;
                    if (context.Users.Count() > 0)
                    {
                        names = context.Users.Take(10).Select(n => n.Name).ToList();

                    }
                    return names;
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                context.Dispose();
                return null;
            }
        }

        public bool CheckUser(User user)
        {
            try{
                using (context = new GuestBookContext())
                {
                    User us = context.Users.Where(n => n.Name == user.Name && n.Pasword == user.Pasword).Single();
                    if (us == null)
                    {
                        return false;
                    }
                    return true;
                }
            } catch(Exception ex) {
                var error = ex.Message;
                context.Dispose();
                 return false;
            }
        }
        


    }
}