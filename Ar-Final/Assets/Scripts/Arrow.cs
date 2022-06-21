using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            ArrowHit(collision.gameObject);
            GameManagerHunterAR.Instance.PlaySound(SoundType.ARROW);
        }
        else if (collision.gameObject.CompareTag("Balloon"))
        {
            GameObject ballonParticle = Instantiate(GameManagerHunterAR.Instance.balloonParticlePrefab, collision.gameObject.transform);
            ArrowHit(collision.gameObject);
            GameManagerHunterAR.Instance.PlaySound(SoundType.BALLOON);
        }
    }

    void ArrowHit(GameObject collidedObject)
    {
        GameManagerHunterAR.Instance.score += 1;
        GameManagerHunterAR.Instance.RemoveFromList(collidedObject);
        Destroy(collidedObject);
        Destroy(this);
    }
}
