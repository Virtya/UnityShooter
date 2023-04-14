using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour
{
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip hitWallSound;
    [SerializeField] private AudioClip hitEnemySound;

    private Camera _camera;
    
    void Start()
    {
        _camera = GetComponent<Camera>();
        soundSource.volume = 0.25f;

        /*Cursor.lockState = CursorLockMode.Locked;*/
        Cursor.visible = true;
    }

    void OnGUI()
    {
        int size = 20;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "+");

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray _ray = _camera.ScreenPointToRay(point);
            RaycastHit _hit;
            if (Physics.Raycast(_ray, out _hit))
            {
                GameObject hitObject = _hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReactToHit();
                    soundSource.PlayOneShot(hitEnemySound);
                    Messenger.Broadcast(GameEvent.ENEMY_HIT);
                }
                else
                {
                    StartCoroutine(SphereIndicator(_hit.point));
                    soundSource.PlayOneShot(hitWallSound);
                }
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
