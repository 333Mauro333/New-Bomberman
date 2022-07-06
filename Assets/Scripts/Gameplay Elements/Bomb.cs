using UnityEngine;


namespace NewBomberman
{
    public class Bomb : MonoBehaviour, IDestroyable, IExploiter
    {
        [Header("Setting Values")]
        [SerializeField] float timeToExplode = 0.0f;
        [SerializeField] float timeExploding = 0.0f;
        [SerializeField] float range = 3.0f;


        float actualExplosionTime;
        float actualExplodingTime;
        bool explodedByAnotherBomb;

        SphereCollider sc;
        MeshRenderer mr;



        void Awake()
        {
            actualExplosionTime = timeToExplode;
            actualExplodingTime = timeExploding;
            explodedByAnotherBomb = false;

            sc = GetComponent<SphereCollider>();
            mr = GetComponent<MeshRenderer>();

            sc.radius *= range;
        }

        void Update()
        {
            HasExploded();
            SubtractTime();
        }



        public void DestroyItSelf()
        {
            if (!explodedByAnotherBomb)
            {
                explodedByAnotherBomb = true;
                Explode();
            }
        }

        public void Explode()
        {
            sc.enabled = true;
            mr.enabled = false;
        }
        public float GetExplosionRange()
        {
            return range;
        }

        void SubtractTime()
        {
            actualExplosionTime = (actualExplosionTime - Time.deltaTime <= 0.0f) ? 0.0f : actualExplosionTime - Time.deltaTime;

            if (actualExplosionTime <= 0.0f)
            {
                Explode();
            }
        }
        void ResetValues()
        {
            actualExplosionTime = timeToExplode;
            actualExplodingTime = timeExploding;
            explodedByAnotherBomb = false;
            mr.enabled = true;
        }

        void HasExploded()
		{
            if (sc.enabled)
			{
                actualExplodingTime = (actualExplodingTime - Time.deltaTime <= 0.0f) ? 0.0f : actualExplodingTime - Time.deltaTime;

                if (actualExplodingTime <= 0.0f)
                {
                    sc.enabled = false;
                    ResetValues();
                    gameObject.SetActive(false);
                }
            }
		}
    }
}
