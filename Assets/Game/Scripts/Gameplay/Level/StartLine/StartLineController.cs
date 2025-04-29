using UnityEngine;

public class StartLineController
{
    private readonly GameObject _startLine;
    private readonly Rigidbody2D _rigidbody;
    private readonly Vector2 _startPosition;

    public StartLineController(GameObject startLine, 
                               LevelMovementController movementController)
    {
        _startLine      = startLine;
        _startPosition  = startLine.transform.localPosition;
        _rigidbody      = startLine.GetComponent<Rigidbody2D>();

        movementController.Add(_rigidbody);
    }

    public void Reset()
    {
        _startLine.transform.localPosition = _startPosition;
        _rigidbody.linearVelocityX = 0;

        _startLine.SetActive(true);
    }
}