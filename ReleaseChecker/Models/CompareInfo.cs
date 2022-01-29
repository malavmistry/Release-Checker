using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ReleaseChecker.Models { 

    public class Commit
    {
        [JsonProperty("commit")]
        public CommitMessage Message { get; set; }
        public string Sha { get; set; }
    }
    public class CompareInfo
    {
        public string Status { get; set; }
        public int Ahead_by { get; set; }
        public int Behind_by { get; set; }
        public int Total_commits { get; set; }
        public List<Commit> Commits { get; set; }
    }
    public class CommitMessage
    {
        public string Message { get; set; }
    }

}
