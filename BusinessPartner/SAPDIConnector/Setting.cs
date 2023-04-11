namespace BusinessPartner.SAPDIConnector
{
    public class Setting
    {
        public SapServer SapServer = new SapServer();
        
        public SapCompany SapCompany = new SapCompany();
        
    }

    public class SapServer { 
        public SapServer() {
            this.UseTrusted = false;
            this.Server = "SK1@saphasemxprd:30013";
            this.DbServerType = "HANADB";
            this.DbUserName = "B1ADMIN";
            this.DbPassword = "7SkyOne*ZjViMDY4Mj";
            this.LicenseServer = "saphasemxprd:40000";
            this.DbLocation = "";
            this.UserDefinedFieldsPrefix = "";
        }
        public bool UseTrusted { get; set; }
        public string Server { get; set; }
        public string DbServerType { get; set; }
        public string DbUserName { get; set; }
        public string DbPassword { get; set; }
        public string LicenseServer { get; set; }
        public string DbLocation { get; set; }
        public string UserDefinedFieldsPrefix { get; set; }
    }

    public class SapCompany
    {

        public SapCompany()
        {
            this.Name = "SBODEMOMX";
            this.CompanyDB = "SBODEMOMX";
            this.UserName = "vpang";
            this.Password = "1234";
        }
        public string Name { get; set; }
        public string CompanyDB { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
