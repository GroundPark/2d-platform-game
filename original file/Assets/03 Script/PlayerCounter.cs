using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCounter : MonoBehaviour
{
    public Sprite[] spriteDigits;       
    public int value = 0;               
    public float spacing = 0.4f;        

    private int displayValue = -1;      

    
    void Update()
    {
        
        if (displayValue != value)
            // 값 변경시 스프라이트 다시 그림
        {
            string digits = value.ToString();
            SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
            //숫자를 문자열로 변환하고  children에 있는 spriterenderer 컴포넌트 얻음

            int numRenderers = renderers.Length;
            // 랜더러의 개수를 얻음 

            if (numRenderers < digits.Length)
            {
                while (numRenderers < digits.Length)
                {
                    
                    GameObject spr = new GameObject();
                    spr.AddComponent<SpriteRenderer>();
                    spr.transform.parent = transform;
                    spr.transform.localPosition = new Vector3(numRenderers * spacing, 0.0f, 0.0f);
                    spr.layer = 5;
                    numRenderers++;
                    //ㄴ 루프무한방지

                    //빈 오브젝트 등록, 컴포턴트 추가하고 자식으로 설정, 자리수에 따른 위치 설정하고 추가 
                }

               
                renderers = GetComponentsInChildren<SpriteRenderer>();
                //갱신
            }

            
            else if (numRenderers > digits.Length)
            {
                while (numRenderers > digits.Length)
                {
                    renderers[numRenderers - 1].sprite = null;
                    numRenderers--;
                    //ㄴ 루프무한방지

                    //랜더러가 많은경우 스프라이트 삭제
                }
            }

            
            int rendererIndex = 0;
            foreach (char digit in digits)
            {

                int spriteIndex = int.Parse(digit.ToString());
                //숫자값 index로 변환
                renderers[rendererIndex].sprite = spriteDigits[spriteIndex];
                //왼쪽(배열)의 0을 기점으로 시작하는 설정
                rendererIndex++;
                //인덱스 증가시켜서 다음렌더러 결정
            }
            displayValue = value;
        }
    }
 
}
