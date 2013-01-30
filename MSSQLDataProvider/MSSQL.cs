using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thyrsus.Shared.Classes;

namespace Thyrsus.DataProviders
{
    public class MSSQL : IDataProvider
    {
        public bool AuthenticateUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public List<Character> GetCharacters(int aid)
        {
            throw new NotImplementedException();
        }
    }
}
