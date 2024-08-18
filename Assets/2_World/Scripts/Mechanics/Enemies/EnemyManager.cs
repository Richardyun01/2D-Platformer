using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemies;    // 적들을 리스트로 관리합니다.
    public DoorMover doorMover;         // 문을 제어하는 DoorMover 스크립트의 참조를 설정합니다.
    public GameObject objectToToggle;   // 활성화/비활성화할 오브젝트의 참조를 설정합니다.

    // Update는 매 프레임마다 호출됩니다.
    void Update()
    {
        // 남아있는 적들이 있는지 확인합니다.
        if (enemies.Count == 0)
        {
            // 적이 모두 처치되었을 때 문을 엽니다.
            if (doorMover != null)
            {
                doorMover.OpenDoor();
            }
            

            // 특정 오브젝트의 활성화/비활성화 기능 추가
            if (objectToToggle != null)
            {
                objectToToggle.SetActive(!objectToToggle.activeSelf);
            }

            // 더 이상 Update를 수행하지 않기 위해 스크립트를 비활성화합니다.
            this.enabled = false;
        }
    }

    // 적이 처치될 때 호출되는 메서드
    public void OnEnemyDefeated(GameObject enemy)
    {
        enemies.Remove(enemy);
    }
}
