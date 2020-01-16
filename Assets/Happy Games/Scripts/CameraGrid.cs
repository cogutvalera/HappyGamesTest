using UnityEngine;

namespace HappyGames.Test
{
	[ExecuteInEditMode]
	public class CameraGrid : MonoBehaviour {
		public bool enableGrid = true;
		
		public float positionZ = 100;
		
		public int rowsNumber = 20, colsNumber = 25, sizeQuadsWidth = 5, sizeQuadsHeight = 5;
		public float cellWidth = 15, cellHeight = 15, lineWidth = 1f;
		
		private float delta = 0.01f;
		
		public Color color = Color.white;
		
		private Vector3 _v1, _v2;
		
		private float _gridWidth, _gridHeight;
		private int _i;
		
		void OnDrawGizmos() {
			if (!enableGrid) {
				return;
			}
			
			_gridWidth = cellWidth * colsNumber;
			_gridHeight = cellHeight * rowsNumber;
			
			for (_i=0; _i<=rowsNumber; _i++) {
				if (sizeQuadsHeight > 0 && _i % sizeQuadsHeight == 0) {
					Gizmos.color = color;
					for (float j=-lineWidth/2f; j<lineWidth/2f; j+=delta) {
						_v1 = transform.position + 
								new Vector3(
									-_gridWidth * 0.5f, 
									-_gridHeight * 0.5f + _i * cellHeight + j, 
									0
								);
						_v1.z = positionZ;
						
						_v2 = transform.position + 
									new Vector3(
										_gridWidth * 0.5f, 
										-_gridHeight * 0.5f + _i * cellHeight + j, 
										0
									);
						_v2.z = positionZ;
						
						Gizmos.DrawLine(_v1, _v2);
					}
				}
				
				Gizmos.color = Color.white;
				
				_v1 = transform.position + 
							new Vector3(
								-_gridWidth * 0.5f, 
								-_gridHeight * 0.5f + _i * cellHeight, 
								0
							);
				_v1.z = positionZ;
				
				_v2 = transform.position + 
							new Vector3(
								_gridWidth * 0.5f, 
								-_gridHeight * 0.5f + _i * cellHeight, 
								0
							);
				_v2.z = positionZ;
				
				Gizmos.DrawLine(_v1, _v2);
			}
			
			for (_i=0; _i<=colsNumber; _i++) {
				if (sizeQuadsWidth > 0 && _i % sizeQuadsWidth == 0) {
					Gizmos.color = color;
					for (float j=-lineWidth/2f; j<lineWidth/2f; j+=delta) {
						_v1 = transform.position + 
									new Vector3(
										-_gridWidth * 0.5f + _i * cellWidth + j, 
										_gridHeight * 0.5f, 
										0
									);
						_v1.z = positionZ;
						
						_v2 = transform.position + 
									new Vector3(
										-_gridWidth * 0.5f + _i * cellWidth + j, 
										-_gridHeight * 0.5f, 
										0
									);
						_v2.z = positionZ;
						
						Gizmos.DrawLine(_v1, _v2);
					}
				}
				
				Gizmos.color = Color.white;
				
				_v1 = transform.position + 
							new Vector3(
								-_gridWidth * 0.5f + _i * cellWidth, 
								_gridHeight * 0.5f, 
								0
							);
				_v1.z = positionZ;
				
				_v2 = transform.position + 
							new Vector3(
								-_gridWidth * 0.5f + _i * cellWidth, 
								-_gridHeight * 0.5f, 
								0
							);
				_v2.z = positionZ;
				
				Gizmos.DrawLine(_v1, _v2);
			}
		}
	}
}