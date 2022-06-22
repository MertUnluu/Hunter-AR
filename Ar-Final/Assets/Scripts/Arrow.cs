using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private GameObject balloonParticlePrefab;

    private void Start()
    {
        GameManagerHunterAR.Instance.PlaySound(SoundType.BOW);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            ArrowHit(collision.gameObject);
            GameManagerHunterAR.Instance.PlaySound(SoundType.ARROW);
        }
        else if (collision.gameObject.CompareTag("Balloon"))
        {
            GameObject ballonParticle = Instantiate(balloonParticlePrefab, collision.gameObject.transform.position, Quaternion.identity);
            ParticleSystem ps = ballonParticle.GetComponent<ParticleSystem>();
            if (ps != null) { ps.Play(); }
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
