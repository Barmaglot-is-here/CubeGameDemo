using System;

namespace Game
{
    public struct ScoreRecordData
    {
        public string UserName { get; set; }
        public int Position { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }
}