using System.Collections.Generic;

namespace BSSPE
{
    public class Contributor
    {
        public string _role { get; set; }
        public string _name { get; set; }
        public string _iconPath { get; set; }
    }

    public class MMA2
    {
        public string version { get; set; }
    }

    public class ChroMapper
    {
        public string version { get; set; }
    }

    public class Editors
    {
        public string _lastEditedBy { get; set; }
        public MMA2 MMA2 { get; set; }
        public ChroMapper ChroMapper { get; set; }
    }

    public class CustomData
    {
        public IList<Contributor> _contributors { get; set; }
        public Editors _editors { get; set; }
    }

    public class DifficultyBeatmap
    {
        public string _difficulty { get; set; }
        public float _difficultyRank { get; set; }
        public string _beatmapFilename { get; set; }
        public float _noteJumpMovementSpeed { get; set; }
        public double _noteJumpStartBeatOffset { get; set; }
        public CustomData _customData { get; set; }
    }

    public class DifficultyBeatmapSet
    {
        public string _beatmapCharacteristicName { get; set; }
        public IList<DifficultyBeatmap> _difficultyBeatmaps { get; set; }
    }

    public class SongProperties
    {
        public string _version { get; set; }
        public string _songName { get; set; }
        public string _songSubName { get; set; }
        public string _songAuthorName { get; set; }
        public string _levelAuthorName { get; set; }
        public float _beatsPerMinute { get; set; }
        public float _shuffle { get; set; }
        public double _shufflePeriod { get; set; }
        public double _previewStartTime { get; set; }
        public float _previewDuration { get; set; }
        public string _songFilename { get; set; }
        public string _coverImageFilename { get; set; }
        public string _environmentName { get; set; }
        public string _allDirectionsEnvironmentName { get; set; }
        public float _songTimeOffset { get; set; }
        public CustomData _customData { get; set; }
        public IList<DifficultyBeatmapSet> _difficultyBeatmapSets { get; set; }
    }


}