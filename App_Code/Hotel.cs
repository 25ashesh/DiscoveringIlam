using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Web;

/// <summary>
/// Summary description for Employee
/// </summary>
public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string Rate { get; set; }
    public string Contact { get; set; }
}