using RTS_TEST.Assets.Shared.Enumerations;

namespace RTS_TEST
{
    interface IPropPhysics
    {
        void Move(DirectionOptions direction, float speed);
    }
}
