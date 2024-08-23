using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemies;    // 적들을 리스트로 관리합니다.
    public DoorMover doorMover;         // 문을 제어하는 DoorMover 스크립트의 참조를 설정합니다.
    public GameObject objectToToggle;   // 활성화/비활성화할 오브젝트의 참조를 설정합니다

    // 적이 처치될 때 호출되는 메서드
    public void OnEnemyDefeated(GameObject enemy)
    {
        Debug.Log("Check Kill");
        enemies.Remove(enemy);
        Destroy(enemy);

        // 남아있는 적들이 있는지 확인합니다.
        if (enemies.Count == 0)
        {
            Debug.Log("All enemies defeated");

            // 적이 모두 처치되었을 때 문을 엽니다.
            if (doorMover != null)
            {
                doorMover.OpenDoor();
            }

            // 특정 오브젝트의 활성화/비활성화 기능 추가
            if (objectToToggle != null)
            {
                Debug.Log("Activating object");
                objectToToggle.SetActive(true);
            }

            // 더 이상 이 스크립트는 필요하지 않습니다.
            this.enabled = false;
        }
    }
}
