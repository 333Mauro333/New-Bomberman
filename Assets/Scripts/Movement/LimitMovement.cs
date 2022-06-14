using UnityEngine;


namespace NewBomberman
{
    public class LimitMovement : MonoBehaviour
    {
        public bool ThereIsAnything(Direction d, string tag = null, int scope = 1)
        {
            RaycastHit raycast;
            Vector3 direction;


            switch (d)
            {
                case Direction.Up:
                    direction = transform.forward * scope;
                    break;

                case Direction.Down:
                    direction = -transform.forward * scope;
                    break;

                case Direction.Left:
                    direction = -transform.right * scope;
                    break;

                case Direction.Right:
                    direction = transform.right * scope;
                    break;

                default:
                    return false;
            }

            if (tag == null)
            {
                return Physics.Raycast(transform.position, direction, out raycast, scope);
            }
            else
            {
                if (Physics.Raycast(transform.position, direction, out raycast, scope))
                {
                    return raycast.collider.CompareTag(tag);
                }
            }

            return false;
        }
    }
}
