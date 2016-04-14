using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AESUtils;

/// <summary>
/// TicketsBase 的摘要说明
/// </summary>
public class TicketsBase
{
    private static object _lockObj = new object();
    private static IAESED _aes = new AESEDClass();
    protected const string _ProxyID = "0003";
    protected const string _EncryptKey = "HBGLKYCTW";
    protected const int _StationID = 8;
    protected SocketTestClient _Client;
    protected string _sessionID;

    public TicketsBase()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public TicketsBase(SocketTestClient cilent,string sessionID)
    {
        _Client = cilent;
        _sessionID = sessionID;
    }

    public TicketsBase(SocketTestClient cilent)
    {
        _Client = cilent;
    }


    protected string GetEnCode(string str)
    {
        //return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
        lock (_lockObj)
        {
            return (string)_aes.GetEn(_EncryptKey, str);
        }

    }
    protected string GetDeCode(string str)
    {
        lock (_lockObj)
        {
            //return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
            return (string)_aes.GetDe(_EncryptKey, str);
        }

    }

    protected string FormatDate(DateTime date)
    {
        return date.ToString("yyyy.MM.dd");
    }

}