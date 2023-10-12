using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    public int selectedWeapon = 0;

    public bool isGunSelected;
    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {

        int previousSelectedWeapon = selectedWeapon;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(selectedWeapon >= transform.childCount -1)
            {
                selectedWeapon = 0;
            }
            else 
            {
                selectedWeapon++;
            }
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if(selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount -1;
            }
            else 
            {
                selectedWeapon--;
            }
        }

        if(previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }

        if(selectedWeapon<1)
        {
            isGunSelected = false;
        }
        else
        {
            isGunSelected = true;
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach(Transform Weapon  in transform)
        {
            if(i == selectedWeapon)
            {
                Weapon.gameObject.SetActive(true);
            }
            else
            {
                Weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
