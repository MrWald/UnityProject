using UnityEngine;

public class PlayerFollow : MonoBehaviour 
{

    public PlayerController Rabit;

    void Update () 
    {
        Transform rabitTransform = Rabit.transform;

        Transform cameraTransform = transform;

        Vector3 rabitPosition = rabitTransform.position;
        Vector3 cameraPosition = cameraTransform.position;

        cameraPosition.x = rabitPosition.x;
        cameraPosition.y = rabitPosition.y;

        cameraTransform.position = cameraPosition;
    }
}