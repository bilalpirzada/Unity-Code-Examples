//variables
public Transform floatPoint;
public float launchSpeed;

Camera cam;

GameObject target;
Rigidbody targetRig;

public float weaponRange=12f;

bool isAttracting;
bool isLaunching; 

void Start(){
  cam = Camera.main;
}

  void Update(){
    //Attract input
    if(Input.GetButtonDown("Fire1")){
    isAttracting = true;
    }
    else if(Input.GetButtonUp("Fire1")){
      isAttracting = false;
    }
    
    // throw with right mouse button
    if(isAttracting)
    {
      if(Input.GetButtonDown("Fire2"))
        isLaunching = true;
    }
    
  }

private void FixedUpdate(){
  if(isAttracting)
      Attract();
   else if(!isAttracting)
      Realease();
      
   if(isLaunching)
      Throw();
}


//method to attract things
private void Attract(){
RaycastHit hit;
  if(target == null)
  {
    if(physics. Taycast(cam.transform.position, cam.transform.forward, out hit, weaponRange)){
    
        if(hit.transform.tag=="CanGrab")
        {
          target = hit.transform.gameObject;
          targetRig = target.GetComponent<Rigidbody>();
          target.transform.position = Vector3.MoveTowards(target.transform.position, floatPoint.position, 0.3f);
          targetRig.useGravity = false;
        }
    }
    else{
      target.transform.positon = Vector3.MoveTowards(target.transform.positon, floatPoint.position, 0.3f)
    }
  }
}

//method to realease object
private void Release(){
  if(target !=null)
  {
    targetRig.useGravity = true;
    target = null;
  }
}

// method to throw an object
private void Throw(){
if(targetRig !=null)
{
  targetRig.useGravity = true;
  targetRig.AddForce(floatPoint.transform.forward * launchSpeed, ForceMode.Impulse);
  target = null;
  isLaunching = false;
}
}

