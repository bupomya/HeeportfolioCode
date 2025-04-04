using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumTypes : MonoBehaviour
{

    // 아이템 타입 (무기, 소모품)
    public enum Item_Type { WP, CB};

    // 무기 타입 (갑옷, 근접무기)
    public enum WP_TYPE { ARMOR, MELEE};

    //소모성 아이템 타입 (체력, 마나)
    public enum CB_TYPE { HP_UP, MP_UP};
}
