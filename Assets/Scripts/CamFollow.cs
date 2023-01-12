using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform _Player;
    public float _SmoothSpeed;

    private Vector3 _targetPos, _NewPos;

    public Vector3 _MinPos,_MaxPos;

    private void LateUpdate()
    {
        if(transform.position!= _Player.position)
        {
            _targetPos = _Player.position;

            Vector3 _CamBoundaryPos = new Vector3(
                 Mathf.Clamp(_targetPos.x, _MinPos.x, _MaxPos.x),
                 Mathf.Clamp(_targetPos.y, _MinPos.y, _MaxPos.y),
                 Mathf.Clamp(_targetPos.z, _MinPos.z, _MaxPos.z));

            _NewPos = Vector3.Lerp(transform.position, _CamBoundaryPos, _SmoothSpeed);
            transform.position = _NewPos;
        }
    }
}
