namespace DMS.DesktopApp.Sync
{
    internal class TableDataPayload
    {
        public string TableName { get; set; }
        public List<Dictionary<string, object>> Rows { get; set; }

    }
}
