using System;

namespace SW_Level_Bot
{
    internal class Statistics
    {
        private const int PadLeft = 16;
        private const int PadRight = 20;

        public int? BadRuneCount { get; set; }
        public int? GoodRuneCount { get; set; }
        public int? LossCount { get; set; }
        public int? MaxedMonsters { get; set; }
        public int? MiscDrops { get; set; }
        public int? Refills { get; set; }
        public int? Runs { get; set; }
        public DateTime StartedDate { get; set; }
        public int? SuccessfulRuns { get; set; }

        public void Print()
        {
            Console.Clear();
            WriteFormat("Started to farm", StartedDate.ToShortTimeString());
            CheckWriteFormat("Runs made", Runs);
            Console.WriteLine("".PadLeft(PadLeft + PadRight + 1, '-'));
            CheckWriteFormat("Successful runs", SuccessfulRuns);
            CheckWriteFormat("Failed runs", LossCount);
            CheckWriteFormat("Good drops", GoodRuneCount);
            CheckWriteFormat("Bad drops", BadRuneCount);
            CheckWriteFormat("Misc drops", MiscDrops);
            CheckWriteFormat("Refills made", Refills);
            CheckWriteFormat("Success rate",
                (int?) (SuccessfulRuns.HasValue && Runs.HasValue
                    ? SuccessfulRuns * 100.0 / (Runs = Runs == 0 ? 1 : Runs)
                    : null));
            CheckWriteFormat("Maxed monster", MaxedMonsters);
        }

        private static void CheckWriteFormat(string output, int? argument)
        {
            if (argument.HasValue)
            {
                WriteFormat(output, argument);
            }
        }

        private static void WriteFormat(string output, object argument)
        {
            Console.WriteLine($"{output.PadRight(PadRight)} {argument.ToString().PadLeft(PadLeft)}");
        }
    }
}