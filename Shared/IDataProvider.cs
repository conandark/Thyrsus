using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thyrsus.Shared.Classes;

namespace Thyrsus.DataProviders
{
    public interface IDataProvider
    {
        #region Account
        bool AuthenticateUser(string username, string password);
        #endregion

        #region Character
        List<Character> GetCharacters(int aid);
        #endregion

        #region World

        #endregion
    }
}
