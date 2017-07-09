﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Characters;

namespace RPG.Weapons
{
    [ExecuteInEditMode] [SelectionBase]
    public class WeaponPickupPoint : MonoBehaviour
    {
        [SerializeField] Weapon weaponConfig;

        void Start()
        {
            DestroyChildren();
            InstantiateWeapon();
        }

        void DestroyChildren()
        {
            foreach (Transform child in transform)
            {
                DestroyImmediate(child.gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (!Application.isPlaying)
            {
                DestroyChildren();
                InstantiateWeapon();
            }
        }

        void InstantiateWeapon()
        {
            var weapon = weaponConfig.GetWeaponPrefab();
            weapon.transform.position = Vector3.zero;
			Instantiate(weapon, gameObject.transform);
        }

        private void OnTriggerEnter()
        {
            FindObjectOfType<Player>().PutWeaponInHand(weaponConfig);
            // TODO consider if enemies should be able to pick-up too
        }
    }
}