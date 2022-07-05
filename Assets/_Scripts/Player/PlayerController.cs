using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private CharacterController controller;
    private bool recoil;
    [SerializeField]
    private float playerSpeed = 2.0f;

    public Animator anim;
    public Weapon currentWeapon;
    public Transform firePoint;

    private void Awake()
    {
        playerInput = new PlayerInput();
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Start()
    {
        
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleShoot();
    }

    void HandleMovement()
    {
        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            anim.SetBool("isWalking", true);
            gameObject.transform.forward = move;
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    void HandleRotation()
    {
        Vector2 aim = playerInput.PlayerMain.Look.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(aim);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;
        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            Vector3 newLookPoint = new Vector3(point.x, transform.position.y, point.z);
            transform.LookAt(newLookPoint);
        }
    }

    void HandleShoot()
    {
        if (playerInput.PlayerMain.Shoot.triggered)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (canShoot())
        {
            anim.SetBool("isShooting", true);
            currentWeapon.Shoot(firePoint);
            StartCoroutine(HandleRecoil());
        }
        else
        {
            anim.SetBool("isShooting", false);
        }
    }

    public bool canShoot()
    {
        if (recoil)
        {
            return false;
        }

        return true;
    }

    public IEnumerator HandleRecoil()
    {
        recoil = true;
        float percent = 0;
        WaitForFixedUpdate update = new WaitForFixedUpdate();

        while (percent < currentWeapon.recoilTime)
        {
            percent += Time.deltaTime;
            yield return update;
        }
        recoil = false;
    }
}
