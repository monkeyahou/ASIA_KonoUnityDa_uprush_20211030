using UnityEngine;

/// <summary>
/// NPC �欰
/// �����ؼжi�J�I����
/// ��ܹ�ܨt��
/// </summary>

public class NPC : MonoBehaviour
{

    [Header("��ܸ��")]
    public DataDialogue dataDialogue;
    [Header("��ܨt��")]
    public DialogueSystem dialogueSystem;
    [Header("Ĳ�o��ܪ���H")]
    public string target = "�D��-����";
    public string target1 = "�D��-�U�l";

    // Ĳ�o�}�l�ƥ�
    // 1. ��Ӫ��󳣭n�� Collider 2D
    // 2. ��ӭn���@�Ӧ� Rigidbody 2D
    // 3. ��ӭn�@�Ӥ� Is Trigger


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == target || collision.name == target1)
        {
            dialogueSystem.StartDialogue(dataDialogue.dialogues);
        }
  
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == target || collision.name == target1)
        {
            dialogueSystem.StoptDialogue();
        }
  
    }

    


}
