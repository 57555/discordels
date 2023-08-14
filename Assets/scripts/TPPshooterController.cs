using Cinemachine;
using StarterAssets;
using UnityEngine;

public class TPPshooterController : MonoBehaviour
{

    public bool playerCanMove = false;
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform bulletPrefab;
    [SerializeField] private Transform bulletPos;


    private StarterAssetsInputs starterAssetsInputs;


    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }



    private void Update()
    {
        shooting();
    }


    private void shooting()
    {
        Vector2 crosshair = new Vector2( Screen.width / 2f, Screen.height / 2f );
        Ray ray = Camera.main.ScreenPointToRay(crosshair);
        if( Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
        }
        transform.LookAt(debugTransform.position);

        if(starterAssetsInputs.shoot)
        {
            Transform theBullet = Instantiate(bulletPrefab, bulletPos);
            theBullet.LookAt(debugTransform.position);
            starterAssetsInputs.shoot = false;
        }
    }


}
