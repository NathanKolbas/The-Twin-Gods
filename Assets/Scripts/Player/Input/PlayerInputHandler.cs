using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 100.0f)] private float speed = 50.0f;
    
    // private Rigidbody _rigidbody;
    private Vector2 _movement;
    private SpriteRenderer _spriteRenderer;
    public PlayerAttacking playerAttacking;
    private bool _isAttacking = false;
    private Animator _animator;
    private static readonly int X = Animator.StringToHash("x");
    private const int IdleLayer = 0;
    private const int WalkLayer = 1;
    private const int AttackStab = 2;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void FixedUpdate()
    {
        if (_isAttacking) return;
        
        transform.Translate(_movement);
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -4.5f, 45.5f), 
            Mathf.Clamp(transform.position.y, -3.25f, 2.5f), 
            transform.position.z
        );
            
        if (_movement.x != 0 || _movement.y != 0)
        {
            _animator.SetLayerWeight(WalkLayer, 1);
        }
        else
        {
            _animator.SetLayerWeight(WalkLayer, 0);
        }

        if (_movement.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_movement.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
    
    
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        Vector2 movementInput = context.ReadValue<Vector2>();
        _movement = new Vector2(movementInput.x, movementInput.y);
        _movement = _movement.normalized * (speed / 100);
    }

    public void AttackingHandler(InputAction.CallbackContext context)
    {
        if (_isAttacking) return;
        
        _isAttacking = true;
        playerAttacking.Punch(_spriteRenderer.flipX);
        var attackLength = _animator.GetCurrentAnimatorStateInfo(AttackStab).length;
        StartCoroutine(_animateStabAttack(attackLength));
    }
    
    private IEnumerator _animateStabAttack(float seconds)
    {
        _animator.SetLayerWeight(AttackStab, 1);
        _animator.Play("Stab", AttackStab, 0f);
        yield return new WaitForSeconds(seconds);
        _animator.SetLayerWeight(AttackStab, 0);
        _isAttacking = false;
    }
}
