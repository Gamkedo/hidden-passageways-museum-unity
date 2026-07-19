using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(LookAtConstraint))]
public class LookAtCamera : MonoBehaviour
{
    private LookAtConstraint lookAtConstraint;

    private void Start()
    {
        lookAtConstraint = GetComponent<LookAtConstraint>();

        ConstraintSource constraintSource = new ConstraintSource();
        constraintSource.sourceTransform = Camera.main.transform;
        constraintSource.weight = 1;
        lookAtConstraint.AddSource(constraintSource);
    }
}
