using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class time : MonoBehaviour
{
    public float timeOfDay; // Время в минутах (0-1440)
    public int day = 0;
    private float dayDuration = 1440f; // Продолжительность полного дня в минутах (24 часа)
    [SerializeField] private GameObject sun; // Ссылка на солнечный свет
    [SerializeField] private float timeScale = 1f; // Коэффициент скорости времени

    void Update()
    {
        // Обновляем время с учетом скорости времени
        timeOfDay += (Time.deltaTime / 60f) * timeScale; // Умножаем на timeScale для настройки скорости
        if (timeOfDay >= dayDuration)
        {
            timeOfDay = 0;
            day++;
        }

        // Рассчитываем угол солнца
        float sunAngle = (timeOfDay / dayDuration) * 360f - 90f; // -90, чтобы солнце было в зените в середине дня
        sun.transform.rotation = Quaternion.Euler(sunAngle, 170f, 0f);
    }
    

    public void time_set(float time_st)
    {
        timeOfDay = time_st;
    }
}

