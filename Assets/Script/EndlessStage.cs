using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessStage : MonoBehaviour
{
    //�}�b�v�̍��E�̒���
    [SerializeField] int StageMapSize = 0;
                     private int CurrentMapIndex;
    [SerializeField] private Transform Player;
    [SerializeField] GameObject[] StageMaps;
    [SerializeField] int StartMapIndex;
    //�}�b�v�̐�ǂݐ�
    [SerializeField] int NextMapsIndex;
    //������X�e�[�W�`�b�v�̕ێ����X�g
    [SerializeField] public List<GameObject> GeneratedStageList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //����������
        CurrentMapIndex = StartMapIndex - 1;
        UpdateStage(NextMapsIndex);

    }

    // Update is called once per frame
    void Update()
    {
        //�L�����N�^�[�̈ʒu���猻�݂̃X�e�[�W�`�b�v�̃C���f�b�N�X���v�Z���܂�
        int charaPositionIndex = (int)(Player.position.x / StageMapSize);
        //���̃X�e�[�W�`�b�v�ɓ�������X�e�[�W�̍X�V�������s���܂��B
        if (charaPositionIndex + NextMapsIndex > CurrentMapIndex)
        {
            UpdateStage(charaPositionIndex + NextMapsIndex);
        }
    }

    //�w��̃C���f�b�N�X�܂ł̃X�e�[�W�`�b�v�𐶐����āA�Ǘ����ɂ���
    void UpdateStage(int toTipIndex)
    {
        if (toTipIndex <= CurrentMapIndex) return;
        //�w��̃X�e�[�W�`�b�v�܂Ő��������
        for (int i = CurrentMapIndex + 1; i <= toTipIndex; i++)
        {
            GameObject stageObject = GenerateStage(i);
            GeneratedStageList.Add(stageObject);
        }
        while (GeneratedStageList.Count > NextMapsIndex + 2) DestroyOldestStage();
        CurrentMapIndex = toTipIndex;

    }

    //�w��̃C���f�b�N�X�ʒu��stage�I�u�W�F�N�g�������_���ɐ���
    GameObject GenerateStage(int tipIndex)
    {
        int nextStageTip = Random.Range(0, StageMaps.Length);

        GameObject stageObject = (GameObject)Instantiate(
            StageMaps[nextStageTip],
            new Vector3(tipIndex * StageMapSize, 0, 0), //�����x�������ɖ�����������̂ł��̏����������Ă���
            Quaternion.identity) as GameObject;
        return stageObject;
    }

    //��ԌÂ��X�e�[�W���폜���܂�
    void DestroyOldestStage()
    {
        GameObject oldStage = GeneratedStageList[0];
        GeneratedStageList.RemoveAt(0);
        Destroy(oldStage);
    }
}

