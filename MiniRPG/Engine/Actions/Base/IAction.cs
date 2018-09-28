using Engine.Enums;
using GameConfig.ConfigSection;

namespace Engine.Actions.Base
{
    interface IAction
    {
        ActionTypes Type { get; }

        ActionResultBase Process(GameState state, GameConfiguration config);

        bool CanApply(GameState state, GameConfiguration config);
    }
}
