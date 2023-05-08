namespace KeyVaultExample
{
    public class RandomSuffixGenerator
    {
        public readonly static string group3 = "super-group";

        private readonly static string group1 = "trevor-group";
        private readonly static string group2 = "johnson-group";

        private readonly Random _random;

        public RandomSuffixGenerator()
        {
            _random = new();
        }

        public string GetRandomGroup()
        {
            int random = _random.Next(0, 100);
            if (random < 48)
            {
                return group1;
            }

            if (random < 96)
            {
                return group2;
            }

            return group3;
        }
    }
}
