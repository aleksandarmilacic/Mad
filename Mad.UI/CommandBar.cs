using Mad.GameEngine.Components;
using Mad.GameEngine.ECS;

namespace Mad.UI
{
    public class CommandBar
    {
        public void DrawCommands(Entity selectedEntity)
        {
            var healthComponent = selectedEntity.GetComponent<HealthComponent>();
            var attackComponent = selectedEntity.GetComponent<AttackComponent>();
            // Add logic to draw or display these attributes in UI
        }
    }
}
