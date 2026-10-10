namespace Game.Level.Generation
{
    public class LevelGenerator : ILevelLoader
    {
        private readonly ObstacleGenerator _obstacleGenerator;
        private readonly CollectablesGenerator _collectablesGenerator;

        public LevelGenerator(ObstacleGenerationConfig config, CollectableGenerationConfig config2, 
                              CollectablesSpawnArea collectablesSpawnArea,
                              CoinCreationProvider coinCreationProvider, AbilityCreationProvider abilityCreationProvider)
        {
            _obstacleGenerator      = new(config);
            _collectablesGenerator  = new(config2, collectablesSpawnArea, coinCreationProvider, abilityCreationProvider);
        }

        public LevelChunk GetNext()
        {
            LevelChunk chunk = new();

            chunk.ObstacleData          = _obstacleGenerator.Generate();
            chunk.CollectableSpawnData  = _collectablesGenerator.Generate();

            return chunk;
        }
    }
}