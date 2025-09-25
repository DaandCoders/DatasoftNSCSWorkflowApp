using DC.DMS.Services.WorkflowModels.Directories;

namespace DMS.ContextHelper.ViewModels
{
    public class SubDirectoryVM
    {
        public int ID { get; set; }
        public int DirectoryID { get; set; }
        public int CaseDirectoryID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public virtual SubDirectory? SubDirectory { get; set; }
    }
}
