using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Thyrsus.Shared.Inter
{
    [ServiceContract()]
    public interface IAccount
    {
        [OperationContract()]
        bool RegisterServer(int sid, string ip, int port, string name, ServerTypes type);

        [OperationContract()]
        Ah_Logon_Exist Ha_Logon(int aid, int authcode, byte sex, int userCount, int sid, int ip);
    }
}
