namespace DMS.API.WindowsServices
{
    public static class ClientAPI
    {
        private static string _getDataSyncUrl = string.Empty;
        public static string BaseUrl { get; set; } = string.Empty;

        public static string DataSyncUrl
        {
            get { return _getDataSyncUrl; }
            set { _getDataSyncUrl = BaseUrl + value; }
        }
    }
}
