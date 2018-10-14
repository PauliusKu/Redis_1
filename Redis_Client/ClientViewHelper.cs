using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis_Client
{
    class ClientViewHelper
    {
        int clnId = -1;
        AppError appErr = new AppError();
        ClientUtil clnUtil = new ClientUtil();
        FlightUtil flUtil = new FlightUtil();

        public ClientViewHelper(int clientId)
        {
            clnId = clientId;
        }
        public void GetAllClientInfo(out string username, out string mail, out decimal money)
        {
            BankUtil bankUt = new BankUtil();
            clnUtil.GetClientInfo(clnId, out username, out mail);
            money = bankUt.GetClientsAmount(clnId);
            flUtil.GetClientFlightInfo();
        }
    }
}
