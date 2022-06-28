using UnityEngine;


namespace NewBomberman
{
    public class EnemyTrackingTrigger : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] GameObject player = null;
        [SerializeField] EnemyMovement enemy = null;



        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(player.tag) && !enemy.HasTarget())
            {
                enemy.SetTarget(player.transform);
            }
        }
    }
}
