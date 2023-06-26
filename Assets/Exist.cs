using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class Exist : MonoBehaviour
    {
        public float LifeTime = 2f;

        private void Start()
        {
            Destroy(this.gameObject, LifeTime);
        }
    }
}
