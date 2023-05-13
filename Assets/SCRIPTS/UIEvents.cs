
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIEvents : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Animator modelAnimator;
    [SerializeField] private Transform modelTransform;
    [SerializeField] private Vector3 exactPos;
    [SerializeField] private bool onSelect;

    public enum Type { framerateslider, overrideslider }
    public Type type;

    [SerializeField] private Slider overrideSlider;
    [SerializeField] private TextMeshProUGUI overrideframeTMP;

    private void Awake()
    {
        if (overrideSlider)
            overrideSlider.value = 1;
    }
    private void Start()
    {
        exactPos = modelTransform.position;
        if (type == Type.overrideslider)
        {
            overrideSlider.onValueChanged.AddListener(OverrideUpdateText);
            overrideSlider.onValueChanged.Invoke(1f);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (type == Type.framerateslider)
        {
            modelAnimator.speed = 0f;
            AnimationController.instance.onDrag = true;
        }
        if (type == Type.overrideslider)
        {
            modelAnimator.speed = 0f;
            AnimationController.instance.onDrag = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (type == Type.framerateslider)
        {
            if (!AnimationController.instance.onPause)
                AnimationManager.instance.SetAnimSpeed();
            AnimationController.instance.onDrag = false;

        }
        if (type == Type.overrideslider)
        {
            if (!AnimationController.instance.onPause)
                AnimationManager.instance.SetAnimSpeed();
            AnimationController.instance.onDrag = false;
            AnimationController.instance.OverDrive(overrideSlider.value);

        }
    }

    public void OverrideUpdateText(float value)
    {
        overrideframeTMP.text = ((int)(value * 100)).ToString();
    }
}
