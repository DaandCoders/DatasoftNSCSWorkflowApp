namespace DMS.ContextHelper.ViewModels
{
    public class StatusCountVM
    {
        public int TotalFileReceived { get; set; }
        public int TotalFileScanned { get; set; }
        public int TotalFileQC { get; set; }
        public int TotalFileClassified { get; set; }
        public int TotalFileQCByClient { get; set; }
        public int TotalFileDispatched { get; set; }
    }
}
