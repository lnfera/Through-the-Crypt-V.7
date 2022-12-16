using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int health, sphereRadius, potion;
    public float maxVignette = 0.7f, minVignette = 0.4f, interpolationPoint, vignetteIntensity;
    public bool invincibility, vignetteGoUp;
    public LayerMask healthMask;
    Vignette vignette;
    // Start is called before the first frame update
    /*void Start()
    {

    }*/
    IEnumerator InvincibilityFrame()
    {
        /*Makes the player invincible and turns the vignette up, waits for one second, then makes vignette start to go down, 
        then waits for one second, then turns off invincibility*/
        invincibility = true;
        vignetteGoUp = true;
        yield return new WaitForSecondsRealtime(1);
        vignetteGoUp = false;
        yield return new WaitForSecondsRealtime(1);
        invincibility = false;
    }
    public void OnCollisionEnter(Collision collision)
    {
        //If the player gets hit by a projectile while they aren't invincible then they take damage, their healthbar is lowered, they say ouch and becomes invincible
        if (collision.collider.tag == "Enemy" && invincibility == false)
        {
            /*AIFollow controller = collision.gameObject.GetComponent<AIFollow>();
            health -= controller.damage;*/
            //healthBar.takedamage(damage);
            //PlayerAudio.PlayOneShot(OuchSound);
            StartCoroutine(InvincibilityFrame());
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        /*Makes sure that interpolationPoint can't go over or under 0-1 and changes the vignette point based on vignetteIntensity 
        which in turn is based on the interpolationPoint*/
        interpolationPoint = Mathf.Clamp(interpolationPoint, 0, 1);
        vignette.intensity.value = vignetteIntensity;
        vignetteIntensity = Mathf.Lerp(minVignette, maxVignette, interpolationPoint);

        //Makes the vignette go up and down when you take damage
        if (invincibility == true && vignetteIntensity <= 0.7f && vignetteIntensity >= 0.4f)
        {
            if (vignetteGoUp == true)
            {
                print("What");
                interpolationPoint += 0.2f;
            }
            if (vignetteGoUp == false)
            {
                interpolationPoint -= 0.08f;
            }
        }
        if (Physics.CheckSphere(transform.position, sphereRadius, healthMask))
        {
            health += potion;
        }
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}