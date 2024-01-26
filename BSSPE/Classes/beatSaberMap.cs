using System;
using System.Collections.Generic;
using System.Text;

namespace BSSPE.Classes
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class mapAvgBpm
    {
    }

    public class mapAvgDuration
    {
    }

    public class mapAvgScore
    {
    }

    public class mapBpm
    {
    }

    public class mapCollaborator
    {
        public bool admin { get; set; }
        public string avatar { get; set; }
        public bool curator { get; set; }
        public bool curatorTab { get; set; }
        public string description { get; set; }
        public string email { get; set; }
        public mapFollowData followData { get; set; }
        public string hash { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string patreon { get; set; }
        public string playlistUrl { get; set; }
        public mapStats stats { get; set; }
        public DateTime suspendedAt { get; set; }
        public bool testplay { get; set; }
        public string type { get; set; }
        public bool uniqueSet { get; set; }
        public int uploadLimit { get; set; }
        public bool verifiedMapper { get; set; }
    }

    public class mapCurator
    {
        public bool admin { get; set; }
        public string avatar { get; set; }
        public bool curator { get; set; }
        public bool curatorTab { get; set; }
        public string description { get; set; }
        public string email { get; set; }
        public mapFollowData followData { get; set; }
        public string hash { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string patreon { get; set; }
        public string playlistUrl { get; set; }
        public mapStats stats { get; set; }
        public DateTime suspendedAt { get; set; }
        public bool testplay { get; set; }
        public string type { get; set; }
        public bool uniqueSet { get; set; }
        public int uploadLimit { get; set; }
        public bool verifiedMapper { get; set; }
    }

    public class mapDiff
    {
        public int bombs { get; set; }
        public string characteristic { get; set; }
        public bool chroma { get; set; }
        public bool cinema { get; set; }
        public string difficulty { get; set; }
        public int events { get; set; }
        public string label { get; set; }
        public int length { get; set; }
        public int maxScore { get; set; }
        public bool me { get; set; }
        public bool ne { get; set; }
        public mapNjs njs { get; set; }
        public int notes { get; set; }
        public int nps { get; set; }
        public int obstacles { get; set; }
        public mapOffset offset { get; set; }
        public mapParitySummary paritySummary { get; set; }
        public int seconds { get; set; }
        public mapStars stars { get; set; }
    }

    public class mapDiffStats
    {
        public int easy { get; set; }
        public int expert { get; set; }
        public int expertPlus { get; set; }
        public int hard { get; set; }
        public int normal { get; set; }
        public int total { get; set; }
    }

    public class mapFollowData
    {
        public bool curation { get; set; }
        public int followers { get; set; }
        public bool following { get; set; }
        public int follows { get; set; }
        public bool upload { get; set; }
    }

    public class Metadata
    {
        public mapBpm bpm { get; set; }
        public int duration { get; set; }
        public string levelAuthorName { get; set; }
        public string songAuthorName { get; set; }
        public string songName { get; set; }
        public string songSubName { get; set; }
    }

    public class mapNjs
    {
    }

    public class mapOffset
    {
    }

    public class mapParitySummary
    {
        public int errors { get; set; }
        public int resets { get; set; }
        public int warns { get; set; }
    }

    public class BeatSaberMap
    {
        public bool automapper { get; set; }
        public bool bookmarked { get; set; }
        public List<mapCollaborator> collaborators { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime curatedAt { get; set; }
        public mapCurator curator { get; set; }
        public string declaredAi { get; set; }
        public DateTime deletedAt { get; set; }
        public string description { get; set; }
        public string id { get; set; }
        public DateTime lastPublishedAt { get; set; }
        public Metadata metadata { get; set; }
        public string name { get; set; }
        public bool qualified { get; set; }
        public bool ranked { get; set; }
        public mapStats stats { get; set; }
        public List<string> tags { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime uploaded { get; set; }
        public mapUploader uploader { get; set; }
        public List<mapVersion> versions { get; set; }
    }

    public class mapSageScore
    {
    }

    public class mapScore
    {
    }

    public class mapScoreOneDP
    {
    }

    public class mapStars
    {
    }

    public class mapStats
    {
        public mapAvgBpm avgBpm { get; set; }
        public mapAvgDuration avgDuration { get; set; }
        public mapAvgScore avgScore { get; set; }
        public mapDiffStats diffStats { get; set; }
        public DateTime firstUpload { get; set; }
        public DateTime lastUpload { get; set; }
        public int rankedMaps { get; set; }
        public int totalDownvotes { get; set; }
        public int totalMaps { get; set; }
        public int totalUpvotes { get; set; }
        public int downloads { get; set; }
        public int downvotes { get; set; }
        public int plays { get; set; }
        public int reviews { get; set; }
        public mapScore score { get; set; }
        public mapScoreOneDP scoreOneDP { get; set; }
        public string sentiment { get; set; }
        public int upvotes { get; set; }
    }

    public class mapTestplay
    {
        public DateTime createdAt { get; set; }
        public string feedback { get; set; }
        public DateTime feedbackAt { get; set; }
        public mapUser user { get; set; }
        public string video { get; set; }
    }

    public class mapUploader
    {
        public bool admin { get; set; }
        public string avatar { get; set; }
        public bool curator { get; set; }
        public bool curatorTab { get; set; }
        public string description { get; set; }
        public string email { get; set; }
        public mapFollowData followData { get; set; }
        public string hash { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string patreon { get; set; }
        public string playlistUrl { get; set; }
        public mapStats stats { get; set; }
        public DateTime suspendedAt { get; set; }
        public bool testplay { get; set; }
        public string type { get; set; }
        public bool uniqueSet { get; set; }
        public int uploadLimit { get; set; }
        public bool verifiedMapper { get; set; }
    }

    public class mapUser
    {
        public bool admin { get; set; }
        public string avatar { get; set; }
        public bool curator { get; set; }
        public bool curatorTab { get; set; }
        public string description { get; set; }
        public string email { get; set; }
        public mapFollowData followData { get; set; }
        public string hash { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string patreon { get; set; }
        public string playlistUrl { get; set; }
        public mapStats stats { get; set; }
        public DateTime suspendedAt { get; set; }
        public bool testplay { get; set; }
        public string type { get; set; }
        public bool uniqueSet { get; set; }
        public int uploadLimit { get; set; }
        public bool verifiedMapper { get; set; }
    }

    public class mapVersion
    {
        public string coverURL { get; set; }
        public DateTime createdAt { get; set; }
        public List<mapDiff> diffs { get; set; }
        public string downloadURL { get; set; }
        public string feedback { get; set; }
        public string hash { get; set; }
        public string key { get; set; }
        public string previewURL { get; set; }
        public mapSageScore sageScore { get; set; }
        public DateTime scheduledAt { get; set; }
        public string state { get; set; }
        public DateTime testplayAt { get; set; }
        public List<mapTestplay> testplays { get; set; }
    }


}
