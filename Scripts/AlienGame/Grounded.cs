using UnityEngine;

public class Grounded : MonoBehaviour
{
    [Header("---Raycast Props")]
    [SerializeField] private float _length;
    [SerializeField] private LayerMask _jumpableMask;
    [SerializeField] private Transform _raycastPoint;



    public bool IsGrounded() => Physics2D.OverlapBox(_raycastPoint.position, new Vector2(1, _length), 0, _jumpableMask);
    public GameObject GetGrounded() => Physics2D.OverlapBox(_raycastPoint.position, new Vector2(1, _length), 0, _jumpableMask).gameObject;

}