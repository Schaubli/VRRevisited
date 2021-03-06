﻿using UnityEngine;
using System.Collections;

public class Canonball : MonoBehaviour {

    private Rigidbody rb;
    public int damage;

    void Start() {
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.position = transform.position;
    }

    public void SetPosition(Vector3 cannonPos) {
        this.transform.position = new Vector3(cannonPos.x,cannonPos.y + 0.26f, cannonPos.z);
    }
    public void SetRotation(float cannonEulerAnglesY, float playerEulerAnglesX) {
        Vector3 eulerRotation = new Vector3(playerEulerAnglesX - 20, cannonEulerAnglesY - 90, 0);
        transform.rotation = Quaternion.Euler(eulerRotation);
    }

    public void SetDamage(int dmg) {
        this.damage = dmg;
    }

    public void Fire(){
        Invoke("DestroyMe", 3);
       // rb.AddForce(transform.forward * 1, ForceMode.Impulse);
    }
    void DestroyMe() {
        Destroy(this.gameObject);
    }
	// Update is called once per frame
	void Update () {
        
   
    this.transform.position = this.transform.position + transform.forward * 0.6f;
    this.transform.Rotate(0.8f, 0, 0);
       

    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("VREnemy"))
        {
            Debug.Log("Hit");
            other.gameObject.GetComponent<VREnemyKrakeKopf>().TakeDamage(this.damage/2);
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("VREnemyShip"))
        {
            other.gameObject.GetComponent<VREnemyShip>().TakeDamage(this.damage);
            Destroy(this.gameObject);
        }

            if (other.gameObject.CompareTag("LootCrate"))
        {
            other.gameObject.GetComponent<LootCrate>().Hit();
            Destroy(this.gameObject);
        }
    }
}
