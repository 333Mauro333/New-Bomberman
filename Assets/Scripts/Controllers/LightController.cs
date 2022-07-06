using UnityEngine;


namespace NewBomberman
{
	[RequireComponent(typeof(Light))]
	public class LightController : MonoBehaviour
	{
		[Header("Configuration")]
		[SerializeField] Color newColor = Color.white;


		Light l = null;



		void Awake()
		{
			l = GetComponent<Light>();
		}



		public void SwitchColor()
		{
			l.color = newColor;
		}
	}
}
