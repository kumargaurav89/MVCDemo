using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDataAccessService
    {
        List<Person> GetPerson(int id);
        List<Person> AllPerson();
        List<Person> suffixPerson();
        IEnumerable<DropDownItem> PersonType();
        void DeletePerson(int id);
        void InsertPerson(Person person);
        List<User> LoginUser(User user);
        void InsertUser(User user);
    }
}
