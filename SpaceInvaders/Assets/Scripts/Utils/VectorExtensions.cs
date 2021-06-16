using UnityEngine;

namespace SpaceInvaders.Utils
{
    public static class VectorExtensions
    {
        public static bool IsGreaterOrEqual(this Vector3 local, Vector3 other)
        {
            return local.x >= other.x && local.y >= other.y && local.z >= other.z;
        }

        public static bool IsLesserOrEqual(this Vector3 local, Vector3 other)
        {
            return local.x <= other.x && local.y <= other.y && local.z <= other.z;
        }
    }
}