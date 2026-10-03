namespace Game.Level.Generation
{
    public class LevelGenerator : ILevelLoader
    {
        private readonly ObstacleGenerator _obstacleGenerator;
        private readonly AbilitiesGenerator _abilitiesGenerator;

        public LevelGenerator(ObstacleGenerationConfig config, int obstacleSectionsCount, Abilities.AbilitiesFactory abilitiesFactory)
        {
            _obstacleGenerator  = new(config.DisablePercentMax, config.DisablePercentMin, obstacleSectionsCount);
            _abilitiesGenerator = new(abilitiesFactory);
        }

        public LevelChunk GetNext()
        {
            LevelChunk chunk = new();

            chunk.ObstacleData  = _obstacleGenerator.Generate();
            chunk.Ability       = _abilitiesGenerator.Generate();

            return chunk;
        }
    }
}