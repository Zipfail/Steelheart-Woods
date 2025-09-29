using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class time : MonoBehaviour
{
    public float timeOfDay; // ����� � ������� (0-1440)
    public int day = 0;
    private float dayDuration = 1440f; // ����������������� ������� ��� � ������� (24 ����)
    [SerializeField] private GameObject sun; // ������ �� ��������� ����
    [SerializeField] private float timeScale = 1f; // ����������� �������� �������

    void Update()
    {
        // ��������� ����� � ������ �������� �������
        timeOfDay += (Time.deltaTime / 60f) * timeScale; // �������� �� timeScale ��� ��������� ��������
        if (timeOfDay >= dayDuration)
        {
            timeOfDay = 0;
            day++;
        }

        // ������������ ���� ������
        float sunAngle = (timeOfDay / dayDuration) * 360f - 90f; // -90, ����� ������ ���� � ������ � �������� ���
        sun.transform.rotation = Quaternion.Euler(sunAngle, 170f, 0f);
    }
    

    public void time_set(float time_st)
    {
        timeOfDay = time_st;
    }
}

