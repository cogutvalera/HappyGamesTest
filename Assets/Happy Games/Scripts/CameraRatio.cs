using UnityEngine;

namespace HappyGames.Test
{
	[ExecuteInEditMode]
	public class CameraRatio : MonoBehaviour {
		public float heightKoefficient = 0.5f, widthKoefficient = 0.5f, WIDTH = 640.0f, HEIGHT = 960.0f;

		public Camera cam;

		[HideInInspector]
		public float targetAspect, windowAspect, scaleHeight, scaleWidth;

		private Rect _rect;

		void Start() {
			if (null == cam) {
				cam = gameObject.GetComponent<Camera>();
				if (null == cam) cam = Camera.main;
			}
		}

		void Update() 
		{
			targetAspect = WIDTH / HEIGHT;
            
			windowAspect = (float)Screen.width / (float)Screen.height;
            
			scaleHeight = windowAspect / targetAspect;
            
			if (scaleHeight < 1.0f)
			{  
				_rect = cam.rect;

				_rect.width = 1.0f;
				_rect.height = scaleHeight;
				_rect.x = 0;
				_rect.y = (1.0f - scaleHeight) * heightKoefficient;

				cam.rect = _rect;
			}
			else
			{
				scaleWidth = 1.0f / scaleHeight;

				_rect = cam.rect;

				_rect.width = scaleWidth;
				_rect.height = 1.0f;
				_rect.x = (1.0f - scaleWidth) * widthKoefficient;
				_rect.y = 0;

				cam.rect = _rect;
			}
		}
	}
}