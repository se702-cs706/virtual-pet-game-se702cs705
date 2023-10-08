using UnityEngine;

namespace PointOfInterestCode
{
    /// <summary>
    /// Attached to a point of interest object that the dog can interact with
    /// </summary>
    public class PointOfInterest : MonoBehaviour
    {
        [SerializeField] public float InheritInterestLevel = 10;
        [SerializeField] public float InterestLevel;
        [SerializeField] public float InterestRadius = 5;
        
        // From how far away can the dog interact with this object
        [SerializeField] public float InteractionDistance = 0.5f;
        
        // time the interaction lasts if not interrupted
        [SerializeField] public float InterestTime = 10;
        
        // If this POI can be interacted with
        public bool canBeUsed { get; set; } = true;
        [SerializeField] private float InheritInterestCooldown = 0;
        private float InterestCooldown = 0;
        [SerializeField] public InterestType InterestType;
        [SerializeField] public DogInteraction interaction;

        private void Start()
        {
            InterestCooldown = InheritInterestCooldown;
        }

        private void Update()
        {
            if(canBeUsed == false)
            {
                InterestCooldown -= Time.deltaTime;
                if(InterestCooldown <= 0)
                {
                    canBeUsed = true;
                    InterestCooldown = InheritInterestCooldown;
                }
            }
        }
    }
}
