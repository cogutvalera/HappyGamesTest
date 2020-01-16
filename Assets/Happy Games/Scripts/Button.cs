using UnityEngine;

namespace HappyGames.Test
{
    public class Button : MonoBehaviour
    {
        // Камера для конвертации точки касания на экране в луч
        public Camera camera;

        void Update()
        {
            // Если не было нажатия, то возвращаемся из метода
            if (false == Input.GetMouseButtonUp(0))
                return;

            // После нажатия конвертируем точку касания на экране в луч
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            // Проверяем куда попал луч
            if (Physics.Raycast(ray, out hit))
            {
                // Если было попадание в эту кнопку
                if (hit.transform == transform)
                {
                    // то совершаем необходимое действие
                    HappyGamesTest.Instance.Action(this, hit.point);
                }
            }
        }
    }
}