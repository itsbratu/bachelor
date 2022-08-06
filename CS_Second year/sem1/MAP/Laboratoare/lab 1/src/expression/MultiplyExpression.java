package expression;

import complex.Complex;
import complex.ComplexExpression;
import factory.Operation;

public class MultiplyExpression extends ComplexExpression {
    public MultiplyExpression(Complex[] args){
        super(Operation.MULTIPLICATION , args);
    }

    protected Complex executeOneOperation(Complex a , Complex b){
        return a.Inmultire(b);
    }
}
