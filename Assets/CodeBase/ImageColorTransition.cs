using UnityEngine;
using UnityEngine.UI;

public class ImageColorTransition : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Color startColor = Color.blue;
    [SerializeField] private Color endColor = Color.red;
    [SerializeField] private float duration = 1.0f;

    private bool isForward = true;
    private float t;

    private void Start()
    {
        // Начинаем с интерполяции от начального цвета
        t = 0f;
    }

    private void Update()
    {
        // Изменяем t в зависимости от направления анимации
        if (isForward)
        {
            t += Time.deltaTime / duration;
            if (t >= 1.0f)
            {
                t = 1.0f;
                isForward = false; // Меняем направление анимации
            }
        }
        else
        {
            t -= Time.deltaTime / duration;
            if (t <= 0.0f)
            {
                t = 0.0f;
                isForward = true; // Меняем направление анимации
            }
        }

        // Обновляем цвет изображения
        image.color = Color.Lerp(startColor, endColor, t);
    }
}