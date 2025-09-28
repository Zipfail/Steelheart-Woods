using UnityEngine;

public class time : MonoBehaviour
{
    public float timeOfDay; // ����� � ������� (0-1440)
    public float dayDuration = 1440f; // ����������������� ������� ��� � ������� (24 ����)
    public GameObject sun; // ������ �� ��������� ����
    public float timeScale = 1f; // ����������� �������� �������

    void Update()
    {
        // ��������� ����� � ������ �������� �������
        timeOfDay += (Time.deltaTime / 60f) * timeScale; // �������� �� timeScale ��� ��������� ��������
        if (timeOfDay >= dayDuration)
        {
            timeOfDay -= dayDuration;
        }

        // ������������ ���� ������
        float sunAngle = (timeOfDay / dayDuration) * 360f - 90f; // -90, ����� ������ ���� � ������ � �������� ���
        sun.transform.rotation = Quaternion.Euler(sunAngle, 170f, 0f);
    }
}

