using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace MainGame.Weapon
{
    public class DiamondFragSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> fragPiece;
        [SerializeField] private int minFrag;
        [SerializeField] private int maxFrag;

        private void OnDestroy()
        {
            var rand = new Random();
            var fragCount = rand.Next(minFrag, maxFrag);
            for (var i = 0; i < fragCount; i++)
            {
                var angle = rand.NextDouble() * Math.PI * 2;
                var type = rand.Next(0, fragPiece.Count);
                Instantiate(fragPiece[type], transform.position, Quaternion.identity).GetComponent<Projectile>().SetDir(new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)));
            }
        }
    }
}