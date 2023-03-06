using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Enemigo : Entity
    {

        [SerializeField] private float moveSpeed = 4f;
        [SerializeField] private float m_distanceThreshold;

    }
}
