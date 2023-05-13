using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class AnimationController : MonoBehaviour
{
    public static AnimationController instance;
    public Animator animator;
    public AnimationClip animationClip;
    public float frameRate;
    public Slider frameRateSlider;
    public Slider overdriveSlider;
    private bool isSet;
    [SerializeField] private TextMeshProUGUI currentframeTMP;
    [SerializeField] private TextMeshProUGUI totalframeTMP;

    [SerializeField] private Vector3 exactpos;
    [SerializeField] private Vector3 exactRotation;


    public bool onDrag;
    public bool onPause;
    private float  totalFrames;
    private float  currenttotalFrames;
  [SerializeField]  private float playbackSpeed;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        exactpos = transform.position;
        exactRotation =  transform.rotation.eulerAngles;
        frameRateSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }
    public void SetAnimationClip(AnimationClip currentclip)
    {
        frameRateSlider.value = 0;
        transform.position = exactpos;
        var rotation = Quaternion.Euler(exactRotation);
        transform.rotation = rotation;
        animationClip = currentclip;
        currenttotalFrames = animationClip.frameRate;
        overdriveSlider.value = 1f;
        SetFrameRate();
    }
    public void OverDrive(float slidervalue)
    {
        currenttotalFrames = animationClip.frameRate / slidervalue;
        SetFrameRate();
    }

    private void SetFrameRate()
    {
        totalFrames = (int)(animationClip.length * currenttotalFrames);
        totalframeTMP.text = totalFrames.ToString();
        playbackSpeed = 1 / totalFrames;
    }
    private void LateUpdate()
    {
        if(!onDrag && !onPause)
        frameRateSlider.value += playbackSpeed;

    }

  
    public void Replay()
    {
        if(!onDrag)
        {
            transform.position = exactpos;
            var rotation = Quaternion.Euler(exactRotation);
            transform.rotation = rotation;
            var currentFrame =0;
            currentframeTMP.text = currentFrame.ToString();
            var currentState = animator.GetCurrentAnimatorStateInfo(0);
            frameRateSlider.value = 0;  
            float normalizedTime = frameRateSlider.value;
            animator.Play(currentState.fullPathHash, 0, normalizedTime);
        }
    }
   
    public void OnSliderValueChanged(float value)
    {
       
        var currentFrame = (int)(animator.GetCurrentAnimatorStateInfo(0).normalizedTime * animator.GetCurrentAnimatorClipInfo(0)[0].clip.length * currenttotalFrames);
        currentframeTMP.text = currentFrame.ToString();
        var currentState = animator.GetCurrentAnimatorStateInfo(0);
        var normalizedTime = frameRateSlider.value;
        animator.Play(currentState.fullPathHash, 0, normalizedTime);

        if(frameRateSlider.value >=1)
        {
            Replay();
        }

    }


}