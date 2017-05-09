using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models.VieModels;

namespace WebApplication1.Models.Provider
{
    interface IDataProvider
    {
        ICollection<Message> Messages { get; }

        ICollection<User> Users { get; }

        bool AddMessage(string name, string message);

        bool CheckUser(User user);

        ICollection<ViewMessage> GetViewMessages(int count);

        ICollection<string> GetUsersNames(int count);
    }
}
