namespace DMS.ContextHelper.ViewModels
{
    public class GetMainDataVM
    {
        public int ID { get; set; }
        public int DocumentID { get; set; }
        public string DocumentName { get; set; } = null!;
        public int CaseID { get; set; }
        public string CaseName { get; set; }
        public int FileDetailID { get; set; }
        public string? DocumentNo { get; set; }
        public string FilePath { get; set;} = null!;
        public int PageFrom { get; set; }
        public int PageTo { get; set; }
    }
}
