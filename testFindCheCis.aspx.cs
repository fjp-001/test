using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
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
        foreach (CheCi cheCi in cheCis) {
            result += cheCi.toString() + "\n";
        }
        TextBox1.Text = "result:\n" + result;
    }
}