using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testFindOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SocketTestClient cilent = new SocketTestClient();
        string sType = "0";
        string sCondition = "123456456789123";
        string sRunDate = "";
        FindOrder findOrder = new FindOrder(cilent, sType, sCondition, sRunDate);
        List<Order> orders = findOrder.findOrder();
        string result = "";
        if (orders == null)
        {
            result += "查询订单失败\n";
            TextBox1.Text = "result:\n" + result;
            return;
        }
        foreach (Order order in orders)
        {
            result += order.toString() + "\n";
        }
        TextBox1.Text = "result:\n" + result;
    }
}