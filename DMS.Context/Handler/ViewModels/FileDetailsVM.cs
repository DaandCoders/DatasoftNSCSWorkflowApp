using static DC.DMS.Services.Enum.WorkflowEnums;

namespace DMS.ContextHelper.ViewModels
{
    public class ImageFileVM
    {
        public int ID {get; set;}
        public int DirectoryID { get; set; }
        public int FileDirectoryID { get; set; }
        public int SubDirectoryID { get; set; }
        public int SerialNo { get; set; }
        public string Name { get; set; }  =null!;
        public string Path { get; set; } = null!;
        public int? QCCreateBy { get; set; }
        public Status Status { get; set; }
        public Flag Flag{ get; set; }
    }
}
