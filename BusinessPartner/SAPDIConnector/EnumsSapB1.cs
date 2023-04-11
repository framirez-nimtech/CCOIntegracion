using System.Collections.Generic;

namespace BusinessPartner.SAPDIConnector
{
    public class EnumsSapB1
    {
        public static readonly Dictionary<string, SAPbobsCOM.BoDataServerTypes> EnumDataServerType = new Dictionary<string, SAPbobsCOM.BoDataServerTypes>
        {
            {"MSSQL", SAPbobsCOM.BoDataServerTypes.dst_MSSQL},
            {"MSSQL2005", SAPbobsCOM.BoDataServerTypes.dst_MSSQL2005},
            {"MSSQL2008", SAPbobsCOM.BoDataServerTypes.dst_MSSQL2008},
            {"MSSQL2012", SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012},
            {"MSSQL2014", SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014},
            {"MSSQL2016", SAPbobsCOM.BoDataServerTypes.dst_MSSQL2016},
            {"MSSQL2017", SAPbobsCOM.BoDataServerTypes.dst_MSSQL2017},
            {"HANADB", SAPbobsCOM.BoDataServerTypes.dst_HANADB},
        };

        public static readonly Dictionary<SAPbobsCOM.BoDataServerTypes, string> DescDataServerType = new Dictionary<SAPbobsCOM.BoDataServerTypes, string>
        {
            {SAPbobsCOM.BoDataServerTypes.dst_MSSQL, "MSSQL"},
            {SAPbobsCOM.BoDataServerTypes.dst_MSSQL2005, "MSSQL2005"},
            {SAPbobsCOM.BoDataServerTypes.dst_MSSQL2008, "MSSQL2008"},
            {SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012, "MSSQL2012"},
            {SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014, "MSSQL2014"},
            {SAPbobsCOM.BoDataServerTypes.dst_MSSQL2016, "MSSQL2016"},
            {SAPbobsCOM.BoDataServerTypes.dst_MSSQL2017, "MSSQL2017"},
            {SAPbobsCOM.BoDataServerTypes.dst_HANADB, "HANADB"}
        };
    }
}
