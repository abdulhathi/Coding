using System;

public class InternalVsExternalNodes {
    public InternalVsExternalNodes() {

    }

    public int CalculateInternalNodes(int degreeZeroCount) {
        // formula : deg(2) = deg(0) - 1
        return degreeZeroCount - 1;
    }
    public int CalculateExternalNodes(int degreeTwoCount) {
        // formula : deg(0) = deg(2) + 1
        return degreeTwoCount + 1;
    }
}