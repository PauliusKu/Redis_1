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

        public void MakeOrder(int flightId, int orderAmount)
        {
            BankUtil bankUt = new BankUtil();
            FlightUtil flUtil = new FlightUtil();
            if (!flUtil.IsFlightClnBooked(flightId, clnId))
            {
                if (flUtil.IsEnoughTicket(flightId, orderAmount))
                {
                    if (bankUt.MoneyTransfer(clnId, companyAcountId, flUtil.GetFlightCost(flightId) * orderAmount))
                    {
                        flUtil.BookFlight(flightId, clnId, orderAmount);
                        appErr.ShowMsg("Order completed successfully");
                    }
                    else appErr.ShowErrorMsg("Bank error");
                }
                else appErr.ShowErrorMsg("Zero tickets left");
            }
            else appErr.ShowErrorMsg("You already have a ticket");

        }

        //I need a new class
        public int GetLeftTicketsAmount(int flightId)
        {
            FlightUtil flUtil = new FlightUtil();
            return flUtil.GetLeftTicketsAmount(flightId);
        }

        public decimal GetTicketsCost(int flightId)
        {
            FlightUtil flUtil = new FlightUtil();
            return flUtil.GetFlightCost(flightId);
        }
    }
}
