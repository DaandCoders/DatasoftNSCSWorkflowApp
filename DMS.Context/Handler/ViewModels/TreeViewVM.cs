namespace DMS.ContextHelper.ViewModels
{
    public class TreeViewVM
    {
        public string Name { get; set; } = null!;
        public string Text { get; set; } = null!;
        public string Tag { get; set; } = null!;
       // public List<TreeViewProperty>? ChildNode { get; set; }
    }
    public class TreeViewProperty
    {
        public string Name { get; set; } = null!;
        public string Text { get; set; } = null!;
        public string Tag { get; set; } = null!;
    }
}
