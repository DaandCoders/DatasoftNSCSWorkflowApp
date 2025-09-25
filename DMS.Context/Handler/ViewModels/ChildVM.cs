namespace DMS.ContextHelper.ViewModels
{
    public class ChildVM
    {
        public int ID { get; set; }
        public int MainDataID { get; set; }
        public int ParentID { get; set; }
        public int CaseID { get; set; }
        public string CaseName { get; set; }
        public string Name { get; set; } = null!;
        public string Path { get; set; } = null!;
    }
}
