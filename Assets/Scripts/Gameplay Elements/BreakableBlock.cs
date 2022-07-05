using UnityEngine;


namespace NewBomberman
{
    public class BreakableBlock : MonoBehaviour, IDestroyable
    {
        [Header("Configuration")]
        [SerializeField] int blockValue = 10;

        [Header("Tag References")]
        [SerializeField] string bombTag = "";


        Player p;



        void Start()
        {
            p = FindObjectOfType<Player>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                DestroyItSelf();
            }
        }

        void OnTriggerEnter(Collider other)
        {
            IExploiter ie = other.gameObject.GetComponent<IExploiter>();

            if (ie != null)
            {
                RaycastHit raycastHit;

                if (Physics.Raycast(transform.position, other.transform.position - transform.position, out raycastHit, ie.GetExplosionRange()))
                {
                    Debug.Log("----------------------------------------------------------------");
                    Debug.Log("YO SOY: " + gameObject.name + ". MI POSICIÓN: " + transform.position);
                    Debug.Log("Objeto detectado: " + raycastHit.transform.gameObject.name + ". Posición: " + raycastHit.transform.position);
                    Debug.Log("----------------------------------------------------------------");
                    //if (raycastHit.transform.gameObject.tag == bombTag)
                    //{
                    //    DestroyItSelf();
                    //}
                }
            }
        }



        public void DestroyItSelf()
        {
            p.AddPoints(blockValue);
            Destroy(gameObject);
        }
    }
}
