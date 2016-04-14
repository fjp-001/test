using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testBuyTicket : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        string dateTime = now.ToString("yyyy.MM.dd");
        SocketTestClient cilent = new SocketTestClient();
        string sessionID = Guid.NewGuid().ToString();
        string destination = "安庆";
        FindCheCis findTicket = new FindCheCis(cilent, sessionID, dateTime, dateTime, destination);
        List<CheCi> cheCis = findTicket.findCheCi();
        var count = cheCis.Count;
        //CheCi cheCi = cheCis[count - 1];
        //TextBox1.Text = "cheCis:" + cheCi.toString();
        string result = "";
        foreach (CheCi cheCii in cheCis)
        {
            result += cheCii.toString() + "\n";
        }

        CheCi cheCi = cheCis[count - 1];
        //CheCi cheCi = cheCis[0];
        if (string.IsNullOrEmpty(cheCi.ActionCode))
        {
            result += "该车次已过售票期\n";
            TextBox1.Text = "result:\n" + result;
            return;
        }
        result += "锁定" + cheCi.toString() + "\n";

        int buyCount = 2;
        string buyerName = "李四";
        string idCardNumber = "123456456789123";
        string phoneNumber = "87654321";
        LockTicket lockTicket = new LockTicket(cilent, sessionID, cheCi, buyCount, buyerName, idCardNumber, phoneNumber);
        if (lockTicket.lockTicket())
        {
            result += "锁定车票成功\n";
            //UnLockTicket unLockTicket = new UnLockTicket(cilent, sessionID);
            //if (unLockTicket.unLockTicket())
            //{
            //    result += "取消锁定车票成功\n";
            //}
            //else {
            //    result += "取消锁定车票失败\n";
            //    TextBox1.Text = "result:\n" + result;
            //    return;
            //}
        }
        else {
            result += "锁定车票失败\n";
            TextBox1.Text = "result:\n" + result;
            return;
        }
        int price = int.Parse(cheCi.Price);
        int totalFeeInt = price * buyCount;
        string trade_no = "6457166";
        string zfType = "1";

        BuyTicket buyTicket = new BuyTicket(cilent, sessionID, totalFeeInt, trade_no, zfType);
        List<Ticket> tickets = buyTicket.buyTicket();
        if (tickets !=null)
        {
            result += "购票成功\n";
            foreach (Ticket ticket in tickets) {
                result += ticket.toString()+"\n";
            }
        }
        else {
            result += "购票失败\n";
            UnLockTicket unLockTicket = new UnLockTicket(cilent, sessionID);
            if (unLockTicket.unLockTicket())
            {
                result += "取消锁定车票成功\n";
            }
            else {
                result += "取消锁定车票失败\n";
                TextBox1.Text = "result:\n" + result;
                return;
            }
            TextBox1.Text = "result:\n" + result;
            return;

        }

        TextBox1.Text = "result:\n" + result;
    }

}