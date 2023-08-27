namespace Mad.GameEngine
{
    public class GameStateManager
    {
        public GameState CurrentState { get; private set; }

        public GameStateManager(GameState initialState)
        {
            CurrentState = initialState;
        }

        public void ChangeState(GameState newState)
        {
            // Here you can put logic for any teardown or setup when changing states.
            CurrentState = newState;
        }

        public void Update()
        {
            // Update logic based on current state
            switch (CurrentState)
            {
                case GameState.MainMenu:
                    // Handle main menu logic
                    break;

                case GameState.InGame:
                    // Handle in-game logic
                    break;

                case GameState.Paused:
                    // Handle paused game logic
                    break;

                case GameState.GameOver:
                    // Handle game over logic
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

}