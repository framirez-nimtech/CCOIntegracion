using SAPbobsCOM;
using System;

namespace BusinessPartner.SAPDIConnector
{
    public class SapConnection
    {
        private static Company oCompany = null;
        
        public static Company connection()
        {

            if (oCompany == null)
            {
                Setting setting = new Setting();

                oCompany = new Company();
                oCompany.language = SAPbobsCOM.BoSuppLangs.ln_English;
                oCompany.Server = setting.SapServer.Server;
                

                if (!EnumsSapB1.EnumDataServerType.ContainsKey(setting.SapServer.DbServerType))
                    throw new Exception("DataServerType [" + setting.SapServer.DbServerType + "] not valid");

                BoDataServerTypes serverType = EnumsSapB1.EnumDataServerType[setting.SapServer.DbServerType];

                oCompany.UseTrusted = setting.SapServer.UseTrusted;
                oCompany.DbUserName = setting.SapServer.DbUserName;
                oCompany.DbPassword = setting.SapServer.DbPassword;
                oCompany.DbServerType = serverType;

                if (!string.IsNullOrWhiteSpace(setting.SapServer.LicenseServer))
                    oCompany.LicenseServer = setting.SapServer.LicenseServer;

                oCompany.CompanyDB = setting.SapCompany.CompanyDB;
                oCompany.UserName = setting.SapCompany.UserName;
                oCompany.Password = setting.SapCompany.Password;

                if (oCompany.Connect() != 0)
                {
                    int sapErrorCode;
                    string sapErrorMsg;
                    oCompany.GetLastError(out sapErrorCode, out sapErrorMsg);
                    throw new Exception("Error connecting to SAP: " + sapErrorCode + " - " + sapErrorMsg);
                }

            }

            return oCompany;

        }
        public void Disconnect()
        {
            oCompany.Disconnect();
        }

    }
}
