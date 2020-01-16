using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

namespace HappyGames.Test
{
    public class HappyGamesTest : MonoBehaviour
    {
        // Кол-во всех уровней
        public int levels = 3;

        // Время задержки показа промаха, а также время перехода между уровнями
        public float timeDuration = 3f;

        // Текстовые метки для промахов и успешных попаданий
        public TextMeshPro textMissed, textSuccess;

        // Счетчики для промахов и успешных попаданий
        public int counterMissed, counterSuccess;

        // Объект для указания промаха
        public GameObject missed;

        // Материал который устанавливается на объекте при успешном попадании
        public Material greenMat;

        // Элемент, который связывает два объекта на разных картинках
        [System.Serializable]
        public class Element
        {
            public Button button1, button2;
        }

        // Список всех элементов текущего уровня
        public List<Element> elements;

        // Синглтон
        private static HappyGamesTest _instance;

        public static HappyGamesTest Instance
        {
            get
            {
                return _instance;
            }
        }

        // Инициализация
        private void Awake()
        {
            _instance = this;

            counterMissed = counterSuccess = 0;
        }

        public void Action(Button b, Vector3 pos)
        {
            // Проходимся в цикле по всем элементам текущего уровня
            foreach (Element el in elements)
            {
                // Если был нажат объект, который принадлежит текущему элементу
                if (el.button1 == b || el.button2 == b)
                {
                    // На обеих картинках показываем успешное попадание
                    el.button1.GetComponent<MeshRenderer>().material = greenMat;
                    el.button2.GetComponent<MeshRenderer>().material = greenMat;

                    // Увеличиваем счетчик успешных попаданий
                    counterSuccess++;
                    textSuccess.text = "Попадания: " + counterSuccess.ToString();

                    // Проверяем если закончился уровень
                    if (counterSuccess >= elements.Count)
                    {
                        // Переход на следующий уровень по кругу
                        Invoke("LoadScene", timeDuration);
                    }

                    return;
                }
            }

            // Отменяем предыдущий вызов метода
            CancelInvoke("DisableMissed");

            // Делаем активным объект промаха и перемещаем на позицию касания на экране
            missed.SetActive(true);
            missed.transform.position = pos;

            // Вызываем метод через временной интервал для отключения объекта промаха
            Invoke("DisableMissed", timeDuration);

            // Вызываем метод через временной интервал для увеличения счетчика промахов
            Invoke("CounterMissed", timeDuration);
        }

        void LoadScene()
        {
            // Получаем индекс текущей сцены
            int i = SceneManager.GetActiveScene().buildIndex;

            // Устанавливаем индекс следующей сцены по кругу
            i = (i + 1) % levels + 1;

            // Загружаем следущий уровень
            SceneManager.LoadScene("Level " + i.ToString(), LoadSceneMode.Single);
        }

        void DisableMissed()
        {
            missed.SetActive(false);
        }

        void CounterMissed()
        {
            counterMissed++;
            textMissed.text = "Промахи: " + counterMissed.ToString();
        }
    }
}
