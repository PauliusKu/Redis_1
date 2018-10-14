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
        int companyAcountId = 9999;
        AppError appErr = new AppError();
        ClientUtil clnUtil = new ClientUtil();

        public ClientViewHelper(int clientId)
        {
            clnId = clientId;
        }
        public void GetAllClientInfo(out string username, out string mail, out decimal money)
        {
            BankUtil bankUt = new BankUtil();
            clnUtil.GetClientInfo(clnId, out username, out mail);
            money = bankUt.GetClientsAmount(clnId);
        }

        public string GetTable(bool isClientTable)
        {
            FlightUtil flUtil = new FlightUtil();
            if (isClientTable) return flUtil.GetClientFlightInfo(clnId);
            else return flUtil.GetSystemFlightInfo();
        }

        public void MakeOrder(int flightId)
        {
            BankUtil bankUt = new BankUtil();
            FlightUtil flUtil = new FlightUtil();
            if (bankUt.MoneyTransfer(clnId, companyAcountId, flUtil.GetFlightCost(flightId)) && flUtil.IsTicket(flightId))
            {
                flUtil.BookFlight(flightId, clnId);
            }
        }
    }
}
