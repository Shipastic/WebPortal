
namespace Entities.Models
{
    public class TreeViewNode
    {
        public string? id { get; set; }
        public string? parent { get; set; }
        public string? text { get; set; }
        public string[]? chields { get; set; }

        public List<TreeViewNodeService>? nodeServices { get; set; }
    }
}
