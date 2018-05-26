using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour 
{

    public PlayerController Rabit;

    void Update () 
    {
        //Отримуємо доступ до компонента Transform
        //це Скорочення до GetComponent<Transform>
        Transform rabitTransform = Rabit.transform;

        //Отримуємо доступ до компонента Transform камери
        Transform cameraTransform = this.transform;

        //Отримуємо доступ до координат кролика
        Vector3 rabitPosition = rabitTransform.position;
        Vector3 cameraPosition = cameraTransform.position;

        //Рухаємо камеру тільки по X,Y
        cameraPosition.x = rabitPosition.x;
        cameraPosition.y = rabitPosition.y;

        //Встановлюємо координати камери
        cameraTransform.position = cameraPosition;
    }
}