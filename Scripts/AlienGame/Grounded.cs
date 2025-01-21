using UnityEngine;

public class Grounded : MonoBehaviour
{
    [Header("---Raycast Props")]
    [SerializeField] private float _length;
    [SerializeField] private LayerMask _jumpableMask;
    [SerializeField] private Transform _raycastPoint;


    //    [Header("---Components")]

    public bool IsGrounded() => Physics2D.OverlapBox(_raycastPoint.position, _length * Vector2.one, 0, _jumpableMask);
    public GameObject GetGrounded() => Physics2D.OverlapBox(_raycastPoint.position, _length * Vector2.one, 0, _jumpableMask).gameObject;

}