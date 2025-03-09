public struct ObstacleData
{
    public bool[] SectionEnabled { get; set; }

    public ObstacleData(bool[] sectionEnabled)
    {
        SectionEnabled = sectionEnabled;
    }
}