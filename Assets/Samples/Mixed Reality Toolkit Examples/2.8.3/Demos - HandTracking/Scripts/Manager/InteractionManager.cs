using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �̱۷������� �ٲٱ�! -> ������
public static class InteractionManager
{
    private static int currentInteraction = 0;
    private static InteractionStarter[] interactionStarters = null;

    public static int GetInteractionNumber()
    {
        return currentInteraction;
    }

    public static void MoveOnNextInteraction()
    {
        currentInteraction++;

    }


}
