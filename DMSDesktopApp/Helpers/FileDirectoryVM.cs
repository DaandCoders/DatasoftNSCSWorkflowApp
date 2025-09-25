using DC.DMS.Services.WorkflowModels.Directories;
using static DC.DMS.Services.Enum.WorkflowEnums;

namespace DMS.DesktopApp.Helpers
{
    public class FileDirectoryVM
    {
        public int ID { get; set; }
        public int DirectoryID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int? CreateBy { get; set; }
        public Status Status { get; set; }

        public virtual FileDirectory? FileDirectory { get; set; }

    }

}
