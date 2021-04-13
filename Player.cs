namespace SportzInteractive
{
    public class Player
    {
        public string Batsman { get; set; }

        public int RunsScored { get; set; }

        public double StrikeRate { get; set; }

        public bool IsRetired { get; set; }

        public override string ToString()
        {
            return $"{nameof(Batsman)}:{Batsman}\n{ nameof(RunsScored)}: { RunsScored}\n{ nameof(StrikeRate)}:{ StrikeRate}\n{nameof(IsRetired)}:{IsRetired}\n";
        }
    }
}
