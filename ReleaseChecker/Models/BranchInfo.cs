
namespace ReleaseChecker.Models
{
    public class BranchInfo
    {        
        public string Name { get; set; }
        public CommitInfo Commit;
    }
    public class CommitInfo {
        public string Sha { get; set; }
        public string Url { get; set; }
    }
}
