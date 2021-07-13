using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.IO;

namespace Tests
{
    public class TestSuite
    {
        [UnityTest]
        public IEnumerator PlaneMovesRight()
        {
            GameObject plane = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Plane"));
            float initialXPos = plane.transform.position.x;
            yield return new WaitForSeconds(0.1f);
            Assert.Greater(plane.transform.position.x, initialXPos);
            Object.Destroy(plane);
        }

        [UnityTest]
        public IEnumerator BulletMovesRight()
        {
            GameObject bullet = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Bullet"));
            float initialXPos = bullet.transform.position.x;
            yield return new WaitForSeconds(0.1f);
            Assert.Greater(bullet.transform.position.x, initialXPos);
            Object.Destroy(bullet);
        }


        [UnityTest]
        public IEnumerator BulletMovesUp()
        {
            GameObject bullet = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Bullet"));
            float initialYPos = bullet.transform.position.y;
            yield return new WaitForSeconds(0.1f);
            Assert.Greater(bullet.transform.position.y, initialYPos);
            Object.Destroy(bullet);
        }
    }
}
