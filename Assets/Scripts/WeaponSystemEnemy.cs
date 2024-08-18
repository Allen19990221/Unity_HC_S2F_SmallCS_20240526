using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;

namespace Kuoan
{
    public class WeaponSystemEnemy : WeaponSystem
    {
        [Header("開槍間隔")]
        [SerializeField, Range(1, 3)]
        private float fireIntervalMin = 3;
        [SerializeField, Range(3, 6)]
        private float fireIntervalMax = 5;

        private ControlSystemEnemy ControlSystemEnemy;
        private bool enemyFire;
        protected override void Awake()
        {
            base.Awake();
            ControlSystemEnemy = transform.root.GetComponent<ControlSystemEnemy>();
        }

        protected override void Update()
        {
            base.Update();
            EnemyInput();
        }

        private void EnemyInput()
        {
            if (enemyFire) return;
            Fire(ControlSystemEnemy.checkPlayer);

            StartCoroutine(FireInterval());
        }

        private IEnumerator FireInterval()
        {
            enemyFire = true;
            float fireInterval = Random.Range(fireIntervalMin, fireIntervalMax);
            yield return new WaitForSeconds(fireInterval);
            enemyFire = false;
        }
    }
}

