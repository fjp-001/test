using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Station 的摘要说明
/// </summary>
public class Station
{
    private string stationname;
    private string zjm;//助记码
    private string distance;
    private string qym;//区域码

    public Station(string stationname, string zjm, string distance, string qym)
    {
        this.stationname = stationname;
        this.zjm = zjm;
        this.distance = distance;
        this.qym = qym;
    }
    public string toString()
    {
        return stationname + "," + zjm + "," + distance + "," + qym;
    }
    public Station()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public string Stationname
    {
        get
        {
            return stationname;
        }

        set
        {
            stationname = value;
        }
    }

    public string Zjm
    {
        get
        {
            return zjm;
        }

        set
        {
            zjm = value;
        }
    }

    public string Distance
    {
        get
        {
            return distance;
        }

        set
        {
            distance = value;
        }
    }

    public string Qym
    {
        get
        {
            return qym;
        }

        set
        {
            qym = value;
        }
    }
}