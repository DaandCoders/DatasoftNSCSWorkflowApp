using static DC.DMS.Services.Enum.WorkflowEnums;


using static DC.DMS.Services.Enum.WorkflowEnums;

namespace DMS.ContextHelper.ViewModels
{
    public class MainDataVM
    {
        public int ID { get; set; }
        public int FileDetailID { get; set; }
        public int DocumentTypeID { get; set; }
        public string? DocumentNumber { get; set; }
        public int CaseTypeID { get; set; }
        public int IndexPageNo { get; set; }
        public string CaseNo { get; set; } = null!;
        public int PageNoFrom { get; set; }
        public int PageNoTo { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public int? CreateBy { get; set; }
        public int? UpdateBy { get; set; }
        public Status Status { get; set; }
        public Flag Flag { get; set; }
    }
}
