package expression;

import complex.Complex;
import complex.ComplexExpression;
import factory.Operation;

public class DivExpression extends ComplexExpression {
    public DivExpression(Complex[] args){
        super(Operation.DIVISION , args);
    }

    protected Complex executeOneOperation(Complex a , Complex b){
        return a.Impartire(b);
    }

}
