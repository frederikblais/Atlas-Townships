using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private Vector3 _moveDelta;
    private RaycastHit2D _raycastHit;

    private void Start() {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate() {
        // Get Input
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Reset _moveDelta
        _moveDelta = new Vector3(x, y, 0);

        // Reset _moveDelta
        _moveDelta = new Vector3(x, y, 0);

        // Swap sprite direction on Left and Right
        if (_moveDelta.x > 0) {
            transform.localScale = Vector3.one;
        } else if (_moveDelta.x < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Send RaycastHit2D to see if we can move
        _raycastHit = Physics2D.BoxCast(
            transform.position, _boxCollider.size, 0, new Vector2(0, _moveDelta.y),
            Mathf.Abs(_moveDelta.y * Time.deltaTime),
            LayerMask.GetMask("Character", "Blocking"));

        if (_raycastHit.collider == null) {
            transform.Translate(0, _moveDelta.y * Time.deltaTime, 0);   // Move
        }

        // Send RaycastHit2D to see if we can move
        _raycastHit = Physics2D.BoxCast(
            transform.position, _boxCollider.size, 0, new Vector2(_moveDelta.x, 0),
            Mathf.Abs(_moveDelta.x * Time.deltaTime),
            LayerMask.GetMask("Character", "Blocking"));

        if (_raycastHit.collider == null) {
            transform.Translate(_moveDelta.x * Time.deltaTime, 0, 0);   // Move
        }

    }
}
