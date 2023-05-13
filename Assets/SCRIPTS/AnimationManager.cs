using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditorInternal;
using UnityEngine;
using UnityEditor;
using System.Xml.Linq;
using Unity.VisualScripting;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine.UI;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager instance;
    [SerializeField] private GameObject model;
    public string clipName;
    public string fbxFilePath;
    [SerializeField] private Animator animator;
    [SerializeField] private  AnimationClip currentClip;
    [SerializeField] private List<Object> animfbx;
    [SerializeField] private List<AnimationClip> anims;
    [SerializeField] private AnimatorOverrideController overrideController;
    [SerializeField] private GameObject currentanimFbx;
    [SerializeField] private Animation a;
    [SerializeField] private AnimationController animcontroller;
    private Vector3 exactpos;
    [SerializeField] private Button playButton;
  //  string animationsPath = "Assets/Resources/Animations/Pivot.fbx";
    string animationsPath = "Assets/Resources/Animations/";
    public float currentanimSpeed;

    [SerializeField] private string clipname;
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        Application.targetFrameRate = 60;
        exactpos = model.transform.position;
        //OnPreprocessAnimation();
    }


   public void SetAnimation(string animName, float animSpeed)
    {
        currentanimSpeed = animSpeed;
        SetAnimSpeed();
        var fbxpath = animationsPath +animName+".fbx";
      //      OnPreprocessAnimation(fbxpath);
        overrideController["mixamo.com"] = GetAnimationClip(fbxpath);
        animator.runtimeAnimatorController = overrideController;
        model.transform.position = exactpos;
        OnPlay();
        playButton.onClick.Invoke();
    }

    private AnimationClip GetAnimationClip(string fbxPath)
    {
        Object[] assets = AssetDatabase.LoadAllAssetsAtPath(fbxPath);
        currentClip = assets.OfType<AnimationClip>().FirstOrDefault();
        // var animationClip = assets.OfType<AnimationClip>();;
    
        animcontroller.SetAnimationClip(currentClip);
        return currentClip;

    }
    public void SetAnimSpeed()
    {
        animator.speed = 1;
    }
    public void OnPause()
    {
        animator.speed = 0f;
        AnimationController.instance.onPause = true;
    } 
    public void OnPlay()
    {
        SetAnimSpeed();
        AnimationController.instance.onPause = false;
    }

}
