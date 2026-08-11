using JetBrains.Annotations;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    // ici on peut:
    // - créer des var
    // - créer des func
    // ici on ne peut pas : 
    // - appeler une fonction

    private Vector2 moveInput = Vector2.zero;
    public float speed = 10f;
    public GameObject Bullet;
    public bool Canshoot = true;
    public bool isShooting = false;
    public float firerate = 1f;

    // initialisé rigidbody
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // assigné notre rb
        rb = GetComponent<Rigidbody2D>();

        //StartCoroutine(ShootMultiple());
    }

    public void Shoot()
    {
        var bullet = Instantiate(Bullet, transform.position, transform.rotation);
    }
    public IEnumerator Firerate()
    {
        while (isShooting)
        {
            Shoot();
            Canshoot = false;
            yield return new WaitForSeconds(firerate);
            Canshoot = true;
            if (!isShooting)
            {
                yield break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        LookToMouse();

        // utiliser notre rb pour lui donner de la vitesse dans la direction MoveInput
        rb.linearVelocity = moveInput * speed;
       
        // ici je peut:
        // - créer des var local

        // - appeler une autre fonction
        // ici je ne peut pas:
        // - créer une fonction


        // sur une equation

        // le code c'est sois des equation (=) ou un ordre (lancer une fonction)

        // une var d'un type X = une autre var d'un type X

        //rotate notre joueur dans la direction de la sourie.


        //var q = Quaternion.LookRotation(MouseManager.Instance.MousePos - transform.position);
        //transform.rotation = q;
        //transform.rotation = q;

    }


    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

    }


    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.started && isShooting == false && Canshoot == true)
        {
            isShooting = true;
            StartCoroutine(Firerate());
            
        }

        if(context.canceled)
        {
            isShooting = false;
        }

    }



   


    private void LookToMouse()
    {
        Vector3 myLocation = transform.position;
        Vector3 targetLocation = MouseManager.Instance.MousePos;
        targetLocation.z = myLocation.z; // ensure there is no 3D rotation by aligning Z position

        // vector from this object towards the target location
        Vector3 vectorToTarget = targetLocation - myLocation;
        // rotate that vector by 360 degrees around the Z axis
        Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 360) * vectorToTarget;

        // get the rotation that points the Z axis forward, and the Y axis 90 degrees away from the target
        // (resulting in the X axis facing the target)
        Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorToTarget);

        // changed this from a lerp to a RotateTowards because you were supplying a "speed" not an interpolation value
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360);
        // RESULTAT : le +Y de notre joueur pointe vers notre sourie.
    }
}
