using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thyrsus.Shared.Classes;

namespace Thyrsus.DataProviders
{
    public class Dummy : IDataProvider
    {
        public bool AuthenticateUser(string username, string password)
        {
            return true;
        }

        public List<Character> GetCharacters(int aid)
        {
            var ret = new List<Character>();
            ret.Add(new Character() { GID = 100001, Name = "Thyrsus", CLevel = 1, JLevel = 1 });
            return ret;
        }
    }
}
