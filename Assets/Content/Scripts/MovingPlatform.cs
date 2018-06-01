using UnityEngine;

public class MovingPlatform : MovingObj 
{

	
    public float TimeToReach;
    public float TimeToWait;
    
    private float _currentTimeToWait;
    
    private bool _goingToA;
    private bool _wait;
    
    // Use this for initialization
    new void Start () 
    {
        base.Start();
        _goingToA = false;
        _wait = true;
        _currentTimeToWait = TimeToWait;
    }

    private void FixedUpdate()
    {
        Vector3 myPos = transform.position;
        Vector3 target = _goingToA ? PointA : PointB;
        Vector3 destination = target - myPos;
        destination.z = 0;
        
        if (_wait)
        {
            _currentTimeToWait -= Time.deltaTime;
            if (!(_currentTimeToWait <= 0)) return;
            _wait = false;
            _currentTimeToWait = TimeToWait;
            MyBody.velocity = new Vector2(destination.x/TimeToReach, destination.y/TimeToReach);
            return;
        }

        if (!IsArrived(myPos, target)) return;
        _goingToA = !_goingToA;
        _wait = true;
        MyBody.velocity = new Vector2(0, 0);
    }

    
}
