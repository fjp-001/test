using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testGetStation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SocketTestClient cilent = new SocketTestClient();
        GetStation getStation = new GetStation(cilent);
        List<Station> stations = getStation.getStation();
        string result = "";
        if (stations == null) {
            result += "查询站点失败\n";
            TextBox1.Text = "result:\n" + result;
            return;
        }

        foreach (Station station in stations)
        {
            result += station.toString() + "\n";
        }
        TextBox1.Text = "result:\n" + result;
    }
}