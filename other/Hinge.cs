private void OnMouseDown()
    {
        Destroy(GetComponent<HingeJoint>());
        Destroy(GetComponentInChildren<HingeJoint>());
        Destroy(GetComponentInParent<HingeJoint>());
    }