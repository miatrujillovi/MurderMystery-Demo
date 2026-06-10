using UnityEngine;
using System;

public class RealTimeClock : MonoBehaviour
{
    [Header("Referencias")]
    public Transform hourHand;
    public Transform minuteHand;

    [Header("Opcional")]
    public bool smooth = true; // movimiento suave

    void Update()
    {
        DateTime now = DateTime.Now;

        float hours = now.Hour % 12;
        float minutes = now.Minute;
        float seconds = now.Second;

        // Ángulos
        float minuteAngle;
        float hourAngle;

        if (smooth)
        {
            minuteAngle = (minutes + seconds / 60f) * 6f;        // 360 / 60 = 6
            hourAngle = (hours + minutes / 60f) * 30f;           // 360 / 12 = 30
        }
        else
        {
            minuteAngle = minutes * 6f;
            hourAngle = hours * 30f;
        }

        // Aplicar rotación (negativo = sentido horario)
        minuteHand.localRotation = Quaternion.Euler(90, 0, minuteAngle);
        hourHand.localRotation = Quaternion.Euler(90, 0, hourAngle);
    }
}